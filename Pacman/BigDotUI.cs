using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public partial class BigDotUI : UserControl
    {
        BigDotController controller;

        public BigDotUI(BigDotController bigDotController)
        {
            controller = bigDotController;
            InitializeComponent();
        }

        // update the dots to black image
        public void updateImage(bool isEaten)
        {
            if (isEaten)
            {
                this.bigDotImage.Image = Properties.Resources.black;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.controller.FlashImage();
        }
    }
}
