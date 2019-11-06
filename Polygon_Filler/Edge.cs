using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Polygon_Filler
{
    public class Edge
    {
        public Vertex v1;
        public Vertex v2;

        public Edge(Vertex v1, Vertex v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public bool canDraw(List<Edge> edges)
        {
            if (edges.Count == 0) return true;
            List<Edge> tmpEdges = new List<Edge>(edges);
            tmpEdges.Remove(tmpEdges.Last());
            if (tmpEdges.Any(e => this.LinesIntersect(this.v1.center, this.v2.center, e.v1.center, e.v2.center) == true))
                return false;
            else return true;
        }

        public void Draw(Bitmap bitmap)
        {
            Point a = this.v1.center;
            Point b = this.v2.center;

            int xi, yi, dx, dy;

            if (a.X < b.X)
            {
                xi = 1;
                dx = b.X - a.X;
            }
            else
            {
                xi = -1;
                dx = a.X - b.X;
            }
            if (a.Y < b.Y)
            {
                yi = 1;
                dy = b.Y - a.Y;
            }
            else
            {
                yi = -1;
                dy = a.Y - b.Y;
            }

            //bitmap.SetPixel(a.X, a.Y, Color.Black);
            //Form.pixelsOfEdges[a.X, a.Y] = this;

            if (dx > dy)
            {
                int ai = (dy - dx) * 2;
                int bi = dy * 2;
                int d = bi - dx;
                while (a.X != b.X)
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
                        a.X += xi;
                    }
                    if (a.X < 0 || a.X >= bitmap.Width || a.Y < 0 || a.Y >= bitmap.Height) continue;
                    bitmap.SetPixel(a.X, a.Y, Color.Black);
                    Form.pixelsOfEdges[a.X, a.Y] = this;
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
                    if (a.X < 0 || a.X >= bitmap.Width || a.Y < 0 || a.Y >= bitmap.Height) continue;
                    bitmap.SetPixel(a.X, a.Y, Color.Black);
                    Form.pixelsOfEdges[a.X, a.Y] = this;
                }
            }
            return;
        }

        private bool LinesIntersect(Point p1, Point p2, Point p3, Point p4)
        {

            int d1 = Orientation(p1, p2, p3);
            int d2 = Orientation(p1, p2, p4);
            int d3 = Orientation(p3, p4, p1);
            int d4 = Orientation(p3, p4, p2);

            if (d1 != d2 && d3 != d4)
                return true;

            if (d1 == 0 && OnSegment(p1, p3, p2)) return true;
            if (d2 == 0 && OnSegment(p1, p4, p2)) return true;
            if (d3 == 0 && OnSegment(p3, p1, p4)) return true;
            if (d4 == 0 && OnSegment(p3, p2, p4)) return true;

            return false;
        }

        private int Orientation(Point p1, Point p2, Point q)
        {
            int val = (p2.Y - p1.Y) * (q.X - p2.X) - (p2.X - p1.X) * (q.Y - p2.Y);

            if (val == 0) return 0;
            return (val > 0) ? 1 : 2;
        }

        private bool OnSegment(Point p, Point q, Point r)
        {
            if (q.X <= Math.Max(p.X, r.X) && q.X >= Math.Min(p.X, r.X) &&
                q.Y <= Math.Max(p.Y, r.Y) && q.Y >= Math.Min(p.Y, r.Y))
                return true;
            return false;
        }
    }
}
