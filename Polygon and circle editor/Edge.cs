using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

/// <summary>
/// Edge class represents an edge of polygon
/// each vertex in edge represents corresponding vertex in polygon
/// </summary>

namespace Polygon_and_circle_editor
{
    public class Edge
    {
        public Vertex v1;
        public Vertex v2;

        public Edge(Vertex v1, Vertex v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        //method to move edge
        public void changeVertices(int dx, int dy)
        {
            v1.center.X += dx;
            v1.center.Y += dy; 
            v2.center.X += dx;
            v2.center.Y += dy;
        }
    }
}
