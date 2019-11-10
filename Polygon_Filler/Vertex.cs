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
            return;
        }

        public Vertex(Point p)
        {
            this.center = p;
            return;
        }

        public void Move(int dx, int dy)
        {
            this.center.X += dx;
            this.center.Y += dy;
            return;
        }

        public bool CanDraw()
        {
            if (this.center.X < 0 || this.center.X >= Form.dbm.Width || this.center.Y < 0 || this.center.Y >= Form.dbm.Height) return false;
            else return true;
        }

        public void Draw(Color color)
        {
            if (this.CanDraw() == false) return;
            for (int i = -2; i < 3; i++)
                for (int j = -2; j < 3; j++)
                {
                    if (this.center.X + i < 0 || this.center.X + i >= Form.dbm.Width || this.center.Y + j < 0 || this.center.Y + j >= Form.dbm.Height) continue;
                    Form.dbm.SetPixel(this.center.X + i, this.center.Y + j, color);
                }                    
            Form.pixelsOfVertices[this.center.X, this.center.Y ] = this;
            return;
        }
    }
}
