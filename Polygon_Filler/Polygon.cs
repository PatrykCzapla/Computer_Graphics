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

        public bool isCorrect = false;

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
                e.Draw();
            foreach (Vertex v in vertices)
                v.Draw();
            return;
        }

        public virtual void Move(int dx, int dy)
        {
            for (int i = 0; i < vertices.Count; i++)
                vertices[i].Move(dx, dy);
            return;
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
