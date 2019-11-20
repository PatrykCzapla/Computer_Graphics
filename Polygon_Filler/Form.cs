using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polygon_Filler
{
    public partial class Form : System.Windows.Forms.Form
    {
        private bool useWeiler = true;

        Stopwatch stopwatch = new Stopwatch();
        int FPScounter = 0;

        public static DirectBitmap dbm = null;
        
        private Image backgroundImage = null;
        public static DirectBitmap backgroundDBM = null;

        private Image bumpMapImage = null;
        public static DirectBitmap bumpMap = null;
        public static float[,] heightMap;
        
        public static Icon icon = new Icon(new Point(100, 100));
        public static float[] colorOfLight = new float[3];
        public static float[] lightVector = new float[3];

        public static Color[,] colorsToFill;

        private int speed = 0;
        private List<Polygon> clippedPolygons = new List<Polygon>();
        
        public static List<Polygon> polygons = new List<Polygon>();
        public static List<ConvexPolygon> convexPolygons = new List<ConvexPolygon>();
        
        private Point previousPoint = new Point(-1, -1);
        private Vertex markedVertex = null;
        private Polygon markedPolygon = null;

        public Form()
        {
            InitializeComponent();
            toolTip.SetToolTip(clearButton, "Clear everything.");
            toolTip.SetToolTip(polygonRadioButton, "Draw polygon." + Environment.NewLine + "Left-click to add vertices." + Environment.NewLine + "Right-click to remove last drawn vertex." + Environment.NewLine + "Middle-click or Ctrl + Enter to close polygon.");
            toolTip.SetToolTip(editRadioButton, "Edit polygon." + Environment.NewLine + "Left-click + drag to move vertex or polygon." + Environment.NewLine + "Right-click to remove polygon.");
            toolTip.SetToolTip(noOfVerticesDomain, "Convex polygons will be based on the given number of random vertices. Max: 5, Min: 3.");
            toolTip.SetToolTip(noOfConvexDomain, "Number of random convex polygons to generate. Max: 3, Min: 1.");
            toolTip.SetToolTip(heightOfLightTextBox, "Height of light. Min: 1.");
            toolTip.SetToolTip(lightPositionRadioButton, "Set light in different position." + Environment.NewLine + "Left-click to set position.");
            toolTip.SetToolTip(changeClippingButton, "Switches clliping algorithm between Weiler-Atherton and Sutherland-Hodgman.");
                       
            clearButton_Click(null, null);
            drawAllPolygons();
        }

        private void drawAllPolygons()
        {
            dbm.Dispose();
            dbm = new DirectBitmap(drawingPictureBox.Size.Width, drawingPictureBox.Size.Height);
            foreach (Polygon p in polygons)
                p.Draw();
            foreach (Polygon p in convexPolygons)
                p.Draw();
            foreach (Polygon p in clippedPolygons)
                p.Draw();
            icon.Draw(lightColorButton.BackColor);
            drawingPictureBox.Image = dbm.Bitmap;            
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            if (timer.Enabled == true) return;

            dbm = new DirectBitmap(drawingPictureBox.Width, drawingPictureBox.Height);
            drawingPictureBox.Image = dbm.Bitmap;
            
            backgroundImage = null;
            backgroundDBM = null;
            textureButton.Image = null;

            bumpMapImage = null;
            bumpMap = null;
            heightMap = null;
            bumpMapButton.Image = null;

            icon = new Icon(new Point(100, 100));
            colorOfLight = new float[] { (float)lightColorButton.BackColor.R / (float)255, (float)lightColorButton.BackColor.G / (float)255, (float)lightColorButton.BackColor.B / (float)255};
            try
            {
                int height = Int32.Parse(heightOfLightTextBox.Text);
                if (height < 1)
                {
                    heightOfLightTextBox.Text = "1";
                    height = 1;
                }
                lightVector = new float[] { (float)icon.center.X, (float)icon.center.Y, (float)Int32.Parse(heightOfLightTextBox.Text) };
            }
            catch(Exception exception)
            {
                heightOfLightTextBox.Text = lightVector[2].ToString();
                Console.WriteLine(exception.Message);                
            }

            clippedPolygons = new List<Polygon>();
            
            polygons = new List<Polygon>();
            convexPolygons = new List<ConvexPolygon>();

            previousPoint = new Point(-1, -1);
            markedVertex = null;
            markedPolygon = null;

            this.FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void drawingPictureBox_Click(object sender, EventArgs e)
        {
            Point currentPoint = new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);

            if (lightPositionRadioButton.Checked == true)
            {
                icon.center.X = currentPoint.X;
                icon.center.Y = currentPoint.Y;
                try
                {
                    int height = Int32.Parse(heightOfLightTextBox.Text);
                    if (height < 1)
                    {
                        heightOfLightTextBox.Text = "1";
                        height = 1;
                    }
                    lightVector = new float[] { (float)icon.center.X, (float)icon.center.Y, (float)height };
                }
                catch (Exception exception)
                {
                    heightOfLightTextBox.Text = lightVector[2].ToString();
                    Console.WriteLine(exception.Message);
                }
                Tools.makeColors();
                drawAllPolygons();
            }

            if (timer.Enabled == true) return;

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
                }
                else if (((MouseEventArgs)e).Button == MouseButtons.Middle)
                {
                    if (polygons.Count == 0 || polygons.Last().isCorrect == true || polygons.Last().vertices.Count < 3) return;
                    Edge newEdge = new Edge(polygons.Last().vertices.Last(), polygons.Last().vertices.First());                    
                    if (newEdge.canDraw(polygons.Last().edges) == true)
                        polygons.Last().edges.Add(newEdge);
                    else return;
                    polygons.Last().isCorrect = true;
                    polygons.Last().checkVerticesOrder();
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
                        if (markedVertex == icon) return;
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
                    }
                    else if (markedPolygon != null)
                    {
                        polygons.Remove(markedPolygon);
                        previousPoint.X = -1;
                    }
                }
            }            
        }

        private void drawingPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (clippedPolygons.Count > 0) clippedPolygons = new List<Polygon>();
            if (timer.Enabled == true) return;


            Point currentPoint = new Point(e.X, e.Y);
            drawAllPolygons();
            button1_Click(sender, e);

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
            }
        }

        private void drawingPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (timer.Enabled == true) return;
            if (markedPolygon != null) markedPolygon.color = Color.Black;
            markedPolygon = null;
            if(editRadioButton.Checked == true)
            {
                previousPoint = e.Location;
                markedVertex = Tools.searchForVertex(previousPoint);
                if (markedVertex == null)
                    markedPolygon = Tools.searchForPolygon(previousPoint);
                if (markedPolygon != null)
                    markedPolygon.color = Color.Red;
                drawAllPolygons();
            }
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            if (timer.Enabled == true) return;

            if (polygons.Count > 0 && polygons.Last().isCorrect == false)
                polygons.RemoveAt(polygons.Count - 1);
            drawAllPolygons();
        }

        private void drawingPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (timer.Enabled == true) return;

            markedVertex = null;
            drawAllPolygons();
        }

        private void drawingPictureBox_SizeChanged(object sender, EventArgs e)
        {
            drawAllPolygons();

            backgroundDBM = new DirectBitmap(dbm.Width, dbm.Height);
            if(backgroundImage != null)
            {
                Bitmap tmp = new Bitmap(backgroundImage, new Size(dbm.Width, dbm.Height));
                for (int i = 0; i < tmp.Width; i++)
                    for (int j = 0; j < tmp.Height; j++)
                        backgroundDBM.SetPixel(i, j, Color.FromArgb(tmp.GetPixel(i, j).R, tmp.GetPixel(i, j).G, tmp.GetPixel(i, j).B));
                tmp.Dispose();
            }

            bumpMap = new DirectBitmap(dbm.Width, dbm.Height);
            if (bumpMapImage != null)
            {
                Bitmap tmp = new Bitmap(bumpMapImage, new Size(dbm.Width, dbm.Height));
                for (int i = 0; i < tmp.Width; i++)
                    for (int j = 0; j < tmp.Height; j++)
                        bumpMap.SetPixel(i, j, Color.FromArgb(tmp.GetPixel(i, j).R, tmp.GetPixel(i, j).G, tmp.GetPixel(i, j).B));
                tmp.Dispose();
            }

            heightMap = new float[bumpMap.Width, bumpMap.Height];
            for (int i = 0; i < heightMap.GetLength(0); i++)
                for (int j = 0; j < heightMap.GetLength(1); j++)
                    heightMap[i, j] = bumpMap.GetPixel(i, j).R;
        }

        private void lightColorButton_Click(object sender, EventArgs e)
        {
            if (fillingColorDialog.ShowDialog() == DialogResult.OK)
            {
                lightColorButton.BackColor = fillingColorDialog.Color;                
                colorOfLight = new float[] { (float)lightColorButton.BackColor.R / (float)255, (float)lightColorButton.BackColor.G / (float)255, (float)lightColorButton.BackColor.B / (float)255 };
            }
            Tools.makeColors();
            drawAllPolygons();
        }

        private void textureButton_Click(object sender, EventArgs e)
        {
            if (timer.Enabled == true) return;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png, *.jpg, *.jpeg)|*.png; *.jpg; *.jpeg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.CheckFileExists == false) return;
                backgroundDBM = new DirectBitmap(dbm.Width, dbm.Height);

                Bitmap tmp = new Bitmap(Image.FromFile(openFileDialog.FileName), new Size(dbm.Width, dbm.Height));
                for (int i = 0; i < tmp.Width; i++)
                    for (int j = 0; j < tmp.Height; j++)
                        backgroundDBM.SetPixel(i, j, Color.FromArgb(tmp.GetPixel(i, j).R, tmp.GetPixel(i, j).G, tmp.GetPixel(i, j).B));
                textureButton.Image = Image.FromFile(openFileDialog.FileName);
                tmp.Dispose();
                backgroundImage = Image.FromFile(openFileDialog.FileName);
            }
            Tools.makeColors();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void bumpMapButton_Click(object sender, EventArgs e)
        {
            if (timer.Enabled == true) return;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png, *.jpg, *.jpeg)|*.png; *.jpg; *.jpeg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.CheckFileExists == false) return;
                bumpMap = new DirectBitmap(dbm.Width, dbm.Height);

                Bitmap tmp = new Bitmap(Image.FromFile(openFileDialog.FileName), new Size(dbm.Width, dbm.Height));
                for (int i = 0; i < tmp.Width; i++)
                    for (int j = 0; j < tmp.Height; j++)
                        bumpMap.SetPixel(i, j, Color.FromArgb(tmp.GetPixel(i, j).R, tmp.GetPixel(i, j).G, tmp.GetPixel(i, j).B));
                bumpMapButton.Image = Image.FromFile(openFileDialog.FileName);
                tmp.Dispose();
                bumpMapImage = Image.FromFile(openFileDialog.FileName);

                heightMap = new float[bumpMap.Width, bumpMap.Height];
                for(int i = 0; i < heightMap.GetLength(0); i++)
                    for (int j = 0; j < heightMap.GetLength(1); j++)
                        heightMap[i, j] = bumpMap.GetPixel(i, j).R;
            }
            Tools.makeColors();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void heightOfLightTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int height = Int32.Parse(heightOfLightTextBox.Text);
                if (height < 1)
                {
                    heightOfLightTextBox.Text = "1";
                    height = 1;
                }
                lightVector = new float[] { (float)icon.center.X, (float)icon.center.Y, (float)height };
            }
            catch (Exception exception)
            {
                heightOfLightTextBox.Text = lightVector[2].ToString();
                Console.WriteLine(exception.Message);
            }
            Tools.makeColors();
            drawAllPolygons();
        }

        private void generateConvexButton_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();
            FPScounter = 0;
            convexPolygons = new List<ConvexPolygon>();
            Random rand = new Random();
            try
            {
                int noOfCovex = Int32.Parse(noOfVerticesDomain.Text);
                if (noOfCovex > 5)
                {
                    noOfVerticesDomain.SelectedIndex = 0;
                    noOfCovex = 5;
                }
                if (noOfCovex < 1)
                {
                    noOfVerticesDomain.SelectedIndex = 2;
                    noOfCovex = 3;
                }

                int noOfPolygons = Int32.Parse(noOfConvexDomain.Text);
                if(noOfPolygons > 3)
                {
                    noOfConvexDomain.SelectedIndex = 0;
                    noOfPolygons = 3;
                }
                if (noOfPolygons < 1)
                {
                    noOfConvexDomain.SelectedIndex = 2;
                    noOfPolygons = 1;
                }
                for (int n = 0; n < noOfPolygons; n++)
                {
                    List<Vertex> convexVertices = new List<Vertex>();
                    for (int i = 0; i < noOfCovex; i++)
                        convexVertices.Add(new Vertex(new Point(rand.Next(2 * (drawingPictureBox.Image.Width / 3), drawingPictureBox.Image.Width - 1), rand.Next(0, drawingPictureBox.Image.Height - 1))));
                    List<Edge> edges = new List<Edge>();
                    ConvexPolygon cp = new ConvexPolygon(convexVertices, edges);
                    bool canAdd = true;
                    foreach(ConvexPolygon p1 in convexPolygons)
                    {
                        foreach (Edge edge in cp.edges)
                        {
                            if (p1.edges.Any(ed => Tools.linesIntersect(ed.v1.center, ed.v2.center, edge.v1.center, edge.v2.center) == true)) canAdd = false;
                        }
                        if (canAdd == true && (p1.vertices.Any(v => Tools.isInside(v.center, cp))) == true) canAdd = false;
                        if (canAdd == true && (cp.vertices.Any(v => Tools.isInside(v.center, p1))) == true) canAdd = false;
                    }
                    cp.checkVerticesOrder();
                    if (canAdd == true) convexPolygons.Add(cp);
                    else n--;
                }
                drawAllPolygons();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void startStopButton_Click(object sender, EventArgs e)
        {
            if (convexPolygons.Count == 0 || polygons.Count == 0) return;
            if(backgroundImage == null || bumpMapImage == null)
            {
                MessageBox.Show("Cannot run animation. Upload bump map and texture first.", "Cannot run animation!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (polygonRadioButton.Checked == true) lightPositionRadioButton.Checked = true;
            if (timer.Enabled)
            {
                startStopButton.Text = "Start animation";
                timer.Stop();
                stopwatch.Stop();
                return;
            }
            if(colorsToFill == null) Tools.makeColors();
            startStopButton.Text = "Stop animation";
            speed = speedTrackBar.Value;
            timer.Interval = 1;
            timer.Start();
            stopwatch.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            FPScounter++;
            if (convexPolygons.All(p => p.vertices.All(v => v.center.X < 0)))
            {
                timer.Stop();
                convexPolygons = new List<ConvexPolygon>();
                startStopButton.Text = "Start animation";
                stopwatch.Stop();
                Console.WriteLine("average FPS: " + (int)((double)FPScounter / ((double)stopwatch.ElapsedMilliseconds / (double)(1000))));
                return;
            }
            foreach (Polygon cp in convexPolygons)
                cp.Move(-1 * speed, 0);

            clippedPolygons = new List<Polygon>();
            
            if(useWeiler == true)
            {
                foreach (Polygon p in polygons)
                    foreach (Polygon cp in convexPolygons)
                        foreach (Polygon pol in Tools.WeilerAtherton(cp, p))
                        {
                            pol.isFilled = true;
                            clippedPolygons.Add(pol);
                        }
            }
            else
            {
                foreach (Polygon p in polygons)
                    foreach (Polygon cp in convexPolygons)
                    {

                    }

            }            
            drawAllPolygons();
        }

        private void speedTrackBar_ValueChanged(object sender, EventArgs e)
        {
            speed = speedTrackBar.Value;
        }

        private void changeClipping(object sender, EventArgs e)
        {
            if(useWeiler == true)
            {
                useWeiler = false;
                changeClippingButton.Text = "Change to Weiler-Atherton";
            }
            else
            {
                useWeiler = true;
                changeClippingButton.Text = "Change to Sutherland-Hodgman";
            }
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
                drawingPictureBox_Click(sender, new MouseEventArgs(MouseButtons.Middle, 1, 0, 0, 0));
            if (e.Control && e.KeyCode == Keys.A)
                startStopButton_Click(sender, e);
        }
                

                              
        //-----TEST-----//
        private void button1_Click(object sender, EventArgs e)
        {
            if (polygons.Count < 2 || polygons.Last().isCorrect == false) return;
            clippedPolygons = new List<Polygon>();
            clippedPolygons.AddRange(Tools.WeilerAtherton(polygons[1], polygons[0]));
            foreach (Polygon p in clippedPolygons) p.isFilled = true;
            drawAllPolygons();
        }
    }
}
