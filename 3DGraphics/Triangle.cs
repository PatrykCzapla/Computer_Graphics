using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    [Serializable]
    public class Triangle : Polygon
    {

        public Triangle()
        {
            this.vertices = new List<Vertex>();
            this.edges = new List<Edge>();
        }

        public Triangle(Vertex v0, Vertex v1, Vertex v2)
        {
            this.vertices = new List<Vertex> { v0, v1, v2 };

            List<Vertex> convexHull = new List<Vertex>();
            vertices.Sort((v, u) => (v.y, v.x).CompareTo((u.y, u.x)));
            convexHull = vertices.OrderBy(v => (vertices.First().x - v.x) / Tools.distance(vertices.First(), v)).ToList();
            this.vertices = new List<Vertex>();
            this.edges = new List<Edge>();
            for (int i = 0; i < convexHull.Count; i++)
                this.vertices.Insert(0, convexHull[i]);
            for (int i = 0; i < this.vertices.Count - 1; i++)
                this.edges.Add(new Edge(this.vertices[i], this.vertices[i + 1]));
            this.edges.Add(new Edge(this.vertices.Last(), this.vertices.First()));

            return;
        }

        public override void Fill(Color color)
        {
            List<Vertex> sorted = vertices.OrderBy(v => v.y).ToList();

            Vertex min = sorted[0];
            Vertex mid = sorted[1];
            Vertex max = sorted[2];

            double A = Tools.triangleArea(min, max, mid);

            double minY = min.y;
            double midY = mid.y;
            double maxY = max.y;

            double minX = min.x;
            double midX = mid.x;
            double maxX = max.x;

            double x1 = 0;
            double x2 = 0;

            double diff1 = 0;
            double diff2 = 0;

            if (maxY != midY)
            {
                bool change = false;
                diff1 = (minX - maxX) / (minY - maxY);
                diff2 = (midX - maxX) / (midY - maxY);

                x1 = maxX - diff1;
                x2 = maxX - diff2;
                if (x1 > x2)
                {
                    double tmp = x1;
                    x1 = x2;
                    x2 = tmp;

                    tmp = diff1;
                    diff1 = diff2;
                    diff2 = tmp;
                    change = true;
                }

                
                for (double y = maxY - 1; y >= midY; y--)
                {
                    for (double x = x1; x < x2; x++)
                    {
                        Vertex a = new Vertex(x, y, 0);
                        double a1 = Tools.triangleArea(a, mid, max);
                        double a2 = Tools.triangleArea(a, max, min);
                        double a3 = Tools.triangleArea(a, min, mid);
                        double z = (min.z * a1 + mid.z * a2 + max.z * a3) / A;
                        if (x < 0 || x >= Form.dbm.Width || y < 0 || y >= Form.dbm.Height) continue;
                        if (z > 1 || z < -1) continue;
                        if (z >= Form.dbm.zBuffer[(int)x, (int)y] && Form.zBuffer == true) continue;

                        Form.dbm.zBuffer[(int)x, (int)y] = z;
                        Form.dbm.SetPixel((int)x, (int)y, color);
                    }
                    x1 -= diff1;
                    x2 -= diff2;
                }

                if (midY == minY) return;

                if(change == true)
                {
                    diff1 = (minX - midX) / (minY - midY);
                    x2 -= diff2;
                    x1 = midX - diff1;
                }
                else
                {
                    diff2 = (minX - midX) / (minY - midY);
                    x1 -= diff1;
                    x2 = midX - diff2;
                }

                change = false;

                if (x1 > x2)
                {
                    double tmp = x1;
                    x1 = x2;
                    x2 = tmp;

                    tmp = diff1;
                    diff1 = diff2;
                    diff2 = tmp;
                    change = true;
                }                               

                for (double y = midY - 1; y > minY; y--)
                {
                    for (double x = x1; x < x2; x++)
                    {
                        Vertex a = new Vertex(x, y, 0);
                        double a1 = Tools.triangleArea(a, mid, max);
                        double a2 = Tools.triangleArea(a, max, min);
                        double a3 = Tools.triangleArea(a, min, mid);
                        double z = (min.z * a1 + mid.z * a2 + max.z * a3) / A;
                        if (x < 0 || x >= Form.dbm.Width || y < 0 || y >= Form.dbm.Height) continue;
                        if (z > 1 || z < -1) continue;
                        if (z >= Form.dbm.zBuffer[(int)x, (int)y] && Form.zBuffer == true) continue;

                        Form.dbm.zBuffer[(int)x, (int)y] = z;
                        Form.dbm.SetPixel((int)x, (int)y, color);
                    }
                    x1 -= diff1;
                    x2 -= diff2;
                }

            }
            else
            {
                diff1 = (minX - maxX) / (minY - maxY);
                diff2 = (minX - midX) / (minY - midY);
                x1 = maxX - diff1;
                x2 = midX - diff2;
                if (x1 > x2)
                {
                    double tmp = x1;
                    x1 = x2;
                    x2 = tmp;

                    tmp = diff1;
                    diff1 = diff2;
                    diff2 = tmp;
                }
                for (double y = maxY - 1; y >= minY; y--)
                {
                    for (double x = x1; x < x2; x++)
                    {
                        Vertex a = new Vertex(x, y, 0);
                        double a1 = Tools.triangleArea(a, mid, max);
                        double a2 = Tools.triangleArea(a, max, min);
                        double a3 = Tools.triangleArea(a, min, mid);
                        double z = (min.z * a1 + mid.z * a2 + max.z * a3) / A;

                        if (x < 0 || x >= Form.dbm.Width || y < 0 || y >= Form.dbm.Height) continue;
                        if (z > 1 || z < -1) continue;
                        if (z >= Form.dbm.zBuffer[(int)x, (int)y] && Form.zBuffer == true) continue;

                        Form.dbm.zBuffer[(int)x, (int)y] = z;
                        Form.dbm.SetPixel((int)x, (int)y, color);
                    }
                    x1 -= diff1;
                    x2 -= diff2;
                }
            }
        }
    }
}
