using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    [Serializable]
    public abstract class Polygon
    {
        public List<Vertex> vertices = new List<Vertex>();
        public List<Edge> edges = new List<Edge>();

        public virtual void Draw(Color color)
        {
            Fill(color);
            for (int i = 0; i < edges.Count; i++)
                edges[i].Draw(Color.Black);
        }

        private class AET
        {
            public double x;
            public double diff;
            public Edge e;

            public AET(double x, double diff, Edge e)
            {
                this.x = x;
                this.diff = diff;
                this.e = e;
            }
        }

        public virtual void Fill(Color color)
        {
            List<AET> AETs = new List<AET>();

            List<Vertex> sortedVertices = vertices.OrderBy(v => v.y).ToList();

            int ymin = (int)sortedVertices.Last().y;
            int ymax = (int)sortedVertices.First().y;


            for (int y = ymin; y >= ymax; y--)
            {
                foreach (Vertex v in vertices.FindAll(u => (int)u.y == y))
                {
                    bool horizontalLine = false;
                    Vertex vertex = null;
                    int index = vertices.IndexOf(v);
                    if (index > 0) vertex = vertices[index - 1];
                    else if (index == 0) vertex = vertices[vertices.Count - 1];
                    if (vertex != null)
                    {
                        Edge edge = edges.Find(e => e.v1 == vertex && e.v2 == v);
                        double diff = 0;
                        if ((int)(vertex.y - v.y) == 0) horizontalLine = true;
                        else diff = ((double)(vertex.x - v.x) / (double)(vertex.y - v.y));
                        if (horizontalLine == false && vertex.y <= v.y) AETs.Add(new AET(v.x, diff, edge));
                        else AETs.RemoveAll(e => e.e == edge);
                    }
                    vertex = null;
                    if (index < vertices.Count - 1) vertex = vertices[index + 1];
                    else if (index == vertices.Count - 1) vertex = vertices[0];
                    if (vertex != null)
                    {
                        Edge edge = edges.Find(e => e.v1 == v && e.v2 == vertex);
                        double diff = 0;
                        if ((int)(vertex.y - v.y) == 0) horizontalLine = true;
                        else
                        {
                            diff = ((double)(vertex.x - v.x) / (double)(vertex.y - v.y));
                            horizontalLine = false;
                        }
                        if (horizontalLine == false && vertex.y <= v.y) AETs.Add(new AET(v.y, diff, edge));
                        else AETs.RemoveAll(e => e.e == edge);
                    }
                }
                AETs = AETs.OrderBy(a => a.x).ToList();
                for (int i = 0; i < AETs.Count; i += 2)
                    for (int x = (int)AETs[i].x + 1; x <= AETs[i + 1].x; x++)
                    {
                        if (x < 0 || x >= Form.dbm.Width || y < 0 || y >= Form.dbm.Height) continue;
                        Form.dbm.SetPixel(x, (int)y, color);
                    }
                
                for (int i = 0; i < AETs.Count; i++)
                {
                    AETs[i].x -= AETs[i].diff;
                }
            }
        }
    }
}
