using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public static class Tools
    {

        public static int orientation(Point p1, Point p2, Point q)
        {
            int val = (p2.Y - p1.Y) * (q.X - p2.X) - (p2.X - p1.X) * (q.Y - p2.Y);

            if (val == 0) return 0;
            return (val > 0) ? 1 : 2;
        }

        public static double distance(Vertex v1, Vertex v2)
        {
            return Math.Sqrt(Math.Pow(v2.x - v1.x, 2) + Math.Pow(v2.y - v1.y, 2));
        }

        public static int cross(Vertex a, Vertex b, Vertex c)
        {
            double value = (b.x - a.x) * (c.y - a.y) - (b.y - a.y) * (c.x - a.x);
            return Math.Abs(value) < 1e-1 ? 0 : value < 0 ? -1 : 1;
        }

        public static double triangleArea(Vertex v1, Vertex v2, Vertex v3)
        {
            double a = distance(v1, v2);
            double b = distance(v1, v3);
            double c = distance(v2, v3);
            double p = 0.5 * (a + b + c);
            return 0.5 * Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }
}