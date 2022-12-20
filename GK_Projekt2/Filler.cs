using Microsoft.VisualBasic.ApplicationServices;
using ObjParser;
using ObjParser.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design.Behavior;

namespace GK_Projekt2
{
    public class Filler
    {
        #region fields
        public const int maxByte = 255;
        public int Height;
        public int Width;
        public int polyCount;
        public EdgeTab[] EdgeTable;
        public EdgeTab ActiveEdgeTuple;
        public Obj obj;
        public Bitmap _texture { get; set; }
        public Bitmap _normalMap { get; set; }
        public Bitmap _bitmap { get; set; }
        public (int, int, int)[]  ScaledVertexOrder;
        public (double, double, double) Io = (1, 1, 1);
        public (double, double, double) Il = (1, 1, 1);
        public double kd = 1;
        public double ks = 1;
        public double m = 1;
        public bool textureColor = true;
        public bool normalVectorModified = true;
        public bool vectorInterpolation = true;
        public (int, int, int) light = (0, 0, 0);
        public Mutex mutex;
        public bool heightMap = false;
        public double[,] ZBuffer;

        #endregion

        public Filler(Obj obj, int Height, int Width, int polyCount, List<(int, int, int, Face)> ScaledVertices, (int, int, int)[] ScaledVertexOrder, Bitmap texture, Bitmap normalMap, bool heightMapToggle, Bitmap bitmap, double[,] ZBuffer)
        {
            this._bitmap = bitmap;
            heightMap = heightMapToggle;
            this._texture = texture;
            this.ScaledVertexOrder = ScaledVertexOrder;
            this.polyCount = polyCount;
            this.Height = Height;
            light.Item1 = - Height;
            light.Item2 = - Height;
            light.Item3 = (int)(Height * 1.5);
            this.Width = Width;
            this.obj = obj;
            EdgeTable = new EdgeTab[Height];
            mutex = new Mutex();
            for (int i = 0; i < EdgeTable.Length; i++)
                EdgeTable[i] = new EdgeTab(polyCount);
            ActiveEdgeTuple = new EdgeTab(polyCount);
            _normalMap = normalMap;
            this.ZBuffer = ZBuffer;
        }

        public void FillPoly(FastBitmapLib.FastBitmap bitmap, (int, int)[] e, Face face)
        {
            for (var i = 0; i < e.Length; i++)
                StoreEdge(e[i].Item1, e[i].Item2, e[(i + 1) % e.Length].Item1, e[(i + 1) % e.Length].Item2);
            Fill(bitmap, face);
        }

        // Algorithm inspired by this idea: https://www.geeksforgeeks.org/scan-line-polygon-filling-using-opengl-c/

