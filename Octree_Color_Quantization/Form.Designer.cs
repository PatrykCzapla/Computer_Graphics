namespace Octree_Color_Quantization
{
    partial class Form
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.outerPanel = new System.Windows.Forms.Panel();
            this.outerTable = new System.Windows.Forms.TableLayoutPanel();
            this.resultTable = new System.Windows.Forms.TableLayoutPanel();
            this.alongPictureBox = new System.Windows.Forms.PictureBox();
            this.afterProgressBar = new System.Windows.Forms.ProgressBar();
            this.alongProgressBar = new System.Windows.Forms.ProgressBar();
            this.afterLabel = new System.Windows.Forms.Label();
            this.alongLabel = new System.Windows.Forms.Label();
            this.afterPictureBox = new System.Windows.Forms.PictureBox();
            this.initialTable = new System.Windows.Forms.TableLayoutPanel();
            this.loadButton = new System.Windows.Forms.Button();
            this.initialPictureBox = new System.Windows.Forms.PictureBox();
            this.initialImageLabel = new System.Windows.Forms.Label();
            this.reduceButton = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.colorCountTextBox = new System.Windows.Forms.TextBox();
            this.colorCountLabel = new System.Windows.Forms.Label();
            this.afterBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.alongBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.outerPanel.SuspendLayout();
            this.outerTable.SuspendLayout();
            this.resultTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alongPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.afterPictureBox)).BeginInit();
            this.initialTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.initialPictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // outerPanel
            // 
            this.outerPanel.AutoScroll = true;
            this.outerPanel.Controls.Add(this.outerTable);
            this.outerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outerPanel.Location = new System.Drawing.Point(0, 0);
            this.outerPanel.Name = "outerPanel";
            this.outerPanel.Size = new System.Drawing.Size(1184, 711);
            this.outerPanel.TabIndex = 0;
            // 
            // outerTable
            // 
            this.outerTable.ColumnCount = 2;
            this.outerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.outerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.outerTable.Controls.Add(this.resultTable, 0, 0);
            this.outerTable.Controls.Add(this.initialTable, 0, 0);
            this.outerTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outerTable.Location = new System.Drawing.Point(0, 0);
            this.outerTable.Name = "outerTable";
            this.outerTable.RowCount = 1;
            this.outerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.outerTable.Size = new System.Drawing.Size(1184, 711);
            this.outerTable.TabIndex = 0;
            // 
            // resultTable
            // 
            this.resultTable.ColumnCount = 1;
            this.resultTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.resultTable.Controls.Add(this.alongPictureBox, 0, 4);
            this.resultTable.Controls.Add(this.afterProgressBar, 0, 2);
            this.resultTable.Controls.Add(this.alongProgressBar, 0, 5);
            this.resultTable.Controls.Add(this.afterLabel, 0, 0);
            this.resultTable.Controls.Add(this.alongLabel, 0, 3);
            this.resultTable.Controls.Add(this.afterPictureBox, 0, 1);
            this.resultTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultTable.Location = new System.Drawing.Point(595, 3);
            this.resultTable.Name = "resultTable";
            this.resultTable.RowCount = 6;
            this.resultTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.resultTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.resultTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.resultTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.resultTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.resultTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.resultTable.Size = new System.Drawing.Size(586, 705);
            this.resultTable.TabIndex = 1;
            // 
            // alongPictureBox
            // 
            this.alongPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.alongPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alongPictureBox.Location = new System.Drawing.Point(3, 385);
            this.alongPictureBox.Name = "alongPictureBox";
            this.alongPictureBox.Size = new System.Drawing.Size(580, 266);
            this.alongPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.alongPictureBox.TabIndex = 6;
            this.alongPictureBox.TabStop = false;
            // 
            // afterProgressBar
            // 
            this.afterProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.afterProgressBar.Location = new System.Drawing.Point(10, 317);
            this.afterProgressBar.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.afterProgressBar.Name = "afterProgressBar";
            this.afterProgressBar.Size = new System.Drawing.Size(566, 20);
            this.afterProgressBar.Step = 1;
            this.afterProgressBar.TabIndex = 1;
            this.afterProgressBar.Visible = false;
            // 
            // alongProgressBar
            // 
            this.alongProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alongProgressBar.Location = new System.Drawing.Point(10, 669);
            this.alongProgressBar.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.alongProgressBar.Name = "alongProgressBar";
            this.alongProgressBar.Size = new System.Drawing.Size(566, 21);
            this.alongProgressBar.Step = 1;
            this.alongProgressBar.TabIndex = 2;
            this.alongProgressBar.Visible = false;
            // 
            // afterLabel
            // 
            this.afterLabel.AutoSize = true;
            this.afterLabel.BackColor = System.Drawing.Color.Transparent;
            this.afterLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.afterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.afterLabel.Location = new System.Drawing.Point(5, 5);
            this.afterLabel.Margin = new System.Windows.Forms.Padding(5);
            this.afterLabel.Name = "afterLabel";
            this.afterLabel.Size = new System.Drawing.Size(576, 20);
            this.afterLabel.TabIndex = 3;
            this.afterLabel.Text = "Reduce after octree construction";
            this.afterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // alongLabel
            // 
            this.alongLabel.AutoSize = true;
            this.alongLabel.BackColor = System.Drawing.Color.Transparent;
            this.alongLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alongLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.alongLabel.Location = new System.Drawing.Point(5, 357);
            this.alongLabel.Margin = new System.Windows.Forms.Padding(5);
            this.alongLabel.Name = "alongLabel";
            this.alongLabel.Size = new System.Drawing.Size(576, 20);
            this.alongLabel.TabIndex = 4;
            this.alongLabel.Text = "Reduce along octree construction";
            this.alongLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // afterPictureBox
            // 
            this.afterPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.afterPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.afterPictureBox.Location = new System.Drawing.Point(3, 33);
            this.afterPictureBox.Name = "afterPictureBox";
            this.afterPictureBox.Size = new System.Drawing.Size(580, 266);
            this.afterPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.afterPictureBox.TabIndex = 5;
            this.afterPictureBox.TabStop = false;
            // 
            // initialTable
            // 
            this.initialTable.ColumnCount = 1;
            this.initialTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.initialTable.Controls.Add(this.loadButton, 0, 2);
            this.initialTable.Controls.Add(this.initialPictureBox, 0, 1);
            this.initialTable.Controls.Add(this.initialImageLabel, 0, 0);
            this.initialTable.Controls.Add(this.reduceButton, 0, 4);
            this.initialTable.Controls.Add(this.infoLabel, 0, 5);
            this.initialTable.Controls.Add(this.tableLayoutPanel1, 0, 3);
            this.initialTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.initialTable.Location = new System.Drawing.Point(3, 3);
            this.initialTable.Name = "initialTable";
            this.initialTable.RowCount = 7;
            this.initialTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.initialTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 270F));
            this.initialTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.initialTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.initialTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.initialTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.initialTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.initialTable.Size = new System.Drawing.Size(586, 705);
            this.initialTable.TabIndex = 0;
            // 
            // loadButton
            // 
            this.loadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.loadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.loadButton.Location = new System.Drawing.Point(10, 310);
            this.loadButton.Margin = new System.Windows.Forms.Padding(10);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(566, 30);
            this.loadButton.TabIndex = 3;
            this.loadButton.Text = "Load image";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // initialPictureBox
            // 
            this.initialPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.initialPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.initialPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.initialPictureBox.InitialImage = null;
            this.initialPictureBox.Location = new System.Drawing.Point(3, 33);
            this.initialPictureBox.Name = "initialPictureBox";
            this.initialPictureBox.Size = new System.Drawing.Size(580, 264);
            this.initialPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.initialPictureBox.TabIndex = 0;
            this.initialPictureBox.TabStop = false;
            // 
            // initialImageLabel
            // 
            this.initialImageLabel.AutoSize = true;
            this.initialImageLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.initialImageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.initialImageLabel.Location = new System.Drawing.Point(5, 5);
            this.initialImageLabel.Margin = new System.Windows.Forms.Padding(5);
            this.initialImageLabel.Name = "initialImageLabel";
            this.initialImageLabel.Size = new System.Drawing.Size(576, 20);
            this.initialImageLabel.TabIndex = 4;
            this.initialImageLabel.Text = "Original image";
            this.initialImageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // reduceButton
            // 
            this.reduceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.reduceButton.BackColor = System.Drawing.Color.Transparent;
            this.reduceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.reduceButton.Location = new System.Drawing.Point(10, 410);
            this.reduceButton.Margin = new System.Windows.Forms.Padding(10);
            this.reduceButton.Name = "reduceButton";
            this.reduceButton.Size = new System.Drawing.Size(566, 30);
            this.reduceButton.TabIndex = 2;
            this.reduceButton.Text = "Reduce to 256 colors";
            this.reduceButton.UseVisualStyleBackColor = false;
            this.reduceButton.Click += new System.EventHandler(this.reduceButton_Click);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoLabel.Location = new System.Drawing.Point(5, 455);
            this.infoLabel.Margin = new System.Windows.Forms.Padding(5);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(576, 225);
            this.infoLabel.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.colorCountTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.colorCountLabel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 353);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(580, 44);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // colorCountTextBox
            // 
            this.colorCountTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorCountTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.colorCountTextBox.Location = new System.Drawing.Point(300, 10);
            this.colorCountTextBox.Margin = new System.Windows.Forms.Padding(10);
            this.colorCountTextBox.Name = "colorCountTextBox";
            this.colorCountTextBox.Size = new System.Drawing.Size(270, 26);
            this.colorCountTextBox.TabIndex = 5;
            this.colorCountTextBox.Text = "256";
            this.colorCountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colorCountTextBox.TextChanged += new System.EventHandler(this.colorCountTextBox_TextChanged);
            // 
            // colorCountLabel
            // 
            this.colorCountLabel.AutoSize = true;
            this.colorCountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.colorCountLabel.Location = new System.Drawing.Point(5, 5);
            this.colorCountLabel.Margin = new System.Windows.Forms.Padding(5);
            this.colorCountLabel.Name = "colorCountLabel";
            this.colorCountLabel.Size = new System.Drawing.Size(280, 34);
            this.colorCountLabel.TabIndex = 6;
            this.colorCountLabel.Text = "Target number of colors:";
            this.colorCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // afterBackgroundWorker
            // 
            this.afterBackgroundWorker.WorkerSupportsCancellation = true;
            this.afterBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.afterBackgroundWorker_DoWork);
            this.afterBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.afterBackgroundWorker_RunWorkerCompleted);
            // 
            // alongBackgroundWorker
            // 
            this.alongBackgroundWorker.WorkerSupportsCancellation = true;
            this.alongBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.alongBackgroundWorker_DoWork);
            this.alongBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.alongBackgroundWorker_RunWorkerCompleted);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1184, 711);
            this.Controls.Add(this.outerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1200, 750);
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Octree Color Quantization";
            this.outerPanel.ResumeLayout(false);
            this.outerTable.ResumeLayout(false);
            this.resultTable.ResumeLayout(false);
            this.resultTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alongPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.afterPictureBox)).EndInit();
            this.initialTable.ResumeLayout(false);
            this.initialTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.initialPictureBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel outerPanel;
        private System.Windows.Forms.TableLayoutPanel outerTable;
        private System.Windows.Forms.TableLayoutPanel initialTable;
        private System.Windows.Forms.TableLayoutPanel resultTable;
        private System.Windows.Forms.PictureBox alongPictureBox;
        private System.Windows.Forms.ProgressBar afterProgressBar;
        private System.Windows.Forms.Label afterLabel;
        private System.Windows.Forms.Label alongLabel;
        private System.Windows.Forms.PictureBox afterPictureBox;
        private System.Windows.Forms.PictureBox initialPictureBox;
        private System.Windows.Forms.Button reduceButton;
        private System.ComponentModel.BackgroundWorker afterBackgroundWorker;
        private System.ComponentModel.BackgroundWorker alongBackgroundWorker;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Label initialImageLabel;
        private System.Windows.Forms.ProgressBar alongProgressBar;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox colorCountTextBox;
        private System.Windows.Forms.Label colorCountLabel;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

