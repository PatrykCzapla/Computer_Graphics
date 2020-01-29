using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab4
{
    [Serializable]
    public class Edge
    {
        public Vertex v1;
        public Vertex v2;

        public Edge(Vertex v1, Vertex v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public void Draw(Color color)
        {
            Point a = new Point((int)v1.x, (int)v1.y);
            Point b = new Point((int)v2.x, (int)v2.y);

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
            if (a.X >= 0 && a.X < Form.dbm.Width && a.Y >= 0 && a.Y < Form.dbm.Height) 
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