        public void Fill(FastBitmapLib.FastBitmap bitmap, Face face)
        {
            int i, j, x1, ymax1, x2, ymax2, FillFlag = 0, coordCount;
            //double p1;
            //double p2;
            //double p3;
            var p1 = obj.VertexList[face.VertexIndexList[0] - 1];
            var p2 = obj.VertexList[face.VertexIndexList[1] - 1];
            var p3 = obj.VertexList[face.VertexIndexList[2] - 1];
            for (i = 0; i < Height; i++)
            {
                for (j = 0; j < EdgeTable[i].count; j++)
                    {
                    (var r1, var r2, var r3) = CalculateBaricentricRatio((i, j), ((int)p1.X, (int)p1.Y, (int)p1.Z), ((int)p2.X, (int)p2.Y, (int)p2.Z), ((int)p3.X, (int)p3.Y, (int)p3.Z));
                        if (( r1 * p1.Z + r2 * p2.Z + r3 * p3.Z) > ZBuffer[i, j])
                            continue;
                        ZBuffer[i, j] = r1 * p1.Z + r2 * p2.Z + r3 * p3.Z;

                        ActiveEdgeTuple.buckets[ActiveEdgeTuple.count].ymax = EdgeTable[i].buckets[j].ymax;
                        ActiveEdgeTuple.buckets[ActiveEdgeTuple.count].xofymin = EdgeTable[i].buckets[j].xofymin;
                        ActiveEdgeTuple.buckets[ActiveEdgeTuple.count].slopeinverse = EdgeTable[i].buckets[j].slopeinverse;
                        InsertSort(ActiveEdgeTuple);
                        ActiveEdgeTuple.count++;
                    }
                    RemoveEdge(ActiveEdgeTuple, i);
                    InsertSort(ActiveEdgeTuple);

                    j = 0;
                    FillFlag = 0;
                    coordCount = 0;
                    x1 = 0;
                    x2 = 0;
                    ymax1 = 0;
                    ymax2 = 0;

                    while (j < ActiveEdgeTuple.count)
                    {
                        if (coordCount % 2 == 0)
                        {
                            x1 = (int)(ActiveEdgeTuple.buckets[j].xofymin);
                            ymax1 = ActiveEdgeTuple.buckets[j].ymax;
                            if (x1 == x2)
                            {
                                if (((x1 == ymax1) && (x2 != ymax2)) || ((x1 != ymax1) && (x2 == ymax2)))
                                {
                                    x2 = x1;
                                    ymax2 = ymax1;
                                }
                                else
                                    coordCount++;
                            }
                            else
                                coordCount++;
                        }
                        else
                        {
                            x2 = (int)ActiveEdgeTuple.buckets[j].xofymin;
                            ymax2 = ActiveEdgeTuple.buckets[j].ymax;

                            FillFlag = 0;

                            if (x1 == x2)
                            {
                                if (((x1 == ymax1) && (x2 != ymax2)) || ((x1 != ymax1) && (x2 == ymax2)))
                                {
                                    x1 = x2;
                                    ymax1 = ymax2;
                                }
                                else
                                {
                                    coordCount++;
                                    FillFlag = 1;
                                }
                            }
                            else
                            {
                                coordCount++;
                                FillFlag = 1;
                            }
                        if (FillFlag != 0)
                        {
                            for (int x = x1; x <= x2; x++)
                            {
                                bitmap.SetPixel(x, i, CalculateColor(x, i, face));
                            }
                        }
                        }
                        j++;
                    }
                    for (int k = 0; k < ActiveEdgeTuple.count; k++)
                    {
                        (ActiveEdgeTuple.buckets[k]).xofymin = (ActiveEdgeTuple.buckets[k]).xofymin + (ActiveEdgeTuple.buckets[k]).slopeinverse;
                    }
            }
            foreach (var e in EdgeTable)
                e.count = 0;
            ActiveEdgeTuple.count = 0;
        }

