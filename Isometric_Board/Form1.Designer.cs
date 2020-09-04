namespace isometricSnake
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Canvas = new System.Windows.Forms.Panel();
            this.borderButton = new System.Windows.Forms.PictureBox();
            this.namePanel = new System.Windows.Forms.Panel();
            this.nameField = new System.Windows.Forms.TextBox();
            this.helpButton = new System.Windows.Forms.Label();
            this.refreshScreen = new System.Windows.Forms.Timer(this.components);
            this.Canvas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.borderButton)).BeginInit();
            this.namePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.Canvas.Controls.Add(this.borderButton);
            this.Canvas.Controls.Add(this.namePanel);
            this.Canvas.Controls.Add(this.helpButton);
            this.Canvas.Location = new System.Drawing.Point(0, 0);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(840, 690);
            this.Canvas.TabIndex = 0;
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            // 
            // borderButton
            // 
            this.borderButton.Image = global::isometricSnake.Properties.Resources.borders_button_off;
            this.borderButton.Location = new System.Drawing.Point(12, 629);
            this.borderButton.Name = "borderButton";
            this.borderButton.Size = new System.Drawing.Size(48, 48);
            this.borderButton.TabIndex = 2;
            this.borderButton.TabStop = false;
            this.borderButton.Click += new System.EventHandler(this.borderButton_Click);
            // 
            // namePanel
            // 
            this.namePanel.BackColor = System.Drawing.Color.White;
            this.namePanel.Controls.Add(this.nameField);
            this.namePanel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.namePanel.Location = new System.Drawing.Point(327, 321);
            this.namePanel.Name = "namePanel";
            this.namePanel.Size = new System.Drawing.Size(187, 49);
            this.namePanel.TabIndex = 1;
            // 
            // nameField
            // 
            this.nameField.Location = new System.Drawing.Point(15, 14);
            this.nameField.Name = "nameField";
            this.nameField.Size = new System.Drawing.Size(156, 20);
            this.nameField.TabIndex = 0;
            this.nameField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nameField_KeyDown);
            // 
            // helpButton
            // 
            this.helpButton.AutoSize = true;
            this.helpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpButton.ForeColor = System.Drawing.SystemColors.Control;
            this.helpButton.Location = new System.Drawing.Point(787, 627);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(24, 25);
            this.helpButton.TabIndex = 0;
            this.helpButton.Text = "?";
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // refreshScreen
            // 
            this.refreshScreen.Enabled = true;
            this.refreshScreen.Interval = 70;
            this.refreshScreen.Tick += new System.EventHandler(this.refreshScreen_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 689);
            this.Controls.Add(this.Canvas);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Isometric Snake";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Canvas.ResumeLayout(false);
            this.Canvas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.borderButton)).EndInit();
            this.namePanel.ResumeLayout(false);
            this.namePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Canvas;
        private System.Windows.Forms.Timer refreshScreen;
        private System.Windows.Forms.Label helpButton;
        private System.Windows.Forms.Panel namePanel;
        private System.Windows.Forms.TextBox nameField;
        private System.Windows.Forms.PictureBox borderButton;
    }
}

