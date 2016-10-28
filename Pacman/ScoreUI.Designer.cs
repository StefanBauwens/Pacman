namespace Pacman
{
    partial class ScoreUI
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
            this.scoreTextLabel = new System.Windows.Forms.Label();
            this.scoreValueLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // scoreTextLabel
            // 
            this.scoreTextLabel.AutoSize = true;
            this.scoreTextLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.scoreTextLabel.Location = new System.Drawing.Point(23, 18);
            this.scoreTextLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.scoreTextLabel.Name = "scoreTextLabel";
            this.scoreTextLabel.Size = new System.Drawing.Size(38, 13);
            this.scoreTextLabel.TabIndex = 0;
            this.scoreTextLabel.Text = "Score:";
            // 
            // scoreValueLabel
            // 
            this.scoreValueLabel.AutoSize = true;
            this.scoreValueLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.scoreValueLabel.Location = new System.Drawing.Point(68, 17);
            this.scoreValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.scoreValueLabel.Name = "scoreValueLabel";
            this.scoreValueLabel.Size = new System.Drawing.Size(13, 13);
            this.scoreValueLabel.TabIndex = 1;
            this.scoreValueLabel.Text = "0";
            // 
            // ScoreUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scoreValueLabel);
            this.Controls.Add(this.scoreTextLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ScoreUI";
            this.Size = new System.Drawing.Size(113, 43);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label scoreTextLabel;
        private System.Windows.Forms.Label scoreValueLabel;
    }
}