        private System.Drawing.Color CalculateColor(int x, int y, Face face)
        {
            (double, double, double) I, I1, I2, I3;
            var color = _texture.GetPixel(x, y);
            var color1 = _texture.GetPixel(ScaledVertexOrder[face.VertexIndexList[0] - 1].Item1, ScaledVertexOrder[face.VertexIndexList[0] - 1].Item2);
            var color2 = _texture.GetPixel(ScaledVertexOrder[face.VertexIndexList[1] - 1].Item1, ScaledVertexOrder[face.VertexIndexList[1] - 1].Item2);
            var color3 = _texture.GetPixel(ScaledVertexOrder[face.VertexIndexList[2] - 1].Item1, ScaledVertexOrder[face.VertexIndexList[2] - 1].Item2);
            var It = ((double)(color.R / (decimal)maxByte), (double)(color.G / (decimal)maxByte), (double)(color.B / (decimal)maxByte));
            var It1 = ((double)(color1.R / (decimal)maxByte), (double)(color1.G / (decimal)maxByte), (double)(color1.B / (decimal)maxByte));
            var It2 = ((double)(color2.R / (decimal)maxByte), (double)(color2.G / (decimal)maxByte), (double)(color2.B / (decimal)maxByte));
            var It3 = ((double)(color3.R / (decimal)maxByte), (double)(color3.G / (decimal)maxByte), (double)(color3.B / (decimal)maxByte));
            color = _normalMap.GetPixel(x, y);
            var Inm = ((double)(color.R / (decimal)maxByte), (double)(color.G / (decimal)maxByte), (double)(color.B / (decimal)maxByte));
            color = _normalMap.GetPixel(x <= this._normalMap.Height ? x + 1 : x, y);
            var nextXInm = ((double)(color.R / (decimal)maxByte), (double)(color.G / (decimal)maxByte), (double)(color.B / (decimal)maxByte));
            color = _normalMap.GetPixel(x, y <= this._normalMap.Height ? y + 1 : y);
            var nextYInm = ((double)(color.R / (decimal)maxByte), (double)(color.G / (decimal)maxByte), (double)(color.B / (decimal)maxByte));
            if (textureColor == true)
            {
                I = It;
                I1 = It1;
                I2 = It2;
                I3 = It3;
            }
            else
            {
                I = Io;
                I1 = Io;
                I2 = Io;
                I3 = Io;
            }

            var v1 = (obj.NVList[face.NVIndexList[0] - 1].X, obj.NVList[face.NVIndexList[0] - 1].Y, obj.NVList[face.NVIndexList[0] - 1].Z);
            var v2 = (obj.NVList[face.NVIndexList[1] - 1].X, obj.NVList[face.NVIndexList[1] - 1].Y, obj.NVList[face.NVIndexList[1] - 1].Z);
            var v3 = (obj.NVList[face.NVIndexList[2] - 1].X, obj.NVList[face.NVIndexList[2] - 1].Y, obj.NVList[face.NVIndexList[2] - 1].Z);

            if (vectorInterpolation)
            {
                var N = NormalizeVector(Interpolate(v1, v2, v3, CalculateBaricentricRatio((x, y),
                    ScaledVertexOrder[face.VertexIndexList[0] - 1],
                    ScaledVertexOrder[face.VertexIndexList[1] - 1],
                    ScaledVertexOrder[face.VertexIndexList[2] - 1])));
                if (normalVectorModified)
                    N = CalculateNFromTexture(Inm, N, nextXInm, nextYInm);

                var L = NormalizeVectorFromVertices((x, y,
                    (ScaledVertexOrder[face.VertexIndexList[0] - 1].Item3 +
                    ScaledVertexOrder[face.VertexIndexList[1] - 1].Item3 +
                    ScaledVertexOrder[face.VertexIndexList[2] - 1].Item3) / 3),
                    light);
                double cosNL = CalculateCosUsingScalarProduct(N, L);
                cosNL = cosNL > 0 ? cosNL : 0;
                double cosVR = CalculateCosUsingScalarProduct((0, 0, 1), ((double)2m * cosNL * N.Item1 - L.Item1, (double)2m * cosNL * N.Item2 - L.Item2, (double)2m * cosNL * N.Item3 - L.Item3));
                cosVR = cosVR > 0 ? cosVR : 0;
                double r = kd * Il.Item1 * I.Item1 * cosNL + ks * Il.Item1 * I.Item1 * Math.Pow(cosVR, m);
                double g = kd * Il.Item2 * I.Item2 * cosNL + ks * Il.Item2 * I.Item2 * Math.Pow(cosVR, m);
                double b = kd * Il.Item3 * I.Item3 * cosNL + ks * Il.Item3 * I.Item3 * Math.Pow(cosVR, m);
                System.Drawing.Color ret = System.Drawing.Color.FromArgb((int)(r * maxByte > maxByte ? maxByte : r * maxByte),
                    (int)(g * maxByte > maxByte ? maxByte : g * maxByte),
                    (int)(b * maxByte > maxByte ? maxByte : b * maxByte));
                return ret;
            }
            else 
            {
                var N1 = NormalizeVector(v1);
                var N2 = NormalizeVector(v2);
                var N3 = NormalizeVector(v3);
                if (normalVectorModified)
                {
                    N1 = CalculateNFromTexture(Inm, N1, nextYInm, nextYInm);
                    N2 = CalculateNFromTexture(Inm, N2, nextYInm, nextYInm);
                    N3 = CalculateNFromTexture(Inm, N3, nextYInm, nextYInm);
                }

                var L = NormalizeVectorFromVertices((x, y,
                    (ScaledVertexOrder[face.VertexIndexList[0] - 1].Item3 +
                    ScaledVertexOrder[face.VertexIndexList[1] - 1].Item3 +
                    ScaledVertexOrder[face.VertexIndexList[2] - 1].Item3) / 3),
                    light);

                double cosNL1 = CalculateCosUsingScalarProduct(N1, L);
                cosNL1 = cosNL1 > 0 ? cosNL1 : 0;
                double cosNL2 = CalculateCosUsingScalarProduct(N2, L);
                cosNL2 = cosNL2 > 0 ? cosNL2 : 0;
                double cosNL3 = CalculateCosUsingScalarProduct(N3, L);
                cosNL3 = cosNL3 > 0 ? cosNL3 : 0;

                double cosVR1 = CalculateCosUsingScalarProduct((0, 0, 1), ((double)2m * cosNL1 * N1.Item1 - L.Item1, (double)2m * cosNL1 * N1.Item2 - L.Item2, (double)2m * cosNL1 * N1.Item3 - L.Item3));
                cosVR1 = cosVR1 > 0 ? cosVR1 : 0;
                double cosVR2 = CalculateCosUsingScalarProduct((0, 0, 1), ((double)2m * cosNL2 * N2.Item1 - L.Item1, (double)2m * cosNL2 * N2.Item2 - L.Item2, (double)2m * cosNL2 * N2.Item3 - L.Item3));
                cosVR2 = cosVR2 > 0 ? cosVR2 : 0;
                double cosVR3 = CalculateCosUsingScalarProduct((0, 0, 1), ((double)2m * cosNL3 * N3.Item1 - L.Item1, (double)2m * cosNL3 * N3.Item2 - L.Item2, (double)2m * cosNL3 * N3.Item3 - L.Item3));
                cosVR3 = cosVR3 > 0 ? cosVR3 : 0;

                double r1 = kd * Il.Item1 * I1.Item1 * cosNL1 + ks * Il.Item1 * I1.Item1 * Math.Pow(cosVR1, m);
                double g1 = kd * Il.Item2 * I1.Item2 * cosNL1 + ks * Il.Item2 * I1.Item2 * Math.Pow(cosVR1, m);
                double b1 = kd * Il.Item3 * I1.Item3 * cosNL1 + ks * Il.Item3 * I1.Item3 * Math.Pow(cosVR1, m);
                double r2 = kd * Il.Item1 * I2.Item1 * cosNL2 + ks * Il.Item1 * I2.Item1 * Math.Pow(cosVR2, m);
                double g2 = kd * Il.Item2 * I2.Item2 * cosNL2 + ks * Il.Item2 * I2.Item2 * Math.Pow(cosVR2, m);
                double b2 = kd * Il.Item3 * I2.Item3 * cosNL2 + ks * Il.Item3 * I2.Item3 * Math.Pow(cosVR2, m);
                double r3 = kd * Il.Item1 * I3.Item1 * cosNL3 + ks * Il.Item1 * I3.Item1 * Math.Pow(cosVR3, m);
                double g3 = kd * Il.Item2 * I3.Item2 * cosNL3 + ks * Il.Item2 * I3.Item2 * Math.Pow(cosVR3, m);
                double b3 = kd * Il.Item3 * I3.Item3 * cosNL3 + ks * Il.Item3 * I3.Item3 * Math.Pow(cosVR3, m);

                double r, g, b;
                (r, g, b) = Interpolate((r1, g1, b1), (r2, g2, b2), (r3, g3, b3), CalculateBaricentricRatio((x, y),
                    ScaledVertexOrder[face.VertexIndexList[0] - 1],
                    ScaledVertexOrder[face.VertexIndexList[1] - 1],
                    ScaledVertexOrder[face.VertexIndexList[2] - 1]));
                System.Drawing.Color ret = System.Drawing.Color.FromArgb((int)(r * maxByte > maxByte || r < 0 ? r < 0 ? 0 : maxByte : r * maxByte),
                    (int)(g * maxByte > maxByte  || g < 0 ? g < 0 ? 0 : maxByte : g * maxByte),
                    (int)(b * maxByte > maxByte || b < 0 ? b < 0 ? 0 : maxByte : b * maxByte));
                return ret;
            }
        }

