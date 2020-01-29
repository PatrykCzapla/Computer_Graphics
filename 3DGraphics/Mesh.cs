using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    [Serializable]
    public class Mesh
    {
        public List<Triangle> triangles;

        public List<Vertex> vertices;

        public void makeMesh()
        {
            vertices = new List<Vertex>();
            foreach (Triangle triangle in triangles)
                vertices.AddRange(triangle.vertices);
        }
    }
}
