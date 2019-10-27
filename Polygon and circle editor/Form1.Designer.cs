namespace Polygon_and_circle_editor
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
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.drawingPanel = new System.Windows.Forms.Panel();
            this.drawingPictureBox = new System.Windows.Forms.PictureBox();
            this.optionsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.clearButton = new System.Windows.Forms.Button();
            this.colorLabel = new System.Windows.Forms.Label();
            this.colorButton = new System.Windows.Forms.Button();
            this.actionGroupBox = new System.Windows.Forms.GroupBox();
            this.actionsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.redoButton = new System.Windows.Forms.Button();
            this.undoButton = new System.Windows.Forms.Button();
            this.actionsPanel = new System.Windows.Forms.Panel();
            this.actionsTextBox = new System.Windows.Forms.TextBox();
            this.tipLabel = new System.Windows.Forms.Label();
            this.polygonButton = new System.Windows.Forms.RadioButton();
            this.circleButton = new System.Windows.Forms.RadioButton();
            this.editButton = new System.Windows.Forms.RadioButton();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.drawingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawingPictureBox)).BeginInit();
            this.optionsTableLayoutPanel.SuspendLayout();
            this.actionGroupBox.SuspendLayout();
            this.actionsTableLayoutPanel.SuspendLayout();
            this.actionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // colorDialog
            // 
            this.colorDialog.AllowFullOpen = false;
            this.colorDialog.ShowHelp = true;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel.Controls.Add(this.drawingPanel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.optionsTableLayoutPanel, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(884, 461);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // drawingPanel
            // 
            this.drawingPanel.Controls.Add(this.drawingPictureBox);
            this.drawingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingPanel.Location = new System.Drawing.Point(3, 3);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(678, 455);
            this.drawingPanel.TabIndex = 0;
            // 
            // drawingPictureBox
            // 
            this.drawingPictureBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.drawingPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingPictureBox.Location = new System.Drawing.Point(0, 0);
            this.drawingPictureBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.drawingPictureBox.Name = "drawingPictureBox";
            this.drawingPictureBox.Size = new System.Drawing.Size(678, 455);
            this.drawingPictureBox.TabIndex = 0;
            this.drawingPictureBox.TabStop = false;
            this.drawingPictureBox.SizeChanged += new System.EventHandler(this.DrawingPictureBox_SizeChanged);
            this.drawingPictureBox.Click += new System.EventHandler(this.DrawingPictureBox_Click);
            this.drawingPictureBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.drawingPictureBox_MouseDoubleClick);
            this.drawingPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawingPictureBox_MouseDown);
            this.drawingPictureBox.MouseLeave += new System.EventHandler(this.DrawingPictureBox_MouseLeave);
            this.drawingPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawingPictureBox_MouseMove);
            // 
            // optionsTableLayoutPanel
            // 
            this.optionsTableLayoutPanel.ColumnCount = 2;
            this.optionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.optionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.optionsTableLayoutPanel.Controls.Add(this.clearButton, 1, 3);
            this.optionsTableLayoutPanel.Controls.Add(this.colorLabel, 0, 1);
            this.optionsTableLayoutPanel.Controls.Add(this.colorButton, 1, 1);
            this.optionsTableLayoutPanel.Controls.Add(this.actionGroupBox, 0, 4);
            this.optionsTableLayoutPanel.Controls.Add(this.tipLabel, 0, 0);
            this.optionsTableLayoutPanel.Controls.Add(this.polygonButton, 0, 2);
            this.optionsTableLayoutPanel.Controls.Add(this.circleButton, 1, 2);
            this.optionsTableLayoutPanel.Controls.Add(this.editButton, 0, 3);
            this.optionsTableLayoutPanel.Controls.Add(this.saveButton, 0, 5);
            this.optionsTableLayoutPanel.Controls.Add(this.openButton, 1, 5);
            this.optionsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsTableLayoutPanel.Location = new System.Drawing.Point(687, 3);
            this.optionsTableLayoutPanel.Name = "optionsTableLayoutPanel";
            this.optionsTableLayoutPanel.RowCount = 6;
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.optionsTableLayoutPanel.Size = new System.Drawing.Size(194, 455);
            this.optionsTableLayoutPanel.TabIndex = 1;
            // 
            // clearButton
            // 
            this.clearButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clearButton.Location = new System.Drawing.Point(107, 130);
            this.clearButton.Margin = new System.Windows.Forms.Padding(10);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(77, 30);
            this.clearButton.TabIndex = 5;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorLabel.Location = new System.Drawing.Point(3, 33);
            this.colorLabel.Margin = new System.Windows.Forms.Padding(3);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Padding = new System.Windows.Forms.Padding(10);
            this.colorLabel.Size = new System.Drawing.Size(91, 34);
            this.colorLabel.TabIndex = 0;
            this.colorLabel.Text = "Color:";
            this.colorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // colorButton
            // 
            this.colorButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorButton.Location = new System.Drawing.Point(107, 40);
            this.colorButton.Margin = new System.Windows.Forms.Padding(10);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(77, 20);
            this.colorButton.TabIndex = 1;
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.BackColorChanged += new System.EventHandler(this.ColorButton_BackColorChanged);
            this.colorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // actionGroupBox
            // 
            this.optionsTableLayoutPanel.SetColumnSpan(this.actionGroupBox, 2);
            this.actionGroupBox.Controls.Add(this.actionsTableLayoutPanel);
            this.actionGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionGroupBox.Location = new System.Drawing.Point(3, 173);
            this.actionGroupBox.Name = "actionGroupBox";
            this.actionGroupBox.Size = new System.Drawing.Size(188, 249);
            this.actionGroupBox.TabIndex = 6;
            this.actionGroupBox.TabStop = false;
            this.actionGroupBox.Text = "Actions";
            // 
            // actionsTableLayoutPanel
            // 
            this.actionsTableLayoutPanel.ColumnCount = 2;
            this.actionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.actionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.actionsTableLayoutPanel.Controls.Add(this.redoButton, 1, 0);
            this.actionsTableLayoutPanel.Controls.Add(this.undoButton, 0, 0);
            this.actionsTableLayoutPanel.Controls.Add(this.actionsPanel, 0, 1);
            this.actionsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionsTableLayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.actionsTableLayoutPanel.Name = "actionsTableLayoutPanel";
            this.actionsTableLayoutPanel.RowCount = 2;
            this.actionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.actionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.actionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.actionsTableLayoutPanel.Size = new System.Drawing.Size(182, 230);
            this.actionsTableLayoutPanel.TabIndex = 0;
            // 
            // redoButton
            // 
            this.redoButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.redoButton.Location = new System.Drawing.Point(101, 10);
            this.redoButton.Margin = new System.Windows.Forms.Padding(10);
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(71, 30);
            this.redoButton.TabIndex = 5;
            this.redoButton.Text = "Redo";
            this.redoButton.UseVisualStyleBackColor = true;
            this.redoButton.Click += new System.EventHandler(this.redoButton_Click);
            // 
            // undoButton
            // 
            this.undoButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.undoButton.Location = new System.Drawing.Point(10, 10);
            this.undoButton.Margin = new System.Windows.Forms.Padding(10);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(71, 30);
            this.undoButton.TabIndex = 3;
            this.undoButton.Text = "Undo";
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // actionsPanel
            // 
            this.actionsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actionsPanel.AutoScroll = true;
            this.actionsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.actionsTableLayoutPanel.SetColumnSpan(this.actionsPanel, 2);
            this.actionsPanel.Controls.Add(this.actionsTextBox);
            this.actionsPanel.Location = new System.Drawing.Point(3, 53);
            this.actionsPanel.Name = "actionsPanel";
            this.actionsPanel.Size = new System.Drawing.Size(176, 174);
            this.actionsPanel.TabIndex = 6;
            // 
            // actionsTextBox
            // 
            this.actionsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.actionsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.actionsTextBox.Location = new System.Drawing.Point(0, 0);
            this.actionsTextBox.Multiline = true;
            this.actionsTextBox.Name = "actionsTextBox";
            this.actionsTextBox.ReadOnly = true;
            this.actionsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.actionsTextBox.Size = new System.Drawing.Size(176, 174);
            this.actionsTextBox.TabIndex = 0;
            this.actionsTextBox.WordWrap = false;
            // 
            // tipLabel
            // 
            this.tipLabel.AutoSize = true;
            this.tipLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.optionsTableLayoutPanel.SetColumnSpan(this.tipLabel, 2);
            this.tipLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tipLabel.Location = new System.Drawing.Point(3, 3);
            this.tipLabel.Margin = new System.Windows.Forms.Padding(3);
            this.tipLabel.Name = "tipLabel";
            this.tipLabel.Size = new System.Drawing.Size(188, 24);
            this.tipLabel.TabIndex = 7;
            this.tipLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // polygonButton
            // 
            this.polygonButton.AutoSize = true;
            this.polygonButton.Checked = true;
            this.polygonButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.polygonButton.Location = new System.Drawing.Point(3, 73);
            this.polygonButton.Name = "polygonButton";
            this.polygonButton.Size = new System.Drawing.Size(91, 44);
            this.polygonButton.TabIndex = 8;
            this.polygonButton.TabStop = true;
            this.polygonButton.Text = "Polygon";
            this.polygonButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.polygonButton.UseVisualStyleBackColor = true;
            this.polygonButton.CheckedChanged += new System.EventHandler(this.Button_CheckedChanged);
            // 
            // circleButton
            // 
            this.circleButton.AutoSize = true;
            this.circleButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.circleButton.Location = new System.Drawing.Point(100, 73);
            this.circleButton.Name = "circleButton";
            this.circleButton.Size = new System.Drawing.Size(91, 44);
            this.circleButton.TabIndex = 9;
            this.circleButton.Text = "Circle";
            this.circleButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.circleButton.UseVisualStyleBackColor = true;
            this.circleButton.CheckedChanged += new System.EventHandler(this.Button_CheckedChanged);
            // 
            // editButton
            // 
            this.editButton.AutoSize = true;
            this.editButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editButton.Location = new System.Drawing.Point(3, 123);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(91, 44);
            this.editButton.TabIndex = 10;
            this.editButton.Text = "Edit";
            this.editButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.CheckedChanged += new System.EventHandler(this.Button_CheckedChanged);
            // 
            // saveButton
            // 
            this.saveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saveButton.Location = new System.Drawing.Point(3, 428);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(91, 24);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // openButton
            // 
            this.openButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openButton.Location = new System.Drawing.Point(100, 428);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(91, 24);
            this.openButton.TabIndex = 12;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.tableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Polygon and circle editor";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.tableLayoutPanel.ResumeLayout(false);
            this.drawingPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drawingPictureBox)).EndInit();
            this.optionsTableLayoutPanel.ResumeLayout(false);
            this.optionsTableLayoutPanel.PerformLayout();
            this.actionGroupBox.ResumeLayout(false);
            this.actionsTableLayoutPanel.ResumeLayout(false);
            this.actionsPanel.ResumeLayout(false);
            this.actionsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Panel drawingPanel;
        private System.Windows.Forms.PictureBox drawingPictureBox;
        private System.Windows.Forms.TableLayoutPanel optionsTableLayoutPanel;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.GroupBox actionGroupBox;
        private System.Windows.Forms.TableLayoutPanel actionsTableLayoutPanel;
        private System.Windows.Forms.Button undoButton;
        private System.Windows.Forms.Button redoButton;
        private System.Windows.Forms.Label tipLabel;
        private System.Windows.Forms.RadioButton polygonButton;
        private System.Windows.Forms.RadioButton circleButton;
        private System.Windows.Forms.RadioButton editButton;
        private System.Windows.Forms.Panel actionsPanel;
        private System.Windows.Forms.TextBox actionsTextBox;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button openButton;
    }
}

