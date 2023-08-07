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
using System.Reflection;

// �r�d�o �wiat�a
namespace GK_Projekt2
{
    // Parsing *.obj files (ObjParser) taken from some open source implementation (https://github.com/stefangordon/ObjParser.git)
    // in order to quicken up the process of doing this project :) (also extended it with some other functionalities that I needed)
    public partial class Form1 : Form
    {
        #region fields

        private const int polySize = 3;
        private List<Obj> _loadedObject { get; set; }
        private List<Obj> _modelObject { get; set; }
        public List<List<((int, int, int), (int, int, int))>> ScaledEdgeList;
        public List<List<(int, int, int, Face)>> ScaledVertexList;
        public List<(int, int, int)[]> ScaledVertexOrder;
        public System.Threading.Mutex animationMutex;
        public List<Bitmap> _bitmap;
        public List<Bitmap> _texture;
        public List<Bitmap> _normalMap;
        public List<FastBitmap> _fastBitmap;
        public List<Filler> _filler;
        public bool animationInProgress = false;
        public bool importing;
        private static int lastTick;
        private static int lastFrameRate;
        private static int frameRate;
        private bool isHeightMapEnabled = false;
        private List<List<Matrix4x4>> transforms;
        private float[] rotationX = new float[startupObjects];
        private float[] rotationY = new float[startupObjects];
        private float[] rotationZ = new float[startupObjects];
        private Vector4[] cameraPosition = new Vector4[startupObjects];
        private float[] e = new float[startupObjects];
        private float[] a = new float[startupObjects];
        private float[] n = new float[startupObjects];
        private float[] f = new float[startupObjects];
        private int currentObject = 0;
        public double[,] ZBuffer;
        public const int startupObjects = 2;

        #endregion

        public Form1()
        {
            InitializeComponent();
            _loadedObject = new List<Obj>();
            _modelObject = new List<Obj>();
            ScaledEdgeList = new List<List<((int, int, int), (int, int, int))>>();
            ScaledVertexList = new List<List<(int, int, int, Face)>>();
            ScaledVertexOrder = new List<(int, int, int)[]>();
            _bitmap = new List<Bitmap>();
            _texture = new List<Bitmap>();
            _normalMap = new List<Bitmap>();
            _fastBitmap = new List<FastBitmap>();
            _filler = new List<Filler>();
            transforms = new List<List<Matrix4x4>>();
            ZBuffer = new double[pbCanvas.Width + 2, pbCanvas.Height + 2];
            for (int j = 0; j < ZBuffer.GetLength(0); j++)
                for (int k = 0; k < ZBuffer.GetLength(1); k++)
                    ZBuffer[j, k] = double.MaxValue;
            for (var i = 0; i < startupObjects; i++)
            {
                rotationX[i] = 0;
                rotationY[i] = 0;
                rotationZ[i] = 0;
                cameraPosition[i] = new Vector4(2, (float)2.5, 3, 1);
                e[i] = (float)1;
                a[i] = (float)1;
                n[i] = (float)3;
                f[i] = (float)10;
                transforms.Add(new List<Matrix4x4>());
                transforms[i].Add(Matrix4x4.CreateRotationX((float)0));
                transforms[i].Add(Matrix4x4.CreateRotationX((float)0));
                transforms[i].Add(Matrix4x4.CreateRotationY((float)0));
                transforms[i].Add(
                    Matrix4x4.CreateLookAt(
                        new Vector3(
                            cameraPosition[i].X,
                            cameraPosition[i].Y,
                            cameraPosition[currentObject].Z
                        ),
                        new Vector3(0, 0, 0),
                        new Vector3(5, 5, 5)
                    )
                );
                transforms[i].Add(
                    Matrix4x4.CreatePerspectiveFieldOfView(
                        e[currentObject],
                        a[currentObject],
                        n[currentObject],
                        f[currentObject]
                    )
                );
                _bitmap.Add(new Bitmap(pbCanvas.Width + 2, pbCanvas.Height + 2));
                _fastBitmap.Add(new FastBitmap(_bitmap[i]));
                var temp = new Bitmap(
                    Image.FromFile(
                        AppDomain.CurrentDomain.BaseDirectory
                            + @"/Resources/pexels-anni-roenkae-2832432.jpg"
                    )
                );
                _texture.Add(new Bitmap(temp, new Size(_bitmap[i].Width, _bitmap[i].Height)));
                temp = new Bitmap(
                    Image.FromFile(
                        AppDomain.CurrentDomain.BaseDirectory
                            + @"/Resources/Water on camera lense effect.png"
                    )
                );
                _normalMap.Add(new Bitmap(temp, new Size(_bitmap[i].Width, _bitmap[i].Height)));
                if (i == 0)
                {
                    _loadedObject.Add(
                        ReadObjFile(
                            AppDomain.CurrentDomain.BaseDirectory
                                + @"/Resources/kryszta� dowoz 24H bielany mokot�w.obj"
                        )
                    );
                    _modelObject.Add(
                        ReadObjFile(
                            AppDomain.CurrentDomain.BaseDirectory
                                + @"/Resources/kryszta� dowoz 24H bielany mokot�w.obj"
                        )
                    );
                }
                else
                {
                    _loadedObject.Add(
                        ReadObjFile(
                            AppDomain.CurrentDomain.BaseDirectory + @"/Resources/coneAVG.obj"
                        )
                    );
                    _modelObject.Add(
                        ReadObjFile(
                            AppDomain.CurrentDomain.BaseDirectory + @"/Resources/coneAVG.obj"
                        )
                    );
                }
                ScaledEdgeList.Add(new List<((int, int, int), (int, int, int))>());
                ScaledVertexList.Add(new List<(int, int, int, Face)>());
                ScaledVertexOrder.Add(new (int, int, int)[_modelObject[i].TextureList.Count]);
                (ScaledEdgeList[i], ScaledVertexList[i], ScaledVertexOrder[i]) = ScaleVertices(
                    _loadedObject[i].FaceList,
                    pbCanvas.Width,
                    pbCanvas.Height,
                    i
                );
                sbLightZ.Value = sbLightZ.Maximum / 2;
                _filler.Add(
                    new Filler(
                        _modelObject[i],
                        pbCanvas.Height,
                        pbCanvas.Width,
                        polySize,
                        ScaledVertexList[i],
                        ScaledVertexOrder[i],
                        _texture[i],
                        _normalMap[i],
                        isHeightMapEnabled,
                        _bitmap[i],
                        ZBuffer
                    )
                );
            }
            DrawObject();
            animationMutex = new System.Threading.Mutex();
        }

