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
            this.polygonRadioButton = new System.Windows.Forms.RadioButton();
            this.clearButton = new System.Windows.Forms.Button();
            this.editRadioButton = new System.Windows.Forms.RadioButton();
            this.generateConvexButton = new System.Windows.Forms.Button();
            this.convexDomain = new System.Windows.Forms.DomainUpDown();
            this.drawingPanel = new System.Windows.Forms.Panel();
            this.drawingPictureBox = new System.Windows.Forms.PictureBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.backTableLayoutPanel.SuspendLayout();
            this.optionsTableLayoutPanel.SuspendLayout();
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
            this.backTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.backTableLayoutPanel.Size = new System.Drawing.Size(1384, 861);
            this.backTableLayoutPanel.TabIndex = 0;
            // 
            // optionsTableLayoutPanel
            // 
            this.optionsTableLayoutPanel.ColumnCount = 2;
            this.optionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.optionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.optionsTableLayoutPanel.Controls.Add(this.polygonRadioButton, 0, 0);
            this.optionsTableLayoutPanel.Controls.Add(this.clearButton, 1, 1);
            this.optionsTableLayoutPanel.Controls.Add(this.editRadioButton, 1, 0);
            this.optionsTableLayoutPanel.Controls.Add(this.generateConvexButton, 1, 2);
            this.optionsTableLayoutPanel.Controls.Add(this.convexDomain, 0, 2);
            this.optionsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsTableLayoutPanel.Location = new System.Drawing.Point(1187, 3);
            this.optionsTableLayoutPanel.Name = "optionsTableLayoutPanel";
            this.optionsTableLayoutPanel.RowCount = 5;
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.optionsTableLayoutPanel.Size = new System.Drawing.Size(194, 855);
            this.optionsTableLayoutPanel.TabIndex = 1;
            // 
            // polygonRadioButton
            // 
            this.polygonRadioButton.AutoSize = true;
            this.polygonRadioButton.Checked = true;
            this.polygonRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.polygonRadioButton.Location = new System.Drawing.Point(3, 3);
            this.polygonRadioButton.Name = "polygonRadioButton";
            this.polygonRadioButton.Size = new System.Drawing.Size(91, 44);
            this.polygonRadioButton.TabIndex = 0;
            this.polygonRadioButton.TabStop = true;
            this.polygonRadioButton.Text = "Draw polygon";
            this.polygonRadioButton.UseVisualStyleBackColor = true;
            this.polygonRadioButton.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // clearButton
            // 
            this.clearButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clearButton.Location = new System.Drawing.Point(100, 60);
            this.clearButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(91, 30);
            this.clearButton.TabIndex = 1;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // editRadioButton
            // 
            this.editRadioButton.AutoSize = true;
            this.editRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editRadioButton.Location = new System.Drawing.Point(100, 3);
            this.editRadioButton.Name = "editRadioButton";
            this.editRadioButton.Size = new System.Drawing.Size(91, 44);
            this.editRadioButton.TabIndex = 2;
            this.editRadioButton.TabStop = true;
            this.editRadioButton.Text = "Edit polygon";
            this.editRadioButton.UseVisualStyleBackColor = true;
            this.editRadioButton.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // generateConvexButton
            // 
            this.generateConvexButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generateConvexButton.Location = new System.Drawing.Point(100, 103);
            this.generateConvexButton.Name = "generateConvexButton";
            this.generateConvexButton.Size = new System.Drawing.Size(91, 44);
            this.generateConvexButton.TabIndex = 4;
            this.generateConvexButton.Text = "Generate convex";
            this.generateConvexButton.UseVisualStyleBackColor = true;
            this.generateConvexButton.Click += new System.EventHandler(this.generateConvexButton_Click);
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
            this.convexDomain.Location = new System.Drawing.Point(24, 115);
            this.convexDomain.Name = "convexDomain";
            this.convexDomain.Size = new System.Drawing.Size(49, 20);
            this.convexDomain.TabIndex = 3;
            this.convexDomain.Text = "3";
            this.convexDomain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // drawingPanel
            // 
            this.drawingPanel.Controls.Add(this.drawingPictureBox);
            this.drawingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingPanel.Location = new System.Drawing.Point(3, 3);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(1178, 855);
            this.drawingPanel.TabIndex = 0;
            // 
            // drawingPictureBox
            // 
            this.drawingPictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.drawingPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingPictureBox.Location = new System.Drawing.Point(0, 0);
            this.drawingPictureBox.Name = "drawingPictureBox";
            this.drawingPictureBox.Size = new System.Drawing.Size(1178, 855);
            this.drawingPictureBox.TabIndex = 0;
            this.drawingPictureBox.TabStop = false;
            this.drawingPictureBox.SizeChanged += new System.EventHandler(this.drawingPictureBox_SizeChanged);
            this.drawingPictureBox.Click += new System.EventHandler(this.drawingPictureBox_Click);
            this.drawingPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawingPictureBox_MouseDown);
            this.drawingPictureBox.MouseLeave += new System.EventHandler(this.drawingPictureBox_MouseLeave);
            this.drawingPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawingPictureBox_MouseMove);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 861);
            this.Controls.Add(this.backTableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Form";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Polygon filler";
            this.backTableLayoutPanel.ResumeLayout(false);
            this.optionsTableLayoutPanel.ResumeLayout(false);
            this.optionsTableLayoutPanel.PerformLayout();
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
    }
}

