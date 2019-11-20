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
            for (int i = 0; i < p.vertices.Count; i++)
                this.vertices.Add(new Vertex(new Point(p.vertices[i].center.X, p.vertices[i].center.Y)));
            for (int i = 0; i < vertices.Count - 1; i++)
                this.edges.Add(new Edge(vertices[i], vertices[i + 1]));
            if (this.isCorrect == true) this.edges.Add(new Edge(vertices.Last(), vertices.First()));
        }

        public virtual void Draw()
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
            
        public virtual void Fill()
        {
            List<AET> AETs = new List<AET>();
            isFilled = true;

            List<Vertex> sortedVertices = vertices.OrderBy(v => v.center.Y).ToList();

            int ymin = sortedVertices.Last().center.Y;
            int ymax = sortedVertices.First().center.Y;

            for (int y = ymin; y >= ymax; y--)
            {
                foreach (Vertex v in vertices.FindAll(u => u.center.Y == y))
                {
                    bool horizontalLine = false;
                    Vertex vertex = null;
                    int index = vertices.IndexOf(v);
                    if (index > 0) vertex = vertices[index - 1];
                    else if (index == 0) vertex = vertices[vertices.Count - 1];
                    if (vertex != null)
                    {
                        Edge edge = edges.Find(e => e.v1 == vertex && e.v2 == v);
                        double diff = 0;
                        if (vertex.center.Y - v.center.Y == 0) horizontalLine = true;
                        else diff = ((double)(vertex.center.X - v.center.X) / (double)(vertex.center.Y - v.center.Y));
                        if (horizontalLine == false && vertex.center.Y <= v.center.Y) AETs.Add(new AET(v.center.X, diff, edge));
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
                        if (horizontalLine == false && vertex.center.Y <= v.center.Y) AETs.Add(new AET(v.center.X, diff, edge));
                        else AETs.RemoveAll(e => e.e == edge);
                    }
                }
                AETs = AETs.OrderBy(a => a.x).ToList();

                if (Form.backgroundDBM != null && Form.bumpMap != null)
                {
                    for (int i = 0; i < AETs.Count; i += 2)
                    {
                        for (int x = (int)AETs[i].x + 1; x <= AETs[i + 1].x; x++)
                        {
                            if (x < 0 || x >= Form.dbm.Width || y < 0 || y >= Form.dbm.Height) continue;
                            Form.dbm.SetPixel(x, y, Form.colorsToFill[x, y]);
                        }
                    }
                }
                for (int i = 0; i < AETs.Count; i++)
                {
                    AETs[i].x -= AETs[i].diff;
                }
            }
        }

        public void checkVerticesOrder()
        {
            if (vertices.Count < 3 || isCorrect == false) return;
            Vertex minY = vertices.First();
            foreach(Vertex v in vertices)
            {
                if (v.center.Y < minY.center.Y) minY = v;
            }
            Edge e1 = edges.Find(e => e.v2 == minY);
            Edge e2 = edges.Find(e => e.v1 == minY);
            //if (Tools.orientation(vertices[0].center, vertices[1].center, vertices[2].center) == 2)
            if (e2.v2.center.X > e1.v1.center.X)
            {                
                Console.WriteLine("Zmieniam kolejnosc");
                List<Vertex> newVertices = new List<Vertex>();
                for (int i = vertices.Count - 1; i >= 0; i--)
                    newVertices.Add(vertices[i]);
                List<Edge> newEdges = new List<Edge>();
                for (int i = 0; i < newVertices.Count - 1; i++)
                    newEdges.Add(new Edge(newVertices[i], newVertices[i + 1]));
                newEdges.Add(new Edge(newVertices.Last(), newVertices.First()));
                vertices = new List<Vertex>();
                edges = new List<Edge>();
                for (int i = 0; i < newVertices.Count; i++)
                    this.vertices.Add(newVertices[i]);
                for (int i = 0; i < newEdges.Count; i++)
                    this.edges.Add(newEdges[i]);
            }
        }
    }

    public class ConvexPolygon : Polygon
    {
        private bool wasFilled = false;
        private Color[,] colorsToFill;
        private List<Color> colorsOfVertices = new List<Color>();

        public ConvexPolygon(List<Vertex> vertices, List<Edge> edges) : base(vertices, edges)
        {
            List<Vertex> convexHull = new List<Vertex>();
            vertices.Sort((v, u) => (v.center.Y, v.center.X).CompareTo((u.center.Y, u.center.X)));
            vertices = vertices.OrderBy(v => (vertices.First().center.X - v.center.X) / Tools.distance(vertices.First(), v)).ToList();
            convexHull.Add(vertices.First());
            convexHull.Add(vertices[1]);
            for (int i = 2; i < vertices.Count; i++)
            {
                while (convexHull.Count >= 2 && Tools.cross(vertices[i], convexHull[convexHull.Count - 2], convexHull[convexHull.Count - 1]) <= 0) convexHull.RemoveAt(convexHull.Count - 1);
                convexHull.Add(vertices[i]);
            }
            this.vertices = new List<Vertex>();
            this.edges = new List<Edge>();
            for (int i = 0; i < convexHull.Count; i++)
                this.vertices.Add(convexHull[i]);
            for (int i = 0; i < this.vertices.Count - 1; i++)
                this.edges.Add(new Edge(this.vertices[i], this.vertices[i + 1]));
            this.edges.Add(new Edge(this.vertices.Last(), this.vertices.First()));
            isFilled = true;

            return;
        }

        public override void Draw()
        {
            Fill();
        }

        public override void Fill()
        {
            int widthMin = int.MaxValue;
            int widthMax = 0;
            int heightMin = 0;
            int heightMax = int.MaxValue;
            foreach (Vertex v in vertices)
            {
                if (v.center.X > widthMax) widthMax = v.center.X;
                if (v.center.X < widthMin) widthMin = v.center.X;
                if (v.center.Y > heightMin) heightMin = v.center.Y;
                if (v.center.Y < heightMax) heightMax = v.center.Y;
            }
            if(wasFilled == false) colorsToFill = new Color[widthMax - widthMin, heightMin - heightMax];

            Random rand = new Random();

            foreach(Vertex v in vertices)
                colorsOfVertices.Add(Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255)));


            List<AET> AETs = new List<AET>();

            List<Vertex> sortedVertices = vertices.OrderBy(v => v.center.Y).ToList();

            int ymin = sortedVertices.Last().center.Y;
            int ymax = sortedVertices.First().center.Y;

            for (int y = ymin; y >= ymax; y--)
            {
                foreach (Vertex v in vertices.FindAll(u => u.center.Y == y))
                {
                    bool horizontalLine = false;
                    Vertex vertex = null;
                    int index = vertices.IndexOf(v);
                    if (index > 0) vertex = vertices[index - 1];
                    else if (index == 0) vertex = vertices[vertices.Count - 1];
                    if (vertex != null)
                    {
                        Edge edge = edges.Find(e => e.v1 == vertex && e.v2 == v);
                        double diff = 0;
                        if (vertex.center.Y - v.center.Y == 0) horizontalLine = true;
                        else diff = ((double)(vertex.center.X - v.center.X) / (double)(vertex.center.Y - v.center.Y));
                        if (horizontalLine == false && vertex.center.Y <= v.center.Y) AETs.Add(new AET(v.center.X, diff, edge));
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
                        if (horizontalLine == false && vertex.center.Y <= v.center.Y) AETs.Add(new AET(v.center.X, diff, edge));
                        else AETs.RemoveAll(e => e.e == edge);
                    }
                }
                AETs = AETs.OrderBy(a => a.x).ToList();
                if (wasFilled == false)
                {
                    for (int i = 0; i < AETs.Count; i += 2)
                    {
                        int index1 = vertices.IndexOf(AETs[i].e.v1);
                        int index2 = vertices.IndexOf(AETs[i].e.v2);
                        int index3 = vertices.IndexOf(AETs[i + 1].e.v1);
                        int index4 = vertices.IndexOf(AETs[i + 1].e.v2);
                        double t1 = Tools.distance(AETs[i].e.v1, new Vertex(new Point((int)AETs[i].x, y))) / Tools.distance(AETs[i].e.v1, AETs[i].e.v2);
                        double t2 = Tools.distance(AETs[i + 1].e.v1, new Vertex(new Point((int)AETs[i + 1].x, y))) / Tools.distance(AETs[i + 1].e.v1, AETs[i + 1].e.v2);

                        Color c1 = colorsOfVertices[index1];
                        Color c2 = colorsOfVertices[index2];
                        Color c3 = colorsOfVertices[index3];
                        Color c4 = colorsOfVertices[index4];

                        Color nc1 = Color.FromArgb(c1.R + (int)(t1 * (c2.R - c1.R)), c1.G + (int)(t1 * (c2.G - c1.G)), c1.B + (int)(t1 * (c2.B - c1.B)));
                        Color nc2 = Color.FromArgb(c3.R + (int)(t2 * (c4.R - c3.R)), c3.G + (int)(t2 * (c4.G - c3.G)), c3.B + (int)(t2 * (c4.B - c3.B)));


                        for (int x = (int)AETs[i].x + 1; x <= AETs[i + 1].x; x++)
                        {
                            if (x < 0 || x >= Form.dbm.Width || y < 0 || y >= Form.dbm.Height) continue;

                            double tt1 = Tools.distance(new Vertex(new Point(x, y)), new Vertex(new Point((int)AETs[i].x, y))) / Tools.distance(new Vertex(new Point((int)AETs[i + 1].x, y)), new Vertex(new Point((int)AETs[i].x, y)));
                            Color col = Color.FromArgb(nc1.R + (int)tt1 * (nc2.R - nc1.R), nc1.G + (int)tt1 * (nc2.G - nc1.G), nc1.B + (int)tt1 * (nc2.B - nc1.B));
                            colorsToFill[widthMax - x, heightMin - y] = col;
                            Form.dbm.SetPixel(x, y, col);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < AETs.Count; i += 2)
                        for (int x = (int)AETs[i].x + 1; x <= AETs[i + 1].x; x++)
                        {
                            if (x < 0 || x >= Form.dbm.Width || y < 0 || y >= Form.dbm.Height) continue;
                            Form.dbm.SetPixel(x, y, colorsToFill[widthMax - x, heightMin - y]);
                        }
                }
                for (int i = 0; i < AETs.Count; i++)
                {
                    AETs[i].x -= AETs[i].diff;
                }
            }
            wasFilled = true;
        }
    }
}
