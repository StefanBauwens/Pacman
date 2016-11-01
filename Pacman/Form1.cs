using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Drawing.Text;
using System.Threading;

namespace Pacman
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.KeyPreview = true;
            InitializeComponent();
        }

        /*private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
        }*/

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            PlayerController.key = keyData;
            PlayerController.keyDelay = PlayerController.KEYSPEED;
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
