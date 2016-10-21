using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public partial class Form1 : Form
    {
        public Form1()
        {   
            InitializeComponent();
        }

        /*private void timer1_Tick(object sender, EventArgs e)
        {
        }*/

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //player.checkKey(e);
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            player.checkKey(e);
        }
    }
}
