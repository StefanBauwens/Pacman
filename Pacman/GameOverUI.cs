using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace Pacman
{
    public partial class GameOverUI : UserControl
    {
        
        GameOverController gameOverController;

        public GameOverUI(GameOverController controller)
        {
            gameOverController = controller;
            InitializeComponent();
            gameOverLabel.Font = LoadFont.loadFont(10);
        }

        private void gameOverLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
