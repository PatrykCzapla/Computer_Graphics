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
            for (int i = -2; i < 3; i++)
                for (int j = -2; j < 3; j++)
                {
                    if (p.X + i >= Form.pixelsOfVertices.GetLength(0) || p.X + i < 0 || p.Y + j >= Form.pixelsOfVertices.GetLength(1) || p.Y + j < 0) continue;
                    if (Form.pixelsOfVertices[p.X + i, p.Y + j] != null) return Form.pixelsOfVertices[p.X + i, p.Y + j];
                }
            return null;
        }

        public static Polygon searchForPolygon(Point p)
        {
            List<Polygon> polygons = new List<Polygon>();
            for (int i = p.X; i < Form.pixelsOfEdges.GetLength(0); i++)
            {
                Edge e = Form.pixelsOfEdges[i, p.Y];
                if (e != null)
                {
                    Polygon polygon = Form.polygons.Find(pol => pol.edges.Contains(e));
                    if (polygons.Contains(polygon) == false) polygons.Add(polygon);
                }
            }
            foreach (Polygon polygon in Form.polygons)
                if (isInside(p, polygon) == true) return polygon;
            return null;
        }

        public static bool isInside(Point p, Polygon polygon)
        {
            int count = 0;
            for (int i = p.X; i < Form.pixelsOfEdges.GetLength(0); i++)
                if (Form.pixelsOfEdges[i, p.Y] != null)
                {
                    if (Form.pixelsOfVertices[i, p.Y] != null) continue;
                    if (polygon.edges.Contains((Form.pixelsOfEdges[i, p.Y])))
                    {
                        if (i != p.X && Form.pixelsOfEdges[i - 1, p.Y] == Form.pixelsOfEdges[i, p.Y]) continue;                            
                        count++;
                    }
                }

            List<Vertex> v = polygon.vertices.FindAll(a => a.center.X >= p.X && a.center.Y == p.Y);
            foreach (Vertex vertex in v)
            {
                Edge e1 = polygon.edges.Find(a => a.v1 == vertex);
                Edge e2 = polygon.edges.Find(a => a.v2 == vertex);
                if (e1.v2.center.Y > p.Y && e2.v1.center.Y > p.Y || e1.v2.center.Y < p.Y && e2.v1.center.Y < p.Y) count +=2;
                else if (e1.v2.center.Y > p.Y && e2.v1.center.Y < p.Y || e1.v2.center.Y < p.Y && e2.v1.center.Y > p.Y) count++;
            }
            if (count % 2 == 1) return true;
            else return false;
        }
    }
}
