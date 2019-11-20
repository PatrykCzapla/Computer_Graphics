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
            this.lightPositionRadioButton = new System.Windows.Forms.RadioButton();
            this.polygonRadioButton = new System.Windows.Forms.RadioButton();
            this.editRadioButton = new System.Windows.Forms.RadioButton();
            this.noOfConvexLabel = new System.Windows.Forms.Label();
            this.speedLabel = new System.Windows.Forms.Label();
            this.speedTrackBar = new System.Windows.Forms.TrackBar();
            this.noOfVerticesLabel = new System.Windows.Forms.Label();
            this.noOfVerticesDomain = new System.Windows.Forms.DomainUpDown();
            this.noOfConvexDomain = new System.Windows.Forms.DomainUpDown();
            this.clearButton = new System.Windows.Forms.Button();
            this.generateConvexButton = new System.Windows.Forms.Button();
            this.startStopButton = new System.Windows.Forms.Button();
            this.textureLabel = new System.Windows.Forms.Label();
            this.bumpMapLabel = new System.Windows.Forms.Label();
            this.textureButton = new System.Windows.Forms.Button();
            this.bumpMapButton = new System.Windows.Forms.Button();
            this.heightOfLightLabel = new System.Windows.Forms.Label();
            this.heightOfLightTextBox = new System.Windows.Forms.TextBox();
            this.lightColorLabel = new System.Windows.Forms.Label();
            this.lightColorButton = new System.Windows.Forms.Button();
            this.drawingPanel = new System.Windows.Forms.Panel();
            this.drawingPictureBox = new System.Windows.Forms.PictureBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.fillingColorDialog = new System.Windows.Forms.ColorDialog();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.testButton = new System.Windows.Forms.Button();
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
            this.optionsTableLayoutPanel.Controls.Add(this.lightPositionRadioButton, 0, 11);
            this.optionsTableLayoutPanel.Controls.Add(this.polygonRadioButton, 0, 0);
            this.optionsTableLayoutPanel.Controls.Add(this.editRadioButton, 1, 0);
            this.optionsTableLayoutPanel.Controls.Add(this.noOfConvexLabel, 0, 3);
            this.optionsTableLayoutPanel.Controls.Add(this.speedLabel, 0, 6);
            this.optionsTableLayoutPanel.Controls.Add(this.speedTrackBar, 1, 6);
            this.optionsTableLayoutPanel.Controls.Add(this.noOfVerticesLabel, 0, 2);
            this.optionsTableLayoutPanel.Controls.Add(this.noOfVerticesDomain, 1, 2);
            this.optionsTableLayoutPanel.Controls.Add(this.noOfConvexDomain, 1, 3);
            this.optionsTableLayoutPanel.Controls.Add(this.clearButton, 0, 1);
            this.optionsTableLayoutPanel.Controls.Add(this.generateConvexButton, 0, 4);
            this.optionsTableLayoutPanel.Controls.Add(this.startStopButton, 0, 5);
            this.optionsTableLayoutPanel.Controls.Add(this.textureLabel, 0, 7);
            this.optionsTableLayoutPanel.Controls.Add(this.bumpMapLabel, 0, 8);
            this.optionsTableLayoutPanel.Controls.Add(this.textureButton, 1, 7);
            this.optionsTableLayoutPanel.Controls.Add(this.bumpMapButton, 1, 8);
            this.optionsTableLayoutPanel.Controls.Add(this.heightOfLightLabel, 0, 9);
            this.optionsTableLayoutPanel.Controls.Add(this.heightOfLightTextBox, 1, 9);
            this.optionsTableLayoutPanel.Controls.Add(this.lightColorLabel, 0, 10);
            this.optionsTableLayoutPanel.Controls.Add(this.lightColorButton, 1, 10);
            this.optionsTableLayoutPanel.Controls.Add(this.testButton, 0, 12);
            this.optionsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsTableLayoutPanel.Location = new System.Drawing.Point(1187, 3);
            this.optionsTableLayoutPanel.Name = "optionsTableLayoutPanel";
            this.optionsTableLayoutPanel.RowCount = 14;
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
            // lightPositionRadioButton
            // 
            this.lightPositionRadioButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lightPositionRadioButton.AutoSize = true;
            this.optionsTableLayoutPanel.SetColumnSpan(this.lightPositionRadioButton, 2);
            this.lightPositionRadioButton.Location = new System.Drawing.Point(29, 566);
            this.lightPositionRadioButton.Name = "lightPositionRadioButton";
            this.lightPositionRadioButton.Size = new System.Drawing.Size(135, 17);
            this.lightPositionRadioButton.TabIndex = 1;
            this.lightPositionRadioButton.TabStop = true;
            this.lightPositionRadioButton.Text = "Change position of light";
            this.lightPositionRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lightPositionRadioButton.UseVisualStyleBackColor = true;
            this.lightPositionRadioButton.CheckedChanged += new System.EventHandler(this.CheckedChanged);
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
            this.polygonRadioButton.Text = "Draw";
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
            this.editRadioButton.Text = "Edit";
            this.editRadioButton.UseVisualStyleBackColor = true;
            this.editRadioButton.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // noOfConvexLabel
            // 
            this.noOfConvexLabel.AutoSize = true;
            this.noOfConvexLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noOfConvexLabel.Location = new System.Drawing.Point(3, 153);
            this.noOfConvexLabel.Margin = new System.Windows.Forms.Padding(3);
            this.noOfConvexLabel.Name = "noOfConvexLabel";
            this.noOfConvexLabel.Size = new System.Drawing.Size(88, 44);
            this.noOfConvexLabel.TabIndex = 6;
            this.noOfConvexLabel.Text = "Number of convex polygons:";
            this.noOfConvexLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.speedTrackBar.LargeChange = 2;
            this.speedTrackBar.Location = new System.Drawing.Point(97, 310);
            this.speedTrackBar.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.speedTrackBar.Minimum = 1;
            this.speedTrackBar.Name = "speedTrackBar";
            this.speedTrackBar.Size = new System.Drawing.Size(94, 30);
            this.speedTrackBar.TabIndex = 12;
            this.speedTrackBar.Value = 1;
            this.speedTrackBar.ValueChanged += new System.EventHandler(this.speedTrackBar_ValueChanged);
            // 
            // noOfVerticesLabel
            // 
            this.noOfVerticesLabel.AutoSize = true;
            this.noOfVerticesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noOfVerticesLabel.Location = new System.Drawing.Point(3, 103);
            this.noOfVerticesLabel.Margin = new System.Windows.Forms.Padding(3);
            this.noOfVerticesLabel.Name = "noOfVerticesLabel";
            this.noOfVerticesLabel.Size = new System.Drawing.Size(88, 44);
            this.noOfVerticesLabel.TabIndex = 7;
            this.noOfVerticesLabel.Text = "Number of vertices in convex polygons:";
            this.noOfVerticesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // noOfVerticesDomain
            // 
            this.noOfVerticesDomain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.noOfVerticesDomain.Items.Add("5");
            this.noOfVerticesDomain.Items.Add("4");
            this.noOfVerticesDomain.Items.Add("3");
            this.noOfVerticesDomain.Location = new System.Drawing.Point(119, 115);
            this.noOfVerticesDomain.Name = "noOfVerticesDomain";
            this.noOfVerticesDomain.Size = new System.Drawing.Size(49, 20);
            this.noOfVerticesDomain.TabIndex = 3;
            this.noOfVerticesDomain.Text = "3";
            this.noOfVerticesDomain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // noOfConvexDomain
            // 
            this.noOfConvexDomain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.noOfConvexDomain.Items.Add("3");
            this.noOfConvexDomain.Items.Add("2");
            this.noOfConvexDomain.Items.Add("1");
            this.noOfConvexDomain.Location = new System.Drawing.Point(119, 165);
            this.noOfConvexDomain.Name = "noOfConvexDomain";
            this.noOfConvexDomain.Size = new System.Drawing.Size(49, 20);
            this.noOfConvexDomain.TabIndex = 11;
            this.noOfConvexDomain.Text = "1";
            this.noOfConvexDomain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.generateConvexButton.Text = "Generate convex polygons";
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
            // textureLabel
            // 
            this.textureLabel.AutoSize = true;
            this.textureLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textureLabel.Location = new System.Drawing.Point(3, 353);
            this.textureLabel.Margin = new System.Windows.Forms.Padding(3);
            this.textureLabel.Name = "textureLabel";
            this.textureLabel.Size = new System.Drawing.Size(88, 44);
            this.textureLabel.TabIndex = 1;
            this.textureLabel.Text = "Texture of clipped filling:";
            this.textureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bumpMapLabel
            // 
            this.bumpMapLabel.AutoSize = true;
            this.bumpMapLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bumpMapLabel.Location = new System.Drawing.Point(3, 403);
            this.bumpMapLabel.Margin = new System.Windows.Forms.Padding(3);
            this.bumpMapLabel.Name = "bumpMapLabel";
            this.bumpMapLabel.Size = new System.Drawing.Size(88, 44);
            this.bumpMapLabel.TabIndex = 1;
            this.bumpMapLabel.Text = "Bump map:";
            this.bumpMapLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textureButton
            // 
            this.textureButton.BackColor = System.Drawing.Color.Transparent;
            this.textureButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textureButton.Location = new System.Drawing.Point(101, 360);
            this.textureButton.Margin = new System.Windows.Forms.Padding(7, 10, 7, 10);
            this.textureButton.Name = "textureButton";
            this.textureButton.Size = new System.Drawing.Size(86, 30);
            this.textureButton.TabIndex = 14;
            this.textureButton.UseVisualStyleBackColor = false;
            this.textureButton.Click += new System.EventHandler(this.textureButton_Click);
            // 
            // bumpMapButton
            // 
            this.bumpMapButton.BackColor = System.Drawing.Color.Transparent;
            this.bumpMapButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bumpMapButton.Location = new System.Drawing.Point(101, 410);
            this.bumpMapButton.Margin = new System.Windows.Forms.Padding(7, 10, 7, 10);
            this.bumpMapButton.Name = "bumpMapButton";
            this.bumpMapButton.Size = new System.Drawing.Size(86, 30);
            this.bumpMapButton.TabIndex = 20;
            this.bumpMapButton.UseVisualStyleBackColor = false;
            this.bumpMapButton.Click += new System.EventHandler(this.bumpMapButton_Click);
            // 
            // heightOfLightLabel
            // 
            this.heightOfLightLabel.AutoSize = true;
            this.heightOfLightLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heightOfLightLabel.Location = new System.Drawing.Point(3, 453);
            this.heightOfLightLabel.Margin = new System.Windows.Forms.Padding(3);
            this.heightOfLightLabel.Name = "heightOfLightLabel";
            this.heightOfLightLabel.Size = new System.Drawing.Size(88, 44);
            this.heightOfLightLabel.TabIndex = 16;
            this.heightOfLightLabel.Text = "Height of light:";
            this.heightOfLightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // heightOfLightTextBox
            // 
            this.heightOfLightTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.heightOfLightTextBox.Location = new System.Drawing.Point(119, 465);
            this.heightOfLightTextBox.Name = "heightOfLightTextBox";
            this.heightOfLightTextBox.Size = new System.Drawing.Size(50, 20);
            this.heightOfLightTextBox.TabIndex = 19;
            this.heightOfLightTextBox.Text = "100";
            this.heightOfLightTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.heightOfLightTextBox.TextChanged += new System.EventHandler(this.heightOfLightTextBox_TextChanged);
            // 
            // lightColorLabel
            // 
            this.lightColorLabel.AutoSize = true;
            this.lightColorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lightColorLabel.Location = new System.Drawing.Point(3, 503);
            this.lightColorLabel.Margin = new System.Windows.Forms.Padding(3);
            this.lightColorLabel.Name = "lightColorLabel";
            this.lightColorLabel.Size = new System.Drawing.Size(88, 44);
            this.lightColorLabel.TabIndex = 17;
            this.lightColorLabel.Text = "Color of light";
            this.lightColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lightColorButton
            // 
            this.lightColorButton.BackColor = System.Drawing.Color.Red;
            this.lightColorButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lightColorButton.Location = new System.Drawing.Point(101, 510);
            this.lightColorButton.Margin = new System.Windows.Forms.Padding(7, 10, 7, 10);
            this.lightColorButton.Name = "lightColorButton";
            this.lightColorButton.Size = new System.Drawing.Size(86, 30);
            this.lightColorButton.TabIndex = 18;
            this.lightColorButton.UseVisualStyleBackColor = false;
            this.lightColorButton.Click += new System.EventHandler(this.lightColorButton_Click);
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
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // testButton
            // 
            this.optionsTableLayoutPanel.SetColumnSpan(this.testButton, 2);
            this.testButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testButton.Location = new System.Drawing.Point(7, 610);
            this.testButton.Margin = new System.Windows.Forms.Padding(7, 10, 7, 10);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(180, 30);
            this.testButton.TabIndex = 21;
            this.testButton.Text = "Test filling";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
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
        private System.Windows.Forms.DomainUpDown noOfVerticesDomain;
        private System.Windows.Forms.Button generateConvexButton;
        private System.Windows.Forms.ColorDialog fillingColorDialog;
        private System.Windows.Forms.Label noOfConvexLabel;
        private System.Windows.Forms.Label noOfVerticesLabel;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.DomainUpDown noOfConvexDomain;
        private System.Windows.Forms.TrackBar speedTrackBar;
        private System.Windows.Forms.Label textureLabel;
        private System.Windows.Forms.Button textureButton;
        private System.Windows.Forms.Button startStopButton;
        private System.Windows.Forms.Label heightOfLightLabel;
        private System.Windows.Forms.Label lightColorLabel;
        private System.Windows.Forms.Button lightColorButton;
        private System.Windows.Forms.TextBox heightOfLightTextBox;
        private System.Windows.Forms.Label bumpMapLabel;
        private System.Windows.Forms.Button bumpMapButton;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.RadioButton lightPositionRadioButton;
        private System.Windows.Forms.Button testButton;
    }
}

