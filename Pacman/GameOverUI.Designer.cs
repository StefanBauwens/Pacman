﻿namespace Pacman
{
    partial class GameOverUI
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
            this.gameOverLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameOverLabel
            // 
            this.gameOverLabel.AutoSize = true;
            this.gameOverLabel.BackColor = System.Drawing.SystemColors.Control;
            this.gameOverLabel.Font = new System.Drawing.Font("8bit", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameOverLabel.ForeColor = System.Drawing.Color.Red;
            this.gameOverLabel.Location = new System.Drawing.Point(30, 14);
            this.gameOverLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gameOverLabel.Name = "gameOverLabel";
            this.gameOverLabel.Size = new System.Drawing.Size(83, 14);
            this.gameOverLabel.TabIndex = 0;
            this.gameOverLabel.Text = "GAME   OVER";
            this.gameOverLabel.Click += new System.EventHandler(this.gameOverLabel_Click);
            // 
            // GameOverUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gameOverLabel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GameOverUI";
            this.Size = new System.Drawing.Size(153, 43);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label gameOverLabel;
    }
}
