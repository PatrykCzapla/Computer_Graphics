using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    [Serializable]
    public class Cuboid : Model
    {
        public double a;
        public double b;
        public double c;

        public Cuboid(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            generateMesh();
            this.mesh.makeMesh();
            this.name = "Cuboid";
            position = new Vector(0, 0, 0);
            rotation = new Vector(0, 0, 0);
            scale = new Vector(1, 1, 1);
        }

        public void generateMesh()
        {
            double aMid = a / 2;
            double bMid = b / 2;
            double cMid = c / 2;

            Mesh mesh = new Mesh();

            Triangle triangle = new Triangle();
            Vector normal = new Vector(0, 0, -1);
            Vertex v0 = new Vertex(aMid, bMid, -cMid, normal);
            Vertex v1 = new Vertex(aMid, -bMid, -cMid, normal);
            Vertex v2 = new Vertex(-aMid, -bMid, -cMid, normal);

            triangle.vertices.Add(v0);
            triangle.vertices.Add(v1);
            triangle.vertices.Add(v2);
            mesh.triangles.Add(triangle);

            triangle = new Triangle();
            v0 = new Vertex(aMid, bMid, -cMid, normal);
            v1 = new Vertex(-aMid, -bMid, -cMid, normal);
            v2 = new Vertex(-aMid, bMid, -cMid, normal);

            triangle.vertices.Add(v0);
            triangle.vertices.Add(v1);
            triangle.vertices.Add(v2);
            mesh.triangles.Add(triangle);

            triangle = new Triangle();
            normal = new Vector(-1, 0, 0);
            v0 = new Vertex(-aMid, -bMid, cMid, normal);
            v1 = new Vertex(-aMid, bMid, cMid, normal);
            v2 = new Vertex(-aMid, bMid, -cMid, normal);

            triangle.vertices.Add(v0);
            triangle.vertices.Add(v1);
            triangle.vertices.Add(v2);
            mesh.triangles.Add(triangle);

            triangle = new Triangle();
            v0 = new Vertex(-aMid, -bMid, cMid, normal);
            v1 = new Vertex(-aMid, bMid, -cMid, normal);
            v2 = new Vertex(-aMid, -bMid, -cMid, normal);

            triangle.vertices.Add(v0);
            triangle.vertices.Add(v1);
            triangle.vertices.Add(v2);
            mesh.triangles.Add(triangle);

            triangle = new Triangle();
            normal = new Vector(0, 0, 1);
            v0 = new Vertex(aMid, -bMid, cMid, normal);
            v1 = new Vertex(aMid, bMid, cMid, normal);
            v2 = new Vertex(-aMid, -bMid, cMid, normal);

            triangle.vertices.Add(v0);
            triangle.vertices.Add(v1);
            triangle.vertices.Add(v2);
            mesh.triangles.Add(triangle);

            triangle = new Triangle();
            v0 = new Vertex(aMid, bMid, cMid, normal);
            v1 = new Vertex(-aMid, bMid, cMid, normal);
            v2 = new Vertex(-aMid, -bMid, cMid, normal);

            triangle.vertices.Add(v0);
            triangle.vertices.Add(v1);
            triangle.vertices.Add(v2);
            mesh.triangles.Add(triangle);

            triangle = new Triangle();
            normal = new Vector(1, 0, 0);
            v0 = new Vertex(aMid, -bMid, -cMid, normal);
            v1 = new Vertex(aMid, bMid, -cMid, normal);
            v2 = new Vertex(aMid, -bMid, cMid, normal);

            triangle.vertices.Add(v0);
            triangle.vertices.Add(v1);
            triangle.vertices.Add(v2);
            mesh.triangles.Add(triangle);

            triangle = new Triangle();
            v0 = new Vertex(aMid, bMid, -cMid, normal);
            v1 = new Vertex(aMid, bMid, cMid, normal);
            v2 = new Vertex(aMid, -bMid, cMid, normal);

            triangle.vertices.Add(v0);
            triangle.vertices.Add(v1);
            triangle.vertices.Add(v2);
            mesh.triangles.Add(triangle);

            triangle = new Triangle();
            normal = new Vector(0, 1, 0);
            v0 = new Vertex(aMid, bMid, -cMid, normal);
            v1 = new Vertex(-aMid, bMid, -cMid, normal);
            v2 = new Vertex(aMid, bMid, cMid, normal);

            triangle.vertices.Add(v0);
            triangle.vertices.Add(v1);
            triangle.vertices.Add(v2);
            mesh.triangles.Add(triangle);

            triangle = new Triangle();
            v0 = new Vertex(-aMid, bMid, -cMid, normal);
            v1 = new Vertex(-aMid, bMid, cMid, normal);
            v2 = new Vertex(aMid, bMid, cMid, normal);

            triangle.vertices.Add(v0);
            triangle.vertices.Add(v1);
            triangle.vertices.Add(v2);
            mesh.triangles.Add(triangle);

            triangle = new Triangle();
            normal = new Vector(0, -1, 0);
            v0 = new Vertex(aMid, -bMid, -cMid, normal);
            v1 = new Vertex(aMid, -bMid, cMid, normal);
            v2 = new Vertex(-aMid, -bMid, cMid, normal);

            triangle.vertices.Add(v0);
            triangle.vertices.Add(v1);
            triangle.vertices.Add(v2);
            mesh.triangles.Add(triangle);

            triangle = new Triangle();
            v0 = new Vertex(aMid, -bMid, -cMid, normal);
            v1 = new Vertex(-aMid, -bMid, cMid, normal);
            v2 = new Vertex(-aMid, -bMid, -cMid, normal);

            triangle.vertices.Add(v0);
            triangle.vertices.Add(v1);
            triangle.vertices.Add(v2);
            mesh.triangles.Add(triangle);

            this.mesh = mesh;
        }

    }
}
