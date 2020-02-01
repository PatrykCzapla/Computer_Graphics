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
            List<Vertex> sorted = new List<Vertex>();
            vertices.Sort((v, u) => (v.y, v.x).CompareTo((u.y, u.x)));
            sorted = vertices.OrderBy(v => (vertices.First().x - v.x) / Tools.distance(vertices.First(), v)).ToList();
            this.vertices = new List<Vertex>();
            this.edges = new List<Edge>();
            for (int i = 0; i < sorted.Count; i++)
                this.vertices.Insert(0, sorted[i]);
        }

        public override void Draw(Color color)
        {
            if(Form.fill == true) Fill(color);
            if (Form.edges == false) return;
            edges.Clear();
            edges.Add(new Edge(vertices[0].screenPosition, vertices[1].screenPosition));
            edges.Add(new Edge(vertices[1].screenPosition, vertices[2].screenPosition));
            edges.Add(new Edge(vertices[2].screenPosition, vertices[0].screenPosition));
            foreach (Edge e in edges)
                e.Draw(Color.Black);
        }

        private Color getPixelColor(List<Vertex> sorted, Color textureColor, double A, double a1, double a2, double a3)
        {
            Color actualColor = textureColor;
            double b1 = a1 / A;
            double b2 = a2 / A;
            double b3 = a3 / A;

            double b1W = b1 / sorted[0].transformationPosition.values[3];
            double b2W = b2 / sorted[1].transformationPosition.values[3];
            double b3W = b3 / sorted[2].transformationPosition.values[3];

            if (b1W == 0 || double.IsNaN(b1W)) b1W = 0.001;
            if (b2W == 0 || double.IsNaN(b2W)) b2W = 0.001;
            if (b3W == 0 || double.IsNaN(b3W)) b3W = 0.001;

            double xAtr = ((sorted[0].transformationNormal.values[0] * b1W) + (sorted[1].transformationNormal.values[0] * b2W) + (sorted[2].transformationNormal.values[0] * b3W)) / (b1W + b2W + b3W);
            double yAtr = ((sorted[0].transformationNormal.values[1] * b1W) + (sorted[1].transformationNormal.values[1] * b2W) + (sorted[2].transformationNormal.values[1] * b3W)) / (b1W + b2W + b3W);
            double zAtr = ((sorted[0].transformationNormal.values[2] * b1W) + (sorted[1].transformationNormal.values[2] * b2W) + (sorted[2].transformationNormal.values[2] * b3W)) / (b1W + b2W + b3W);

            Vector normal = new Vector(xAtr, yAtr, zAtr);

            normal = normal.normalize();

            double Vx = ((sorted[0].inCameraPosition.values[0] * b1W) + (sorted[1].inCameraPosition.values[0] * b2W) + (sorted[2].inCameraPosition.values[0] * b3W)) / (b1W + b2W + b3W);
            double Vy = ((sorted[0].inCameraPosition.values[1] * b1W) + (sorted[1].inCameraPosition.values[1] * b2W) + (sorted[2].inCameraPosition.values[1] * b3W)) / (b1W + b2W + b3W);
            double Vz = ((sorted[0].inCameraPosition.values[2] * b1W) + (sorted[1].inCameraPosition.values[2] * b2W) + (sorted[2].inCameraPosition.values[2] * b3W)) / (b1W + b2W + b3W);

            Vector V = new Vector(Vx, Vy, Vz);
            V = V.normalize();

            double red = 0;
            double green = 0;
            double blue = 0;

            foreach (Light l in Form.lights)
            {
                red = Form.lights.First().ka * (double)l.color.R / 255 * textureColor.R / 255;
                green = Form.lights.First().ka * (double)l.color.G / 255 * textureColor.G / 255;
                blue = Form.lights.First().ka * (double)l.color.B / 255 * textureColor.B / 255;

                double dist = l.transformationPosition.distance3D(new Vector(Vx, Vy, Vz));

                double Lx = ((sorted[0].x * b1W) + (sorted[1].x * b2W) + (sorted[2].x * b3W)) / (b1W + b2W + b3W);
                double Ly = ((sorted[0].y * b1W) + (sorted[1].y * b2W) + (sorted[2].y * b3W)) / (b1W + b2W + b3W);
                double Lz = ((sorted[0].z * b1W) + (sorted[1].z * b2W) + (sorted[2].z * b3W)) / (b1W + b2W + b3W);

                Vector L = new Vector(l.position.values[0] - Lx, l.position.values[2] - Ly, l.position.values[2] - Lz);
                L = L.normalize();

                double If = 1 / (l.Ac + l.Al * dist + l.Aq * dist * dist);

                Vector R = new Vector(0, 0, 0);
                for (int i = 0; i < 3; i++)
                {
                    R.values[i] += 2 * L.dotProduct(normal) * normal.values[i] - L.values[i];
                }

                R = R.normalize();

                Vector s = new Vector(l.transformationPosition.values[0] - Vx, l.transformationPosition.values[1] - Vy, l.transformationPosition.values[2] - Vz).normalize();
                double Id = s.dotProduct(normal);
                if (Id < 0) Id = 0;
                if (Id > 1) Id = 1;

                red += l.kd * Id * normal.dotProduct(L);
                red += l.ks * l.intensity * Math.Pow(R.dotProduct(V), l.shine);
                green += l.kd * Id * normal.dotProduct(L);
                green += l.ks * l.intensity * Math.Pow(R.dotProduct(V), l.shine);
                blue += l.kd * Id * normal.dotProduct(L);
                blue += l.ks * l.intensity * Math.Pow(R.dotProduct(V), l.shine);

                if (dist > l.attentuation)
                {
                    red *= If;
                    green *= If;
                    blue *= If;
                }
            }
            red *= 255;
            green *= 255;
            blue *= 255;
            if (red < 0) red = 0;
            if (red > 255) red = 255;
            if (green < 0) green = 0;
            if (green > 255) green = 255;
            if (blue < 0) blue = 0;
            if (blue > 255) blue = 255;
            return Color.FromArgb((int)red, (int)green, (int)blue);
        }

        public override void Fill(Color textureColor)
        {
            List<Vertex> sorted = vertices.OrderBy(v => v.screenPosition.values[1]).ToList();

            Color acutalColor = textureColor;
            Color originalColor = textureColor;

            Vertex min = new Vertex(sorted[0].screenPosition.values[0], sorted[0].screenPosition.values[1], sorted[0].screenPosition.values[2]);
            Vertex mid = new Vertex(sorted[1].screenPosition.values[0], sorted[1].screenPosition.values[1], sorted[1].screenPosition.values[2]);
            Vertex max = new Vertex(sorted[2].screenPosition.values[0], sorted[2].screenPosition.values[1], sorted[2].screenPosition.values[2]);

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
                        if (Form.lights.Count > 0) acutalColor = getPixelColor(sorted, textureColor, A, a1, a2, a3);
                        Form.dbm.SetPixel((int)x, (int)y, acutalColor);
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

                for (double y = midY - 1; y >= minY; y--)
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
                        if (Form.lights.Count > 0) acutalColor = getPixelColor(sorted, textureColor, A, a1, a2, a3);
                        Form.dbm.SetPixel((int)x, (int)y, acutalColor);
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
                 
                        if (Form.lights.Count > 0) acutalColor = getPixelColor(sorted, textureColor, A, a1, a2, a3);
                        Form.dbm.SetPixel((int)x, (int)y, acutalColor);
                    }
                    x1 -= diff1;
                    x2 -= diff2;
                }
            }
        }
    }
}
