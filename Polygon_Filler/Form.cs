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
        private Image backgroundImage = null;
        public static DirectBitmap dbm = null;
        public static DirectBitmap backgroundDBM = null;

        private Icon icon = new Icon(new Point(100, 100));

        private Image bumpMapImage = null;
        public static DirectBitmap bumpMap = null;
        public static float[,] heightMap;

        public static float[] lightVector = new float[3];
        public static float[] colorOfLight = new float[3];
        public static Polygon lightPolygon;

        private bool animationOn = false;
        private int speed = 0;

        public static List<Polygon> polygons = new List<Polygon>();
        public static List<ConvexPolygon> convexPolygons = new List<ConvexPolygon>();

        private List<Polygon> clippedPolygons = new List<Polygon>();

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
        }

        private void drawAllPolygons()
        {
            dbm.Dispose();
            dbm = new DirectBitmap(drawingPictureBox.Size.Width, drawingPictureBox.Size.Height);
            foreach (Polygon p in polygons)
            {
                p.Draw();
            }
            foreach (Polygon p in convexPolygons)
            {
                p.Draw();
            }
            foreach (Polygon p in clippedPolygons)
            {
                p.colorOfFilling = colorOfFillingButton.BackColor;
                p.Draw();
                p.Fill();
            }
            lightPolygon.Draw();
            //Icon icon1 = new Icon("light_icon.ico", 10, 10);
            //Bitmap bmp = icon1.ToBitmap();
            //Graphics g = drawingPictureBox.CreateGraphics();
            //g.DrawIcon(icon1, 30, 30);
            icon.Draw(lightColorButton.BackColor);
            drawingPictureBox.Image = dbm.Bitmap;


            return;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            if (animationOn == true) return;
            List<Vertex> verticesOfLight = new List<Vertex>();
            List<Edge> edgesOfLight = new List<Edge>();
            verticesOfLight.Add(new Vertex(new Point(50, 40)));
            verticesOfLight.Add(new Vertex(new Point(70, 40)));
            verticesOfLight.Add(new Vertex(new Point(70, 60)));
            verticesOfLight.Add(new Vertex(new Point(50, 60)));
            for (int i = 0; i < verticesOfLight.Count - 1; i++)
                edgesOfLight.Add(new Edge(verticesOfLight[i], verticesOfLight[i + 1]));
            edgesOfLight.Add(new Edge(verticesOfLight.Last(), verticesOfLight.First()));
            lightPolygon = new Polygon(verticesOfLight, edgesOfLight);
            lightPolygon.colorOfFilling = lightColorButton.BackColor;
            lightPolygon.color = lightColorButton.BackColor;
            lightPolygon.isCorrect = true;
            lightPolygon.isFilled = true;



            colorOfLight = new float[] { (float)lightColorButton.BackColor.R / (float)255, (float)lightColorButton.BackColor.G / (float)255, (float)lightColorButton.BackColor.B / (float)255};
            try
            {
                lightVector = new float[] { (float)lightPolygon.vertices.First().center.X, (float)lightPolygon.vertices.First().center.Y, (float)Int32.Parse(heightOfLightTextBox.Text) };
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            polygons = new List<Polygon>();
            convexPolygons = new List<ConvexPolygon>();
            clippedPolygons = new List<Polygon>();
            textureButton.Image = null;
            bumpMapButton.Image = null;
            previousPoint = new Point(-1, -1);
            animationOn = false;
            heightMap = null;
            markedVertex = null;
            markedPolygon = null;
            backgroundDBM = null;
            bumpMap = null;
            bumpMapImage = null;
            animationOn = false;
            animationOn = false;
            dbm = new DirectBitmap(drawingPictureBox.Width, drawingPictureBox.Height);
            lightPolygon.Draw();
            drawingPictureBox.Image = dbm.Bitmap;
            return;
        }

        private void drawingPictureBox_Click(object sender, EventArgs e)
        {
            if (animationOn == true) return;
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
                        if (markedPolygon == lightPolygon) return;
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

        private void drawingPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (animationOn == true) return;
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
                    if (markedPolygon == lightPolygon)
                    {
                        try
                        {
                            lightVector = new float[] { (float)lightPolygon.vertices.First().center.X, (float)lightPolygon.vertices.First().center.Y, (float)Int32.Parse(heightOfLightTextBox.Text) };

                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                    }
                }
                previousPoint = currentPoint;
                return;
            }
        }

        private void drawingPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (animationOn == true) return;
            if (markedPolygon != null && markedPolygon != lightPolygon) markedPolygon.color = Color.Black;
            markedPolygon = null;
            if(editRadioButton.Checked == true)
            {
                previousPoint = e.Location;
                markedVertex = Tools.searchForVertex(previousPoint);
                if (markedVertex == null)
                    markedPolygon = Tools.searchForPolygon(previousPoint);
                if(markedPolygon != null)
                {
                    if (markedPolygon == lightPolygon) return;
                    markedPolygon.color = Color.Red;
                    drawAllPolygons();
                }
            }
            return;
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            if (animationOn == true) return;
            if (polygons.Count > 0 && polygons.Last().isCorrect == false)
                polygons.RemoveAt(polygons.Count - 1);
            drawAllPolygons();
            return;
        }

        private void drawingPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (animationOn == true) return;
            markedVertex = null;
            drawAllPolygons();
            return;
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
            return;
        }

        private void lightColorButton_Click(object sender, EventArgs e)
        {
            if (animationOn == true) return;
            if (fillingColorDialog.ShowDialog() == DialogResult.OK)
            {
                lightColorButton.BackColor = fillingColorDialog.Color;                
                colorOfLight = new float[] { (float)lightColorButton.BackColor.R / (float)255, (float)lightColorButton.BackColor.G / (float)255, (float)lightColorButton.BackColor.B / (float)255 };
                lightPolygon.color = lightColorButton.BackColor;
                lightPolygon.colorOfFilling = lightColorButton.BackColor;

            }
        }

        private void colorOfFillingButton_Click(object sender, EventArgs e)
        {
            if (animationOn == true) return;
            if (fillingColorDialog.ShowDialog() == DialogResult.OK)
                colorOfFillingButton.BackColor = fillingColorDialog.Color;
        }

        private void textureButton_Click(object sender, EventArgs e)
        {
            if (animationOn == true) return;
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
            if (animationOn == true) return;
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
                lightVector = new float[] { (float)lightPolygon.vertices.First().center.X, (float)lightPolygon.vertices.First().center.Y, (float)height };
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void generateConvexButton_Click(object sender, EventArgs e)
        {
            if (animationOn == true) return;
            convexPolygons = new List<ConvexPolygon>();
            Random rand = new Random();
            try
            {
                int noOfCovex = Int32.Parse(convexDomain.Text);
                if (noOfCovex > 15)
                {
                    convexDomain.SelectedIndex = 0;
                    noOfCovex = 15;
                }
                int noOfPolygons = Int32.Parse(convexNoDomain.Text);
                if(noOfPolygons > 7)
                {
                    convexNoDomain.SelectedIndex = 0;
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
                return;
            }
        }

        private void startStopButton_Click(object sender, EventArgs e)
        {           
            if (animationOn == false && backgroundWorker.IsBusy == false)
            {
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                speed = speedTrackBar.Value;
                backgroundWorker.RunWorkerAsync();
                animationOn = true;
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
                //foreach (Polygon p in polygons)
                //    foreach (Polygon cp in convexPolygons)
                //        foreach (Polygon pol in Tools.WeilerAtherton(cp, p))
                //            clippedPolygons.Add(pol);
                if (convexPolygons[0].vertices.Any(v => Tools.isInside(v.center, polygons[0]))) clippedPolygons.Add(convexPolygons[0]);
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
            animationOn = false;
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
            //if (polygons.Count < 2) return;
            //List<Vertex> vertices = new List<Vertex>();
            //if (polygons.Count > 2)polygons.RemoveAt(polygons.Count - 1);
            //Random rand = new Random();
            //for (int i = 0; i < 10000; i++)
            //    vertices.Add(new Vertex(new Point(rand.Next(0, dbm.Width -1), rand.Next(0, dbm.Height - 1))));
            //foreach (Polygon p in polygons)
            //    foreach (Vertex v in p.vertices)
            //        vertices.Add(v);

            //foreach (Polygon p in clippedPolygons)
            //    foreach (Vertex v in p.vertices)
            //        vertices.Add(v);
            //foreach (Vertex v in vertices)
            //if (Tools.isInside2(v, polygons.First()) || Tools.isInside2(v, polygons[1]))
            // v.tmp = true;//koloruje wierzcholek ktory jest w srodku

            if (polygons.Count < 2 || polygons.Last().isCorrect == false) return;
            clippedPolygons = new List<Polygon>();
            clippedPolygons.AddRange(Tools.WeilerAtherton(polygons[1], polygons[0]));
            drawAllPolygons();
            foreach (Polygon p in clippedPolygons)
                foreach (Vertex v in p.vertices)
                {
                    Console.WriteLine("Polygon no: " + clippedPolygons.IndexOf(p));
                    Console.WriteLine("X: " + v.center.X + " Y: " + v.center.Y);
                    Console.WriteLine("Intersection: " + v.IsIntersection);
                    Console.WriteLine("Entry: " + v.IsEntry);
                    Console.WriteLine("Inside: " + v.Inside);
                    Console.WriteLine();
                }
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
