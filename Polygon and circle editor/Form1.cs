using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polygon_and_circle_editor
{
    public partial class Form : System.Windows.Forms.Form
    {
        public static List<Polygon> polygons = new List<Polygon>();
        public static List<Circle> circles = new List<Circle>();
        private Color currentColor;
        private Point previousPoint = new Point(-1, -1);

        private List<Action> actionsToUndo = new List<Action>();
        private List<Action> actionsToRedo = new List<Action>();

        public static Edge[,] pixelsOfEdges;
        public static Vertex[,] pixelsOfVertices;
        private Vertex vertexToMove = null;
        private Edge edgeToMove = null;
        private Circle circleToMove = null;
        private Circle circleToChange = null;
        private Polygon polygonToMove = null;

        public Form()
        {
            InitializeComponent();
            drawingPictureBox.Image = new Bitmap(drawingPictureBox.Width, drawingPictureBox.Height);
            currentColor = colorButton.BackColor = Color.Black;
            pixelsOfVertices = new Vertex[drawingPictureBox.Image.Width, drawingPictureBox.Image.Height];
            pixelsOfEdges = new Edge[drawingPictureBox.Image.Width, drawingPictureBox.Image.Height];
            ClearButton_Click(null, null);
            
            this.toolTip.SetToolTip(this.clearButton, "Clear everything.");
            this.toolTip.SetToolTip(this.redoButton, "Redo previously undone action." + Environment.NewLine + "Ctrl + Shift + z");
            this.toolTip.SetToolTip(this.undoButton, "Undo last action." + Environment.NewLine + "Ctrl + z");
            this.toolTip.SetToolTip(this.colorButton, "Change color of currently drawing figure.");
            this.toolTip.SetToolTip(this.polygonButton, "Draw polygon." + Environment.NewLine + "Left-click to add vertices." + Environment.NewLine + "Right-click to remove last drawn vertex." + Environment.NewLine + "Middle-click or Ctrl + Enter to close polygon.");
            this.toolTip.SetToolTip(this.circleButton, "Draw circle." + Environment.NewLine + "Left-click to add center or choose radius." + Environment.NewLine + "Right-click to remove center.");
            this.toolTip.SetToolTip(this.editButton, "Edit figures." + Environment.NewLine + "Left-click + drag to move vertex, edge, polygon, circle or to change radius of circle." + Environment.NewLine + "Right-click to remove figure or vertex." + Environment.NewLine + "Double left-click to add vertex on edge.");
        }

        private void DrawingPictureBox_Click(object sender, EventArgs e)
        {
            Point currentPoint = new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);

            displayActions();
            drawingPictureBox.Image = new Bitmap(drawingPictureBox.Size.Width, drawingPictureBox.Size.Height);
            Drawer.drawAll(ref polygons, ref circles, (Bitmap)drawingPictureBox.Image);

            if(editButton.Checked == true && previousPoint.X != -1)
            {
                vertexToMove = null;
                edgeToMove = null;
                circleToMove = null;
                circleToChange = null;
                if (((MouseEventArgs)e).Button == System.Windows.Forms.MouseButtons.Right)
                {
                    Vertex vertexToDelete = Editor.searchForVertex(previousPoint);
                    if (vertexToDelete != null)
                    {
                        Polygon p = polygons.Find(a => a.vertices.Contains(vertexToDelete));
                        if(p.vertices.Count <= 3)
                        {
                            previousPoint.X = -1;
                            tipLabel.Text = "Polygon must have at least 3 vertices.";
                            return;
                        }
                        actionsToUndo.Add(new Action("Removed vertex", polygons, circles, currentColor));
                        actionsToRedo = new List<Action>();
                        displayActions();
                        Edge e1 = p.edges.Find(a => a.v2 == vertexToDelete);
                        Edge e2 = p.edges.Find(a => a.v1 == vertexToDelete);
                        Edge newEdge = new Edge(e1.v1, e2.v2);
                        p.edges.Insert(p.edges.IndexOf(e1), newEdge);
                        p.edges.Remove(e1);
                        p.edges.Remove(e2);
                        p.vertices.Remove(vertexToDelete);
                        previousPoint.X = -1;
                        tipLabel.Text = "Removed vertex.";
                        return;
                    }
                    Polygon polygonToDelete = Editor.searchForPolygon(previousPoint);
                    if (polygonToDelete != null)
                    {
                        actionsToUndo.Add(new Action("Removed polygon", polygons, circles, currentColor));
                        actionsToRedo = new List<Action>();
                        displayActions();
                        polygons.Remove(polygonToDelete);
                        tipLabel.Text = "Removed polygon.";                        
                        previousPoint.X = -1;
                        return;
                    }
                    Circle circleToDelete = Editor.searchForCircle(previousPoint);
                    if(circleToDelete != null)
                    {
                        actionsToUndo.Add(new Action("Removed circle", polygons, circles, currentColor));
                        actionsToRedo = new List<Action>();
                        displayActions();
                        circles.Remove(circleToDelete);
                        tipLabel.Text = "Removed circle.";                        
                        previousPoint.X = -1;
                        return;
                    }
                }
                previousPoint.X = -1;
                return;
            }
            else if (polygonButton.Checked == true)
            {
                Edge newEdge = new Edge(new Vertex(new Point(0, 0)), new Vertex(new Point(0, 0)));

                if (polygons.Count > 0 && polygons.Last().isCorrect == false && (polygons.Last().vertices.Find(a => (a.center.X == currentPoint.X && a.center.Y == currentPoint.Y)) != null)) return;

                if (((MouseEventArgs)e).Button == System.Windows.Forms.MouseButtons.Middle)
                {
                    if (polygons.Count == 0) return;
                    if (polygons.Last().isCorrect == true) return;

                    if (polygons.Last().vertices.Count < 3)
                    {
                        tipLabel.Text = "Polygon must have at least 3 vertices.";
                        return;
                    }

                    newEdge = new Edge(polygons.Last().vertices.Last(), polygons.Last().vertices.First());

                    if (Drawer.canDrawEdge(newEdge, (Bitmap)drawingPictureBox.Image) == true)
                    {
                        actionsToUndo.Add(new Action("Added polygon", polygons, circles, currentColor));
                        actionsToRedo = new List<Action>();
                        displayActions();
                        polygons.Last().edges.Add(newEdge);
                        tipLabel.Text = "Added correct polygon.";
                        polygons.Last().isCorrect = true;                        
                        drawingPictureBox.Image = new Bitmap(drawingPictureBox.Size.Width, drawingPictureBox.Size.Height);
                        Drawer.drawAll(ref polygons, ref circles, (Bitmap)drawingPictureBox.Image);
                    }
                    return;
                }
                if (((MouseEventArgs)e).Button == System.Windows.Forms.MouseButtons.Right && polygons.Count > 0 && polygons.Last().isCorrect == false)
                {
                    if (polygons.Last().vertices.Count == 1)
                    {
                        actionsToUndo.Add(new Action("Removed vertex", polygons, circles, currentColor));
                        actionsToRedo = new List<Action>();
                        displayActions();
                        polygons.RemoveAt(polygons.Count - 1);
                        drawingPictureBox.Image = new Bitmap(drawingPictureBox.Size.Width, drawingPictureBox.Size.Height);
                        Drawer.drawAll(ref polygons, ref circles, (Bitmap)drawingPictureBox.Image);
                        tipLabel.Text = "Removed vertex.";
                        return;
                    }

                    actionsToUndo.Add(new Action("Removed vertex", polygons, circles, currentColor));
                    actionsToRedo = new List<Action>();
                    displayActions();
                    polygons.Last().vertices.RemoveAt(polygons.Last().vertices.Count - 1);
                    polygons.Last().edges.RemoveAt(polygons.Last().edges.Count - 1);
                    tipLabel.Text = "Removed vertex.";

                    drawingPictureBox.Image = new Bitmap(drawingPictureBox.Size.Width, drawingPictureBox.Size.Height);
                    Drawer.drawAll(ref polygons, ref circles, (Bitmap)drawingPictureBox.Image);
                    return;
                }
                else if (((MouseEventArgs)e).Button == System.Windows.Forms.MouseButtons.Right) return;

                if (polygons.Count == 0 || (polygons.Count > 0 && polygons.Last().isCorrect == true))
                {
                    Vertex newVertex = new Vertex(currentPoint);
                    List<Vertex> vertices = new List<Vertex>();
                    vertices.Add(newVertex);
                    Polygon newPolygon = new Polygon(vertices, new List<Edge>(), currentColor);
                    if (Drawer.canDrawVertex(newVertex, (Bitmap)drawingPictureBox.Image) == true)
                    {
                        actionsToUndo.Add(new Action("Added vertex", polygons, circles, currentColor));
                        actionsToRedo = new List<Action>();
                        displayActions();
                        polygons.Add(newPolygon);
                        tipLabel.Text = "Added vertex.";                        
                        drawingPictureBox.Image = new Bitmap(drawingPictureBox.Size.Width, drawingPictureBox.Size.Height);
                        Drawer.drawAll(ref polygons, ref circles, (Bitmap)drawingPictureBox.Image);
                    }                    
                    return;
                }
                else if (polygons.Last().isCorrect == false)
                {
                    Vertex newVertex = new Vertex(currentPoint);
                    newEdge = new Edge(polygons.Last().vertices.Last(), newVertex);

                    if (Drawer.canDrawEdge(newEdge, (Bitmap)drawingPictureBox.Image) == true && Drawer.canDrawVertex(newVertex, (Bitmap)drawingPictureBox.Image) == true)
                    {
                        actionsToUndo.Add(new Action("Added vertex and edge", polygons, circles, currentColor));
                        actionsToRedo = new List<Action>();
                        displayActions();
                        polygons.Last().vertices.Add(newVertex);
                        polygons.Last().edges.Add(newEdge);
                        tipLabel.Text = "Added vertex and edge.";                        
                        drawingPictureBox.Image = new Bitmap(drawingPictureBox.Size.Width, drawingPictureBox.Size.Height);
                        Drawer.drawAll(ref polygons, ref circles, (Bitmap)drawingPictureBox.Image);
                    }
                }               
            }
            else if (circleButton.Checked == true)
            {
                if (((MouseEventArgs)e).Button == System.Windows.Forms.MouseButtons.Right && circles.Count > 0 && circles.Last().radius == -1)
                {
                    actionsToUndo.Add(new Action("Removed center", polygons, circles, currentColor));
                    actionsToRedo = new List<Action>();
                    displayActions();
                    circles.RemoveAt(circles.Count - 1);
                    tipLabel.Text = "Removed center.";

                    drawingPictureBox.Image = new Bitmap(drawingPictureBox.Size.Width, drawingPictureBox.Size.Height);
                    Drawer.drawAll(ref polygons, ref circles, (Bitmap)drawingPictureBox.Image);
                    return;
                }
                else if (((MouseEventArgs)e).Button == System.Windows.Forms.MouseButtons.Right) return;
                if (circles.Count == 0 || circles.Last().radius >= 0)
                {
                    actionsToUndo.Add(new Action("Added center", polygons, circles, currentColor));
                    actionsToRedo = new List<Action>();
                    displayActions();
                    Vertex newVertex = new Vertex(currentPoint);
                    if (Drawer.canDrawVertex(newVertex, (Bitmap)drawingPictureBox.Image) == false) return;
                    Circle newCircle = new Circle(currentPoint, -1, currentColor);
                    circles.Add(newCircle);
                    tipLabel.Text = "Added center.";
                    drawingPictureBox.Image = new Bitmap(drawingPictureBox.Size.Width, drawingPictureBox.Size.Height);
                    Drawer.drawAll(ref polygons, ref circles, (Bitmap)drawingPictureBox.Image);
                    return;
                }
                else
                {
                    int radius = (int)Drawer.distance(circles.Last().center, currentPoint);
                    Circle c = new Circle(circles.Last().center, radius, currentColor);
                    if (c.canDraw((Bitmap)drawingPictureBox.Image) == false)
                    {
                        circles.RemoveAt(circles.Count - 1);
                        return;
                    }
                    actionsToUndo.Add(new Action("Added circle", polygons, circles, currentColor));
                    actionsToRedo = new List<Action>();
                    displayActions();
                    circles.Last().radius = radius;
                    tipLabel.Text = "Added circle.";
                    drawingPictureBox.Image = new Bitmap(drawingPictureBox.Size.Width, drawingPictureBox.Size.Height);
                    Drawer.drawAll(ref polygons, ref circles, (Bitmap)drawingPictureBox.Image);
                    return;
                }
            }
        }

        private void DrawingPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            Point currentPoint = new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);

            drawingPictureBox.Image = new Bitmap(drawingPictureBox.Size.Width, drawingPictureBox.Size.Height);
            Drawer.drawAll(ref polygons, ref circles, (Bitmap)drawingPictureBox.Image);

            if (editButton.Checked == true && previousPoint.X != -1)
            {                
                if(vertexToMove != null)
                {
                    vertexToMove.changeCenter(currentPoint.X - previousPoint.X, currentPoint.Y - previousPoint.Y);
                    if(Drawer.canDrawVertex(vertexToMove, (Bitmap) drawingPictureBox.Image) == false)
                    {
                        vertexToMove.changeCenter(previousPoint.X - currentPoint.X, previousPoint.Y - currentPoint.Y);
                        return;
                    }
                    tipLabel.Text = "Moved vertex.";
                    previousPoint = currentPoint;
                    return;
                }
                if(edgeToMove != null)
                {
                    Polygon p = polygons.Find(a => a.edges.Contains(edgeToMove));
                    Vertex v1 = p.vertices.Find(a => a == edgeToMove.v1);
                    Vertex v2 = p.vertices.Find(a => a == edgeToMove.v2);

                    edgeToMove.changeVertices(currentPoint.X - previousPoint.X, currentPoint.Y - previousPoint.Y);
                    if(Drawer.canDrawVertex(edgeToMove.v1, (Bitmap)drawingPictureBox.Image) == false || Drawer.canDrawVertex(edgeToMove.v2, (Bitmap)drawingPictureBox.Image) == false)
                    {
                        edgeToMove.changeVertices(previousPoint.X - currentPoint.X, previousPoint.Y - currentPoint.Y);
                        return;
                    }

                    v1 = edgeToMove.v1;
                    v2 = edgeToMove.v2;
                    tipLabel.Text = "Moved edge.";
                    previousPoint = currentPoint;
                    return;
                }
                if (polygonToMove != null)
                {
                    polygonToMove.changePosition(currentPoint.X - previousPoint.X, currentPoint.Y - previousPoint.Y);
                    if(polygonToMove.canDraw((Bitmap)drawingPictureBox.Image) == false)
                    {
                        polygonToMove.changePosition(previousPoint.X - currentPoint.X, previousPoint.Y - currentPoint.Y);
                        return;
                    }
                    tipLabel.Text = "Moved polygon.";
                    previousPoint = currentPoint;
                    return;
                }
                if (circleToChange != null)
                {
                    circleToChange.changeRadius(currentPoint);
                    if(circleToChange.canDraw((Bitmap)drawingPictureBox.Image) == false)
                    {
                        circleToChange.changeRadius(previousPoint);
                        return;
                    }
                    tipLabel.Text = "Changed radius.";
                    previousPoint = currentPoint;
                    return;
                }
                if (circleToMove != null)
                {
                    circleToMove.changeCenter(currentPoint.X - previousPoint.X, currentPoint.Y - previousPoint.Y);
                    if (circleToMove.canDraw((Bitmap)drawingPictureBox.Image) == false)
                    {
                        circleToMove.changeCenter(previousPoint.X - currentPoint.X, previousPoint.Y - currentPoint.Y);
                        return;
                    }
                    tipLabel.Text = "Moved circle.";
                    previousPoint = currentPoint;
                    return;
                }
            }
            else if (polygonButton.Checked == true)
            {
                Vertex newVertex = new Vertex(currentPoint);

                if (polygons.Count == 0 || polygons.Last().isCorrect == true)
                {
                    if(Drawer.canDrawVertex(newVertex, (Bitmap)drawingPictureBox.Image) == true)
                    {
                        Drawer.drawVertex(newVertex, currentColor, (Bitmap)drawingPictureBox.Image);
                    }
                }                    
                else if(polygons.Last().isCorrect == false)
                {
                    Edge newEdge = new Edge(polygons.Last().vertices.Last(), newVertex);

                    if (Drawer.canDrawEdge(newEdge, (Bitmap)drawingPictureBox.Image) == true && Drawer.canDrawVertex(newVertex, (Bitmap)drawingPictureBox.Image) == true)
                    {
                        Drawer.drawEdge(newEdge, currentColor, (Bitmap)drawingPictureBox.Image);
                        Drawer.drawVertex(newVertex, currentColor, (Bitmap)drawingPictureBox.Image);
                        return;
                    }
                }
            }
            else if(circleButton.Checked == true)
            {
                if (circles.Count == 0 || circles.Last().radius >= 0)
                {
                    Vertex newVertex = new Vertex(currentPoint);
                    if (Drawer.canDrawVertex(newVertex, (Bitmap)drawingPictureBox.Image) == false) return;
                    Drawer.drawVertex(newVertex, currentColor, (Bitmap)drawingPictureBox.Image);
                    return;
                }
                else
                {
                    int radius = (int)Drawer.distance(circles.Last().center, currentPoint);
                    Circle c = new Circle(circles.Last().center, radius, currentColor);
                    if (c.canDraw((Bitmap)drawingPictureBox.Image) == false) return;
                    c.Draw((Bitmap)drawingPictureBox.Image);
                    return;
                }
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            drawingPictureBox.Image = new Bitmap(drawingPictureBox.Width, drawingPictureBox.Height);
            pixelsOfVertices = new Vertex[drawingPictureBox.Image.Width, drawingPictureBox.Image.Height];
            pixelsOfEdges = new Edge[drawingPictureBox.Image.Width, drawingPictureBox.Image.Height];
            polygons = new List<Polygon>();
            circles = new List<Circle>();
            actionsToRedo = new List<Action>();
            actionsToUndo = new List<Action>();
            displayActions();
            tipLabel.Text = "";
        }

        private void Button_CheckedChanged(object sender, EventArgs e)
        {
            tipLabel.Text = "";
            drawingPictureBox.Image = new Bitmap(drawingPictureBox.Size.Width, drawingPictureBox.Size.Height);
            if (polygons.Count > 0 && polygons.Last().isCorrect == false)
            {
                while (actionsToUndo.Count > 0 && actionsToUndo.Last().polygons.Count > 0 && actionsToUndo.Last().polygons.Last().isCorrect == false)
                {
                    actionsToUndo.RemoveAt(actionsToUndo.Count - 1);
                }
                actionsToRedo = new List<Action>();
                actionsToUndo.RemoveAt(actionsToUndo.Count - 1);

                polygons.RemoveAt(polygons.Count - 1);
            }
            else if (circles.Count > 0 && circles.Last().radius == -1)
            {
                actionsToUndo.RemoveAt(actionsToUndo.Count - 1);
                actionsToRedo = new List<Action>();
                circles.RemoveAt(circles.Count - 1);
            }
            displayActions();
            Drawer.drawAll(ref polygons, ref circles, (Bitmap)drawingPictureBox.Image);
        }

        private void DrawingPictureBox_SizeChanged(object sender, EventArgs e)
        {
            drawingPictureBox.Image = new Bitmap(drawingPictureBox.Size.Width, drawingPictureBox.Size.Height);                
            if (polygons.Count > 0 && polygons.Last().isCorrect == false && polygons.Last().canDraw((Bitmap)drawingPictureBox.Image) == false)
            {
                while (actionsToUndo.Count > 0 && actionsToUndo.Last().polygons.Count > 0 && actionsToUndo.Last().polygons.Last().isCorrect == false)
                {
                    actionsToUndo.RemoveAt(actionsToUndo.Count - 1);
                }
                actionsToRedo = new List<Action>();
                actionsToUndo.RemoveAt(actionsToUndo.Count - 1);

                polygons.RemoveAt(polygons.Count - 1);
            }
            else if (circles.Count > 0 && circles.Last().radius == -1 && circles.Last().canDraw((Bitmap)drawingPictureBox.Image) == false)
            {
                actionsToUndo.RemoveAt(actionsToUndo.Count - 1);
                actionsToRedo = new List<Action>();
                circles.RemoveAt(circles.Count - 1);
            }
            displayActions();
            Drawer.drawAll(ref polygons, ref circles, (Bitmap)drawingPictureBox.Image);
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
                colorButton.BackColor = colorDialog.Color;
        }

        private void ColorButton_BackColorChanged(object sender, EventArgs e)
        {
            actionsToUndo.Add(new Action("Change of color", polygons, circles, currentColor));
            actionsToRedo = new List<Action>();
            displayActions();
            currentColor = colorDialog.Color;

            if (polygons.Count > 0 && polygons.Last().isCorrect == false) polygons.Last().color = currentColor;
            else if (circles.Count > 0 && circles.Last().radius == -1) circles.Last().color = currentColor;

            drawingPictureBox.Image = new Bitmap(drawingPictureBox.Size.Width, drawingPictureBox.Size.Height);
            Drawer.drawAll(ref polygons, ref circles, (Bitmap)drawingPictureBox.Image);
        }

        private void DrawingPictureBox_MouseLeave(object sender, EventArgs e)
        {
            drawingPictureBox.Image = new Bitmap(drawingPictureBox.Size.Width, drawingPictureBox.Size.Height);
            Drawer.drawAll(ref polygons, ref circles, ((Bitmap)drawingPictureBox.Image));
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
            {
                if (polygonButton.Checked == true)
                    DrawingPictureBox_Click(sender, new MouseEventArgs(MouseButtons.Middle, 1, 0, 0, 0));
            }               
            else if (e.Control && e.Shift && e.KeyCode == Keys.Z)
            {
                redoButton_Click(sender, e);
            }
            else if(e.Control && e.KeyCode == Keys.Z)
            {
                undoButton_Click(sender, e);
            }
        }

        private void drawingPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (editButton.Checked == true)
            {
                previousPoint = e.Location;
                if (e.Button == System.Windows.Forms.MouseButtons.Right) return;
                vertexToMove = Editor.searchForVertex(previousPoint);
                Point tmp = new Point(0, 0);
                if (vertexToMove == null) edgeToMove = Editor.searchForPolygonEdge(previousPoint, ref tmp);
                else
                {
                    actionsToUndo.Add(new Action("Moved vertex", polygons, circles, currentColor));
                    actionsToRedo = new List<Action>();
                    return;
                }
                if (edgeToMove == null) polygonToMove = Editor.searchForPolygon(previousPoint);
                else
                {
                    actionsToUndo.Add(new Action("Moved edge", polygons, circles, currentColor));
                    actionsToRedo = new List<Action>();
                    return;
                }
                if (polygonToMove == null) circleToChange = Editor.searchForCircleEdge(previousPoint);
                else
                {
                    actionsToUndo.Add(new Action("Moved polygon", polygons, circles, currentColor));
                    actionsToRedo = new List<Action>();
                    return;
                }
                if (circleToChange == null) circleToMove = Editor.searchForCircle(previousPoint);
                else
                {
                    actionsToUndo.Add(new Action("Changed radius", polygons, circles, currentColor));
                    actionsToRedo = new List<Action>();
                    return;
                }
                if(circleToMove != null)
                {                    
                    {
                        actionsToUndo.Add(new Action("Moved circle", polygons, circles, currentColor));
                        actionsToRedo = new List<Action>();
                        return;
                    }
                }
            }
        }

        private void drawingPictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Left && editButton.Checked == true && previousPoint.X != -1)
            {
                Point exactPoint = new Point(0, 0);
                Edge edge = Editor.searchForPolygonEdge(previousPoint, ref exactPoint);
                if(edge != null)
                {
                    actionsToUndo.RemoveAt(actionsToUndo.Count - 1);
                    actionsToUndo.RemoveAt(actionsToUndo.Count - 1);
                    actionsToUndo.Add(new Action("Added vertex on edge", polygons, circles, currentColor));
                    actionsToRedo = new List<Action>();
                    displayActions();
                    Vertex newVertex = new Vertex(exactPoint);
                    Polygon p = polygons.Find(a => a.edges.Contains(edge));
                    Edge newEdge = new Edge(edge.v1, newVertex);
                    Edge newEdge2 = new Edge(newVertex, edge.v2);
                    
                    p.edges.Insert(p.edges.IndexOf(edge), newEdge);
                    p.edges.Insert(p.edges.IndexOf(edge), newEdge2);
                    p.edges.Remove(edge);
                    p.vertices.Insert(p.vertices.IndexOf(edge.v2), newVertex);
                    tipLabel.Text = "Added vertex on edge.";
                }
                previousPoint.X = -1;
            }
        }

        private void displayActions()
        {
            List<String> descriptions = new List<string>();
            if (actionsToRedo.Count > 0)
            {
                descriptions.Add("Actions to redo:");
                descriptions.Add(Environment.NewLine);
                for(int i = actionsToRedo.Count - 1; i >= 0; i--)
                    descriptions.Add("- " + actionsToRedo[i].description);
                descriptions.Add(Environment.NewLine);
            }
            if(actionsToUndo.Count > 0)
            {
                descriptions.Add("Actions to undo:");
                descriptions.Add(Environment.NewLine);
                for (int i = actionsToUndo.Count - 1; i >= 0; i--)
                    descriptions.Add("- " + actionsToUndo[i].description);
            }
            actionsTextBox.Text = String.Join(Environment.NewLine, descriptions);
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            if (actionsToUndo.Count == 0)
            {
                tipLabel.Text = "No actions to undo.";
                return;
            }
            Action action = actionsToUndo.Last();

            if(action.polygons.Find(a => a.isCorrect == false && a.canDraw((Bitmap)drawingPictureBox.Image) == false) != null)
            {
                tipLabel.Text = "Cannot change not visible figure";
                return;
            }

            if (action.circles.Find(a => a.radius == -1 && a.canDraw((Bitmap)drawingPictureBox.Image) == false) != null)
            {
                tipLabel.Text = "Cannot change not visible figure";
                return;
            }



            if (action.circles.Count > 0 && action.circles.Last().radius == -1) circleButton.Checked = true;
            if (action.polygons.Count > 0 && action.polygons.Last().isCorrect == false) polygonButton.Checked = true;
            actionsToRedo.Add(new Action(action.description, polygons, circles, currentColor));
            actionsToUndo.Remove(action);
            tipLabel.Text = "Undone " + action.description;
            polygons = action.polygons;
            circles = action.circles;
            currentColor = action.currentColor;
            displayActions();
            drawingPictureBox.Image = new Bitmap(drawingPictureBox.Size.Width, drawingPictureBox.Size.Height);
            Drawer.drawAll(ref polygons, ref circles, (Bitmap)drawingPictureBox.Image);
        }

        private void redoButton_Click(object sender, EventArgs e)
        {
            if (actionsToRedo.Count == 0)
            {
                tipLabel.Text = "No actions to redo.";
                return;
            }
            Action action = actionsToRedo.Last();
            
            if (action.polygons.Find(a => a.isCorrect == false && a.canDraw((Bitmap)drawingPictureBox.Image) == false) != null)
            {
                tipLabel.Text = "Cannot change not visible figure";
                return;
            }

            actionsToUndo.Add(new Action(action.description, polygons, circles, currentColor));
            actionsToRedo.Remove(action);
            tipLabel.Text = "Redone " + action.description;
            polygons = action.polygons;
            circles = action.circles;
            currentColor = action.currentColor;
            displayActions(); 
            drawingPictureBox.Image = new Bitmap(drawingPictureBox.Size.Width, drawingPictureBox.Size.Height);
            Drawer.drawAll(ref polygons, ref circles, (Bitmap)drawingPictureBox.Image);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "txt files (*.txt)|*.txt";
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                foreach(Polygon p in polygons)
                {
                    if (p.isCorrect == false) continue;
                    string s = "P" + polygons.IndexOf(p) + ": color:" + p.color.R + "," + p.color.G + "," + p.color.B + ": vertices:";
                    for(int i = 0; i < p.vertices.Count; i++)
                    {
                        s += "v" + i + ":" + p.vertices[i].center.X + "," + p.vertices[i].center.Y + ": ";
                    }
                    sw.WriteLine(s);
                }
                foreach(Circle c in circles)
                {
                    if (c.radius == -1) continue;
                    string s = "C" + circles.IndexOf(c) + ": color:" + c.color.R + "," + c.color.G + "," + c.color.B + ": center: " + c.center.X + "," + c.center.Y + ": radius:" + c.radius;
                    sw.WriteLine(s);
                }

                sw.Close();
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {            
            openFileDialog.Filter = "txt files (*.txt)|*.txt";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.CheckFileExists == false) return;
                StreamReader sr = new StreamReader(openFileDialog.FileName);
                ClearButton_Click(sender, e);
                while(sr.EndOfStream != true)
                {
                    string s = sr.ReadLine();
                    if (s[0] == 'C')
                    {
                        string[] components = s.Split(':');
                        string[] colors = components[2].Split(',');
                        Color color = Color.FromArgb(Int32.Parse(colors[0]), Int32.Parse(colors[1]), Int32.Parse(colors[2]));
                        string[] centers = components[4].Split(',');
                        Point center = new Point(Int32.Parse(centers[0]), Int32.Parse(centers[1]));
                        int radius = Int32.Parse(components[6]);
                        circles.Add(new Circle(center, radius, color));
                    }
                    if(s[0] == 'P')
                    {
                        List<Vertex> vert = new List<Vertex>();
                        string[] components = s.Split(':');
                        string[] colors = components[2].Split(',');
                        Color color = Color.FromArgb(Int32.Parse(colors[0]), Int32.Parse(colors[1]), Int32.Parse(colors[2]));
                        for(int i = 5; i < components.Count(); i += 2)
                        {
                            string[] vertices = components[i].Split(',');
                            Point v = new Point(Int32.Parse(vertices[0]), Int32.Parse(vertices[1]));
                            vert.Add(new Vertex(v));
                        }
                        List<Edge> edges = new List<Edge>();
                        if (vert.Count == 1) polygons.Add(new Polygon(vert, edges, color));
                        else
                        {
                            for(int i = 0; i < vert.Count - 1; i++)
                                edges.Add(new Edge(vert[i], vert[i + 1]));
                            edges.Add(new Edge(vert.Last(), vert.First()));
                            polygons.Add(new Polygon(vert, edges, color));
                            polygons.Last().isCorrect = true;
                        }
                    }
                }                
                sr.Close();
                Drawer.drawAll(ref polygons, ref circles, (Bitmap)drawingPictureBox.Image);
            }
        }
    }
}