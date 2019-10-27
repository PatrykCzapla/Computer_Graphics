using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Figure class represents any figure (polygon and circle)
/// </summary>

namespace Polygon_and_circle_editor
{
    public abstract class Figure
    {
        public Color color;

        public abstract bool canDraw(Bitmap bitmap);
        public abstract void Draw(Bitmap bitmap);
    }

    public class Polygon : Figure
    {
        public List<Vertex> vertices = new List<Vertex>();
        public List<Edge> edges = new List<Edge>();

        public bool isCorrect = false; //used to check if given polygon is correct

        public Polygon(List<Vertex> vertices, List<Edge> edges, Color color)
        {
            for(int i = 0; i < vertices.Count; i++)
                this.vertices.Add(vertices[i]);
            for (int i = 0; i < edges.Count; i++)
                this.edges.Add(edges[i]);
            this.color = color;
        }

        //method returns the new object
        public Polygon(Polygon p)
        {
            this.color = p.color;
            this.isCorrect = p.isCorrect;
            for (int i = 0; i < p.vertices.Count; i++)
                this.vertices.Add(new Vertex(p.vertices[i]));
            for (int i = 0; i < vertices.Count - 1; i++)
                this.edges.Add(new Edge(vertices[i], vertices[i + 1]));
            if (this.isCorrect == true) this.edges.Add(new Edge(vertices.Last(), vertices.First()));           
        }

        public override bool canDraw(Bitmap bitmap)
        {
            for(int i = 0; i < vertices.Count; i++)
            foreach (Vertex v in vertices)
                if (Drawer.canDrawVertex(v, bitmap) == false) return false;
            return true;
        }

        public override void Draw(Bitmap bitmap)
        {
            if (canDraw(bitmap) == false) return;
            foreach (Edge e in edges)
                Drawer.drawEdge(e, this.color, bitmap);
            foreach (Vertex v in vertices)
                Drawer.drawVertex(v, this.color, bitmap);
            return;
        }

        //method to move polygon
        public void changePosition(int dx, int dy)
        {
            for(int i = 0; i < vertices.Count; i++)
            {
                vertices[i].center.X += dx;
                vertices[i].center.Y += dy;
            }
        }
    }

    public class Circle : Figure
    {
        public Point center;
        public int radius;

        public Circle(Point center, int radius, Color color)
        {
            this.center = center;
            this.radius = radius;
            this.color = color;
        }

        //method returns the new object
        public Circle(Circle c)
        {
            this.radius = c.radius;
            this.color = c.color;
            this.center = c.center;
        }

        public override bool canDraw(Bitmap bitmap)
        {
            if (center.X >= bitmap.Width || center.X < 0 || center.Y > bitmap.Height || center.Y < 0) return false;
            if (center.X + radius >= bitmap.Width || center.X - radius < 0 || center.Y + radius >= bitmap.Height || center.Y - radius < 0) return false;
            else return true;
        }

        public override void Draw(Bitmap bitmap)
        {
            if (radius == -1) return;
            int deltaE = 3;
            int deltaSE = 5 - 2 * radius;
            int d = 1 - radius;
            int x = 0;
            int y = radius;

            bitmap.SetPixel(center.X + x, center.Y + y, color);
            bitmap.SetPixel(center.X + y, center.Y + x, color);
            bitmap.SetPixel(center.X + y, center.Y - x, color);
            bitmap.SetPixel(center.X + x, center.Y - y, color);
            bitmap.SetPixel(center.X - x, center.Y - y, color);
            bitmap.SetPixel(center.X - y, center.Y - x, color);
            bitmap.SetPixel(center.X - y, center.Y + x, color);
            bitmap.SetPixel(center.X - x, center.Y + y, color);

            //Form.pixels[center.X + x, center.Y + y] = this;
            //Form.pixels[center.X + y, center.Y + x] = this;
            //Form.pixels[center.X + y, center.Y - x] = this;
            //Form.pixels[center.X + x, center.Y - y] = this;
            //Form.pixels[center.X - x, center.Y - y] = this;
            //Form.pixels[center.X - y, center.Y - x] = this;
            //Form.pixels[center.X - y, center.Y + x] = this;
            //Form.pixels[center.X - x, center.Y + y] = this;


            while (y > x)
            {
                if (d < 0)
                {
                    d += deltaE;
                    deltaE += 2;
                    deltaSE += 2;
                }
                else
                {
                    d += deltaSE;
                    deltaE += 2;
                    deltaSE += 4;
                    y--;
                }
                x++;

                bitmap.SetPixel(center.X + x, center.Y + y, color);
                bitmap.SetPixel(center.X + y, center.Y + x, color);
                bitmap.SetPixel(center.X + y, center.Y - x, color);
                bitmap.SetPixel(center.X + x, center.Y - y, color);
                bitmap.SetPixel(center.X - x, center.Y - y, color);
                bitmap.SetPixel(center.X - y, center.Y - x, color);
                bitmap.SetPixel(center.X - y, center.Y + x, color);
                bitmap.SetPixel(center.X - x, center.Y + y, color);

                //Form.pixels[center.X + x, center.Y + y] = this;
                //Form.pixels[center.X + y, center.Y + x] = this;
                //Form.pixels[center.X + y, center.Y - x] = this;
                //Form.pixels[center.X + x, center.Y - y] = this;
                //Form.pixels[center.X - x, center.Y - y] = this;
                //Form.pixels[center.X - y, center.Y - x] = this;
                //Form.pixels[center.X - y, center.Y + x] = this;
                //Form.pixels[center.X - x, center.Y + y] = this;
            }
            return;
        }        

        public void changeRadius(Point newPoint)
        {
            this.radius = Drawer.distance(this.center, newPoint);
        }

        //method to move circle
        public void changeCenter(int dx, int dy)
        {
            this.center.X += dx;
            this.center.Y += dy;
        }
    }
}