        #region Helper Functions

        private void InsertSort(EdgeTab edgeTab)
        {
            int i, j;
            Bucket temp;

            for (i = 1; i < edgeTab.count; i++)
            {
                temp.ymax = edgeTab.buckets[i].ymax;
                temp.xofymin = edgeTab.buckets[i].xofymin;
                temp.slopeinverse = edgeTab.buckets[i].slopeinverse;
                j = i - 1;

                while ((j >= 0) && (temp.xofymin < edgeTab.buckets[j].xofymin))
                {
                    edgeTab.buckets[j + 1].ymax = edgeTab.buckets[j].ymax;
                    edgeTab.buckets[j + 1].xofymin = edgeTab.buckets[j].xofymin;
                    edgeTab.buckets[j + 1].slopeinverse = edgeTab.buckets[j].slopeinverse;
                    j = j - 1;
                }
                edgeTab.buckets[j + 1].ymax = temp.ymax;
                edgeTab.buckets[j + 1].xofymin = temp.xofymin;
                edgeTab.buckets[j + 1].slopeinverse = temp.slopeinverse;
            }
        }

        private void StoreEdge(int x1, int y1, int x2, int y2)
        {
            float m, minv;
            int ymaxTS, xwithyminTS, scanline;

            if (x2 == x1)
                minv = 0;
            else
            {
                m = ((float)(y2 - y1)) / ((float)(x2 - x1));
                if (y2 == y1)
                    return;
                minv = 1 / m;
            }

            if (y1 > y2)
            {
                scanline = y2;
                ymaxTS = y1;
                xwithyminTS = x2;
            }
            else
            {
                scanline = y1;
                ymaxTS = y2;
                xwithyminTS = x1;
            }
            EdgeTable[scanline].buckets[EdgeTable[scanline].count].ymax = ymaxTS;
            EdgeTable[scanline].buckets[EdgeTable[scanline].count].xofymin = xwithyminTS;
            EdgeTable[scanline].buckets[EdgeTable[scanline].count].slopeinverse = minv;
            InsertSort(EdgeTable[scanline]);
            EdgeTable[scanline].count++;
        }

