namespace Pacman
{
    partial class Form1
    {
        public PlayerController player;

        //public PlayerController player;
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
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 336);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

            player = new PlayerController();
            player.view.Top = 16; //change this later by doing the initialising in worldcontroller!!
            player.view.Left = 16;
            this.Controls.Add(player.view);

            TileController beginTile = new TileController();
            beginTile.Model.X = 9;
            beginTile.Model.Y = 9;

            EnemyController blinky = new EnemyController(player, beginTile);
            blinky.View.Top = 16;
            blinky.View.Left = 16;
            this.Controls.Add(blinky.View);

            EnemyController blinky1 = new EnemyController(player, beginTile);
            blinky1.View.Top = 16;
            blinky1.View.Left = 32;
            blinky1.Model.X = 2;
            this.Controls.Add(blinky1.View);

            EnemyController blinky2 = new EnemyController(player, beginTile);
            blinky2.View.Top = 16;
            blinky2.View.Left = 16;
            this.Controls.Add(blinky2.View);

            EnemyController blinky3 = new EnemyController(player, beginTile);
            blinky3.View.Top = 16;
            blinky3.View.Left = 16;
            this.Controls.Add(blinky3.View);

            //LivesController lives = new LivesController();
            //this.Controls.Add(lives.view);

            WorldController world = new WorldController();
            this.Controls.Add(world.view);

        }

        #endregion
    }
}

