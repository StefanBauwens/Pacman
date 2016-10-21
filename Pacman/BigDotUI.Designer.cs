namespace Pacman
{
    partial class BigDotUI
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
            this.bigDotImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.bigDotImage)).BeginInit();
            this.SuspendLayout();
            // 
            // bigDotImage
            // 
            this.bigDotImage.Image = global::Pacman.Properties.Resources.bigdot;
            this.bigDotImage.Location = new System.Drawing.Point(0, 0);
            this.bigDotImage.Margin = new System.Windows.Forms.Padding(2);
            this.bigDotImage.Name = "bigDotImage";
            this.bigDotImage.Size = new System.Drawing.Size(16, 16);
            this.bigDotImage.TabIndex = 0;
            this.bigDotImage.TabStop = false;
            // 
            // BigDotUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bigDotImage);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "BigDotUI";
            this.Size = new System.Drawing.Size(16, 16);
            ((System.ComponentModel.ISupportInitialize)(this.bigDotImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox bigDotImage;
    }
}
