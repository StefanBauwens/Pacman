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
    public partial class WorldUI : UserControl
    {
        WorldController worldController;

        public WorldUI(WorldController controller)
        {
            worldController = controller;
            InitializeComponent();
        }
    }
}