        private void RemoveEdge(EdgeTab edgeTab, int y)
        {
            int i, j;
            for (i = 0; i < edgeTab.count; i++)
            {
                if (edgeTab.buckets[i].ymax == y)
                {

                    for (j = i; j < edgeTab.count - 1; j++)
                    {
                        edgeTab.buckets[j].ymax = edgeTab.buckets[j + 1].ymax;
                        edgeTab.buckets[j].xofymin = edgeTab.buckets[j + 1].xofymin;
                        edgeTab.buckets[j].slopeinverse = edgeTab.buckets[j + 1].slopeinverse;
                    }
                    edgeTab.count--;
                    i--;
                }
            }
        }

        private (double, double, double) CalculateBaricentricRatio((int, int) x, (int, int, int) a, (int, int, int) b, (int, int, int) c)
        {
            double field = a.Item1 * (b.Item2 - c.Item2) + b.Item1 * (c.Item2 - a.Item2) + c.Item1 * (a.Item2 - b.Item2);
            double field1 = x.Item1 * (b.Item2 - c.Item2) + b.Item1 * (c.Item2 - x.Item2) + c.Item1 * (x.Item2 - b.Item2);
            double field2 = a.Item1 * (x.Item2 - c.Item2) + x.Item1 * (c.Item2 - a.Item2) + c.Item1 * (a.Item2 - x.Item2);
            double field3 = a.Item1 * (b.Item2 - x.Item2) + b.Item1 * (x.Item2 - a.Item2) + x.Item1 * (a.Item2 - b.Item2);
            return (field == 0 ? 0 : (field1 / field), field == 0 ? 0 : (field2 / field), field == 0 ? 0 : (field3 / field));
        }

        private (double, double, double) Interpolate((double, double, double) v1, (double, double, double) v2, (double, double, double) v3, (double, double, double) ratio)
        {
            return (v1.Item1 * ratio.Item1 + v2.Item1 * ratio.Item2 + v3.Item1 * ratio.Item3,
                v1.Item2 * ratio.Item1 + v2.Item2 * ratio.Item2 + v3.Item2 * ratio.Item3,
                v1.Item3 * ratio.Item1 + v2.Item3 * ratio.Item2 + v3.Item3 * ratio.Item3);
        }

