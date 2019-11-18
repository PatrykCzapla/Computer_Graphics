namespace Polygon_Filler
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
            this.backTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.optionsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.bumpMapLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.polygonRadioButton = new System.Windows.Forms.RadioButton();
            this.editRadioButton = new System.Windows.Forms.RadioButton();
            this.noOfPolygonsLabel = new System.Windows.Forms.Label();
            this.speedLabel = new System.Windows.Forms.Label();
            this.speedTrackBar = new System.Windows.Forms.TrackBar();
            this.colorOfFillingClippedLabel = new System.Windows.Forms.Label();
            this.textureButton = new System.Windows.Forms.Button();
            this.colorHeightLabel = new System.Windows.Forms.Label();
            this.lightColorLabel = new System.Windows.Forms.Label();
            this.lightColorButton = new System.Windows.Forms.Button();
            this.heightOfLightTextBox = new System.Windows.Forms.TextBox();
            this.noOfVerticesInPolygonsLabel = new System.Windows.Forms.Label();
            this.convexDomain = new System.Windows.Forms.DomainUpDown();
            this.convexNoDomain = new System.Windows.Forms.DomainUpDown();
            this.clearButton = new System.Windows.Forms.Button();
            this.generateConvexButton = new System.Windows.Forms.Button();
            this.startStopButton = new System.Windows.Forms.Button();
            this.colorOfFillingButton = new System.Windows.Forms.Button();
            this.textureLabel = new System.Windows.Forms.Label();
            this.bumpMapButton = new System.Windows.Forms.Button();
            this.drawingPanel = new System.Windows.Forms.Panel();
            this.drawingPictureBox = new System.Windows.Forms.PictureBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.fillingColorDialog = new System.Windows.Forms.ColorDialog();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.backTableLayoutPanel.SuspendLayout();
            this.optionsTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackBar)).BeginInit();
            this.drawingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawingPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // backTableLayoutPanel
            // 
            this.backTableLayoutPanel.ColumnCount = 2;
            this.backTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.backTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.backTableLayoutPanel.Controls.Add(this.optionsTableLayoutPanel, 1, 0);
            this.backTableLayoutPanel.Controls.Add(this.drawingPanel, 0, 0);
            this.backTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.backTableLayoutPanel.Name = "backTableLayoutPanel";
            this.backTableLayoutPanel.RowCount = 1;
            this.backTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.backTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 861F));
            this.backTableLayoutPanel.Size = new System.Drawing.Size(1384, 661);
            this.backTableLayoutPanel.TabIndex = 0;
            // 
            // optionsTableLayoutPanel
            // 
            this.optionsTableLayoutPanel.ColumnCount = 2;
            this.optionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.45361F));
            this.optionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.54639F));
            this.optionsTableLayoutPanel.Controls.Add(this.bumpMapLabel, 0, 9);
            this.optionsTableLayoutPanel.Controls.Add(this.button1, 0, 12);
            this.optionsTableLayoutPanel.Controls.Add(this.polygonRadioButton, 0, 0);
            this.optionsTableLayoutPanel.Controls.Add(this.editRadioButton, 1, 0);
            this.optionsTableLayoutPanel.Controls.Add(this.noOfPolygonsLabel, 0, 3);
            this.optionsTableLayoutPanel.Controls.Add(this.speedLabel, 0, 6);
            this.optionsTableLayoutPanel.Controls.Add(this.speedTrackBar, 1, 6);
            this.optionsTableLayoutPanel.Controls.Add(this.colorOfFillingClippedLabel, 0, 7);
            this.optionsTableLayoutPanel.Controls.Add(this.textureButton, 1, 8);
            this.optionsTableLayoutPanel.Controls.Add(this.colorHeightLabel, 0, 10);
            this.optionsTableLayoutPanel.Controls.Add(this.lightColorLabel, 0, 11);
            this.optionsTableLayoutPanel.Controls.Add(this.lightColorButton, 1, 11);
            this.optionsTableLayoutPanel.Controls.Add(this.heightOfLightTextBox, 1, 10);
            this.optionsTableLayoutPanel.Controls.Add(this.noOfVerticesInPolygonsLabel, 0, 2);
            this.optionsTableLayoutPanel.Controls.Add(this.convexDomain, 1, 2);
            this.optionsTableLayoutPanel.Controls.Add(this.convexNoDomain, 1, 3);
            this.optionsTableLayoutPanel.Controls.Add(this.clearButton, 0, 1);
            this.optionsTableLayoutPanel.Controls.Add(this.generateConvexButton, 0, 4);
            this.optionsTableLayoutPanel.Controls.Add(this.startStopButton, 0, 5);
            this.optionsTableLayoutPanel.Controls.Add(this.colorOfFillingButton, 1, 7);
            this.optionsTableLayoutPanel.Controls.Add(this.textureLabel, 0, 8);
            this.optionsTableLayoutPanel.Controls.Add(this.bumpMapButton, 1, 9);
            this.optionsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsTableLayoutPanel.Location = new System.Drawing.Point(1187, 3);
            this.optionsTableLayoutPanel.Name = "optionsTableLayoutPanel";
            this.optionsTableLayoutPanel.RowCount = 13;
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.optionsTableLayoutPanel.Size = new System.Drawing.Size(194, 655);
            this.optionsTableLayoutPanel.TabIndex = 1;
            // 
            // bumpMapLabel
            // 
            this.bumpMapLabel.AutoSize = true;
            this.bumpMapLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bumpMapLabel.Location = new System.Drawing.Point(3, 453);
            this.bumpMapLabel.Margin = new System.Windows.Forms.Padding(3);
            this.bumpMapLabel.Name = "bumpMapLabel";
            this.bumpMapLabel.Size = new System.Drawing.Size(88, 44);
            this.bumpMapLabel.TabIndex = 1;
            this.bumpMapLabel.Text = "Bump map:";
            this.bumpMapLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 603);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // polygonRadioButton
            // 
            this.polygonRadioButton.AutoSize = true;
            this.polygonRadioButton.Checked = true;
            this.polygonRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.polygonRadioButton.Location = new System.Drawing.Point(3, 3);
            this.polygonRadioButton.Name = "polygonRadioButton";
            this.polygonRadioButton.Size = new System.Drawing.Size(88, 44);
            this.polygonRadioButton.TabIndex = 0;
            this.polygonRadioButton.TabStop = true;
            this.polygonRadioButton.Text = "Draw polygon";
            this.polygonRadioButton.UseVisualStyleBackColor = true;
            this.polygonRadioButton.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // editRadioButton
            // 
            this.editRadioButton.AutoSize = true;
            this.editRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editRadioButton.Location = new System.Drawing.Point(97, 3);
            this.editRadioButton.Name = "editRadioButton";
            this.editRadioButton.Size = new System.Drawing.Size(94, 44);
            this.editRadioButton.TabIndex = 2;
            this.editRadioButton.TabStop = true;
            this.editRadioButton.Text = "Edit polygon";
            this.editRadioButton.UseVisualStyleBackColor = true;
            this.editRadioButton.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // noOfPolygonsLabel
            // 
            this.noOfPolygonsLabel.AutoSize = true;
            this.noOfPolygonsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noOfPolygonsLabel.Location = new System.Drawing.Point(3, 153);
            this.noOfPolygonsLabel.Margin = new System.Windows.Forms.Padding(3);
            this.noOfPolygonsLabel.Name = "noOfPolygonsLabel";
            this.noOfPolygonsLabel.Size = new System.Drawing.Size(88, 44);
            this.noOfPolygonsLabel.TabIndex = 6;
            this.noOfPolygonsLabel.Text = "Number of convex polygons:";
            this.noOfPolygonsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.speedLabel.Location = new System.Drawing.Point(3, 303);
            this.speedLabel.Margin = new System.Windows.Forms.Padding(3);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(88, 44);
            this.speedLabel.TabIndex = 8;
            this.speedLabel.Text = "Speed of animation:";
            this.speedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // speedTrackBar
            // 
            this.speedTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.speedTrackBar.Location = new System.Drawing.Point(97, 310);
            this.speedTrackBar.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.speedTrackBar.Minimum = 1;
            this.speedTrackBar.Name = "speedTrackBar";
            this.speedTrackBar.Size = new System.Drawing.Size(94, 30);
            this.speedTrackBar.TabIndex = 12;
            this.speedTrackBar.Value = 1;
            // 
            // colorOfFillingClippedLabel
            // 
            this.colorOfFillingClippedLabel.AutoSize = true;
            this.colorOfFillingClippedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorOfFillingClippedLabel.Location = new System.Drawing.Point(3, 353);
            this.colorOfFillingClippedLabel.Margin = new System.Windows.Forms.Padding(3);
            this.colorOfFillingClippedLabel.Name = "colorOfFillingClippedLabel";
            this.colorOfFillingClippedLabel.Size = new System.Drawing.Size(88, 44);
            this.colorOfFillingClippedLabel.TabIndex = 9;
            this.colorOfFillingClippedLabel.Text = "Color of clipped filling:";
            this.colorOfFillingClippedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textureButton
            // 
            this.textureButton.BackColor = System.Drawing.SystemColors.Control;
            this.textureButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textureButton.Location = new System.Drawing.Point(101, 410);
            this.textureButton.Margin = new System.Windows.Forms.Padding(7, 10, 7, 10);
            this.textureButton.Name = "textureButton";
            this.textureButton.Size = new System.Drawing.Size(86, 30);
            this.textureButton.TabIndex = 14;
            this.textureButton.UseVisualStyleBackColor = false;
            this.textureButton.Click += new System.EventHandler(this.textureButton_Click);
            // 
            // colorHeightLabel
            // 
            this.colorHeightLabel.AutoSize = true;
            this.colorHeightLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorHeightLabel.Location = new System.Drawing.Point(3, 503);
            this.colorHeightLabel.Margin = new System.Windows.Forms.Padding(3);
            this.colorHeightLabel.Name = "colorHeightLabel";
            this.colorHeightLabel.Size = new System.Drawing.Size(88, 44);
            this.colorHeightLabel.TabIndex = 16;
            this.colorHeightLabel.Text = "Height of light:";
            this.colorHeightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lightColorLabel
            // 
            this.lightColorLabel.AutoSize = true;
            this.lightColorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lightColorLabel.Location = new System.Drawing.Point(3, 553);
            this.lightColorLabel.Margin = new System.Windows.Forms.Padding(3);
            this.lightColorLabel.Name = "lightColorLabel";
            this.lightColorLabel.Size = new System.Drawing.Size(88, 44);
            this.lightColorLabel.TabIndex = 17;
            this.lightColorLabel.Text = "Color of light";
            this.lightColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lightColorButton
            // 
            this.lightColorButton.BackColor = System.Drawing.Color.Yellow;
            this.lightColorButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lightColorButton.Location = new System.Drawing.Point(101, 560);
            this.lightColorButton.Margin = new System.Windows.Forms.Padding(7, 10, 7, 10);
            this.lightColorButton.Name = "lightColorButton";
            this.lightColorButton.Size = new System.Drawing.Size(86, 30);
            this.lightColorButton.TabIndex = 18;
            this.lightColorButton.UseVisualStyleBackColor = false;
            this.lightColorButton.Click += new System.EventHandler(this.lightColorButton_Click);
            // 
            // heightOfLightTextBox
            // 
            this.heightOfLightTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.heightOfLightTextBox.Location = new System.Drawing.Point(119, 515);
            this.heightOfLightTextBox.Name = "heightOfLightTextBox";
            this.heightOfLightTextBox.Size = new System.Drawing.Size(50, 20);
            this.heightOfLightTextBox.TabIndex = 19;
            this.heightOfLightTextBox.Text = "1";
            this.heightOfLightTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.heightOfLightTextBox.TextChanged += new System.EventHandler(this.heightOfLightTextBox_TextChanged);
            // 
            // noOfVerticesInPolygonsLabel
            // 
            this.noOfVerticesInPolygonsLabel.AutoSize = true;
            this.noOfVerticesInPolygonsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noOfVerticesInPolygonsLabel.Location = new System.Drawing.Point(3, 103);
            this.noOfVerticesInPolygonsLabel.Margin = new System.Windows.Forms.Padding(3);
            this.noOfVerticesInPolygonsLabel.Name = "noOfVerticesInPolygonsLabel";
            this.noOfVerticesInPolygonsLabel.Size = new System.Drawing.Size(88, 44);
            this.noOfVerticesInPolygonsLabel.TabIndex = 7;
            this.noOfVerticesInPolygonsLabel.Text = "Number of vertices in convex polygons:";
            this.noOfVerticesInPolygonsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // convexDomain
            // 
            this.convexDomain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.convexDomain.Items.Add("15");
            this.convexDomain.Items.Add("14");
            this.convexDomain.Items.Add("13");
            this.convexDomain.Items.Add("12");
            this.convexDomain.Items.Add("11");
            this.convexDomain.Items.Add("10");
            this.convexDomain.Items.Add("9");
            this.convexDomain.Items.Add("8");
            this.convexDomain.Items.Add("7");
            this.convexDomain.Items.Add("6");
            this.convexDomain.Items.Add("5");
            this.convexDomain.Items.Add("4");
            this.convexDomain.Items.Add("3");
            this.convexDomain.Location = new System.Drawing.Point(119, 115);
            this.convexDomain.Name = "convexDomain";
            this.convexDomain.Size = new System.Drawing.Size(49, 20);
            this.convexDomain.TabIndex = 3;
            this.convexDomain.Text = "3";
            this.convexDomain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // convexNoDomain
            // 
            this.convexNoDomain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.convexNoDomain.Items.Add("7");
            this.convexNoDomain.Items.Add("6");
            this.convexNoDomain.Items.Add("5");
            this.convexNoDomain.Items.Add("4");
            this.convexNoDomain.Items.Add("3");
            this.convexNoDomain.Items.Add("2");
            this.convexNoDomain.Items.Add("1");
            this.convexNoDomain.Location = new System.Drawing.Point(119, 165);
            this.convexNoDomain.Name = "convexNoDomain";
            this.convexNoDomain.Size = new System.Drawing.Size(49, 20);
            this.convexNoDomain.TabIndex = 11;
            this.convexNoDomain.Text = "1";
            this.convexNoDomain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // clearButton
            // 
            this.optionsTableLayoutPanel.SetColumnSpan(this.clearButton, 2);
            this.clearButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clearButton.Location = new System.Drawing.Point(3, 60);
            this.clearButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(188, 30);
            this.clearButton.TabIndex = 1;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // generateConvexButton
            // 
            this.optionsTableLayoutPanel.SetColumnSpan(this.generateConvexButton, 2);
            this.generateConvexButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generateConvexButton.Location = new System.Drawing.Point(7, 210);
            this.generateConvexButton.Margin = new System.Windows.Forms.Padding(7, 10, 7, 10);
            this.generateConvexButton.Name = "generateConvexButton";
            this.generateConvexButton.Size = new System.Drawing.Size(180, 30);
            this.generateConvexButton.TabIndex = 4;
            this.generateConvexButton.Text = "Generate convex";
            this.generateConvexButton.UseVisualStyleBackColor = true;
            this.generateConvexButton.Click += new System.EventHandler(this.generateConvexButton_Click);
            // 
            // startStopButton
            // 
            this.optionsTableLayoutPanel.SetColumnSpan(this.startStopButton, 2);
            this.startStopButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startStopButton.Location = new System.Drawing.Point(7, 260);
            this.startStopButton.Margin = new System.Windows.Forms.Padding(7, 10, 7, 10);
            this.startStopButton.Name = "startStopButton";
            this.startStopButton.Size = new System.Drawing.Size(180, 30);
            this.startStopButton.TabIndex = 15;
            this.startStopButton.Text = "Start animation";
            this.startStopButton.UseVisualStyleBackColor = true;
            this.startStopButton.Click += new System.EventHandler(this.startStopButton_Click);
            // 
            // colorOfFillingButton
            // 
            this.colorOfFillingButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.colorOfFillingButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorOfFillingButton.Location = new System.Drawing.Point(101, 360);
            this.colorOfFillingButton.Margin = new System.Windows.Forms.Padding(7, 10, 7, 10);
            this.colorOfFillingButton.Name = "colorOfFillingButton";
            this.colorOfFillingButton.Size = new System.Drawing.Size(86, 30);
            this.colorOfFillingButton.TabIndex = 13;
            this.colorOfFillingButton.UseVisualStyleBackColor = false;
            this.colorOfFillingButton.Click += new System.EventHandler(this.colorOfFillingButton_Click);
            // 
            // textureLabel
            // 
            this.textureLabel.AutoSize = true;
            this.textureLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textureLabel.Location = new System.Drawing.Point(3, 403);
            this.textureLabel.Margin = new System.Windows.Forms.Padding(3);
            this.textureLabel.Name = "textureLabel";
            this.textureLabel.Size = new System.Drawing.Size(88, 44);
            this.textureLabel.TabIndex = 1;
            this.textureLabel.Text = "Texture of clipped filling:";
            this.textureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bumpMapButton
            // 
            this.bumpMapButton.BackColor = System.Drawing.Color.Transparent;
            this.bumpMapButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bumpMapButton.Location = new System.Drawing.Point(101, 460);
            this.bumpMapButton.Margin = new System.Windows.Forms.Padding(7, 10, 7, 10);
            this.bumpMapButton.Name = "bumpMapButton";
            this.bumpMapButton.Size = new System.Drawing.Size(86, 30);
            this.bumpMapButton.TabIndex = 20;
            this.bumpMapButton.UseVisualStyleBackColor = false;
            this.bumpMapButton.Click += new System.EventHandler(this.bumpMapButton_Click);
            // 
            // drawingPanel
            // 
            this.drawingPanel.Controls.Add(this.drawingPictureBox);
            this.drawingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingPanel.Location = new System.Drawing.Point(3, 3);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(1178, 655);
            this.drawingPanel.TabIndex = 0;
            // 
            // drawingPictureBox
            // 
            this.drawingPictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.drawingPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.drawingPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingPictureBox.Location = new System.Drawing.Point(0, 0);
            this.drawingPictureBox.Name = "drawingPictureBox";
            this.drawingPictureBox.Size = new System.Drawing.Size(1178, 655);
            this.drawingPictureBox.TabIndex = 0;
            this.drawingPictureBox.TabStop = false;
            this.drawingPictureBox.SizeChanged += new System.EventHandler(this.drawingPictureBox_SizeChanged);
            this.drawingPictureBox.Click += new System.EventHandler(this.drawingPictureBox_Click);
            this.drawingPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawingPictureBox_MouseDown);
            this.drawingPictureBox.MouseLeave += new System.EventHandler(this.drawingPictureBox_MouseLeave);
            this.drawingPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawingPictureBox_MouseMove);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 661);
            this.Controls.Add(this.backTableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(800, 700);
            this.Name = "Form";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Polygon filler";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.backTableLayoutPanel.ResumeLayout(false);
            this.optionsTableLayoutPanel.ResumeLayout(false);
            this.optionsTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackBar)).EndInit();
            this.drawingPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drawingPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel backTableLayoutPanel;
        private System.Windows.Forms.Panel drawingPanel;
        private System.Windows.Forms.PictureBox drawingPictureBox;
        private System.Windows.Forms.TableLayoutPanel optionsTableLayoutPanel;
        private System.Windows.Forms.RadioButton polygonRadioButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.RadioButton editRadioButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.DomainUpDown convexDomain;
        private System.Windows.Forms.Button generateConvexButton;
        private System.Windows.Forms.ColorDialog fillingColorDialog;
        private System.Windows.Forms.Label noOfPolygonsLabel;
        private System.Windows.Forms.Label noOfVerticesInPolygonsLabel;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.DomainUpDown convexNoDomain;
        private System.Windows.Forms.TrackBar speedTrackBar;
        private System.Windows.Forms.Label textureLabel;
        private System.Windows.Forms.Button textureButton;
        private System.Windows.Forms.Button startStopButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Label colorHeightLabel;
        private System.Windows.Forms.Label lightColorLabel;
        private System.Windows.Forms.Button lightColorButton;
        private System.Windows.Forms.TextBox heightOfLightTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label bumpMapLabel;
        private System.Windows.Forms.Button bumpMapButton;
        private System.Windows.Forms.Label colorOfFillingClippedLabel;
        private System.Windows.Forms.Button colorOfFillingButton;
    }
}

