namespace Pacman
{
    partial class DoorTileUI
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
            this.doorTileImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.doorTileImage)).BeginInit();
            this.SuspendLayout();
            // 
            // doorTileImage
            // 
            this.doorTileImage.Image = global::Pacman.Properties.Resources.doorTileEnemies;
            this.doorTileImage.Location = new System.Drawing.Point(0, 0);
            this.doorTileImage.Name = "doorTileImage";
            this.doorTileImage.Size = new System.Drawing.Size(16, 16);
            this.doorTileImage.TabIndex = 0;
            this.doorTileImage.TabStop = false;
            // 
            // DoorTileUI
            // 
            this.Controls.Add(this.doorTileImage);
            this.Name = "DoorTileUI";
            this.Size = new System.Drawing.Size(16, 16);
            ((System.ComponentModel.ISupportInitialize)(this.doorTileImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox doorTile;
        private System.Windows.Forms.PictureBox doorTileImage;
    }
}
