using ObjParser;

// Parsing *.obj files (ObjParser) taken from some open source implementation (https://github.com/stefangordon/ObjParser.git) in order to quicken up the process of doing this project :)

namespace GK_Projekt2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ReadObjFile();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void ReadObjFile()
        {
            // Working!
            var reader = new Obj();
            reader.LoadObj(AppDomain.CurrentDomain.BaseDirectory + @"/Resources/quad_sphere.obj");
            System.Diagnostics.Debug.WriteLine(reader.VertexList);
        }
    }
}