        public Obj ReadObjFile(string path)
        {
            var reader = new Obj();
            reader.LoadObj(path);
            return reader;
        }

        private void btnImport_Click(object sender, EventArgs ev)
        {
            importing = true;
            if (!animationInProgress)
            {
                for (var i = 0; i < _bitmap.Count; i++)
                {
                    _bitmap[i] = new Bitmap(pbCanvas.Width + 2, pbCanvas.Height + 2);
                    _fastBitmap[0] = new FastBitmap(_bitmap[0]);
                }
                using (OpenFileDialog dialog = new OpenFileDialog())
                {
                    dialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    dialog.Filter = "obj files (*.obj)|*.obj";
                    dialog.FilterIndex = 2;
                    dialog.RestoreDirectory = true;
                    dialog.Multiselect = true;
                    var tempBitmap = _bitmap[0];
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        _bitmap.Clear();
                        _modelObject.Clear();
                        _loadedObject.Clear();
                        _filler.Clear();
                        ScaledEdgeList.Clear();
                        ScaledVertexList.Clear();
                        transforms.Clear();
                        rotationX = new float[dialog.FileNames.Length];
                        rotationY = new float[dialog.FileNames.Length];
                        rotationZ = new float[dialog.FileNames.Length];
                        e = new float[dialog.FileNames.Length];
                        Array.Fill(e, (float)1);
                        a = new float[dialog.FileNames.Length];
                        Array.Fill(a, (float)1);
                        n = new float[dialog.FileNames.Length];
                        Array.Fill(n, (float)3);
                        f = new float[dialog.FileNames.Length];
                        Array.Fill(f, (float)10);
                        cameraPosition = new Vector4[dialog.FileNames.Length];
                        Array.Fill(cameraPosition, new Vector4(2, (float)2.5, 3, 1));
                        for (var i = 0; i < dialog.FileNames.Length; i++)
                        {
                            _modelObject.Add(ReadObjFile(dialog.FileNames[i]));
                            _loadedObject.Add(ReadObjFile(dialog.FileNames[i]));
                            ScaledVertexOrder.Add(
                                new (int, int, int)[_modelObject[i].TextureList.Count]
                            );
                            ScaledEdgeList.Add(null);
                            ScaledVertexList.Add(null);
                            transforms.Add(new List<Matrix4x4>());
                            transforms[i].Add(Matrix4x4.CreateRotationX((float)0));
                            transforms[i].Add(Matrix4x4.CreateRotationX((float)0));
                            transforms[i].Add(Matrix4x4.CreateRotationY((float)0));
                            transforms[i].Add(
                                Matrix4x4.CreateLookAt(
                                    new Vector3(
                                        cameraPosition[i].X,
                                        cameraPosition[i].Y,
                                        cameraPosition[i].Z
                                    ),
                                    new Vector3(0, 0, 0),
                                    new Vector3(5, 5, 5)
                                )
                            );
                            transforms[i].Add(
                                Matrix4x4.CreatePerspectiveFieldOfView(e[i], a[i], n[i], f[i])
                            );
                            // Temporary bitmap assigning
                            _bitmap.Add(tempBitmap);

                            (ScaledEdgeList[i], ScaledVertexList[i], ScaledVertexOrder[i]) =
                                ScaleVertices(
                                    _modelObject[i].FaceList,
                                    pbCanvas.Width,
                                    pbCanvas.Height,
                                    i
                                );
                            _filler.Add(
                                new Filler(
                                    _modelObject[i],
                                    pbCanvas.Height,
                                    pbCanvas.Width,
                                    polySize,
                                    ScaledVertexList[i],
                                    ScaledVertexOrder[i],
                                    _texture[0],
                                    _normalMap[0],
                                    isHeightMapEnabled,
                                    _bitmap[i],
                                    ZBuffer
                                )
                            );
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
            if (!_fastBitmap[0].Locked)
            {
                using (var graphics = Graphics.FromImage(_bitmap[0]))
                    graphics.FillRectangle(
                        Brushes.White,
                        new Rectangle(0, 0, _bitmap[0].Width, _bitmap[0].Height)
                    );
                for (int i = 0; i < ZBuffer.GetLength(0); i++)
                    for (int j = 0; j < ZBuffer.GetLength(1); j++)
                        ZBuffer[i, j] = double.MaxValue;
                for (var i = 0; i < _loadedObject.Count; i++)
                {
                    // Transform
                    TransformMesh(i);

                    // Filling and shading
                    _fastBitmap[0].Lock();
                    FillMesh(_fastBitmap[0], i);
                    // async not working for multiple objects filling
                    //await Task.Run(() => FillMesh(_fastBitmap[0], i));
                    _fastBitmap[0].Unlock();

                    //Drawing mesh
                    if (cbMesh.Checked)
                        DrawLines(_bitmap[0], System.Drawing.Color.Black, 1, i);

                    pbCanvas.Image = _bitmap[0].Clone(
                        new Rectangle(0, 0, _bitmap[0].Width, _bitmap[i].Height),
                        System.Drawing.Imaging.PixelFormat.DontCare
                    );
                }
            }
        }

        public void DrawObjectAnimation()
        {
            if (!_fastBitmap[0].Locked)
            {
                using (var graphics = Graphics.FromImage(_bitmap[0]))
                    graphics.FillRectangle(
                        Brushes.White,
                        new Rectangle(0, 0, _bitmap[0].Width, _bitmap[0].Height)
                    );
                for (int i = 0; i < ZBuffer.GetLength(0); i++)
                    for (int j = 0; j < ZBuffer.GetLength(1); j++)
                        ZBuffer[i, j] = double.MaxValue;
                for (var i = 0; i < _loadedObject.Count; i++)
                {
                    // Lab comment
                    //_fastBitmap[i].Lock();
                    //FillMesh(_fastBitmap[i], i);
                    //_fastBitmap[i].Unlock();

                    TransformMesh(i);

                    if (cbMesh.Checked)
                        DrawLines(_bitmap[0], System.Drawing.Color.Black, 1, i);

                    pbCanvas.Image = _bitmap[0].Clone(
                        new Rectangle(0, 0, _bitmap[i].Width, _bitmap[0].Height),
                        System.Drawing.Imaging.PixelFormat.DontCare
                    );
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
                    graphics.DrawLine(
                        pen,
                        i.Item1.Item1,
                        i.Item1.Item2,
                        i.Item2.Item1,
                        i.Item2.Item2
                    );
                }
                pen.Dispose();
            }
        }

        public void FillMesh(FastBitmap bitmap, int index)
        {
            var temp = new (int, int)[polySize];
            for (var i = 0; i < ScaledVertexList[index].Count; i++)
            {
                temp[i % polySize] = (
                    ScaledVertexList[index][i].Item1,
                    ScaledVertexList[index][i].Item2
                );
                if (i % polySize == 2)
                {
                    _filler[index].FillPoly(bitmap, temp, ScaledVertexList[index][i].Item4);
                }
            }
        }

        public (int, int, int) ScaleToCurrentSize(double x, double y, double z, Bitmap bitmap)
        {
            return (
                (int)((x * 0.99 + 1) * bitmap.Height / 2),
                (int)((y * 0.99 + 1) * bitmap.Height / 2),
                (int)((z * 0.99 + 1) * bitmap.Height / 2)
            );
        }

        public (
            List<((int, int, int), (int, int, int))>,
            List<(int, int, int, Face)>,
            (int, int, int)[]
        ) ScaleVertices(List<Face> faces, int width, int height, int index)
        {
            var ret1 = new List<((int, int, int), (int, int, int))>();
            var ret2 = new List<(int, int, int, Face)>();
            var ret3 = new List<(int, int, int)>();
            foreach (var i in faces)
            {
                for (int j = 0; j < i.VertexIndexList.Length; j++)
                {
                    // removing points outside of the screen
                    if (
                        _modelObject[index].VertexList.Count > i.VertexIndexList[j] - 1
                        && _modelObject[index].VertexList.Count
                            > i.VertexIndexList[(j + 1) % i.VertexIndexList.Length] - 1
                    )
                    {
                        if (
                            _modelObject[index].VertexList[i.VertexIndexList[j] - 1].X < -1
                            || _modelObject[index].VertexList[i.VertexIndexList[j] - 1].X > 1
                            || _modelObject[index].VertexList[i.VertexIndexList[j] - 1].Y < -1
                            || _modelObject[index].VertexList[i.VertexIndexList[j] - 1].Y > 1
                        )
                        {
                            for (var k = 0; k < j; k++)
                            {
                                ret1.RemoveAt(ret1.Count - 1);
                                ret2.RemoveAt(ret2.Count - 1);
                            }
                            j = i.VertexIndexList.Length;
                            continue;
                        }
                        if (
                            _modelObject[index].VertexList[
                                i.VertexIndexList[(j + 1) % i.VertexIndexList.Length] - 1
                            ].X < -1
                            || _modelObject[index].VertexList[
                                i.VertexIndexList[(j + 1) % i.VertexIndexList.Length] - 1
                            ].X > 1
                            || _modelObject[index].VertexList[
                                i.VertexIndexList[(j + 1) % i.VertexIndexList.Length] - 1
                            ].Y < -1
                            || _modelObject[index].VertexList[
                                i.VertexIndexList[(j + 1) % i.VertexIndexList.Length] - 1
                            ].Y > 1
                        )
                        {
                            for (var k = 0; k < j; k++)
                            {
                                ret1.RemoveAt(ret1.Count - 1);
                                ret2.RemoveAt(ret2.Count - 1);
                            }
                            j = i.VertexIndexList.Length;
                            continue;
                        }

                        var point1 = ScaleToCurrentSize(
                            _modelObject[index].VertexList[i.VertexIndexList[j] - 1].X,
                            _modelObject[index].VertexList[i.VertexIndexList[j] - 1].Y,
                            _modelObject[index].VertexList[i.VertexIndexList[j] - 1].Z,
                            _bitmap[index]
                        );
                        var point2 = ScaleToCurrentSize(
                            _modelObject[index].VertexList[
                                i.VertexIndexList[(j + 1) % i.VertexIndexList.Length] - 1
                            ].X,
                            _modelObject[index].VertexList[
                                i.VertexIndexList[(j + 1) % i.VertexIndexList.Length] - 1
                            ].Y,
                            _modelObject[index].VertexList[
                                i.VertexIndexList[(j + 1) % i.VertexIndexList.Length] - 1
                            ].Z,
                            _bitmap[index]
                        );
                        var temp = (
                            (point1.Item1, point1.Item2, point1.Item3),
                            (point2.Item1, point2.Item2, point2.Item3)
                        );
                        ret1.Add(temp);
                        ret2.Add((point1.Item1, point1.Item2, point1.Item3, i));
                    }
                }
            }
            for (var i = 0; i < _modelObject[index].VertexList.Count; i++)
            {
                var point = ScaleToCurrentSize(
                    _modelObject[index].VertexList[i].X,
                    _modelObject[index].VertexList[i].Y,
                    _modelObject[index].VertexList[i].Z,
                    _bitmap[index]
                );
                //if(point.Item1 >= 0 && point.Item1 < _bitmap[index].Width && point.Item2 >= 0 && point.Item2 < _bitmap[index].Height)
                ret3.Add(point);
            }
            //for(var i = 0; i < faces.Count; i++)
            //{
            //    if (faces[i].VertexIndexList[0] - 1 >= ret3.Count || faces[i].VertexIndexList[1] - 1 >= ret3.Count || faces[i].VertexIndexList[2] - 1 >= ret3.Count)
            //        _modelObject[index].FaceList.RemoveAt(i);
            //}
            return (ret1, ret2, ret3.ToArray());
        }

        public void Animation()
        {
            animationInProgress = true;
            int increment = 10;
            (int, int) middle = (pbCanvas.Width / 2, pbCanvas.Height / 2);
            while (animationInProgress)
            {
                // Lab 4 modifs
                //rotationX += (float)0.01;
                //transforms[0] = Matrix4x4.CreateRotationX(rotationX);

                for (var j = 0; j < _bitmap.Count; j++)
                {
                    int radius = pbCanvas.Width / 2;
                    for (
                        int i = 0;
                        animationInProgress && i < 3 * pbCanvas.Width / 4;
                        i += increment, radius -= increment / 3
                    )
                    {
                        _filler[j].light.Item1 = i;
                        double y =
                            middle.Item2
                            - Math.Sqrt(
                                -Math.Pow(middle.Item1, 2)
                                    + 2 * middle.Item1 * i
                                    - Math.Pow(i, 2)
                                    + (Math.Pow(radius, 2))
                            );
                        _filler[j].light.Item2 = (int)y;
                        DrawObjectAnimation();
                        CalculateFrameRate();
                    }
                    for (
                        int i = (int)(3 * pbCanvas.Width / 4);
                        animationInProgress && i > pbCanvas.Width / 4;
                        i -= increment, radius -= increment / 3
                    )
                    {
                        _filler[j].light.Item1 = i;
                        double y =
                            middle.Item2
                            + Math.Sqrt(
                                -Math.Pow(middle.Item1, 2)
                                    + 2 * middle.Item1 * i
                                    - Math.Pow(i, 2)
                                    + (Math.Pow(radius, 2))
                            );
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
            Vector4 normalVector;
            _modelObject[index].VertexList.Clear();
            for (var i = 0; i < _loadedObject[index].VertexList.Count; i++)
            {
                // points transformations
                point = new Vector4(
                    (float)_loadedObject[index].VertexList[i].X,
                    (float)_loadedObject[index].VertexList[i].Y,
                    (float)_loadedObject[index].VertexList[i].Z,
                    (float)1
                );

                foreach (var t in transforms[index])
                    point = TransformVector(point, t);

                point.X /= point.W;
                point.Y /= point.W;
                point.Z /= point.W;
                var vertex = new Vertex();
                vertex.X = point.X;
                vertex.Y = point.Y;
                vertex.Z = point.Z;
                _modelObject[index].VertexList.Add(vertex);

                // Normal vectors transformations
            }
            for (var i = 0; i < _loadedObject[index].VertexList.Count; i++)
            {
                normalVector = new Vector4(
                    (float)_loadedObject[index].NVList[i].X,
                    (float)_loadedObject[index].NVList[i].Y,
                    (float)_loadedObject[index].NVList[i].Z,
                    0
                );
                foreach (var t in transforms[index])
                    normalVector = TransformVector(normalVector, t);

                _modelObject[index].NVList[i] = new NormalVector();
                _modelObject[index].NVList[i].X = normalVector.X;
                _modelObject[index].NVList[i].X = normalVector.Y;
                _modelObject[index].NVList[i].X = normalVector.Z;
            }
            (ScaledEdgeList[index], ScaledVertexList[index], ScaledVertexOrder[index]) =
                ScaleVertices(_modelObject[index].FaceList, pbCanvas.Width, pbCanvas.Height, index);
            _filler[index].ScaledVertexOrder = ScaledVertexOrder[index];
        }
    }
}
