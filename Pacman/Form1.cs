using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace Pacman
{
    public partial class Form1 : Form
    {
        public Form1()
        {   
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //player.checkKey(e);
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            player.checkKey(e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //PrivateFontCollection pfc = new PrivateFontCollection();
            //pfc.AddFontFile(@"Resources\pacmanfont.ttf");
            //this.Font = new Font(pfc.Families[0], 15, FontStyle.Regular);
            //this.scoreTextLabel.Font = new Font(pfc.Families[0], 10, FontStyle.Regular);

            /*for (int i = 0; i < this.Controls.Count; i++)
            {

                foreach(Label l in Controls[i].labe)
                {
                    l.Font = new Font(pfc.Families[0], 10, FontStyle.Regular);
                }
            }*/
        }
    }
}
