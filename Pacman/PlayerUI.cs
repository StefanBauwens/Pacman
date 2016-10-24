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
    public partial class PlayerUI : UserControl
    {
        PlayerController playerController;

        public PlayerUI(PlayerController controller)
        {
            playerController = controller;
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            playerController.movePlayer();
        }

        /*private void PlayerUI_KeyDown(object sender, KeyEventArgs e)
        {
           // playerController.checkKey(e);
        }*/
        
        private void PlayerUI_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            playerController.checkKeyAFewTimes(e);
            //playerController.checkKey(e);
        }

        private void PlayerUI_KeyDown(object sender, KeyEventArgs e)
        {
            //playerController.checkKey(e);
        }
    }
}
