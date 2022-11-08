using ObjParser;
using ObjParser.Types;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GK_Projekt2
{
// Parsing *.obj files (ObjParser) taken from some open source implementation (https://github.com/stefangordon/ObjParser.git)
// in order to quicken up the process of doing this project :) (also extended it with some other functionalities that I needed)
    public partial class Form1 : Form
    {
        private Obj _loadedObject { get; set; }
        private Bitmap _bitmap { get; set; }
        public List<((int, int), (int, int))> ScaledEdgeList;

        public Form1()
        {
            InitializeComponent();
            _bitmap = new Bitmap(pbCanvas.Width, pbCanvas.Height);
            _loadedObject = ReadObjFile(AppDomain.CurrentDomain.BaseDirectory + @"/Resources/ico_sphere.obj");
            ScaledEdgeList = new List<((int, int), (int, int))>();
            ScaledEdgeList = ScaleVertices(_loadedObject.FaceList, pbCanvas.Width, pbCanvas.Height);
            pbCanvas.Image = _bitmap;
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
                    ScaledEdgeList = ScaleVertices(_loadedObject.FaceList, pbCanvas.Width, pbCanvas.Height);
                    DrawMesh();
                }
            }
        }

        private void btnFillMesh_Click(object sender, EventArgs e)
        {
            // Filling triangles with the proper colouring to be implemented
            FillMesh();
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
            DrawLine(newBitmap, System.Drawing.Color.Black, 2);
            foreach (var j in _loadedObject.NVList)
            {
                var point1 = ScaleToCurrentSize(j.X, j.Y);
                newBitmap.SetPixel(point1.Item1 + 2, point1.Item2 + 2, System.Drawing.Color.FromArgb(255, 0, 0));
            }
            pbCanvas.Image = newBitmap.Clone(new Rectangle(0, 0, newBitmap.Width, newBitmap.Height), System.Drawing.Imaging.PixelFormat.DontCare);
        }

        public void DrawLine(Bitmap newBitmap, System.Drawing.Color color, int size)
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

        public System.Drawing.Color CalculateColor()
        {
            var ret = new System.Drawing.Color();

            return ret;
        }

        public void FillPolygon(int[] vertices)
        {

        }

        public void FillMesh()
        {

        }

        public (int, int) ScaleToCurrentSize(double x, double y)
        {
            return ((int)((x + 1) * pbCanvas.Width / 2), (int)((y + 1) * pbCanvas.Height / 2));
        }


        public List<((int, int), (int, int))> ScaleVertices(List<Face> faces, int width, int height)
        {
            var ret = new List<((int, int), (int, int))>();
            foreach (var i in faces)
            {
                for (int j = 0; j < i.VertexIndexList.Length; j++)
                {
                    var point1 = ScaleToCurrentSize(_loadedObject.VertexList[i.VertexIndexList[j] - 1].X, _loadedObject.VertexList[i.VertexIndexList[j] - 1].Y);
                    var point2 = ScaleToCurrentSize(_loadedObject.VertexList[i.VertexIndexList[(j + 1) % i.VertexIndexList.Length] - 1].X, _loadedObject.VertexList[i.VertexIndexList[(j + 1) % i.VertexIndexList.Length] - 1].Y);
                    var temp = ((point1.Item1, point1.Item2), (point2.Item1, point2.Item2));
                    ret.Add(temp);
                }
            }
            return ret;
        }
    }
}