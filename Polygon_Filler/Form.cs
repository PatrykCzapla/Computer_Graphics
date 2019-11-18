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
        public static DirectBitmap dbm = null;
        
        private Image backgroundImage = null;
        public static DirectBitmap backgroundDBM = null;

        private Image bumpMapImage = null;
        public static DirectBitmap bumpMap = null;
        public static float[,] heightMap;
        
        public static Icon icon = new Icon(new Point(100, 100));
        public static float[] colorOfLight = new float[3];
        public static float[] lightVector = new float[3];
        
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
            //this.toolTip.SetToolTip(this.clearButton, "Clear everything.");
            //this.toolTip.SetToolTip(this.polygonRadioButton, "Draw polygon." + Environment.NewLine + "Left-click to add vertices." + Environment.NewLine + "Right-click to remove last drawn vertex." + Environment.NewLine + "Middle-click or Ctrl + Enter to close polygon.");
            //this.toolTip.SetToolTip(this.editRadioButton, "Edit polygon." + Environment.NewLine + "Left-click + drag to move vertex or polygon." + Environment.NewLine + "Right-click to remove polygon.");

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
            {
                p.colorOfFilling = colorOfFillingButton.BackColor;
                p.Draw();
                p.Fill();
            }
            icon.Draw(lightColorButton.BackColor);
            drawingPictureBox.Image = dbm.Bitmap;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy == true) return;

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
                Console.WriteLine(exception.Message);                
            }

            clippedPolygons = new List<Polygon>();
            
            polygons = new List<Polygon>();
            convexPolygons = new List<ConvexPolygon>();

            previousPoint = new Point(-1, -1);
            markedVertex = null;
            markedPolygon = null;
        }

        private void drawingPictureBox_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy == true) return;

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
            if (backgroundWorker.IsBusy == true) return;

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
                    if (markedVertex == icon)
                    {
                        try
                        {
                            lightVector = new float[] { (float)icon.center.X, (float)icon.center.Y, (float)Int32.Parse(heightOfLightTextBox.Text) };

                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }                        
                    }
                    Polygon currentPolygon = polygons.Find(p => p.vertices.Contains(markedVertex));
                    markedVertex.Move(currentPoint.X - previousPoint.X, currentPoint.Y - previousPoint.Y);
                    if (markedVertex == icon)
                    {
                        if (markedVertex.CanDraw() == false)
                            markedVertex.Move(previousPoint.X - currentPoint.X, previousPoint.Y - currentPoint.Y);
                        previousPoint = currentPoint;
                        return;
                    }
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
            if (backgroundWorker.IsBusy == true) return;

            if (markedPolygon != null) markedPolygon.color = Color.Black;
            markedPolygon = null;
            if(editRadioButton.Checked == true)
            {
                previousPoint = e.Location;
                markedVertex = Tools.searchForVertex(previousPoint);
                if (markedVertex == null)
                    markedPolygon = Tools.searchForPolygon(previousPoint);
                if(markedPolygon != null)
                {
                    markedPolygon.color = Color.Red;
                    drawAllPolygons();
                }
            }
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy == true) return;

            if (polygons.Count > 0 && polygons.Last().isCorrect == false)
                polygons.RemoveAt(polygons.Count - 1);
            drawAllPolygons();
        }

        private void drawingPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy == true) return;

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
            if (backgroundWorker.IsBusy == true) return;

            if (fillingColorDialog.ShowDialog() == DialogResult.OK)
            {
                lightColorButton.BackColor = fillingColorDialog.Color;                
                colorOfLight = new float[] { (float)lightColorButton.BackColor.R / (float)255, (float)lightColorButton.BackColor.G / (float)255, (float)lightColorButton.BackColor.B / (float)255 };
            }
        }

        private void colorOfFillingButton_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy == true) return;

            if (fillingColorDialog.ShowDialog() == DialogResult.OK)
                colorOfFillingButton.BackColor = fillingColorDialog.Color;
        }

        private void textureButton_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy == true) return;

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
        }

        private void bumpMapButton_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy == true) return;

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
                Console.WriteLine(exception.Message);
            }
        }

        private void generateConvexButton_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy == true) return;

            convexPolygons = new List<ConvexPolygon>();
            Random rand = new Random();
            try
            {
                int noOfCovex = Int32.Parse(noOfVerticesDomain.Text);
                if (noOfCovex > 15)
                {
                    noOfVerticesDomain.SelectedIndex = 0;
                    noOfCovex = 15;
                }
                int noOfPolygons = Int32.Parse(noOfConvexDomain.Text);
                if(noOfPolygons > 7)
                {
                    noOfConvexDomain.SelectedIndex = 0;
                    noOfPolygons = 7;
                }
                for (int n = 0; n < noOfPolygons; n++)
                {
                    List<Vertex> convexVertices = new List<Vertex>();
                    for (int i = 0; i < noOfCovex; i++)
                        convexVertices.Add(new Vertex(new Point(rand.Next(2 * (drawingPictureBox.Image.Width / 3), drawingPictureBox.Image.Width - 1), rand.Next(0, drawingPictureBox.Image.Height - 1))));
                    List<Edge> edges = new List<Edge>();
                    convexPolygons.Add(new ConvexPolygon(convexVertices, edges));
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
            if (backgroundWorker.IsBusy == false)
            {
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                speed = speedTrackBar.Value;
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            if (convexPolygons.Count == 0 || polygons.Count == 0) return;
            int maxX = 0;
            foreach (Polygon p in convexPolygons)
                foreach (Vertex v in p.vertices)
                    if (v.center.X > maxX) maxX = v.center.X;

            for (int i = maxX; i >= 0; i--)
            {
                if (convexPolygons.All(p => p.vertices.All(v => v.center.X < 0))) return;
                foreach (Polygon cp in convexPolygons)
                {
                    cp.Move(-1, 0);
                }

                clippedPolygons = new List<Polygon>();
                foreach (Polygon p in polygons)
                    foreach (Polygon cp in convexPolygons)
                        foreach (Polygon pol in Tools.WeilerAtherton(cp, p))
                            clippedPolygons.Add(pol);
                Thread.Sleep(100 / (2 * speed));
                worker.ReportProgress(((maxX / speed) - i) * (100 / (maxX / speed))); 
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            drawAllPolygons();
            drawingPictureBox.Refresh();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
                drawingPictureBox_Click(sender, new MouseEventArgs(MouseButtons.Middle, 1, 0, 0, 0));
        }
                







        //-----TESTY-----//
        private void button1_Click(object sender, EventArgs e)
        {
            //wypelnianie czesci wpsolnej dwoch pierwszych narysowanych wielokatow
            if (polygons.Count < 2 || polygons.Last().isCorrect == false) return;
            clippedPolygons = new List<Polygon>();
            clippedPolygons.AddRange(Tools.WeilerAtherton(polygons[1], polygons[0]));
            drawAllPolygons();

            ////wypisywanie info o wielokacie
            //foreach (Polygon p in polygons)
            //    foreach (Vertex v in p.vertices)
            //    {
            //        Console.WriteLine("Polygon no: " + polygons.IndexOf(p));
            //        Console.WriteLine("X: " + v.center.X + " Y: " + v.center.Y);
            //        Console.WriteLine("Intersection: " + v.IsIntersection);
            //        Console.WriteLine("Entry: " + v.IsEntry);
            //        Console.WriteLine("Inside: " + v.tmp);
            //        Console.WriteLine();
            //    }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ////testuje isInside
            if (polygons.Count < 2) return;
            List<Vertex> vertices = new List<Vertex>();
            if (polygons.Count > 2) polygons.RemoveAt(polygons.Count - 1);
            Random rand = new Random();
            for (int i = 0; i < 10000; i++)
                vertices.Add(new Vertex(new Point(rand.Next(0, dbm.Width - 1), rand.Next(0, dbm.Height - 1))));
            foreach (Polygon p in polygons)
                foreach (Vertex v in p.vertices)
                    vertices.Add(v);

            foreach (Polygon p in clippedPolygons)
                foreach (Vertex v in p.vertices)
                    vertices.Add(v);
            foreach (Vertex v in vertices)
                if (Tools.isInside(v.center, polygons.First()) || Tools.isInside(v.center, polygons[1]))
                    v.Inside = true;//koloruje wierzcholek ktory jest w srodku

            //if (polygons.Count < 2 || polygons.Last().isCorrect == false) return;
            //clippedPolygons = new List<Polygon>();
            //clippedPolygons.AddRange(Tools.WeilerAtherton(polygons[1], polygons[0]));
            //drawAllPolygons();
            //foreach (Polygon p in clippedPolygons)
            //    foreach (Vertex v in p.vertices)
            //    {
            //        Console.WriteLine("Polygon no: " + clippedPolygons.IndexOf(p));
            //        Console.WriteLine("X: " + v.center.X + " Y: " + v.center.Y);
            //        Console.WriteLine("Intersection: " + v.IsIntersection);
            //        Console.WriteLine("Entry: " + v.IsEntry);
            //        Console.WriteLine("Inside: " + v.Inside);
            //        Console.WriteLine();
            //    }
            //polygons.Add(new Polygon(vertices, new List<Edge>()));

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            markedPolygon.colorOfFilling = colorOfFillingButton.BackColor;
            if (markedPolygon != null) markedPolygon.Fill();
            drawAllPolygons();
        }

        
    }
}
