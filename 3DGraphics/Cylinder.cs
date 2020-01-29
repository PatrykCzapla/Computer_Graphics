using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Cylinder
    {
        public Mesh createCylinder(int meshDiv, double radius, double height)
        {
            double midHeight = height / 2;
            double negMidHeight = -midHeight;

            Mesh mesh = new Mesh();
            mesh.triangles = new List<Triangle>();

            Vertex up = new Vertex(0, midHeight, 0);
            Vertex down = new Vertex(0, negMidHeight, 0);

            for (double i = 0; i < 2 * Math.PI; i += Math.PI / (double)meshDiv)
            {
                Triangle t0 = new Triangle();
                Triangle t1 = new Triangle();
                Triangle t2 = new Triangle();
                Triangle t3 = new Triangle();

                double x1 = radius * (float)Math.Sin(i);
                double y1 = (float)Math.Cos(i);
                double x2 = radius * (float)Math.Sin(i + Math.PI / (double)meshDiv);
                double y2 = (float)Math.Cos(i + Math.PI / (double)meshDiv);

                t0.vertices.Add(down);
                t0.vertices.Add(new Vertex(x1, negMidHeight, y1));
                t0.vertices.Add(new Vertex(x2, negMidHeight, y2));

                t1.vertices.Add(new Vertex(x1, midHeight, y1));
                t1.vertices.Add(up);
                t1.vertices.Add(new Vertex(x2, midHeight, y2));

                t2.vertices.Add(new Vertex(x1, midHeight, y1));
                t2.vertices.Add(new Vertex(x2, midHeight, y2));
                t2.vertices.Add(new Vertex(x1, negMidHeight, y1));

                t3.vertices.Add(new Vertex(x1, negMidHeight, y1));
                t3.vertices.Add(new Vertex(x2, midHeight, y2));
                t3.vertices.Add(new Vertex(x2, negMidHeight, y2));

                mesh.triangles.Add(t0);
                mesh.triangles.Add(t1);
                mesh.triangles.Add(t2);
                mesh.triangles.Add(t3);
            }
            mesh.makeMesh();
            return mesh;
        }
    }
}
