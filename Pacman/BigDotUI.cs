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
        public BigDotUI()
        {
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
    }
}
