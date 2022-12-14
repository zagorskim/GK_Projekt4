using ObjParser;
using ObjParser.Types;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Policy;
using System.Windows.Forms;
using FastBitmapLib;
using System.CodeDom.Compiler;
using System.IO;
using System.Drawing.Configuration;
using System.Numerics;
using System;
using System.Runtime.InteropServices;
// èrÛd≥o úwiat≥a
namespace GK_Projekt2
{
    // Parsing *.obj files (ObjParser) taken from some open source implementation (https://github.com/stefangordon/ObjParser.git)
    // in order to quicken up the process of doing this project :) (also extended it with some other functionalities that I needed)
    public partial class Form1 : Form
    {
        #region fields

        private const int polySize = 3;
        private List<Obj> _loadedObject { get; set; }
        public List<List<((int, int, int), (int, int, int))>> ScaledEdgeList;
        public List<List<(int, int, int, Face)>> ScaledVertexList;
        public List<(int, int, int)[]> ScaledVertexOrder;
        public System.Threading.Mutex animationMutex;
        public List<Bitmap> _bitmap;
        public List<Bitmap> _texture;
        public List<Bitmap> _normalMap;
        public List<FastBitmap> _fastBitmap;
        // need to make a list of fillers to be able to fill different polygons of different vertex count
        public List<Filler> _filler;
        public bool animationInProgress = false;
        public bool importing;
        private static int lastTick;
        private static int lastFrameRate;
        private static int frameRate;
        private bool isHeightMapEnabled = false;
        private Vector4 cameraPosition;
        private List<Matrix4x4> transforms;
        private float rotationX = 1;
        private float rotationY = 0;
        private float rotationZ = 0;
        #endregion

