using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygon_Filler
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

        public void Move(int dx, int dy)
        {
            this.center.X += dx;
            this.center.Y += dy;
        }

        public bool CanDraw(Bitmap bitmap)
        {
            if (this.center.X < 0 || this.center.X >= bitmap.Width || this.center.Y < 0 || this.center.Y  >= bitmap.Height) return false;
            else return true;
        }

        public void Draw(Bitmap bitmap)
        {
            if (this.CanDraw(bitmap) == false) return;
            bitmap.SetPixel(this.center.X, this.center.Y, Color.Black);
            Form.pixelsOfVertices[this.center.X, this.center.Y ] = this;
        }
    }
}
