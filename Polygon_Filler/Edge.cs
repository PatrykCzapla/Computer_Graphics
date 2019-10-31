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

            bitmap.SetPixel(a.X, a.Y, Color.Black);
            Form.pixelsOfEdges[a.X, a.Y] = this;

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
                    bitmap.SetPixel(a.X, a.Y, Color.Black);
                    Form.pixelsOfEdges[a.X, a.Y] = this;
                }
            }
            return;
        }
    }
}
