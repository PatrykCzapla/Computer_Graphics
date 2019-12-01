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

        private Stopwatch stopwatch = new Stopwatch();

        public Form()
        {
            InitializeComponent();
        }

        private void colorsCountTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (colorsCount == colorsCountTrackBar.Value * 8) return;
            if (afterBackgroundWorker.IsBusy == true || alongBackgroundWorker.IsBusy == true)
            {
                MessageBox.Show("Cannot change value while reduction in progess.", "Reduction in progress", MessageBoxButtons.OK, MessageBoxIcon.Error);
                colorsCountTrackBar.Value = colorsCount / 8;
                return;
            }
            colorsCount = colorsCountTrackBar.Value * 8;
            reduceButton.Text = "Reduce to " + colorsCount + " colors";
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
            infoLabel.Invoke(new MethodInvoker(delegate { infoLabel.Text += "Number of colors in original picture: " + Tools.countLeafs(root); }));
            while (Tools.countLeafs(root) > colorsCount)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    return;
                }
                Tools.ReduceTree(root);
            }
            infoLabel.Invoke(new MethodInvoker(delegate { infoLabel.Text += Environment.NewLine + "Number of colors after reduction: " + Tools.countLeafs(root); }));
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
                    while (Tools.countLeafs(root) > colorsCount)
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
            infoLabel.Invoke(new MethodInvoker(delegate { infoLabel.Text += Environment.NewLine + "Number of colors along reduction: " + Tools.countLeafs(root); }));
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
    }
}
