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
    public partial class LivesUI : UserControl
    {
        public LivesUI()
        {
            InitializeComponent();
        }

        // update view by changing images of lives (lives --> black)
        public void updateLives(int newNrLives)
        {
            if (newNrLives == 2)
            {
                this.imageLifeRight.Image = Properties.Resources.black;
            }
            else if (newNrLives == 1)
            {
                this.imageLifeMiddle.Image = Properties.Resources.black;
            }
            else if (newNrLives == 0)
            {
                this.imageLifeLeft.Image = Properties.Resources.black;
            }
        }

        
    }
}
