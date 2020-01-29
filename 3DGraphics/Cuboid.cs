using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Cuboid
    {
        public Mesh createCuboid(double a, double b, double c)
        {
            double aMid = a / 2;
            double bMid = b / 2;
            double cMid = c / 2;

            Mesh mesh = new Mesh();
            mesh.triangles = new List<Triangle>();

            Triangle triangle = new Triangle();
            Vector normal = new Vector(0, 0, -1);
            Vertex v0 = new Vertex(aMid, bMid, -cMid, normal, 0.748573, 0.750412);
            Vertex v1 = new Vertex(aMid, -bMid, -cMid, normal, 0.749279, 0.501284);
            Vertex v2 = new Vertex(-aMid, -bMid, -cMid, normal, 0.999110, 0.501077);

            triangle.vertices.Add(v0);
            triangle.vertices.Add(v1);
            triangle.vertices.Add(v2);
            mesh.triangles.Add(triangle);

            triangle = new Triangle();
            v0 = new Vertex(aMid, bMid, -cMid, normal, 0.748573, 0.750412);
            v1 = new Vertex(-aMid, -bMid, -cMid, normal, 0.999110, 0.501077);
            v2 = new Vertex(-aMid, bMid, -cMid, normal, 0.999455, 0.750380);

            triangle.vertices.Add(v0);
            triangle.vertices.Add(v1);
            triangle.vertices.Add(v2);
            mesh.triangles.Add(triangle);

            triangle = new Triangle();
            normal = new Vector(-1, 0, 0);
            v0 = new Vertex(-aMid, -bMid, cMid, normal, 0.250471, 0.500702);
            v1 = new Vertex(-aMid, bMid, cMid, normal, 0.249682, 0.749677);
            v2 = new Vertex(-aMid, bMid, -cMid, normal, 0.001085, 0.750380);

            triangle.vertices.Add(v0);
            triangle.vertices.Add(v1);
            triangle.vertices.Add(v2);
            mesh.triangles.Add(triangle);

            triangle = new Triangle();
            v0 = new Vertex(-aMid, -bMid, cMid, normal, 0.250471, 0.500702);
            v1 = new Vertex(-aMid, bMid, -cMid, normal, 0.001085, 0.750380);
            v2 = new Vertex(-aMid, -bMid, -cMid, normal, 0.001517, 0.499994);

            triangle.vertices.Add(v0);
            triangle.vertices.Add(v1);
            triangle.vertices.Add(v2);
            mesh.triangles.Add(triangle);

            triangle = new Triangle();
            normal = new Vector(0, 0, 1);
            v0 = new Vertex(aMid, -bMid, cMid, normal, 0.499422, 0.500239);
            v1 = new Vertex(aMid, bMid, cMid, normal, 0.500149, 0.750166);
            v2 = new Vertex(-aMid, -bMid, cMid, normal, 0.250471, 0.500702);

            triangle.vertices.Add(v0);
            triangle.vertices.Add(v1);
            triangle.vertices.Add(v2);
            mesh.triangles.Add(triangle);

            triangle = new Triangle();
            v0 = new Vertex(aMid, bMid, cMid, normal, 0.500149, 0.750166);
            v1 = new Vertex(-aMid, bMid, cMid, normal, 0.249682, 0.749677);
            v2 = new Vertex(-aMid, -bMid, cMid, normal, 0.250471, 0.500702);

            triangle.vertices.Add(v0);
            triangle.vertices.Add(v1);
            triangle.vertices.Add(v2);
            mesh.triangles.Add(triangle);

            triangle = new Triangle();
            normal = new Vector(1, 0, 0);
            v0 = new Vertex(aMid, -bMid, -cMid, normal, 0.250471, 0.500702);
            v1 = new Vertex(aMid, bMid, -cMid, normal, 0.748573, 0.750412);
            v2 = new Vertex(aMid, -bMid, cMid, normal, 0.499422, 0.500239);

            triangle.vertices.Add(v0);
            triangle.vertices.Add(v1);
            triangle.vertices.Add(v2);
            mesh.triangles.Add(triangle);

            triangle = new Triangle();
            v0 = new Vertex(aMid, bMid, -cMid, normal, 0.748573, 0.750412);
            v1 = new Vertex(aMid, bMid, cMid, normal, 0.500149, 0.750166);
            v2 = new Vertex(aMid, -bMid, cMid, normal, 0.499422, 0.500239);

            triangle.vertices.Add(v0);
            triangle.vertices.Add(v1);
            triangle.vertices.Add(v2);
            mesh.triangles.Add(triangle);

            triangle = new Triangle();
            normal = new Vector(0, 1, 0);
            v0 = new Vertex(aMid, bMid, -cMid, normal, 0.748573, 0.750412);
            v1 = new Vertex(-aMid, bMid, -cMid, normal, 0.748355, 0.998230);
            v2 = new Vertex(aMid, bMid, cMid, normal, 0.500149, 0.750166);

            triangle.vertices.Add(v0);
            triangle.vertices.Add(v1);
            triangle.vertices.Add(v2);
            mesh.triangles.Add(triangle);

            triangle = new Triangle();
            v0 = new Vertex(-aMid, bMid, -cMid, normal, 0.748355, 0.998230);
            v1 = new Vertex(-aMid, bMid, cMid, normal, 0.500193, 0.998728);
            v2 = new Vertex(aMid, bMid, cMid, normal, 0.500149, 0.750166);

            triangle.vertices.Add(v0);
            triangle.vertices.Add(v1);
            triangle.vertices.Add(v2);
            mesh.triangles.Add(triangle);

            triangle = new Triangle();
            normal = new Vector(0, -1, 0);
            v0 = new Vertex(aMid, -bMid, -cMid, normal, 0.749279, 0.501284);
            v1 = new Vertex(aMid, -bMid, cMid, normal, 0.499422, 0.500239);
            v2 = new Vertex(-aMid, -bMid, cMid, normal, 0.498993, 0.250415);

            triangle.vertices.Add(v0);
            triangle.vertices.Add(v1);
            triangle.vertices.Add(v2);
            mesh.triangles.Add(triangle);

            triangle = new Triangle();
            v0 = new Vertex(aMid, -bMid, -cMid, normal, 0.749279, 0.501284);
            v1 = new Vertex(-aMid, -bMid, cMid, normal, 0.498993, 0.250415);
            v2 = new Vertex(-aMid, -bMid, -cMid, normal, 0.748953, 0.250920);

            triangle.vertices.Add(v0);
            triangle.vertices.Add(v1);
            triangle.vertices.Add(v2);
            mesh.triangles.Add(triangle);

            mesh.makeMesh();
            return mesh;
        }

    }
}
