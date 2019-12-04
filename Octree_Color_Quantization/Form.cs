using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Octree_Color_Quantization
{
    public partial class Form : System.Windows.Forms.Form
    {
        private Image initialImage;
        private Bitmap copyImage;

        private int colorsCount = 256;
        private bool canReduce = true;

        private Stopwatch stopwatch = new Stopwatch();

        public Form()
        {
            InitializeComponent();

            this.toolTip.SetToolTip(initialPictureBox, "Original image.");
            this.toolTip.SetToolTip(afterPictureBox, "Image with reduction used after insertion.");
            this.toolTip.SetToolTip(alongPictureBox, "Image with reduction used along insertion.");
            this.toolTip.SetToolTip(colorCountTextBox, "Number from range [1, 16777216].");
            this.toolTip.SetToolTip(infoLabel, "Information about reduction process.");
            this.toolTip.SetToolTip(reduceButton, "Starts/cancels reduction if target number of colors is correct number and if image is loaded.");
            this.toolTip.SetToolTip(afterProgressBar, "Progress of reduction after insertion.");
            this.toolTip.SetToolTip(alongProgressBar, "Progress of reduction along insertion.");
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            if (afterBackgroundWorker.IsBusy == true || alongBackgroundWorker.IsBusy == true)
            {
                MessageBox.Show("Cannot load image while reduction in progess.", "Reduction in progress", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png, *.jpg, *.jpeg)|*.png; *.jpg; *.jpeg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.CheckFileExists == false) return;
                initialImage = Image.FromFile(openFileDialog.FileName);
                initialPictureBox.Image = initialImage;
            }
        }

        private void reduceButton_Click(object sender, EventArgs e)
        {
            if (afterBackgroundWorker.IsBusy == true || alongBackgroundWorker.IsBusy == true)
            {
                infoLabel.Text = "";
                afterBackgroundWorker.CancelAsync();
                alongBackgroundWorker.CancelAsync();
                afterProgressBar.Value = 0;
                alongProgressBar.Value = 0;
                afterProgressBar.Visible = false;
                alongProgressBar.Visible = false;
                reduceButton.Text = "Reduce to " + colorsCount + " colors";
                stopwatch.Stop();
                return;
            }
            if (initialImage == null)
            {
                MessageBox.Show("Cannot run reduction. Upload image first.", "No image loaded", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(canReduce == false)
            {
                MessageBox.Show("Cannot run reduction. Target number of colors must be value from range [1, 16777216].", "Wrong number format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            infoLabel.Text = "";
            copyImage = new Bitmap(initialPictureBox.Image);
            afterProgressBar.Visible = true;
            afterProgressBar.Maximum = 2 * (initialPictureBox.Image.Width * initialPictureBox.Image.Height);
            alongProgressBar.Visible = true;
            alongProgressBar.Maximum = 2 * (initialPictureBox.Image.Width * initialPictureBox.Image.Height);
            stopwatch.Reset();
            stopwatch.Start();
            alongBackgroundWorker.RunWorkerAsync();
            afterBackgroundWorker.RunWorkerAsync();
            reduceButton.Text = "Cancel reduction";
        }

        private void afterBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            TreeNode root = new TreeNode();
            root.level = 0;
            for (int x = 0; x < initialPictureBox.Image.Width; x++)
                for (int y = 0; y < initialPictureBox.Image.Height; y++)
                {
                    if(worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        return;
                    }
                    Tools.InsertTree(ref root, ((Bitmap)(initialPictureBox.Image)).GetPixel(x, y), ref root);
                    afterProgressBar.Invoke(new MethodInvoker(delegate
                    {
                        afterProgressBar.Value++;
                    }));
                }
            infoLabel.Invoke(new MethodInvoker(delegate { infoLabel.Text += "Number of colors in original picture: " + Tools.countColors(root); }));
            while (Tools.countColors(root) > colorsCount)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    return;
                }
                Tools.ReduceTree(root);
            }
            infoLabel.Invoke(new MethodInvoker(delegate { infoLabel.Text += Environment.NewLine + "Number of colors after reduction: " + Tools.countColors(root); }));
            Bitmap newImage = new Bitmap(initialPictureBox.Image.Width, initialPictureBox.Image.Height);
            for (int x = 0; x < newImage.Width; x++)
                for (int y = 0; y < newImage.Height; y++)
                {
                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        return;
                    }
                    newImage.SetPixel(x, y, Tools.getColor(root, ((Bitmap)(initialPictureBox.Image)).GetPixel(x, y)));
                    afterProgressBar.Invoke(new MethodInvoker(delegate
                    {
                        afterProgressBar.Value++;
                    }));
                }
            afterPictureBox.Image = newImage;
        }

        private void afterBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true) return;
            if(alongBackgroundWorker.IsBusy == false)
            {
                afterProgressBar.Value = 0;
                alongProgressBar.Value = 0;
                afterProgressBar.Visible = false;
                alongProgressBar.Visible = false;
                reduceButton.Text = "Reduce to " + colorsCount + "colors";
                stopwatch.Stop();
                MessageBox.Show("Time of reduction was: " + (stopwatch.ElapsedMilliseconds / 1000) + " seconds.", "Time of reduction", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void alongBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            TreeNode root = new TreeNode();
            root.level = 0;
            for (int x = 0; x < copyImage.Width; x++)
                for (int y = 0; y < copyImage.Height; y++)
                {
                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        return;
                    }
                    Tools.InsertTree(ref root, copyImage.GetPixel(x, y), ref root);
                    while (Tools.countColors(root) > colorsCount)
                    {
                        if (worker.CancellationPending == true)
                        {
                            e.Cancel = true;
                            return;
                        }
                        Tools.ReduceTree(root);
                    }
                    alongProgressBar.Invoke(new MethodInvoker(delegate
                    {
                        alongProgressBar.Value++;
                    }));
                }
            infoLabel.Invoke(new MethodInvoker(delegate { infoLabel.Text += Environment.NewLine + "Number of colors along reduction: " + Tools.countColors(root); }));
            Bitmap newImage = new Bitmap(copyImage.Width, copyImage.Height);
            for (int x = 0; x < newImage.Width; x++)
                for (int y = 0; y < newImage.Height; y++)
                {
                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        return;
                    }
                    if (root == null) continue;

                    newImage.SetPixel(x, y, Tools.getColor(root, copyImage.GetPixel(x, y)));
                    alongProgressBar.Invoke(new MethodInvoker(delegate
                    {
                        alongProgressBar.Value++;
                    }));
                }
            alongPictureBox.Image = newImage;
        }

        private void alongBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true) return;
            if (afterBackgroundWorker.IsBusy == false)
            {
                afterProgressBar.Value = 0;
                alongProgressBar.Value = 0;
                afterProgressBar.Visible = false;
                alongProgressBar.Visible = false;
                reduceButton.Text = "Reduce to " + colorsCount + "colors";
                stopwatch.Stop();
                MessageBox.Show("Time of reduction was: " + (stopwatch.ElapsedMilliseconds / 1000) + " seconds.", "Time of reduction", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void colorCountTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int tmp = 0;
                if(afterBackgroundWorker.IsBusy == true || alongBackgroundWorker.IsBusy == true)
                {
                    Int32.TryParse(colorCountTextBox.Text, out tmp);
                    if (tmp == colorsCount) return;
                    MessageBox.Show("Cannot change value while reduction in progess.", "Reduction in progress", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    colorCountTextBox.Text = colorsCount.ToString();
                    return;
                }
                tmp = Int32.Parse(colorCountTextBox.Text);
                if (tmp < 1 || tmp > 16777216) throw new Exception("Wrong value.");
                else colorsCount = tmp;
                reduceButton.Text = "Reduce to " + colorsCount + " colors";
                canReduce = true;
                colorCountTextBox.ForeColor = Color.Black;

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                canReduce = false;
                colorCountTextBox.ForeColor = Color.Red;
            }
        }
    }
}
