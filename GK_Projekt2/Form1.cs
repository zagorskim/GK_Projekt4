using ObjParser;
using ObjParser.Types;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Policy;
using System.Windows.Forms;
using FastBitmapLib;

namespace GK_Projekt2
{
// Parsing *.obj files (ObjParser) taken from some open source implementation (https://github.com/stefangordon/ObjParser.git)
// in order to quicken up the process of doing this project :) (also extended it with some other functionalities that I needed)
    public partial class Form1 : Form
    {
        private const int polySize = 3;
        private Obj _loadedObject { get; set; }
        private Bitmap _bitmap { get; set; }
        public List<((int, int, int), (int, int, int))> ScaledEdgeList;
        public List<(int, int, int, Face)> ScaledVertexList;
        public (int, int, int)[] ScaledVertexOrder;
        public System.Threading.Mutex animationMutex;
        // need to make a list of fillers to be able to fill different polygons of different vertex count
        public Filler _filler;
        public bool animationInProgress = false;

        public Form1()
        {
            InitializeComponent();
            _bitmap = new Bitmap(pbCanvas.Width, pbCanvas.Height);
            _loadedObject = ReadObjFile(AppDomain.CurrentDomain.BaseDirectory + @"/Resources/hemisphereAVG.obj");
            ScaledEdgeList = new List<((int, int, int), (int, int, int))>();
            ScaledVertexList = new List<(int, int, int, Face)>();
            ScaledVertexOrder = new (int, int, int)[_loadedObject.TextureList.Count];
            (ScaledEdgeList, ScaledVertexList, ScaledVertexOrder) = ScaleVertices(_loadedObject.FaceList, pbCanvas.Width, pbCanvas.Height);
            pbCanvas.Image = _bitmap;
            _filler = new Filler(_loadedObject, pbCanvas.Height, pbCanvas.Width, polySize, ScaledVertexList, ScaledVertexOrder);
            DrawMesh();
            animationMutex = new System.Threading.Mutex();
        }

