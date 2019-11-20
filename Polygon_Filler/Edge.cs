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
            return;
        }

        public bool canDraw(List<Edge> edges)
        {
            if (edges.Count == 0) return true;
            if (edges.Any(e => Tools.linesIntersect(this.v1.center, this.v2.center, e.v1.center, e.v2.center) == true))
                return false;
            else return true;
        }

        public void Draw(Color color)
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
            Form.dbm.SetPixel(a.X, a.Y, color);
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
                    if (a.X < 0 || a.X >= Form.dbm.Width || a.Y < 0 || a.Y >= Form.dbm.Height) continue;
                    Form.dbm.SetPixel(a.X, a.Y, color);
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
                    if (a.X < 0 || a.X >= Form.dbm.Width || a.Y < 0 || a.Y >= Form.dbm.Height) continue;
                    Form.dbm.SetPixel(a.X, a.Y, color);
                }
            }
            return;
        }        
    }
}
