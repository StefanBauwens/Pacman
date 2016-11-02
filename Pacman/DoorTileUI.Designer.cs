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
            this.doorTile = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.doorTile)).BeginInit();
            this.SuspendLayout();
            // 
            // doorTile
            // 
            this.doorTile.Image = global::Pacman.Properties.Resources.doorTileEnemies;
            this.doorTile.Location = new System.Drawing.Point(0, 0);
            this.doorTile.Name = "doorTile";
            this.doorTile.Size = new System.Drawing.Size(22, 16);
            this.doorTile.TabIndex = 0;
            this.doorTile.TabStop = false;
            // 
            // DoorTileUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.doorTile);
            this.Name = "DoorTileUI";
            this.Size = new System.Drawing.Size(22, 16);
            ((System.ComponentModel.ISupportInitialize)(this.doorTile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox doorTile;
    }
}
