using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygon_Filler
{
    public class Polygon
    {
        public List<Vertex> vertices = new List<Vertex>();
        public List<Edge> edges = new List<Edge>();

        public bool isFilled = false;
        public bool isCorrect = false;
        public Color color = Color.Black;
        public Color colorOfFilling = Color.White;

        public Polygon(List<Vertex> vertices, List<Edge> edges)
        {
            for (int i = 0; i < vertices.Count; i++)
                this.vertices.Add(vertices[i]);
            for (int i = 0; i < edges.Count; i++)
                this.edges.Add(edges[i]);
            return;
        }

        public Polygon(Polygon p)
        {
            this.color = p.color;
            this.isCorrect = p.isCorrect;
            this.isFilled = p.isFilled;
            this.colorOfFilling = p.colorOfFilling;
            for (int i = 0; i < p.vertices.Count; i++)
                this.vertices.Add(new Vertex(new Point(p.vertices[i].center.X, p.vertices[i].center.Y)));
            for (int i = 0; i < vertices.Count - 1; i++)
                this.edges.Add(new Edge(vertices[i], vertices[i + 1]));
            if (this.isCorrect == true) this.edges.Add(new Edge(vertices.Last(), vertices.First()));
        }

        public void Draw()
        {
            foreach (Edge e in edges)
                e.Draw(color);
            foreach (Vertex v in vertices)
                v.Draw(color);
            if (isFilled == true) this.Fill();
            return;
        }

        public void Move(int dx, int dy)
        {
            for (int i = 0; i < vertices.Count; i++)
                vertices[i].Move(dx, dy);
            return;
        }

        protected class AET
        {
            public double x;
            public double diff;
            public Edge e;

            public AET(double x, double diff, Edge e)
            {
                this.x = x;
                this.diff = diff;
                this.e = e;
            }
        }

        public void Fill()
        {
            List<AET> AETs = new List<AET>();
            isFilled = true;

            List<Vertex> sortedVertices = vertices.OrderBy(v => v.center.Y).ToList();

            int ymin = sortedVertices.Last().center.Y;
            int ymax = sortedVertices.First().center.Y;

            for(int y = ymin; y >= ymax; y--)
            {
                foreach (Vertex v in vertices.FindAll(u => u.center.Y == y ))
                {
                    bool horizontalLine = false;
                    Vertex vertex = null;
                    int index = vertices.IndexOf(v);
                    if (index > 0) vertex = vertices[index - 1];
                    else if (index == 0) vertex = vertices[vertices.Count - 1];
                    if(vertex != null)
                    {
                        Edge edge = edges.Find(e => e.v1 == vertex && e.v2 == v);
                        double diff = 0;
                        if (vertex.center.Y - v.center.Y == 0) horizontalLine = true;
                        else diff = ((double)(vertex.center.X - v.center.X) / (double)(vertex.center.Y - v.center.Y));
                        if (horizontalLine == false && vertex.center.Y <= v.center.Y) AETs.Add(new AET( v.center.X, diff, edge));
                        else AETs.RemoveAll(e => e.e == edge);
                    }
                    vertex = null;
                    if (index < vertices.Count - 1) vertex = vertices[index + 1];
                    else if (index == vertices.Count - 1) vertex = vertices[0];
                    if (vertex != null)
                    {
                        Edge edge = edges.Find(e => e.v1 == v && e.v2 == vertex);
                        double diff = 0;
                        if (vertex.center.Y - v.center.Y == 0) horizontalLine = true;
                        else
                        {
                            diff = ((double)(vertex.center.X - v.center.X) / (double)(vertex.center.Y - v.center.Y));
                            horizontalLine = false;
                        }                        
                        if (horizontalLine == false && vertex.center.Y <= v.center.Y) AETs.Add(new AET( v.center.X, diff, edge));
                        else AETs.RemoveAll(e => e.e == edge);
                    }
                }
                AETs = AETs.OrderBy(a => a.x).ToList();

                if (Form.backgroundDBM != null && Form.bumpMap != null && this != Form.lightPolygon)
                {
                    for (int i = 0; i < AETs.Count; i += 2)
                    {
                        for (int x = (int)AETs[i].x + 1; x <= AETs[i + 1].x; x++)
                        {
                            if (x < 0 || x >= Form.dbm.Width || y < 0 || y >= Form.dbm.Height) continue;

                            float[] D = new float[3];
                            float[] T = new float[] { (float)1, (float)0, (float)0 };
                            float[] B = new float[] { (float)0, (float)1, (float)0 };
                            float dhdx = -((Form.heightMap[(x + 1) % Form.heightMap.GetLength(0), y] - Form.heightMap[x, y]) / 255);
                            float dhdy = -((Form.heightMap[x, (y + 1) % Form.heightMap.GetLength(1)] - Form.heightMap[x, y]) / 255);
                            for(int j = 0; j < D.Count(); j++)
                                D[j] = T[j] * dhdx + B[j] * dhdy;                           


                            float[] Io = new float[] { (float)Form.backgroundDBM.GetPixel(x, y).R / (float)255, (float)Form.backgroundDBM.GetPixel(x, y).G / (float)255, (float)Form.backgroundDBM.GetPixel(x, y).B / (float)255 };
                            float[] L = new float[] { Form.lightVector[0] - (float)x, Form.lightVector[1] - (float)y, Form.lightVector[2] };

                            float lengthL = (float)Math.Sqrt((L[0] * L[0] + L[1] * L[1] + L[2] * L[2]));
                            for (int j = 0; j < L.Count(); j++)
                            {
                                L[j] /= lengthL;
                            }
                            float[] N = new float[] { (float)0 + D[0], (float)0 + D[1], (float)1 + D[2] };

                            float lengthN = (float)Math.Sqrt((N[0] * N[0] + N[1] * N[1] + N[2] * N[2]));

                            for (int j = 0; j < N.Count(); j++)
                            {
                                N[j] /= lengthN;
                            }

                            float[] color = new float[] { Io[0] * Form.colorOfLight[0] * Tools.ScalarProduct(N, L), Io[1] * Form.colorOfLight[1] * Tools.ScalarProduct(N, L), Io[2] * Form.colorOfLight[2] * Tools.ScalarProduct(N, L) };
                            for (int j = 0; j < color.Count(); j++)
                            {
                                color[j] *= 255;
                                if (color[j] < 0) color[j] = 0;
                                if (color[j] > 255) color[j] = 255;
                            }
                            if (Tools.ScalarProduct(N, L) < 0) Form.dbm.SetPixel(x, y, Color.Black);    
                            Form.dbm.SetPixel(x, y, Color.FromArgb((int)color[0], (int)color[1], (int)color[2]));
                        }
                    }
                }
                else if (Form.backgroundDBM == null && Form.bumpMap != null && this != Form.lightPolygon)
                {
                    for (int i = 0; i < AETs.Count; i += 2)
                    {
                        for (int x = (int)AETs[i].x + 1; x <= AETs[i + 1].x; x++)
                        {
                            if (x < 0 || x >= Form.dbm.Width || y < 0 || y >= Form.dbm.Height) continue;

                            float[] D = new float[3];
                            float[] T = new float[] { (float)1, (float)0, (float)0 };
                            float[] B = new float[] { (float)0, (float)1, (float)0 };
                            float dhdx = -((Form.heightMap[(x + 1) % Form.heightMap.GetLength(0), y] - Form.heightMap[x, y]) / 255);
                            float dhdy = -((Form.heightMap[x, (y + 1) % Form.heightMap.GetLength(1)] - Form.heightMap[x, y]) / 255);
                            for (int j = 0; j < D.Count(); j++)
                                D[j] = T[j] * dhdx + B[j] * dhdy;


                            float[] Io = new float[] { colorOfFilling.R / (float)255, colorOfFilling.G / (float)255, colorOfFilling.B / (float)255 };
                            float[] L = new float[] { Form.lightVector[0] - (float)x, Form.lightVector[1] - (float)y, Form.lightVector[2] };

                            float lengthL = (float)Math.Sqrt((L[0] * L[0] + L[1] * L[1] + L[2] * L[2]));
                            for (int j = 0; j < L.Count(); j++)
                            {
                                L[j] /= lengthL;
                            }
                            float[] N = new float[] { (float)0 + D[0], (float)0 + D[1], (float)1 + D[2] };

                            float lengthN = (float)Math.Sqrt((N[0] * N[0] + N[1] * N[1] + N[2] * N[2]));

                            for (int j = 0; j < N.Count(); j++)
                            {
                                N[j] /= lengthN;
                            }

                            float[] color = new float[] { Io[0] * Form.colorOfLight[0] * Tools.ScalarProduct(N, L), Io[1] * Form.colorOfLight[1] * Tools.ScalarProduct(N, L), Io[2] * Form.colorOfLight[2] * Tools.ScalarProduct(N, L) };
                            for (int j = 0; j < color.Count(); j++)
                            {
                                color[j] *= 255;
                                if (color[j] < 0) color[j] = 0;
                                if (color[j] > 255) color[j] = 255;
                            }
                            Form.dbm.SetPixel(x, y, Color.FromArgb((int)color[0], (int)color[1], (int)color[2]));
                        }
                    }
                }
                else if (Form.backgroundDBM != null && this != Form.lightPolygon)
                {
                    for (int i = 0; i < AETs.Count; i += 2)
                    {
                        for (int x = (int)AETs[i].x + 1; x <= AETs[i + 1].x; x++)
                        {
                            if (x < 0 || x >= Form.dbm.Width || y < 0 || y >= Form.dbm.Height) continue;
                            float[] Io = new float[] { (float)Form.backgroundDBM.GetPixel(x, y).R / (float)255, (float)Form.backgroundDBM.GetPixel(x, y).G / (float)255, (float)Form.backgroundDBM.GetPixel(x, y).B / (float)255 };
                            float[] L = new float[] { Form.lightVector[0] - (float)x, Form.lightVector[1] - (float)y, Form.lightVector[2] };
                            float length = (float)Math.Sqrt((L[0] * L[0] + L[1] * L[1] + L[2] * L[2]));
                            for (int j = 0; j < L.Count(); j++)
                            {
                                L[j] /= length;
                            }
                            float[] N = new float[] { (float)0, (float)0, (float)1 };
                            float[] color = new float[] { Io[0] * Form.colorOfLight[0] * Tools.ScalarProduct(N, L), Io[1] * Form.colorOfLight[1] * Tools.ScalarProduct(N, L), Io[2] * Form.colorOfLight[2] * Tools.ScalarProduct(N, L)};
                            for (int j = 0; j < color.Count(); j++)
                            {
                                color[j] *= 255;
                                if (color[j] < 0)
                                    color[j] = 0;
                                if (color[j] > 255) color[j] = 255;
                            }
                            Form.dbm.SetPixel(x, y, Color.FromArgb((int)color[0], (int)color[1], (int)color[2]));
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < AETs.Count; i += 2)
                    {
                        for (int x = (int)AETs[i].x + 1; x <= AETs[i + 1].x; x++)
                        {
                            if (x < 0 || x >= Form.dbm.Width || y < 0 || y >= Form.dbm.Height) continue;
                            Form.dbm.SetPixel(x, y, colorOfFilling);
                        }
                    }
                }
                
                for (int i = 0; i < AETs.Count; i++)
                {
                    AETs[i].x -= AETs[i].diff;
                }
            }
        }
    }

    public class ConvexPolygon : Polygon
    {
        public ConvexPolygon(List<Vertex> vertices, List<Edge> edges) : base(vertices, edges)
        {
            List<Vertex> convexHull = new List<Vertex>();
            vertices.Sort((v, u) => (v.center.Y, v.center.X).CompareTo((u.center.Y, u.center.X)));
            vertices = vertices.OrderBy(v => (vertices.First().center.X - v.center.X) / Tools.Distance(vertices.First(), v)).ToList();
            convexHull.Add(vertices.First());
            convexHull.Add(vertices[1]);
            for (int i = 2; i < vertices.Count; i++)
            {
                while (convexHull.Count >= 2 && Tools.Cross(vertices[i], convexHull[convexHull.Count - 2], convexHull[convexHull.Count - 1]) <= 0) convexHull.RemoveAt(convexHull.Count - 1);
                convexHull.Add(vertices[i]);
            }
            this.vertices = new List<Vertex>();
            for (int i = 0; i < convexHull.Count; i++)
                this.vertices.Add(convexHull[i]);
            for (int i = 0; i < this.vertices.Count - 1; i++)
                this.edges.Add(new Edge(this.vertices[i], this.vertices[i + 1]));
            this.edges.Add(new Edge(this.vertices.Last(), this.vertices.First()));
            return;
        }
    }
}
