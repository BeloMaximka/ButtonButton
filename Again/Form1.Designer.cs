namespace Again
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.physicsTimer = new System.Windows.Forms.Timer(this.components);
            this.uptimeTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // physicsTimer
            // 
            this.physicsTimer.Enabled = true;
            this.physicsTimer.Interval = 16;
            this.physicsTimer.Tick += new System.EventHandler(this.physicsTimer_Tick);
            // 
            // uptimeTimer
            // 
            this.uptimeTimer.Enabled = true;
            this.uptimeTimer.Interval = 1;
            this.uptimeTimer.Tick += new System.EventHandler(this.uptimeTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "Form1";
            this.Text = "Кнопоки";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer physicsTimer;
        private System.Windows.Forms.Timer uptimeTimer;
    }
}