using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

/// <summary>
/// Drawer class implements any usefull method in drawing figure on bitmap
/// </summary>

namespace Polygon_and_circle_editor
{
    public static class Drawer
    {
        public static void drawAll(ref List<Polygon> polygons, ref List<Circle> circles, Bitmap bitmap)
        {
            Form.pixelsOfEdges = new Edge[bitmap.Width, bitmap.Height];
            Form.pixelsOfVertices = new Vertex[bitmap.Width, bitmap.Height];
            
            foreach (Polygon p in polygons)
            {
                if (p.canDraw(bitmap) == false) continue;
                else p.Draw(bitmap);
            }

            foreach (Circle c in circles)
            {
                if (c.canDraw(bitmap) == false) continue;
                else c.Draw(bitmap);
            }
        }

        public static bool canDrawVertex(Vertex v, Bitmap bitmap)
        {
            for (int i = -3; i <= 3; i++)
                for (int j = -3; j <= 3; j++)
                {
                    if (Math.Abs(i) + Math.Abs(j) >= 5) continue;
                    if (v.center.X + i >= bitmap.Width || v.center.X + i < 0 || v.center.Y + j >= bitmap.Height || v.center.Y + j < 0) return false;
                }
            return true;
        }

        public static void drawVertex(Vertex v, Color color, Bitmap bitmap)
        {
            Point a = v.center;
            for (int i = -3; i <= 3; i++)
                for (int j = -3; j <= 3; j++)
                {
                    if (Math.Abs(i) + Math.Abs(j) >= 5) continue;
                    bitmap.SetPixel(a.X + i, a.Y + j, color);
                    Form.pixelsOfVertices[a.X + i, a.Y + j] = v;
                }
            return;
        }

        public static bool canDrawEdge(Edge e, Bitmap bitmap)
        {
            return canDrawVertex(e.v2, bitmap);
        }

        public static void drawEdge(Edge e, Color color, Bitmap bitmap)
        {
            Point a = e.v1.center;
            Point b = e.v2.center;

            int xi, yi, dx, dy;

            if(a.X < b.X)
            {
                xi = 1;
                dx = b.X - a.X;
            }
            else
            {
                xi = -1;
                dx = a.X - b.X;
            }
            if(a.Y < b.Y)
            {
                yi = 1;
                dy = b.Y - a.Y;
            }
            else
            {
                yi = -1;
                dy = a.Y - b.Y;
            }

            bitmap.SetPixel(a.X, a.Y, color);
            Form.pixelsOfEdges[a.X, a.Y] = e;

            if(dx > dy)
            {
                int ai = (dy - dx) * 2;
                int bi = dy * 2;
                int d = bi - dx;
                while(a.X != b.X)
                {
                    if(d >= 0)
                    {
                        a.X += xi;
                        a.Y += yi;
                        d += ai;
                    }
                    else
                    {
                        d += bi;
                        a.X += xi;
                    }
                    bitmap.SetPixel(a.X, a.Y, color);
                    Form.pixelsOfEdges[a.X, a.Y] = e;
                }

            }
            else
            {
                int ai = (dx - dy) * 2;
                int bi = dx * 2;
                int d = bi - dy;
                while (a.Y != b.Y)
                {
                    if (d >= 0)
                    {
                        a.X += xi;
                        a.Y += yi;
                        d += ai;
                    }
                    else
                    {
                        d += bi;
                        a.Y += yi;
                    }
                    bitmap.SetPixel(a.X, a.Y, color);
                    Form.pixelsOfEdges[a.X, a.Y] = e;
                }
            }
            return;
        }

        public static int distance(Point a, Point b)
        {
            return (int)(Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2)));
        }
    }
}
