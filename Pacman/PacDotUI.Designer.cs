﻿namespace Pacman
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
            this.pacDotImage.Location = new System.Drawing.Point(29, 19);
            this.pacDotImage.Name = "pacDotImage";
            this.pacDotImage.Size = new System.Drawing.Size(100, 50);
            this.pacDotImage.TabIndex = 0;
            this.pacDotImage.TabStop = false;
            // 
            // PacDotUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pacDotImage);
            this.Name = "PacDotUI";
            ((System.ComponentModel.ISupportInitialize)(this.pacDotImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pacDotImage;
    }
}
