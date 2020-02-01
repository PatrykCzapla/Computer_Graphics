using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    [Serializable]
    public class Cylinder : Model
    {
        public int meshDiv;
        public double radius;
        public double height;

        public Cylinder(int meshDiv, double radius, double height)
        {
            this.meshDiv = meshDiv;
            this.radius = radius;
            this.height = height;
            this.name = "Cylinder";
            position = new Vector(0, 0, 0);
            rotation = new Vector(0, 0, 0);
            scale = new Vector(1, 1, 1);
            generateMesh();
            this.mesh.makeMesh();
        }

        public void generateMesh()
        {
            double midHeight = height / 2;
            double negMidHeight = -midHeight;

            Mesh mesh = new Mesh();

            Vertex up = new Vertex(0, midHeight, 0);
            Vertex down = new Vertex(0, negMidHeight, 0);

            for (double i = 0; i < 2 * Math.PI; i += Math.PI / meshDiv)
            {
                Triangle t0 = new Triangle();
                Triangle t1 = new Triangle();
                Triangle t2 = new Triangle();
                Triangle t3 = new Triangle();

                double x1 = radius * Math.Sin(i);
                double z1 = radius * Math.Cos(i);
                double x2 = radius * Math.Sin(i + Math.PI / meshDiv);
                double z2 = radius * Math.Cos(i + Math.PI / meshDiv);

                t0.vertices.Add(down);
                t0.vertices.Add(new Vertex(x1, negMidHeight, z1));
                t0.vertices.Add(new Vertex(x2, negMidHeight, z2));

                t1.vertices.Add(new Vertex(x1, midHeight, z1));
                t1.vertices.Add(up);
                t1.vertices.Add(new Vertex(x2, midHeight, z2));

                t2.vertices.Add(new Vertex(x1, midHeight, z1));
                t2.vertices.Add(new Vertex(x2, midHeight, z2));
                t2.vertices.Add(new Vertex(x1, negMidHeight, z1));

                t3.vertices.Add(new Vertex(x1, negMidHeight, z1));
                t3.vertices.Add(new Vertex(x2, midHeight, z2));
                t3.vertices.Add(new Vertex(x2, negMidHeight, z2));

                foreach (Vertex v in t0.vertices)
                    v.makeNormal(this.position);
                foreach (Vertex v in t1.vertices)
                    v.makeNormal(this.position);
                foreach (Vertex v in t2.vertices)
                    v.makeNormal(this.position);
                foreach (Vertex v in t3.vertices)
                    v.makeNormal(this.position);

                mesh.triangles.Add(t0);
                mesh.triangles.Add(t1);
                mesh.triangles.Add(t2);
                mesh.triangles.Add(t3);
            }
            this.mesh = mesh;
        }
    }
}
