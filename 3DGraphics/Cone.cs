using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Cone
    {
        public Mesh createCone(int meshDiv, double radius, double height)
        {
            Mesh mesh = new Mesh();
            mesh.triangles = new List<Triangle>();

            Vertex up = new Vertex(0, -1, 0);
            Vertex down = new Vertex(0, -1 - height, 0);
            for(double i = 0; i < 2 * Math.PI; i += Math.PI / meshDiv)
            {
                Triangle t0 = new Triangle();
                Triangle t1 = new Triangle();

                double x1 = radius * Math.Sin(i);
                double y1 = Math.Cos(i);
                double x2 = radius * Math.Sin(i + Math.PI / meshDiv);
                double y2 = Math.Cos(i + Math.PI / meshDiv);

                t0.vertices.Add(down);
                t0.vertices.Add(new Vertex(x2, -1, y2));
                t0.vertices.Add(new Vertex(x1, -1, y1));

                t1.vertices.Add(up);
                t1.vertices.Add(new Vertex(x1, -1, y1));
                t1.vertices.Add(new Vertex(x2, -1, y2));

                mesh.triangles.Add(t0);
                mesh.triangles.Add(t1);
            }
            mesh.makeMesh();
            return mesh;
        }
    }
}
