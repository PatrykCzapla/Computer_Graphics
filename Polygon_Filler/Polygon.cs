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

        public bool CanDraw(Bitmap bitmap)
        {
            if (vertices.Any(v => v.CanDraw(bitmap) == false)) return false;
            return true;
        }

        public void Draw(Bitmap bitmap)
        {
            if (CanDraw(bitmap) == false) return;
            foreach (Edge e in edges)
                e.Draw(bitmap);
            foreach (Vertex v in vertices)
                v.Draw(bitmap);
            return;
        }

        public void Move(int dx, int dy)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                vertices[i].center.X += dx;
                vertices[i].center.Y += dy;
            }
        }
    }
}
