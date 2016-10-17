namespace Pacman
{
    partial class LivesUI
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
            this.imageLifeLeft = new System.Windows.Forms.PictureBox();
            this.imageLiveMiddle = new System.Windows.Forms.PictureBox();
            this.imageLifeRight = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageLifeLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageLiveMiddle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageLifeRight)).BeginInit();
            this.SuspendLayout();
            // 
            // imageLifeLeft
            // 
            this.imageLifeLeft.Image = global::Pacman.Properties.Resources.pacmanLives;
            this.imageLifeLeft.Location = new System.Drawing.Point(66, 13);
            this.imageLifeLeft.Name = "imageLifeLeft";
            this.imageLifeLeft.Size = new System.Drawing.Size(14, 19);
            this.imageLifeLeft.TabIndex = 0;
            this.imageLifeLeft.TabStop = false;
            // 
            // imageLiveMiddle
            // 
            this.imageLiveMiddle.Image = global::Pacman.Properties.Resources.pacmanLives;
            this.imageLiveMiddle.Location = new System.Drawing.Point(86, 13);
            this.imageLiveMiddle.Name = "imageLiveMiddle";
            this.imageLiveMiddle.Size = new System.Drawing.Size(24, 19);
            this.imageLiveMiddle.TabIndex = 1;
            this.imageLiveMiddle.TabStop = false;
            // 
            // imageLifeRight
            // 
            this.imageLifeRight.Image = global::Pacman.Properties.Resources.pacmanLives;
            this.imageLifeRight.Location = new System.Drawing.Point(117, 13);
            this.imageLifeRight.Name = "imageLifeRight";
            this.imageLifeRight.Size = new System.Drawing.Size(30, 19);
            this.imageLifeRight.TabIndex = 2;
            this.imageLifeRight.TabStop = false;
            // 
            // LivesUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.imageLifeRight);
            this.Controls.Add(this.imageLiveMiddle);
            this.Controls.Add(this.imageLifeLeft);
            this.Name = "LivesUI";
            ((System.ComponentModel.ISupportInitialize)(this.imageLifeLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageLiveMiddle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageLifeRight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox imageLifeLeft;
        public System.Windows.Forms.PictureBox imageLiveMiddle;
        public System.Windows.Forms.PictureBox imageLifeRight;
    }
}
