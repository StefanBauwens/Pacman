namespace Pacman
{
    partial class EnemyUI
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
            this.enemyImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.enemyImage)).BeginInit();
            this.SuspendLayout();
            // 
            // enemyImage
            // 
            this.enemyImage.Image = global::Pacman.Properties.Resources.blinky;
            this.enemyImage.Location = new System.Drawing.Point(0, 0);
            this.enemyImage.Margin = new System.Windows.Forms.Padding(4);
            this.enemyImage.Name = "enemyImage";
            this.enemyImage.Size = new System.Drawing.Size(21, 20);
            this.enemyImage.TabIndex = 0;
            this.enemyImage.TabStop = false;
            this.enemyImage.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // EnemyUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.enemyImage);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "EnemyUI";
            this.Size = new System.Drawing.Size(248, 185);
            ((System.ComponentModel.ISupportInitialize)(this.enemyImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox enemyImage;
    }
}
