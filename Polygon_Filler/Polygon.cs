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
        }

        public void Draw(Bitmap bitmap)
        {
            foreach (Edge e in edges)
                e.Draw(bitmap);
            foreach (Vertex v in vertices)
                v.Draw(bitmap);
            return;
        }

        public void Move(int dx, int dy)
        {
            for (int i = 0; i < vertices.Count; i++)
                vertices[i].Move(dx, dy);
        }
    }

    public class ConvexPolygon
    {
        public List<Vertex> vertices = new List<Vertex>();
        public List<Edge> edges = new List<Edge>();


        public ConvexPolygon(List<Vertex> vertices)
        {
            for (int i = 0; i < vertices.Count; i++)
                this.vertices.Add(vertices[i]);
            List<Vertex> convex = new List<Vertex>();
            vertices.Sort((v, u) => (v.center.Y, v.center.X).CompareTo((u.center.Y, u.center.X)));
            vertices = vertices.OrderBy(v => (vertices.First().center.X - v.center.X) / Distance(vertices.First(), v)).ToList();
            convex.Add(vertices.First());
            convex.Add(vertices[1]);
            for (int i = 2; i < vertices.Count; i++)
            {
                while (convex.Count >= 2 && Cross(vertices[i], convex[convex.Count - 2], convex[convex.Count - 1]) <= 0) convex.RemoveAt(convex.Count - 1);
                convex.Add(vertices[i]);
            }
            this.vertices = convex;
            for (int i = 0; i < this.vertices.Count - 1; i++)
                edges.Add(new Edge(this.vertices[i], this.vertices[i + 1]));
            edges.Add(new Edge(this.vertices.Last(), this.vertices.First()));
        }

        public void Draw(Bitmap bitmap)
        {
            foreach (Edge e in edges)
                e.Draw(bitmap);
            foreach (Vertex v in vertices)
                v.Draw(bitmap);
            return;
        }

        private int Cross(Vertex o, Vertex a, Vertex b)
        {
            double value = (a.center.X - o.center.X) * (b.center.Y - o.center.Y) - (a.center.Y - o.center.Y) * (b.center.X - o.center.X);
            return Math.Abs(value) < 1e-10 ? 0 : value < 0 ? -1 : 1;
        }

        public static double Distance(Vertex v1, Vertex v2)
        {
            return Math.Sqrt(Math.Pow(v2.center.X - v1.center.X, 2) + Math.Pow(v2.center.Y - v1.center.Y, 2));
        }
    }
}
