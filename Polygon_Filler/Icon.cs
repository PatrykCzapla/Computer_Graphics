using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygon_Filler
{
    public class Icon : Vertex
    {
        public Icon(Point p) : base(p) { }
        public Icon(Vertex v) : base(v) { }

        public override bool CanDraw()
        {
            if (this.center.X - 6 < 0 || this.center.X + 6 >= Form.dbm.Width || this.center.Y - 6 < 0 || this.center.Y + 6>= Form.dbm.Height) return false;
            else return true;
        }

        public override void Draw(Color color)
        {
            if (this.CanDraw() == false) return;
            for (int i = -6; i < 7; i++)
                for (int j = -6; j < 7; j++)
                {
                    if (this.center.X + i < 0 || this.center.X + i >= Form.dbm.Width || this.center.Y + j < 0 || this.center.Y + j >= Form.dbm.Height) continue;
                    if (Tools.distance(this, new Vertex(new Point(center.X + i, center.Y + j))) > 6) continue;
                    if(Math.Abs(i) == Math.Abs(j) || Tools.distance(this, new Vertex(new Point(center.X + i, center.Y + j))) == 6 || i == 0 || j == 0)
                        Form.dbm.SetPixel(this.center.X + i, this.center.Y + j, color);
                }
            return;
        }
    }
}