        public Obj ReadObjFile(string path)
        {
            var reader = new Obj();
            reader.LoadObj(path);
            return reader;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            var obj = new Obj();
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "obj files (*.obj)|*.obj";
                dialog.FilterIndex = 2;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = dialog.FileName;
                    obj.LoadObj(dialog.OpenFile());
                    _loadedObject = obj;
                    ScaledVertexOrder = new (int, int, int)[_loadedObject.TextureList.Count];
                    (ScaledEdgeList, ScaledVertexList, ScaledVertexOrder) = ScaleVertices(_loadedObject.FaceList, pbCanvas.Width, pbCanvas.Height);
                    _filler = new Filler(_loadedObject, pbCanvas.Height, pbCanvas.Width, polySize, ScaledVertexList, ScaledVertexOrder);
                    DrawMesh();
                }
            }
        }

        public void DrawMesh()
        {
            var newBitmap = new Bitmap(pbCanvas.Width + 2, pbCanvas.Height + 2);
            var fastBitmap = new FastBitmap(newBitmap);
            fastBitmap.Lock();
            FillMesh(fastBitmap);
            fastBitmap.Unlock();
            if(cbMesh.Checked)
                DrawLines(newBitmap, System.Drawing.Color.Black, 1);
            pbCanvas.Image = newBitmap.Clone(new Rectangle(0, 0, newBitmap.Width, newBitmap.Height), System.Drawing.Imaging.PixelFormat.DontCare);
        }

        public void DrawLines(Bitmap newBitmap, System.Drawing.Color color, int size)
        {
            using (var graphics = Graphics.FromImage(newBitmap))
            {
                Pen pen = new Pen(color, size);
                foreach (var i in ScaledEdgeList)
                {
                    graphics.DrawLine(pen, i.Item1.Item1, i.Item1.Item2, i.Item2.Item1, i.Item2.Item2);
                }
                pen.Dispose();
            }
        }

        public Dictionary<string, (int, int)[]> BucketSort()
        {
            var ret = new Dictionary<string, (int, int)[]>();

            return ret;

        }

        public void FillMesh(FastBitmap bitmap)
        {
            var temp = new (int, int)[polySize];
            for (var i = 0; i < ScaledVertexList.Count; i++)
            {
                temp[i % polySize] = (ScaledVertexList[i].Item1, ScaledVertexList[i].Item2);
                if (i % polySize == 2)
                    _filler.FillPoly(bitmap, temp, ScaledVertexList[i].Item4);
            }
        }

        public (int, int, int) ScaleToCurrentSize(double x, double y, double z)
        {
            return ((int)((x * 0.99 + 1) * pbCanvas.Width / 2), (int)((y * 0.99 + 1) * pbCanvas.Height / 2), (int)((z * 0.99 + 1) * pbCanvas.Height / 2));
        }


        public (List<((int, int, int), (int, int, int))>, List<(int, int, int, Face)>, (int, int, int)[]) ScaleVertices(List<Face> faces, int width, int height)
        {
            var ret1 = new List<((int, int, int), (int, int, int))>();
            var ret2 = new List<(int, int, int, Face)>();
            var ret3 = new (int, int, int)[_loadedObject.VertexList.Count];
            foreach (var i in faces)
            {
                for (int j = 0; j < i.VertexIndexList.Length; j++)
                {
                    var point1 = ScaleToCurrentSize(_loadedObject.VertexList[i.VertexIndexList[j] - 1].X, 
                        _loadedObject.VertexList[i.VertexIndexList[j] - 1].Y, 
                        _loadedObject.VertexList[i.VertexIndexList[j] - 1].Z);
                    var point2 = ScaleToCurrentSize(_loadedObject.VertexList[i.VertexIndexList[(j + 1) % i.VertexIndexList.Length] - 1].X, 
                        _loadedObject.VertexList[i.VertexIndexList[(j + 1) % i.VertexIndexList.Length] - 1].Y, 
                        _loadedObject.VertexList[i.VertexIndexList[(j + 1) % i.VertexIndexList.Length] - 1].Z);
                    var temp = ((point1.Item1, point1.Item2, point1.Item3), (point2.Item1, point2.Item2, point2.Item3));
                    ret1.Add(temp);
                    ret2.Add((point1.Item1, point1.Item2, point1.Item3, i));
                }
            }
            for (var i = 0; i < _loadedObject.VertexList.Count; i++)
            {
                var point = ScaleToCurrentSize(_loadedObject.VertexList[i].X, _loadedObject.VertexList[i].Y, _loadedObject.VertexList[i].Z);
                ret3[i] = point;
            }
            return (ret1, ret2, ret3);
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            _filler.kd = (double)((HScrollBar)sender).Value / 100;
            DrawMesh();
        }

        private void sbKs_Scroll(object sender, ScrollEventArgs e)
        {
            _filler.ks = (double)((HScrollBar)sender).Value / 100;
            DrawMesh();
        }

        private void sbLightX_Scroll(object sender, ScrollEventArgs e)
        {
            _filler.light.Item1 = (int)(pbCanvas.Height * (double)((HScrollBar)sender).Value / 100);
            DrawMesh();
        }

        private void sbLightY_Scroll(object sender, ScrollEventArgs e)
        {
            _filler.light.Item2 = (int)(pbCanvas.Width * (double)((HScrollBar)sender).Value / 100);
            DrawMesh();
        }

        private void sbLightZ_Scroll(object sender, ScrollEventArgs e)
        {
            _filler.light.Item3 = (int)(pbCanvas.Height * 2 * (double)((HScrollBar)sender).Value / 100);
            DrawMesh();
        }

        private void sbm_Scroll(object sender, ScrollEventArgs e)
        {
            _filler.m = (double)((HScrollBar)sender).Value;
            DrawMesh();
        }

        private void sbLightR_Scroll(object sender, ScrollEventArgs e)
        {
            _filler.Il.Item1 = (double)((HScrollBar)sender).Value / 100;
            DrawMesh();
        }

        private void sbLightG_Scroll(object sender, ScrollEventArgs e)
        {
            _filler.Il.Item2 = (double)((HScrollBar)sender).Value / 100;
            DrawMesh();
        }

        private void sbLightB_Scroll(object sender, ScrollEventArgs e)
        {
            _filler.Il.Item3 = (double)((HScrollBar)sender).Value / 100;
            DrawMesh();
        }

        private void cbMesh_CheckedChanged(object sender, EventArgs e)
        {
            DrawMesh();
        }

        private async void btnAnimation_Click(object sender, EventArgs e)
        {
            animationInProgress = true;
            (int, int) middle = (pbCanvas.Width / 2, pbCanvas.Height / 2);
            for (int i = (int)(pbCanvas.Width / 4); animationInProgress && i < 3 * pbCanvas.Width / 4; i += 10)
            {
                _filler.light.Item1 = i;
                double y = middle.Item2 - Math.Sqrt(-Math.Pow(middle.Item1, 2) + 2 * middle.Item1 * i - Math.Pow(i, 2) + (Math.Pow(pbCanvas.Width / 2, 2)));
                _filler.light.Item2 = (int)y;
                DrawMesh();
                this.Refresh();
            }
            for (int i = (int)(3 * pbCanvas.Width / 4); animationInProgress && i > pbCanvas.Width / 4; i -= 10)
            {
                _filler.light.Item1 = i;
                double y = middle.Item2 + Math.Sqrt(-Math.Pow(middle.Item1, 2) + 2 * middle.Item1 * i - Math.Pow(i, 2) + (Math.Pow(pbCanvas.Width / 2, 2)));
                _filler.light.Item2 = (int)y;
                DrawMesh();
                this.Refresh();
            }
            animationInProgress = false;
        }

        private void Animation()
        { 

        }
    }
}