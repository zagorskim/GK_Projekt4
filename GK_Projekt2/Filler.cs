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
        public const int maxByte = 255;
        public int Height;
        public int Width;
        public int polyCount;
        public EdgeTab[] EdgeTable;
        public EdgeTab ActiveEdgeTuple;
        public Obj obj;
        public List<(int, int, int, Face)> ScaledVertices;
        public Bitmap _texture { get; set; }
        public (int, int, int)[]  ScaledVertexOrder;
        public (double, double, double) Io = (1, 1, 1);
        public (double, double, double) Il = (1, 1, 1);
        public double kd = 1;
        public double ks = 1;
        public double m = 1;
        public bool textureColor = true;

        public (int, int, int) light = (0, 0, 0);


        public Filler(Obj obj, int Height, int Width, int polyCount, List<(int, int, int, Face)> ScaledVertices, (int, int, int)[] ScaledVertexOrder, Bitmap texture)
        {
            this._texture = texture;
            this.ScaledVertices = ScaledVertices;
            this.ScaledVertexOrder = ScaledVertexOrder;
            this.polyCount = polyCount;
            this.Height = Height;
            light.Item3 = Height;
            this.Width = Width;
            this.obj = obj;
            EdgeTable = new EdgeTab[Height];
            for (int i = 0; i < EdgeTable.Length; i++)
                EdgeTable[i] = new EdgeTab(polyCount);
            ActiveEdgeTuple = new EdgeTab(polyCount);
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
                for (i = 0; i < Height; i++)
                {
                    for (j = 0; j < EdgeTable[i].count; j++)
                    {
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
                                for (int x = x1; x <= x2; x++)
                                    bitmap.SetPixel(x, i, CalculateColor(x, i, face));
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
            //TBD something's wrong, light Z parameter somehow influence it's Y parameter
            (double, double, double) I;
            if (textureColor == true)
            {
                var color = _texture.GetPixel(x, y);
                I = ((double)((decimal)color.R / (decimal)maxByte), (double)((decimal)color.G / (decimal)maxByte), (double)((decimal)color.B / (decimal)maxByte));
            }
            else
                I = this.Io;
            var v1 = (obj.NVList[face.NVIndexList[0] - 1].X, obj.NVList[face.NVIndexList[0] - 1].Y, obj.NVList[face.NVIndexList[0] - 1].Z);
            var v2 = (obj.NVList[face.NVIndexList[1] - 1].X, obj.NVList[face.NVIndexList[1] - 1].Y, obj.NVList[face.NVIndexList[1] - 1].Z);
            var v3 = (obj.NVList[face.NVIndexList[2] - 1].X, obj.NVList[face.NVIndexList[2] - 1].Y, obj.NVList[face.NVIndexList[2] - 1].Z);

            var N = NormalizeVector(InterpolateVectors(v1, v2, v3, CalculateBaricentricRatio((x, y),
                ScaledVertexOrder[face.VertexIndexList[0] - 1],
                ScaledVertexOrder[face.VertexIndexList[1] - 1],
                ScaledVertexOrder[face.VertexIndexList[2] - 1])));
            var L = NormalizeVectorFromVertices((x, y, 
                (ScaledVertexOrder[face.VertexIndexList[0] - 1].Item3 + 
                ScaledVertexOrder[face.VertexIndexList[1] - 1].Item3 + 
                ScaledVertexOrder[face.VertexIndexList[2] - 1].Item3) / 3), 
                light);
            double cosNL = CalculateCosUsingScalarProduct(N, L);
            cosNL = cosNL > 0 ? cosNL : 0;
            double cosVR = CalculateCosUsingScalarProduct((0, 0, 1), ( cosNL * N.Item1 - L.Item1, 2 * cosNL * N.Item2 - L.Item2, 2 * cosNL * N.Item3 - L.Item3));
            cosVR = cosVR > 0 ? cosVR : 0;
            double r = kd * Il.Item1 * I.Item1 * cosNL + ks * Il.Item1 * I.Item1 * Math.Pow(cosVR, m);
            double g = kd * Il.Item2 * I.Item2 * cosNL + ks * Il.Item2 * I.Item2 * Math.Pow(cosVR, m);
            double b = kd * Il.Item3 * I.Item3 * cosNL + ks * Il.Item3 * I.Item3 * Math.Pow(cosVR, m);
            System.Drawing.Color ret = System.Drawing.Color.FromArgb((int)(r * maxByte > maxByte ? maxByte : r * maxByte), 
                (int)(g * maxByte > maxByte ? maxByte : g * maxByte), 
                (int)(b * maxByte > maxByte ? maxByte : b * maxByte));
            return ret;
        }
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

        private (double, double, double) InterpolateVectors((double, double, double) v1, (double, double, double) v2, (double, double, double) v3, (double, double, double) ratio)
        {
            return (v1.Item1 * ratio.Item1 + v2.Item1 * ratio.Item2 + v3.Item1 * ratio.Item3,
                v1.Item2 * ratio.Item1 + v2.Item2 * ratio.Item2 + v3.Item2 * ratio.Item3,
                v1.Item3 * ratio.Item1 + v2.Item3 * ratio.Item2 + v3.Item3 * ratio.Item3);
        }

        private double CalculateCosUsingScalarProduct((double, double, double) versor1, (double, double, double) versor2)
        {
            return versor1.Item1 * versor2.Item1 + versor1.Item2 * versor2.Item2 + versor1.Item3 * versor2.Item3;
        }

        private (double, double, double) NormalizeVector((double, double, double) v)
        {
            double scaleParameter = Math.Sqrt(Math.Pow(v.Item1, 2) + Math.Pow(v.Item2, 2) + Math.Pow(v.Item3, 2));
            if(scaleParameter == 0)
                return (0,0,0);
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
    }

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
}