        public Form1()
        {
            InitializeComponent();
            _loadedObject = new List<Obj>();
            ScaledEdgeList = new List<List<((int, int, int), (int, int, int))>>();
            ScaledVertexList = new List<List<(int, int, int, Face)>>();
            ScaledVertexOrder = new List<(int, int, int)[]>();
            _bitmap = new List<Bitmap>();
            _texture = new List<Bitmap>();
            _normalMap = new List<Bitmap>();
            _fastBitmap = new List<FastBitmap>();
            _filler = new List<Filler>();
            cameraPosition = new Vector4(2, (float)2.5, 3, 1);
            transforms = new List<Matrix4x4>();
            transforms.Add(Matrix4x4.CreateRotationX((float)1));
            transforms.Add(Matrix4x4.CreateLookAt(new Vector3(cameraPosition.X, cameraPosition.Y, cameraPosition.Z), new Vector3(1, 1, 1), new Vector3(0, 0, 1)));
            float e = 1;
            float a = 1;
            float n = (float)0.075;
            float f = (float)0.13;

            transforms.Add(new Matrix4x4(e, 0, 0, 0, 0, e / a, 0, 0, 0, 0, -(f + n) / (f - n), (-2 * f * n) / (f - n), 0, 0, -1, 0));

            for (var i = 0; i < tpbCanvas.ColumnCount * tpbCanvas.RowCount; i++)
            {
                _bitmap.Add(new Bitmap(pbCanvas.Width + 2, pbCanvas.Height + 2));
                _fastBitmap.Add(new FastBitmap(_bitmap[i]));
                var temp = new Bitmap(Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"/Resources/pexels-anni-roenkae-2832432.jpg"));
                _texture.Add(new Bitmap(temp, new Size(_bitmap[i].Width, _bitmap[i].Height)));
                temp = new Bitmap(Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"/Resources/Water on camera lense effect.png"));
                _normalMap.Add(new Bitmap(temp, new Size(_bitmap[i].Width, _bitmap[i].Height)));
                _loadedObject.Add(ReadObjFile(AppDomain.CurrentDomain.BaseDirectory + @"/Resources/hemisphereAVG.obj"));
                ScaledEdgeList.Add(new List<((int, int, int), (int, int, int))>());
                ScaledVertexList.Add(new List<(int, int, int, Face)>());
                ScaledVertexOrder.Add(new (int, int, int)[_loadedObject[i].TextureList.Count]);
                (ScaledEdgeList[i], ScaledVertexList[i], ScaledVertexOrder[i]) = ScaleVertices(_loadedObject[i].FaceList, pbCanvas.Width, pbCanvas.Height, i);
                _filler.Add(new Filler(_loadedObject[i], pbCanvas.Height, pbCanvas.Width, polySize, ScaledVertexList[i], ScaledVertexOrder[i], _texture[i], _normalMap[i], isHeightMapEnabled, _bitmap[i]));
            }
            sbLightZ.Value = sbLightZ.Maximum / 2;
            DrawObject();
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
            importing = true;
            if (!animationInProgress)
            {
                for (var i = 0; i < _bitmap.Count; i++)
                {
                    _bitmap[i] = new Bitmap(pbCanvas.Width + 2, pbCanvas.Height + 2);
                    _fastBitmap[i] = new FastBitmap(_bitmap[i]);
                }
                using (OpenFileDialog dialog = new OpenFileDialog())
                {
                    dialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    dialog.Filter = "obj files (*.obj)|*.obj";
                    dialog.FilterIndex = 2;
                    dialog.RestoreDirectory = true;
                    dialog.Multiselect = true;

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        for (var i = 0; i < dialog.FileNames.Length; i++)
                        {
                            var obj = ReadObjFile(dialog.FileNames[i]);
                            _loadedObject[i] = obj;
                            ScaledVertexOrder[i] = new (int, int, int)[_loadedObject[i].TextureList.Count];
                            (ScaledEdgeList[i], ScaledVertexList[i], ScaledVertexOrder[i]) = ScaleVertices(_loadedObject[i].FaceList, pbCanvas.Width, pbCanvas.Height, i);
                            _filler[i] = new Filler(_loadedObject[i], pbCanvas.Height, pbCanvas.Width, polySize, ScaledVertexList[i], ScaledVertexOrder[i], _texture[i], _normalMap[i], isHeightMapEnabled, _bitmap[i]);
                        }
                        SetFillerValues();
                        if (!animationInProgress)
                            DrawObject();
                    }
                }
            }
            importing = false;
        }

        // Asynchronous drawing provides better UI behaviour, but sometimes doesn't complete calculations, disabling async drawing will fix it
        public async void DrawObject()
        {
            for (var i = 0; i < _bitmap.Count; i++)
            {
                if (!_fastBitmap[i].Locked)
                {
                    // Commented on lab
                    // Filling and shading
                    //_fastBitmap[i].Lock();
                    //await Task.Run(() => FillMesh(_fastBitmap[i], i));
                    //_fastBitmap[i].Unlock();

                    // Transform
                    if (i == 1)
                        TransformMesh(i);

                    //Drawing mesh
                    if (cbMesh.Checked)
                        DrawLines(_bitmap[i], System.Drawing.Color.Black, 1, i);

                    switch (i)
                    {
                        case 0:
                            pbCanvas.Image = _bitmap[i].Clone(new Rectangle(0, 0, _bitmap[i].Width, _bitmap[i].Height), System.Drawing.Imaging.PixelFormat.DontCare);
                            break;
                        case 1:
                            pbCanvas2.Image = _bitmap[i].Clone(new Rectangle(0, 0, _bitmap[i].Width, _bitmap[i].Height), System.Drawing.Imaging.PixelFormat.DontCare);
                            break;
                        case 2:
                            pbCanvas3.Image = _bitmap[i].Clone(new Rectangle(0, 0, _bitmap[i].Width, _bitmap[i].Height), System.Drawing.Imaging.PixelFormat.DontCare);
                            break;
                        case 3:
                            pbCanvas4.Image = _bitmap[i].Clone(new Rectangle(0, 0, _bitmap[i].Width, _bitmap[i].Height), System.Drawing.Imaging.PixelFormat.DontCare);
                            break;
                    }
                }
            }
        }

        public void DrawObjectAnimation()
        {
            for (var i = 0; i < _bitmap.Count; i++)
            {
                if (!_fastBitmap[i].Locked)
                {
                    // Lab comment
                    //_fastBitmap[i].Lock();
                    //FillMesh(_fastBitmap[i], i);
                    //_fastBitmap[i].Unlock();

                    if (i == 1)
                        TransformMesh(i);

                    if (cbMesh.Checked)
                        DrawLines(_bitmap[i], System.Drawing.Color.Black, 1, i);
                    switch (i)
                    {
                        case 0:
                            pbCanvas.Image = _bitmap[i].Clone(new Rectangle(0, 0, _bitmap[i].Width, _bitmap[i].Height), System.Drawing.Imaging.PixelFormat.DontCare);
                            break;
                        case 1:
                            pbCanvas2.Image = _bitmap[i].Clone(new Rectangle(0, 0, _bitmap[i].Width, _bitmap[i].Height), System.Drawing.Imaging.PixelFormat.DontCare);
                            break;
                        case 2:
                            pbCanvas3.Image = _bitmap[i].Clone(new Rectangle(0, 0, _bitmap[i].Width, _bitmap[i].Height), System.Drawing.Imaging.PixelFormat.DontCare);
                            break;
                        case 3:
                            pbCanvas4.Image = _bitmap[i].Clone(new Rectangle(0, 0, _bitmap[i].Width, _bitmap[i].Height), System.Drawing.Imaging.PixelFormat.DontCare);
                            break;
                    }
                }
            }
        }

        public void DrawLines(Bitmap newBitmap, System.Drawing.Color color, int size, int index)
        {
                using (var graphics = Graphics.FromImage(newBitmap))
                {
                    Pen pen = new Pen(color, size);
                    foreach (var i in ScaledEdgeList[index])
                    {
                        graphics.DrawLine(pen, i.Item1.Item1, i.Item1.Item2, i.Item2.Item1, i.Item2.Item2);
                    }
                    pen.Dispose();
                }
        }

        public void FillMesh(FastBitmap bitmap, int index)
        {
            var temp = new (int, int)[polySize];
            for (var i = 0; i < ScaledVertexList[index].Count; i++)
            {
                temp[i % polySize] = (ScaledVertexList[index][i].Item1, ScaledVertexList[index][i].Item2);
                if (i % polySize == 2)
                {
                    _filler[index].FillPoly(bitmap, temp, ScaledVertexList[index][i].Item4);
                }
            }
        }

        public (int, int, int) ScaleToCurrentSize(double x, double y, double z, Bitmap bitmap)
        {
            return ((int)((x * 0.99 + 1) * bitmap.Height / 2), (int)((y * 0.99 + 1) * bitmap.Height / 2), (int)((z * 0.99) * bitmap.Height / 2));
        }

        public (List<((int, int, int), (int, int, int))>, List<(int, int, int, Face)>, (int, int, int)[]) ScaleVertices(List<Face> faces, int width, int height, int index)
        {
            var ret1 = new List<((int, int, int), (int, int, int))>();
            var ret2 = new List<(int, int, int, Face)>();
            var ret3 = new (int, int, int)[_loadedObject[index].VertexList.Count];
            foreach (var i in faces)
            {
                for (int j = 0; j < i.VertexIndexList.Length; j++)
                {
                    var point1 = ScaleToCurrentSize(_loadedObject[index].VertexList[i.VertexIndexList[j] - 1].X,
                        _loadedObject[index].VertexList[i.VertexIndexList[j] - 1].Y,
                        _loadedObject[index].VertexList[i.VertexIndexList[j] - 1].Z,
                        _bitmap[index]);
                    var point2 = ScaleToCurrentSize(_loadedObject[index].VertexList[i.VertexIndexList[(j + 1) % i.VertexIndexList.Length] - 1].X,
                        _loadedObject[index].VertexList[i.VertexIndexList[(j + 1) % i.VertexIndexList.Length] - 1].Y,
                        _loadedObject[index].VertexList[i.VertexIndexList[(j + 1) % i.VertexIndexList.Length] - 1].Z,
                        _bitmap[index]);
                    var temp = ((point1.Item1, point1.Item2, point1.Item3), (point2.Item1, point2.Item2, point2.Item3));
                    ret1.Add(temp);
                    ret2.Add((point1.Item1, point1.Item2, point1.Item3, i));
                }
            }
            for (var i = 0; i < _loadedObject[index].VertexList.Count; i++)
            {
                var point = ScaleToCurrentSize(_loadedObject[index].VertexList[i].X, _loadedObject[index].VertexList[i].Y, _loadedObject[index].VertexList[i].Z, _bitmap[index]);
                ret3[i] = point;
            }
            return (ret1, ret2, ret3);
        }

        public void Animation()
        {
            animationInProgress = true;
            int increment = 10;
            (int, int) middle = (pbCanvas.Width / 2, pbCanvas.Height / 2);
            while (animationInProgress)
            {
                // Lab 4 modifs
                rotationX += (float)0.01;
                transforms[0] = Matrix4x4.CreateRotationX(rotationX);

                for (var j = 0; j < _bitmap.Count; j++)
                {
                    int radius = pbCanvas.Width / 2;
                    for (int i = 0; animationInProgress && i < 3 * pbCanvas.Width / 4; i += increment, radius -= increment / 3)
                    {
                        _filler[j].light.Item1 = i;
                        double y = middle.Item2 - Math.Sqrt(-Math.Pow(middle.Item1, 2) + 2 * middle.Item1 * i - Math.Pow(i, 2) + (Math.Pow(radius, 2)));
                        _filler[j].light.Item2 = (int)y;
                        DrawObjectAnimation();
                        CalculateFrameRate();
                    }
                    for (int i = (int)(3 * pbCanvas.Width / 4); animationInProgress && i > pbCanvas.Width / 4; i -= increment, radius -= increment / 3)
                    {
                        _filler[j].light.Item1 = i;
                        double y = middle.Item2 + Math.Sqrt(-Math.Pow(middle.Item1, 2) + 2 * middle.Item1 * i - Math.Pow(i, 2) + (Math.Pow(radius, 2)));
                        _filler[j].light.Item2 = (int)y;
                        if (y < 10000)
                            DrawObjectAnimation();
                        CalculateFrameRate();
                    }
                }
            }
            animationInProgress = false;
        }

        public static void CalculateFrameRate()
        {
            if (System.Environment.TickCount - lastTick >= 1000)
            {
                lastFrameRate = frameRate;
                frameRate = 0;
                lastTick = System.Environment.TickCount;
            }
            frameRate++;
            System.Diagnostics.Debug.WriteLine(lastFrameRate);
        }

        public static Vector4 TransformVector(Vector4 v, Matrix4x4 m)
        {
            return Vector4.Transform(v, m);
        }

        private void TransformMesh(int index)
        {
                Vector4 point;
                for (var i = 0; i < _loadedObject[index].VertexList.Count; i++)
                {
                    point = new Vector4((float)_loadedObject[index].VertexList[i].X, 
                        (float)_loadedObject[index].VertexList[i].Y, 
                        (float)_loadedObject[index].VertexList[i].Z, 
                        (float)1);
                if (point.X >= -1 && point.X <= 1 && point.Y >= -1 && point.Y <= 1 && point.Z >= -1 && point.Z <= 1)
                {
                    point = TransformVector(point, transforms[0]);
                    point = TransformVector(point, transforms[1]);
                    point = TransformVector(point, transforms[2]);

                    point.X /= point.W;
                    point.Y /= point.W;
                    point.Z /= point.W;

                    (_loadedObject[index].VertexList[i].X,
                        _loadedObject[index].VertexList[i].Y,
                        _loadedObject[index].VertexList[i].Z) =
                        (point.X, point.Y, point.Z);

                }
                (ScaledEdgeList[index], ScaledVertexList[index], ScaledVertexOrder[index]) = ScaleVertices(
                    _loadedObject[index].FaceList, pbCanvas.Width, pbCanvas.Height, index);

            }
        }
    }
}