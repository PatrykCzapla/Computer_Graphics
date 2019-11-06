using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygon_Filler
{
    public static class Editor
    {
        public static Vertex searchForVertex(Point p)
        {
            for (int i = -3; i <= 3; i++)
                for (int j = -3; j <= 3; j++)
                {
                    if (Math.Abs(i) + Math.Abs(j) >= 5) continue;
                    if (p.X + i >= Form.pixelsOfVertices.GetLength(0) || p.X + i < 0 || p.Y + j >= Form.pixelsOfVertices.GetLength(1) || p.Y + j < 0) continue;
                    if (Form.pixelsOfVertices[p.X + i, p.Y + j] != null)
                        return Form.pixelsOfVertices[p.X + i, p.Y + j];
                }
            return null;
        }

        public static Polygon searchForPolygon(Point p)
        {
            List<Edge> edges = new List<Edge>();
            for (int i = p.X; i < Form.pixelsOfEdges.GetLength(0); i++)
            {
                if (Form.pixelsOfEdges[i, p.Y] != null)
                {
                    if (!edges.Contains(Form.pixelsOfEdges[i, p.Y]))
                    {
                        edges.Add(Form.pixelsOfEdges[i, p.Y]);
                    }
                }
            }
            for (int i = 0; i < edges.Count; i++)
            {
                Polygon polygon = Form.polygons.Find(a => a.edges.Contains(edges.First()));
                int count = edges.FindAll(a => polygon.edges.Contains(a)).Count;
                List<Vertex> v = polygon.vertices.FindAll(a => a.center.X >= p.X && a.center.Y == p.Y);
                foreach (Vertex vertex in v)
                {
                    Edge e1 = polygon.edges.Find(a => a.v1 == vertex);
                    Edge e2 = polygon.edges.Find(a => a.v2 == vertex);
                    if (e1.v2.center.Y >= p.Y && e2.v1.center.Y >= p.Y || e1.v2.center.Y <= p.Y && e2.v1.center.Y <= p.Y) count += 2;
                    else if (e1.v2.center.Y > p.Y && e2.v1.center.Y < p.Y || e1.v2.center.Y < p.Y && e2.v1.center.Y > p.Y) count++;
                }
                if (count % 2 == 1) return polygon;
                edges.RemoveAll(a => polygon.edges.Contains(a));
            }
            return null;
        }
    }
}
