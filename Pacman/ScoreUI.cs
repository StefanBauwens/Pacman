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
    public partial class ScoreUI : UserControl
    {
        public ScoreUI()
        {
            InitializeComponent();
        }

        // update the score label with new score
        public void updateScore(int newScore)
        {
            this.scoreValueLabel.Text = newScore.ToString();
        }

        /*private void label1_Click(object sender, EventArgs e)
        {

        }*/
    }
}
