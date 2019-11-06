using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polygon_Filler
{
    public partial class Form : System.Windows.Forms.Form
    {
        public static Edge[,] pixelsOfEdges;
        public static Vertex[,] pixelsOfVertices;

        public static List<Polygon> polygons = new List<Polygon>();
        private List<ConvexPolygon> convexPolygons = new List<ConvexPolygon>();

        private Point previousPoint = new Point(-1, -1);
        private Vertex markedVertex = null;
        private Polygon markedPolygon = null;
        
        public Form()
        {
            InitializeComponent();
            this.toolTip.SetToolTip(this.clearButton, "Clear everything.");
            this.toolTip.SetToolTip(this.polygonRadioButton, "Draw polygon." + Environment.NewLine + "Left-click to add vertices." + Environment.NewLine + "Right-click to remove last drawn vertex." + Environment.NewLine + "Middle-click or Ctrl + Enter to close polygon.");
            this.toolTip.SetToolTip(this.editRadioButton, "Edit polygon." + Environment.NewLine + "Left-click + drag to move vertex or polygon." + Environment.NewLine + "Right-click to remove polygon.");

            clearButton_Click(null, null);
        }

        private void drawAllPolygons()
        {
            drawingPictureBox.Image.Dispose();
            drawingPictureBox.Image = new Bitmap(drawingPictureBox.Size.Width, drawingPictureBox.Size.Height);
            pixelsOfEdges = new Edge[drawingPictureBox.Image.Width, drawingPictureBox.Image.Height];
            pixelsOfVertices = new Vertex[drawingPictureBox.Image.Width, drawingPictureBox.Image.Height];
            foreach (Polygon p in polygons)
                p.Draw((Bitmap)drawingPictureBox.Image);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            polygons = new List<Polygon>();
            convexPolygons = new List<ConvexPolygon>();
            previousPoint = new Point(-1, -1);
            markedVertex = null;
            markedPolygon = null;  
            drawingPictureBox.Image = new Bitmap(drawingPictureBox.Width, drawingPictureBox.Height);
            pixelsOfEdges = new Edge[drawingPictureBox.Image.Width, drawingPictureBox.Image.Height];
            pixelsOfVertices = new Vertex[drawingPictureBox.Width, drawingPictureBox.Height];
        }

        private void drawingPictureBox_Click(object sender, EventArgs e)
        {
            Point currentPoint = new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);

            drawAllPolygons();

            if (polygonRadioButton.Checked == true)
            {
                if (polygons.Count > 0 && polygons.Last().isCorrect == false && (polygons.Last().vertices.Find(a => (a.center.X == currentPoint.X && a.center.Y == currentPoint.Y)) != null)) return;
                Vertex newVertex = new Vertex(currentPoint);

                if (((MouseEventArgs)e).Button == MouseButtons.Left)
                {
                    if (polygons.Count == 0 || polygons.Last().isCorrect == true)
                    {
                        polygons.Add(new Polygon(new List<Vertex> { newVertex }, new List<Edge>()));
                        drawingPictureBox.Image = new Bitmap(drawingPictureBox.Size.Width, drawingPictureBox.Size.Height);
                        drawAllPolygons();
                    }
                    else
                    {
                        Edge newEdge = new Edge(polygons.Last().vertices.Last(), newVertex);
                        if (newEdge.canDraw(polygons.Last().edges) == true)
                        {
                            polygons.Last().edges.Add(newEdge);
                            polygons.Last().vertices.Add(newVertex);
                        }
                        drawingPictureBox.Image = new Bitmap(drawingPictureBox.Size.Width, drawingPictureBox.Size.Height);
                        drawAllPolygons();
                    }
                }
                else if (((MouseEventArgs)e).Button == MouseButtons.Middle)
                {
                    if (polygons.Count == 0 || polygons.Last().isCorrect == true || polygons.Last().vertices.Count < 3) return;
                    Edge newEdge = new Edge(polygons.Last().vertices.Last(), polygons.Last().vertices.First());
                    List<Edge> tmpEdges = new List<Edge>(polygons.Last().edges);
                    tmpEdges.Remove(tmpEdges.First());
                    if (newEdge.canDraw(tmpEdges) == true)
                        polygons.Last().edges.Add(newEdge);
                    else return;
                    polygons.Last().isCorrect = true;
                    drawingPictureBox.Image = new Bitmap(drawingPictureBox.Size.Width, drawingPictureBox.Size.Height);
                    drawAllPolygons();
                }
                else if (((MouseEventArgs)e).Button == MouseButtons.Right)
                {
                    if (polygons.Count == 0 || polygons.Last().isCorrect == true) return;
                    else
                    {
                        polygons.Last().vertices.Remove(polygons.Last().vertices.Last());
                        if (polygons.Last().vertices.Count != 0)
                            polygons.Last().edges.Remove(polygons.Last().edges.Last());
                        else
                            polygons.Remove(polygons.Last());
                        drawAllPolygons();
                    }
                }
            }
            else if (editRadioButton.Checked == true && previousPoint.X != -1)
            {
                if(((MouseEventArgs)e).Button == MouseButtons.Right)
                {
                    if (markedVertex != null)
                    {
                        Polygon p = polygons.Find(a => a.vertices.Contains(markedVertex));
                        if (p.vertices.Count <= 3)
                        {
                            previousPoint.X = -1;
                            return;
                        }
                        Edge e1 = p.edges.Find(a => a.v2 == markedVertex);
                        Edge e2 = p.edges.Find(a => a.v1 == markedVertex);
                        Edge newEdge = new Edge(e1.v1, e2.v2);
                        p.edges.Insert(p.edges.IndexOf(e1), newEdge);
                        p.edges.Remove(e1);
                        p.edges.Remove(e2);
                        p.vertices.Remove(markedVertex);
                        previousPoint.X = -1;
                        return;
                    }
                    else if (markedPolygon != null)
                    {
                        polygons.Remove(markedPolygon);
                        previousPoint.X = -1;
                        return;
                    }
                    markedPolygon = null;
                    markedVertex = null;
                    previousPoint.X = -1;
                    return;
                }                
            }
        }

        private void generateConvexButton_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int noOfCovex = Int32.Parse(convexDomain.Text);
            List<Vertex> convexVertices = new List<Vertex>();
            for(int i = 0; i < noOfCovex; i++)
                convexVertices.Add(new Vertex(new Point(rand.Next(0, drawingPictureBox.Image.Width - 1), rand.Next(0, drawingPictureBox.Image.Height - 1))));
            convexPolygons.Add(new ConvexPolygon(convexVertices));
            drawingPictureBox.Image = new Bitmap(drawingPictureBox.Size.Width, drawingPictureBox.Size.Height);
            drawAllPolygons();
            foreach (ConvexPolygon cp in convexPolygons)
                cp.Draw((Bitmap)drawingPictureBox.Image);
        }

        private void drawingPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            Point currentPoint = new Point(e.X, e.Y);

            drawAllPolygons();

            if (polygonRadioButton.Checked == true)
            {
                Vertex newVertex = new Vertex(currentPoint);

                if (polygons.Count == 0 || polygons.Last().isCorrect == true)
                    newVertex.Draw((Bitmap)drawingPictureBox.Image);
                else if (polygons.Last().isCorrect == false)
                {
                    Edge newEdge = new Edge(polygons.Last().vertices.Last(), newVertex);
                    if (newEdge.canDraw(polygons.Last().edges) == true)
                    {
                        newEdge.Draw((Bitmap)drawingPictureBox.Image);
                        newVertex.Draw((Bitmap)drawingPictureBox.Image);
                    }
                }
            }
            else if (editRadioButton.Checked == true && previousPoint.X != -1 && e.Button == MouseButtons.Left)
            {
                if (markedVertex != null)
                {
                    markedVertex.Move(currentPoint.X - previousPoint.X, currentPoint.Y - previousPoint.Y);
                    previousPoint = currentPoint;
                    return;
                }
                else if (markedPolygon != null)
                {
                    Console.WriteLine("yuytaj");

                    markedPolygon.Move(currentPoint.X - previousPoint.X, currentPoint.Y - previousPoint.Y);
                    previousPoint = currentPoint;
                    return;
                }
            }
        }

        private void drawingPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if(editRadioButton.Checked == true)
            {
                previousPoint = e.Location;
                markedVertex = Editor.searchForVertex(previousPoint);
                if (markedVertex == null)
                    markedPolygon = Editor.searchForPolygon(previousPoint);
            }
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            if (polygons.Count > 0 && polygons.Last().isCorrect == false)
            {
                polygons.RemoveAt(polygons.Count - 1);
            }
            drawAllPolygons();
        }
    }
}
