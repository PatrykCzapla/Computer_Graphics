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

        public bool IsIntersection = false;
        public bool IsEntry = false;
        public bool Visited = false;
        public double distance = 0;
        public Vertex correspondingVertex = null;

        public Vertex(Vertex v)
        {
            this.center = v.center;
            this.IsIntersection = v.IsIntersection;
            this.IsEntry = v.IsEntry;
            this.distance = v.distance;
            this.correspondingVertex = v.correspondingVertex;
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

        public virtual bool CanDraw()
        {
            if (this.center.X < 0 || this.center.X >= Form.dbm.Width || this.center.Y < 0 || this.center.Y >= Form.dbm.Height) return false;
            else return true;
        }

        public virtual void Draw(Color color)
        {
            if (this.CanDraw() == false || IsIntersection == true) return;
            for (int i = -2; i < 3; i++)
                for (int j = -2; j < 3; j++)
                {
                    if (this.center.X + i < 0 || this.center.X + i >= Form.dbm.Width || this.center.Y + j < 0 || this.center.Y + j >= Form.dbm.Height) continue;
                    Form.dbm.SetPixel(this.center.X + i, this.center.Y + j, color);
                }
            return;
        }
    }
}
