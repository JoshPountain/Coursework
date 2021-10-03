namespace Coursework_V._1
{
    partial class MainWindow
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
            this.pbSpace = new System.Windows.Forms.PictureBox();
            this.UniversalTime = new System.Windows.Forms.Timer(this.components);
            this.LocalTime = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbSpace)).BeginInit();
            this.SuspendLayout();
            // 
            // pbSpace
            // 
            this.pbSpace.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pbSpace.Location = new System.Drawing.Point(12, 12);
            this.pbSpace.Name = "pbSpace";
            this.pbSpace.Size = new System.Drawing.Size(776, 426);
            this.pbSpace.TabIndex = 0;
            this.pbSpace.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pbSpace);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSpace)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSpace;
        private System.Windows.Forms.Timer UniversalTime;
        private System.Windows.Forms.Timer LocalTime;
    }
}

