using ObjParser;
using System.Drawing;
using System.Windows.Forms;

// Parsing *.obj files (ObjParser) taken from some open source implementation (https://github.com/stefangordon/ObjParser.git)
// in order to quicken up the process of doing this project :) (also extended it with some other functionalities that I needed)

namespace GK_Projekt2
{
    public partial class Form1 : Form
    {
        private Obj _loadedObject { get; set; }
        private Bitmap _bitmap { get; set; }

        public Form1()
        {
            InitializeComponent();
            _bitmap = new Bitmap(pbCanvas.Width, pbCanvas.Height);
            _loadedObject = ReadObjFile(AppDomain.CurrentDomain.BaseDirectory + @"/Resources/quad_sphere.obj");
            //pbCanvas.Image = _bitmap;
            //Draw();
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

                    //Read the contents of the file into a stream
                    obj.LoadObj(dialog.OpenFile());
                }
            }
            _loadedObject = obj;
            Draw();
        }

        private void btnFillMesh_Click(object sender, EventArgs e)
        {
            // Filling triangles with the proper colouring to be implemented
            FillMesh();
            Draw();
        }

        public void Draw()
        {
            var newBitmap = new Bitmap(pbCanvas.Width + 2, pbCanvas.Height + 2);
            //foreach (var i in _loadedObject.NVList)
            //{
            //    var temp = ScaleToCurrentSize(i.X, i.Y);
            //    newBitmap.SetPixel(temp.Item1, temp.Item2, Color.FromArgb(255, 0, 0));
            //}
            foreach (var i in _loadedObject.FaceList)
                using (var graphics = Graphics.FromImage(newBitmap))
                {
                    Pen blackPen = new Pen(Color.Black, 1);
                    for (int j = 0; j < i.VertexIndexList.Length; j++)
                    {
                        var point1 = ScaleToCurrentSize(_loadedObject.VertexList[i.VertexIndexList[j] - 1].X, _loadedObject.VertexList[i.VertexIndexList[j] - 1].Y);
                        var point2 = ScaleToCurrentSize(_loadedObject.VertexList[i.VertexIndexList[(j + 1) % i.VertexIndexList.Length] - 1].X, _loadedObject.VertexList[i.VertexIndexList[(j + 1) % i.VertexIndexList.Length] - 1].Y);
                        graphics.DrawLine(blackPen, point1.Item1, point1.Item2,point2.Item1,point2.Item2);
                    }
                    blackPen.Dispose();
                }
            pbCanvas.Image = newBitmap.Clone(new Rectangle(0, 0, newBitmap.Width, newBitmap.Height), System.Drawing.Imaging.PixelFormat.DontCare);
        }

        public void DrawLine()
        {

        }

        public void FillMesh()
        {

        }

        public (int, int) ScaleToCurrentSize(double x, double y)
        {
            return ((int)((x + 1) * pbCanvas.Width / 2), (int)((y + 1) * pbCanvas.Height / 2));
        }
    }
}