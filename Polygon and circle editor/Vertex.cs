using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Vertex class represents a vertex of polygon
/// </summary>

namespace Polygon_and_circle_editor
{
    public class Vertex
    {
        public Point center;

        public Vertex(Point center)
        {
            this.center = center;
        }

        public Vertex(Vertex v)
        {
            this.center = v.center;
        }

        //method to move vertex
        public void changeCenter(int dx, int dy)
        {
            this.center.X += dx;
            this.center.Y += dy;
        }
    }
}
