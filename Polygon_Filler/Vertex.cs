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

        public Vertex(Vertex v)
        {
            this.center = v.center;
        }

        public Vertex(Point p)
        {
            this.center = p;
        }

        public void Move(int dx, int dy)
        {
            this.center.X += dx;
            this.center.Y += dy;
        }

        public bool CanDraw(Bitmap bitmap)
        {
            if (this.center.X < 0 || this.center.X >= bitmap.Width || this.center.Y < 0 || this.center.Y >= bitmap.Height) return false;
            else return true;
        }

        public void Draw(Bitmap bitmap)
        {
            if (this.CanDraw(bitmap) == false) return;
            for (int i = -2; i < 3; i++)
                for (int j = -2; j < 3; j++)
                {
                    if (this.center.X + i < 0 || this.center.X + i >= bitmap.Width || this.center.Y + j < 0 || this.center.Y + j >= bitmap.Height) continue;
                    bitmap.SetPixel(this.center.X + i, this.center.Y + j, Color.Black);
                }                    
            Form.pixelsOfVertices[this.center.X, this.center.Y ] = this;
        }
    }
}
