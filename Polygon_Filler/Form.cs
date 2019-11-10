﻿using System;
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
        public static DirectBitmap dbm = null;

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
            dbm.Dispose();
            dbm = new DirectBitmap(drawingPictureBox.Size.Width, drawingPictureBox.Size.Height);
            pixelsOfEdges = new Edge[dbm.Width, dbm.Height];
            pixelsOfVertices = new Vertex[dbm.Width, dbm.Height];
            foreach (Polygon p in polygons)
            {
                p.Draw();
                if (p.isFilled == true) p.Fill(p.colorOfFilling);
            }
            drawingPictureBox.Image = dbm.Bitmap;
            return;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            polygons = new List<Polygon>();
            convexPolygons = new List<ConvexPolygon>();
            previousPoint = new Point(-1, -1);
            markedVertex = null;
            markedPolygon = null;
            dbm = new DirectBitmap(drawingPictureBox.Width, drawingPictureBox.Height);
            drawingPictureBox.Image = dbm.Bitmap;
            pixelsOfEdges = new Edge[dbm.Width, dbm.Height];
            pixelsOfVertices = new Vertex[dbm.Width, dbm.Height];
            return;
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
                        polygons.Add(new Polygon(new List<Vertex> { newVertex }, new List<Edge>()));
                    else
                    {
                        Edge newEdge = new Edge(polygons.Last().vertices.Last(), newVertex);
                        if (newEdge.canDraw(polygons.Last().edges) == true)
                        {
                            polygons.Last().edges.Add(newEdge);
                            polygons.Last().vertices.Add(newVertex);
                        }
                    }
                    drawAllPolygons();
                    return;
                }
                else if (((MouseEventArgs)e).Button == MouseButtons.Middle)
                {
                    if (polygons.Count == 0 || polygons.Last().isCorrect == true || polygons.Last().vertices.Count < 3) return;
                    Edge newEdge = new Edge(polygons.Last().vertices.Last(), polygons.Last().vertices.First());                    
                    if (newEdge.canDraw(polygons.Last().edges) == true)
                        polygons.Last().edges.Add(newEdge);
                    else return;
                    polygons.Last().isCorrect = true;
                    drawingPictureBox.Image = new Bitmap(drawingPictureBox.Size.Width, drawingPictureBox.Size.Height);
                    drawAllPolygons();
                    return;
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
                    return;
                }
                return;
            }
            else if (editRadioButton.Checked == true && previousPoint.X != -1)
            {
                if(((MouseEventArgs)e).Button == MouseButtons.Right)
                {
                    if (markedVertex != null)
                    {
                        Polygon currentPolygon = polygons.Find(a => a.vertices.Contains(markedVertex));
                        if (currentPolygon.vertices.Count <= 3)
                        {
                            previousPoint.X = -1;
                            return;
                        }
                        Edge e1 = currentPolygon.edges.Find(a => a.v2 == markedVertex);
                        Edge e2 = currentPolygon.edges.Find(a => a.v1 == markedVertex);
                        Edge newEdge = new Edge(e1.v1, e2.v2);
                        currentPolygon.edges.Insert(currentPolygon.edges.IndexOf(e1), newEdge);
                        currentPolygon.edges.Remove(e1);
                        currentPolygon.edges.Remove(e2);
                        currentPolygon.vertices.Remove(markedVertex);

                        if (currentPolygon.edges.Any(ed => ed.canDraw(currentPolygon.edges) == false))
                        {
                            currentPolygon.edges.Insert(currentPolygon.edges.IndexOf(newEdge), e1);
                            currentPolygon.edges.Insert(currentPolygon.edges.IndexOf(e1), e2);
                            currentPolygon.vertices.Insert(currentPolygon.vertices.IndexOf(newEdge.v2), markedVertex);
                            currentPolygon.edges.Remove(newEdge);
                        }
                        previousPoint.X = -1;
                        return;
                    }
                    else if (markedPolygon != null)
                    {
                        polygons.Remove(markedPolygon);
                        previousPoint.X = -1;
                        return;
                    }
                    markedVertex = null;
                    previousPoint.X = -1;
                    return;
                }
                return;
            }
            return;
        }

        private void generateConvexButton_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int noOfCovex = Int32.Parse(convexDomain.Text);
            List<Vertex> convexVertices = new List<Vertex>();
            for(int i = 0; i < noOfCovex; i++)
                convexVertices.Add(new Vertex(new Point(rand.Next(0, drawingPictureBox.Image.Width - 1), rand.Next(0, drawingPictureBox.Image.Height - 1))));
            convexPolygons.Add(new ConvexPolygon(convexVertices, new List<Edge>()));
            drawingPictureBox.Image = new Bitmap(drawingPictureBox.Size.Width, drawingPictureBox.Size.Height);
            drawAllPolygons();
            foreach (ConvexPolygon cp in convexPolygons)
                cp.Draw();
            return;
        }

        private void drawingPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            Point currentPoint = new Point(e.X, e.Y);
            drawAllPolygons();            

            if (polygonRadioButton.Checked == true)
            {

                Vertex newVertex = new Vertex(currentPoint);

                if (polygons.Count == 0 || polygons.Last().isCorrect == true)
                    newVertex.Draw(Color.Black);
                else if (polygons.Last().isCorrect == false)
                {
                    Edge newEdge = new Edge(polygons.Last().vertices.Last(), newVertex);
                    if (newEdge.canDraw(polygons.Last().edges) == true)
                    {
                        newEdge.Draw(Color.Black);
                        newVertex.Draw(Color.Black);
                    }
                }
            }
            else if (editRadioButton.Checked == true && previousPoint.X != -1 && e.Button == MouseButtons.Left)
            {
                if (markedVertex != null)
                {
                    Polygon currentPolygon = polygons.Find(p => p.vertices.Contains(markedVertex));
                    markedVertex.Move(currentPoint.X - previousPoint.X, currentPoint.Y - previousPoint.Y);
                    if (currentPolygon.edges.Any(ed => ed.canDraw(currentPolygon.edges) == false))
                        markedVertex.Move(previousPoint.X - currentPoint.X, previousPoint.Y - currentPoint.Y);
                }
                else if (markedPolygon != null)
                {
                    markedPolygon.Move(currentPoint.X - previousPoint.X, currentPoint.Y - previousPoint.Y);
                    if (markedPolygon.vertices.Any(v => v.CanDraw() == false))
                        markedPolygon.Move(previousPoint.X - currentPoint.X, previousPoint.Y - currentPoint.Y);
                }
                previousPoint = currentPoint;
                return;
            }
        }

        private void drawingPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if(markedPolygon != null) markedPolygon.color = Color.Black;
            markedPolygon = null;
            if(editRadioButton.Checked == true)
            {
                previousPoint = e.Location;
                markedVertex = Editor.searchForVertex(previousPoint);
                if (markedVertex == null)
                    markedPolygon = Editor.searchForPolygon(previousPoint);
                if(markedPolygon != null)
                {
                    markedPolygon.color = Color.Red;
                    drawAllPolygons();
                }
            }
            return;
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            if (polygons.Count > 0 && polygons.Last().isCorrect == false)
                polygons.RemoveAt(polygons.Count - 1);
            drawAllPolygons();
            return;
        }

        private void drawingPictureBox_MouseLeave(object sender, EventArgs e)
        {
            markedVertex = null;
            drawAllPolygons();
            return;
        }

        private void drawingPictureBox_SizeChanged(object sender, EventArgs e)
        {
            drawAllPolygons();
            return;
        }

        private void fillingColorButton_Click(object sender, EventArgs e)
        {
            if (fillingColorDialog.ShowDialog() == DialogResult.OK)
                fillingColorButton.BackColor = fillingColorDialog.Color;
        }

        private void fillButton_Click(object sender, EventArgs e)
        {
            if (markedPolygon != null)
                markedPolygon.Fill(fillingColorButton.BackColor);
            drawAllPolygons();
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
                drawingPictureBox_Click(sender, new MouseEventArgs(MouseButtons.Middle, 1, 0, 0, 0));
        }
    }
}
