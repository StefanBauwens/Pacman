namespace Pacman
{
    partial class ReadyUI
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
            this.readyLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // readyLabel
            // 
            this.readyLabel.AutoSize = true;
            this.readyLabel.Font = new System.Drawing.Font("8bit", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.readyLabel.ForeColor = System.Drawing.Color.Yellow;
            this.readyLabel.Location = new System.Drawing.Point(5, 1);
            this.readyLabel.Name = "readyLabel";
            this.readyLabel.Size = new System.Drawing.Size(53, 15);
            this.readyLabel.TabIndex = 0;
            this.readyLabel.Text = "READY!";
            // 
            // ReadyUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.readyLabel);
            this.Name = "ReadyUI";
            this.Size = new System.Drawing.Size(65, 18);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label readyLabel;
    }
}
