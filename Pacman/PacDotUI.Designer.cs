namespace Pacman
{
    partial class PacDotUI
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pacDotImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pacDotImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pacDotImage
            // 
            this.pacDotImage.Image = global::Pacman.Properties.Resources.pacdot;
            this.pacDotImage.Location = new System.Drawing.Point(0, 0);
            this.pacDotImage.Margin = new System.Windows.Forms.Padding(2);
            this.pacDotImage.Name = "pacDotImage";
            this.pacDotImage.Size = new System.Drawing.Size(16, 16);
            this.pacDotImage.TabIndex = 0;
            this.pacDotImage.TabStop = false;
            // 
            // PacDotUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pacDotImage);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PacDotUI";
            this.Size = new System.Drawing.Size(16, 16);
            ((System.ComponentModel.ISupportInitialize)(this.pacDotImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pacDotImage;
    }
}
