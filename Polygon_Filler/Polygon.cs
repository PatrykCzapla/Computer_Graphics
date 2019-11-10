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
        class AET
        {
            public int ymax;
            public double x;
            public double diff;
            public Edge e;

            public AET(int ymax, double x, double diff, Edge e)
            {
                this.ymax = ymax;
                this.x = x;
                this.diff = diff;
                this.e = e;
            }
        }

        public Polygon(Polygon p)
        {
            this.color = p.color;
            this.isCorrect = p.isCorrect;
            for (int i = 0; i < p.vertices.Count; i++)
                this.vertices.Add(new Vertex(p.vertices[i]));
            for (int i = 0; i < vertices.Count - 1; i++)
                this.edges.Add(new Edge(vertices[i], vertices[i + 1]));
            if (this.isCorrect == true) this.edges.Add(new Edge(vertices.Last(), vertices.First()));
        }

        public List<Vertex> vertices = new List<Vertex>();
        public List<Edge> edges = new List<Edge>();

        public bool isFilled = false;
        public bool isCorrect = false;
        public Color color = Color.Black;
        public Color colorOfFilling = Color.Black;

        public Polygon(List<Vertex> vertices, List<Edge> edges)
        {
            for (int i = 0; i < vertices.Count; i++)
                this.vertices.Add(vertices[i]);
            for (int i = 0; i < edges.Count; i++)
                this.edges.Add(edges[i]);
            return;
        }

        public void Draw()
        {
            foreach (Edge e in edges)
                e.Draw(color);
            foreach (Vertex v in vertices)
                v.Draw(color);
            return;
        }

        public virtual void Move(int dx, int dy)
        {
            for (int i = 0; i < vertices.Count; i++)
                vertices[i].Move(dx, dy);
            return;
        }

        public virtual void Fill(Color color)
        {
            colorOfFilling = color;
            List<AET> AETs = new List<AET>();
            isFilled = true;

            List<Vertex> sortedVertices = vertices.OrderBy(v => v.center.Y).ToList();

            int ymin = sortedVertices.Last().center.Y;
            int ymax = sortedVertices.First().center.Y;

            for(int y = ymin; y >= ymax; y--)
            {
                foreach (Vertex v in vertices.FindAll(u => u.center.Y == y ))
                {

                    Vertex vertex = null;
                    int index = vertices.IndexOf(v);
                    if (index > 0) vertex = vertices[index - 1];
                    else if (index == 0) vertex = vertices[vertices.Count - 1];
                    if(vertex != null)
                    {
                        Edge edge = edges.Find(e => e.v1 == vertex && e.v2 == v);
                        double diff = 0;
                        if (vertex.center.Y - v.center.Y == 0) diff = (double)vertex.center.X - (double)v.center.X;
                        else diff = ((double)(vertex.center.X - v.center.X) / (double)(vertex.center.Y - v.center.Y));
                        if (vertex.center.Y <= v.center.Y) AETs.Add(new AET(vertex.center.Y, v.center.X, diff, edge));
                        else AETs.RemoveAll(e => e.e == edge);

                    }
                    vertex = null;
                    if (index < vertices.Count - 1) vertex = vertices[index + 1];
                    else if (index == vertices.Count - 1) vertex = vertices[0];
                    if (vertex != null)
                    {
                        Edge edge = edges.Find(e => e.v1 == v && e.v2 == vertex);
                        double diff = 0;
                        if (vertex.center.Y - v.center.Y == 0) diff = (double)vertex.center.X - (double)v.center.X;
                        else diff = ((double)(vertex.center.X - v.center.X) / (double)(vertex.center.Y - v.center.Y));
                        if (vertex.center.Y <= v.center.Y) AETs.Add(new AET(vertex.center.Y, v.center.X, diff, edge));
                        else AETs.RemoveAll(e => e.e == edge);
                    }
                }
                AETs = AETs.OrderBy(a => a.x).ToList();

                for (int i = 0; i < AETs.Count; i += 2)
                {
                    for (int x = (int)AETs[i].x + 1; x <= AETs[i + 1].x; x++)
                    {
                        if (x < 0 || x >= Form.dbm.Width || y < 0 || y >= Form.dbm.Height) continue;
                        Form.dbm.SetPixel(x, y, colorOfFilling);
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
            for (int i = 0; i < vertices.Count; i++)
                this.vertices.Add(vertices[i]);
            List<Vertex> convexHull = new List<Vertex>();
            vertices.Sort((v, u) => (v.center.Y, v.center.X).CompareTo((u.center.Y, u.center.X)));
            vertices = vertices.OrderBy(v => (vertices.First().center.X - v.center.X) / Distance(vertices.First(), v)).ToList();
            convexHull.Add(vertices.First());
            convexHull.Add(vertices[1]);
            for (int i = 2; i < vertices.Count; i++)
            {
                while (convexHull.Count >= 2 && Cross(vertices[i], convexHull[convexHull.Count - 2], convexHull[convexHull.Count - 1]) <= 0) convexHull.RemoveAt(convexHull.Count - 1);
                convexHull.Add(vertices[i]);
            }
            this.vertices = convexHull;
            for (int i = 0; i < this.vertices.Count - 1; i++)
                this.edges.Add(new Edge(this.vertices[i], this.vertices[i + 1]));
            this.edges.Add(new Edge(this.vertices.Last(), this.vertices.First()));
            return;
        }

        public override void Move(int dx, int dy)
        {
            return;
        }

        private int Cross(Vertex o, Vertex v, Vertex u)
        {
            double value = (v.center.X - o.center.X) * (u.center.Y - o.center.Y) - (v.center.Y - o.center.Y) * (u.center.X - o.center.X);
            return Math.Abs(value) < 1e-10 ? 0 : value < 0 ? -1 : 1;
        }

        public static double Distance(Vertex v1, Vertex v2)
        {
            return Math.Sqrt(Math.Pow(v2.center.X - v1.center.X, 2) + Math.Pow(v2.center.Y - v1.center.Y, 2));
        }
    }
}
