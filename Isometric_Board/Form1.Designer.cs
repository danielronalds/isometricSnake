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
            this.helpButton = new System.Windows.Forms.Label();
            this.refreshScreen = new System.Windows.Forms.Timer(this.components);
            this.Canvas.SuspendLayout();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.Canvas.Controls.Add(this.helpButton);
            this.Canvas.Location = new System.Drawing.Point(0, 0);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(840, 690);
            this.Canvas.TabIndex = 0;
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            // 
            // helpButton
            // 
            this.helpButton.AutoSize = true;
            this.helpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpButton.ForeColor = System.Drawing.SystemColors.Control;
            this.helpButton.Location = new System.Drawing.Point(802, 641);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Canvas;
        private System.Windows.Forms.Timer refreshScreen;
        private System.Windows.Forms.Label helpButton;
    }
}

