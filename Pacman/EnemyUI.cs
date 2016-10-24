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
    public partial class EnemyUI : UserControl
    {
        EnemyController enemyController;

        public EnemyUI(EnemyController controller)
        {
            enemyController = controller;
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void updateImage(bool isRunningAway)
        {
            if(isRunningAway)
            {
                //this.enemyImage.Image = Properties.Resources.Naam van blauwe image
            }
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.enemyController.moveEnemy();
        }
    }
}
