using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private List<Polygon> polygons = new List<Polygon>();

        public Form()
        {
            InitializeComponent();

            this.toolTip.SetToolTip(this.clearButton, "Clear everything.");
            this.toolTip.SetToolTip(this.polygodRadioButton, "Draw polygon." + Environment.NewLine + "Left-click to add vertices." + Environment.NewLine + "Right-click to remove last drawn vertex." + Environment.NewLine + "Middle-click or Ctrl + Enter to close polygon.");
            this.toolTip.SetToolTip(this.editRadioButton, "Edit polygon." + Environment.NewLine + "Left-click + drag to move vertex or polygon." + Environment.NewLine + "Right-click to remove polygon.");

            clearButton_Click(null, null);
        }

        private void drawAllPolygons()
        {
            foreach (Polygon p in polygons)
                p.Draw((Bitmap)drawingPictureBox.Image);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            polygons = new List<Polygon>();
            drawingPictureBox.Image = new Bitmap(drawingPictureBox.Width, drawingPictureBox.Height);
            pixelsOfEdges = new Edge[drawingPictureBox.Image.Width, drawingPictureBox.Image.Height];
            pixelsOfVertices = new Vertex[drawingPictureBox.Width, drawingPictureBox.Height];
        }

        private void drawingPictureBox_Click(object sender, EventArgs e)
        {
            Point currentPoint = new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);

            if (polygodRadioButton.Checked == true)
            {
                if (polygons.Count > 0 && polygons.Last().isCorrect == false && (polygons.Last().vertices.Find(a => (a.center.X == currentPoint.X && a.center.Y == currentPoint.Y)) != null)) return;


            }
        }
    }
}
