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
            this.bigDotImage.Location = new System.Drawing.Point(50, 20);
            this.bigDotImage.Name = "bigDotImage";
            this.bigDotImage.Size = new System.Drawing.Size(100, 50);
            this.bigDotImage.TabIndex = 0;
            this.bigDotImage.TabStop = false;
            // 
            // BigDotUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bigDotImage);
            this.Name = "BigDotUI";
            ((System.ComponentModel.ISupportInitialize)(this.bigDotImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox bigDotImage;
    }
}