        private double CalculateCosUsingScalarProduct((double, double, double) versor1, (double, double, double) versor2)
        {
            // X works properly, kd element of equation is not visible for upper half of the object
            return versor1.Item1 * versor2.Item1 + versor1.Item2 * versor2.Item2 + versor1.Item3 * versor2.Item3;
        }

        private (double, double, double) NormalizeVector((double, double, double) v)
        {
            double scaleParameter = Math.Sqrt(Math.Pow(v.Item1, 2) + Math.Pow(v.Item2, 2) + Math.Pow(v.Item3, 2));
            if(scaleParameter == 0)
                return (0, 0, 0);
            return (v.Item1 / scaleParameter, v.Item2 / scaleParameter, v.Item3 / scaleParameter);
        }

        private (double, double, double) NormalizeVectorFromVertices((int, int, int) v, (int, int, int) light)
        {
            int x = light.Item1 - v.Item1;
            int y = light.Item2 - v.Item2;
            int z = light.Item3 - v.Item3;
            double scaleParameter = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
            if (scaleParameter == 0)
                return (0, 0, 0);
            return (x / scaleParameter, y / scaleParameter, z / scaleParameter);
        }

        private (double, double, double) CalculateNFromTexture((double, double, double) I, (double, double, double) N, (double, double, double) nextIX, (double, double, double) nextIY)
        {
            (double, double, double) ret;
            var P = (0, 0, 1);
            var B = VectorProduct(N, P);
            var T = VectorProduct(B, N);
            if (heightMap)
            {
                double[,] matrix = new double[3, 3];
                matrix[0, 0] = T.Item1;
                matrix[1, 0] = T.Item2;
                matrix[2, 0] = T.Item3;
                matrix[0, 1] = B.Item1;
                matrix[1, 1] = B.Item2;
                matrix[2, 1] = B.Item3;
                matrix[0, 2] = N.Item1;
                matrix[1, 2] = N.Item2;
                matrix[2, 2] = N.Item3;
                var Nt = ScaleTexture(I);
                ret.Item1 = matrix[0, 0] * Nt.Item1 + matrix[0, 1] * Nt.Item2 + matrix[0, 2] * Nt.Item3;
                ret.Item2 = matrix[1, 0] * Nt.Item1 + matrix[1, 1] * Nt.Item2 + matrix[1, 2] * Nt.Item3;
                ret.Item3 = matrix[2, 0] * Nt.Item1 + matrix[2, 1] * Nt.Item2 + matrix[2, 2] * Nt.Item3;
            }
            else
            {
                var deltaX = nextIX.Item1 - I.Item1;
                var deltaY = nextIY.Item1 - I.Item1;
                var Tdeltax = (T.Item1 * deltaX, T.Item1 * deltaX, T.Item1 * deltaX);
                var BdeltaY = (B.Item1 * deltaY, B.Item1 * deltaY, B.Item1 * deltaY);
                var D = (Tdeltax.Item1 + BdeltaY.Item1, Tdeltax.Item2 + BdeltaY.Item2, Tdeltax.Item3 + BdeltaY.Item3);
                ret = NormalizeVector((N.Item1 + 0.5 * D.Item1, N.Item2 + 0.5 * D.Item2, N.Item3 + 0.5 * D.Item3));
            }
            return ret;
        }

        private (double, double, double) ScaleTexture((double, double, double) I)
        {
            return (I.Item1, I.Item2 , (I.Item3 + 1) / 2);
        }

        private (double, double, double) VectorProduct((double, double, double) A, (double, double, double) B)
        {
            return (A.Item2 * B.Item3 - A.Item3 * B.Item2, A.Item3 * B.Item1 - A.Item1 * B.Item3, A.Item1 * B.Item2 - A.Item2 * B.Item1);
        }

        #endregion
    }

    #region types

    public struct Bucket
    {
        public int ymax;
        public double xofymin;
        public double slopeinverse;
    }

    public class EdgeTab
    {
        public int count;
        public Bucket[] buckets;

        public EdgeTab(int polyCount)
        {
            count = 0;
            buckets = new Bucket[polyCount];
        }
    }

    #endregion
}
