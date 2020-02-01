using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    [Serializable]
    public class Cone : Model
    {
        public int meshDiv;
        public double radius;
        public double height;

        public Cone(int meshDiv, double radius, double height)
        {
            this.meshDiv = meshDiv;
            this.radius = radius;
            this.height = height;
            this.name = "Cone";
            position = new Vector(0, 0, 0);
            rotation = new Vector(0, 0, 0);
            scale = new Vector(1, 1, 1);
            generateMesh();
            this.mesh.makeMesh();
        }

        public void generateMesh()
        {
            Mesh mesh = new Mesh();

            Vertex up = new Vertex(0, -1, 0);
            Vertex down = new Vertex(0, -1 - height, 0);
            for(double i = 0; i < 2 * Math.PI; i += Math.PI / meshDiv)
            {
                Triangle t0 = new Triangle();
                Triangle t1 = new Triangle();

                double x1 = radius * Math.Sin(i);
                double y1 = radius * Math.Cos(i);
                double x2 = radius * Math.Sin(i + Math.PI / meshDiv);
                double y2 = radius * Math.Cos(i + Math.PI / meshDiv);

                t0.vertices.Add(down);
                t0.vertices.Add(new Vertex(x2, -1, y2));
                t0.vertices.Add(new Vertex(x1, -1, y1));
                foreach (Vertex v in t0.vertices)
                    v.makeNormal(this.position);

                t1.vertices.Add(up);
                t1.vertices.Add(new Vertex(x1, -1, y1));
                t1.vertices.Add(new Vertex(x2, -1, y2));
                foreach (Vertex v in t1.vertices)
                    v.makeNormal(this.position);

                mesh.triangles.Add(t0);
                mesh.triangles.Add(t1);
            }
            this.mesh = mesh;
        }
    }
}
