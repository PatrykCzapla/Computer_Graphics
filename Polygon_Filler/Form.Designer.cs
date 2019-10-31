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
            this.drawingPanel = new System.Windows.Forms.Panel();
            this.drawingPictureBox = new System.Windows.Forms.PictureBox();
            this.polygodRadioButton = new System.Windows.Forms.RadioButton();
            this.clearButton = new System.Windows.Forms.Button();
            this.editRadioButton = new System.Windows.Forms.RadioButton();
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
            this.backTableLayoutPanel.Size = new System.Drawing.Size(800, 461);
            this.backTableLayoutPanel.TabIndex = 0;
            // 
            // optionsTableLayoutPanel
            // 
            this.optionsTableLayoutPanel.ColumnCount = 2;
            this.optionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.optionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.optionsTableLayoutPanel.Controls.Add(this.polygodRadioButton, 0, 0);
            this.optionsTableLayoutPanel.Controls.Add(this.clearButton, 1, 1);
            this.optionsTableLayoutPanel.Controls.Add(this.editRadioButton, 1, 0);
            this.optionsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsTableLayoutPanel.Location = new System.Drawing.Point(603, 3);
            this.optionsTableLayoutPanel.Name = "optionsTableLayoutPanel";
            this.optionsTableLayoutPanel.RowCount = 5;
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.optionsTableLayoutPanel.Size = new System.Drawing.Size(194, 455);
            this.optionsTableLayoutPanel.TabIndex = 1;
            // 
            // drawingPanel
            // 
            this.drawingPanel.Controls.Add(this.drawingPictureBox);
            this.drawingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingPanel.Location = new System.Drawing.Point(3, 3);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(594, 455);
            this.drawingPanel.TabIndex = 0;
            // 
            // drawingPictureBox
            // 
            this.drawingPictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.drawingPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingPictureBox.Location = new System.Drawing.Point(0, 0);
            this.drawingPictureBox.Name = "drawingPictureBox";
            this.drawingPictureBox.Size = new System.Drawing.Size(594, 455);
            this.drawingPictureBox.TabIndex = 0;
            this.drawingPictureBox.TabStop = false;
            this.drawingPictureBox.Click += new System.EventHandler(this.drawingPictureBox_Click);
            // 
            // polygodRadioButton
            // 
            this.polygodRadioButton.AutoSize = true;
            this.polygodRadioButton.Checked = true;
            this.polygodRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.polygodRadioButton.Location = new System.Drawing.Point(3, 3);
            this.polygodRadioButton.Name = "polygodRadioButton";
            this.polygodRadioButton.Size = new System.Drawing.Size(91, 44);
            this.polygodRadioButton.TabIndex = 0;
            this.polygodRadioButton.TabStop = true;
            this.polygodRadioButton.Text = "Draw polygon";
            this.polygodRadioButton.UseVisualStyleBackColor = true;
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
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 461);
            this.Controls.Add(this.backTableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Form";
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
        private System.Windows.Forms.RadioButton polygodRadioButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.RadioButton editRadioButton;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

