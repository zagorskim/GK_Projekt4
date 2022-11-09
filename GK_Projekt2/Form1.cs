using ObjParser;
using ObjParser.Types;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Policy;
using System.Windows.Forms;

namespace GK_Projekt2
{
// Parsing *.obj files (ObjParser) taken from some open source implementation (https://github.com/stefangordon/ObjParser.git)
// in order to quicken up the process of doing this project :) (also extended it with some other functionalities that I needed)
    public partial class Form1 : Form
    {
        private const int polySize = 3;
        private Obj _loadedObject { get; set; }
        private Bitmap _bitmap { get; set; }
        public List<((int, int), (int, int))> ScaledEdgeList;
        public List<(int, int)> ScaledVertexList;
        // need to make a list of fillers to be able to fill different polygons of different vertex count
        public Filler _filler;
        public Form1()
        {
            InitializeComponent();
            _bitmap = new Bitmap(pbCanvas.Width, pbCanvas.Height);
            _loadedObject = ReadObjFile(AppDomain.CurrentDomain.BaseDirectory + @"/Resources/cone.obj");
            ScaledEdgeList = new List<((int, int), (int, int))>();
            ScaledVertexList = new List<(int, int)>();
            (ScaledEdgeList, ScaledVertexList) = ScaleVertices(_loadedObject.FaceList, pbCanvas.Width, pbCanvas.Height);
            pbCanvas.Image = _bitmap;
            _filler = new Filler(_loadedObject, pbCanvas.Height, pbCanvas.Width, polySize);
            DrawMesh();
        }

        public Obj ReadObjFile(string path)
        {
            // Working!
            var reader = new Obj();
            reader.LoadObj(path);
            return reader;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            var obj = new Obj();
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = "c:\\";
                dialog.Filter = "obj files (*.obj)|*.obj";
                dialog.FilterIndex = 2;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = dialog.FileName;
                    obj.LoadObj(dialog.OpenFile());
                    _loadedObject = obj;
                    (ScaledEdgeList, ScaledVertexList) = ScaleVertices(_loadedObject.FaceList, pbCanvas.Width, pbCanvas.Height);
                    DrawMesh();
                }
            }
        }

        private void btnFillMesh_Click(object sender, EventArgs e)
        {
            DrawMesh();
        }

        public void DrawMesh()
        {
            var newBitmap = new Bitmap(pbCanvas.Width + 2, pbCanvas.Height + 2);
            //foreach (var i in _loadedObject.NVList)
            //{
            //    var temp = ScaleToCurrentSize(i.X, i.Y);
            //    newBitmap.SetPixel(temp.Item1, temp.Item2, Color.FromArgb(255, 0, 0));
            //}
            FillMesh(newBitmap);
            if(cbMesh.Checked)
                DrawLines(newBitmap, System.Drawing.Color.Black, 1);
            //foreach (var j in _loadedObject.NVList)
            //{
            //    var point1 = ScaleToCurrentSize(j.X, j.Y);
            //    newBitmap.SetPixel(point1.Item1, point1.Item2, System.Drawing.Color.FromArgb(255, 0, 0));
            //}
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

        public void FillMesh(Bitmap bitmap)
        {
            var temp = new (int, int)[polySize];
            for (var i = 0; i < ScaledVertexList.Count; i++)
            {
                temp[i % polySize] = ScaledVertexList[i];
                if (i % polySize == 2)
                    _filler.FillPoly(bitmap, temp);
            }
        }

        public (int, int) ScaleToCurrentSize(double x, double y)
        {
            return ((int)((x * 0.99 + 1) * pbCanvas.Width / 2), (int)((y * 0.99 + 1) * pbCanvas.Height / 2));
        }


        public (List<((int, int), (int, int))>, List<(int, int)>) ScaleVertices(List<Face> faces, int width, int height)
        {
            var ret1 = new List<((int, int), (int, int))>();
            var ret2 = new List<(int, int)>();
            foreach (var i in faces)
            {
                for (int j = 0; j < i.VertexIndexList.Length; j++)
                {
                    var point1 = ScaleToCurrentSize(_loadedObject.VertexList[i.VertexIndexList[j] - 1].X, _loadedObject.VertexList[i.VertexIndexList[j] - 1].Y);
                    var point2 = ScaleToCurrentSize(_loadedObject.VertexList[i.VertexIndexList[(j + 1) % i.VertexIndexList.Length] - 1].X, _loadedObject.VertexList[i.VertexIndexList[(j + 1) % i.VertexIndexList.Length] - 1].Y);
                    var temp = ((point1.Item1, point1.Item2), (point2.Item1, point2.Item2));
                    ret1.Add(temp);
                    ret2.Add(point1);
                }
            }
            return (ret1, ret2);
        }
    }
}