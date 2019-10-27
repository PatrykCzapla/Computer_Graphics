using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

/// <summary>
/// Editor class includes methods to search for figure to be edited
/// </summary>

namespace Polygon_and_circle_editor
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

        public static Edge searchForPolygonEdge(Point p, ref Point exactPoint)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (p.X + i >= Form.pixelsOfEdges.GetLength(0) || p.X + i < 0 || p.Y + j >= Form.pixelsOfEdges.GetLength(1) || p.Y + j < 0) continue;
                    if (Form.pixelsOfEdges[p.X + i, p.Y + j] != null)
                    {
                        exactPoint.X = p.X + i;
                        exactPoint.Y = p.Y + j;
                        return Form.pixelsOfEdges[p.X + i, p.Y + j];
                    }
                }
            return null;
        }

        public static Circle searchForCircleEdge(Point p)
        {
            foreach (Circle c in Form.circles)
            {
                if (c.canDraw(new Bitmap(Form.pixelsOfEdges.GetLength(0), Form.pixelsOfEdges.GetLength(1))) == false) continue;
                if (Drawer.distance(c.center, p) <= c.radius + 1 && Drawer.distance(c.center, p) >= c.radius - 1) return c;
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
            for(int i = 0; i < edges.Count; i++)
            {
                Polygon polygon = Form.polygons.Find(a => a.edges.Contains(edges.First()));
                int count = edges.FindAll(a => polygon.edges.Contains(a)).Count;
                List<Vertex> v = polygon.vertices.FindAll(a => a.center.X >= p.X && a.center.Y == p.Y);
                foreach(Vertex vertex in v)
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

        public static Circle searchForCircle(Point p)
        {
            foreach (Circle c in Form.circles)
            {
                if (c.canDraw(new Bitmap(Form.pixelsOfEdges.GetLength(0), Form.pixelsOfEdges.GetLength(1))) == false) continue;
                if (Drawer.distance(c.center, p) < c.radius) return c;
            }
            return null;
        }
    }
}
