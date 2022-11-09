using ObjParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design.Behavior;

namespace GK_Projekt2
{
    public class Filler
    {
        public int Height;
        public int Width;
        public int polyCount;
        public EdgeTab[] EdgeTable;
        public EdgeTab ActiveEdgeTuple;
        public Obj obj;

        public Filler(Obj obj, int Height, int Width, int polyCount)
        {
            this.polyCount = polyCount;
            this.Height = Height;
            this.Width = Width;
            this.obj = obj;
            EdgeTable = new EdgeTab[Height];
            for (int i = 0; i < EdgeTable.Length; i++)
                EdgeTable[i] = new EdgeTab(polyCount);
            ActiveEdgeTuple = new EdgeTab(polyCount);
        }

        public void FillPoly(Bitmap bitmap, (int, int)[] e)
        {
            for (var i = 0; i < e.Length; i++)
                StoreEdge(e[i].Item1, e[i].Item2, e[(i + 1) % e.Length].Item1, e[(i + 1) % e.Length].Item2);
            Fill(bitmap);
        }

        // Algorithm inspired by this idea: https://www.geeksforgeeks.org/scan-line-polygon-filling-using-opengl-c/

        void Fill(Bitmap bitmap)
        {
            int i, j, x1, ymax1, x2, ymax2, FillFlag = 0, coordCount;
            Pen pen = new Pen(System.Drawing.Color.Red, 1);
            using (var graphics = Graphics.FromImage(bitmap))
            {
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
                                    bitmap.SetPixel(x, i, CalculateColor(x - x1, i));
                        }
                        j++;
                    }
                    for (int k = 0; k < ActiveEdgeTuple.count; k++)
                    {
                        (ActiveEdgeTuple.buckets[k]).xofymin = (ActiveEdgeTuple.buckets[k]).xofymin + (ActiveEdgeTuple.buckets[k]).slopeinverse;
                    }
                }
                pen.Dispose();
            }
            foreach (var e in EdgeTable)
                e.count = 0;
            ActiveEdgeTuple.count = 0;
        }

        public System.Drawing.Color CalculateColor(int xoffset, int y)
        {
            // TBD to be implemented NVwise
            var ret = System.Drawing.Color.ForestGreen;
            return ret;
        }
        void InsertSort(EdgeTab edgeTab)
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
        void StoreEdge(int x1, int y1, int x2, int y2)
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

        void RemoveEdge(EdgeTab edgeTab, int y)
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
