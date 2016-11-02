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
    public partial class DoorTileUI : UserControl
    {
        DoorTileController doorTileController;

        public DoorTileUI(DoorTileController controller)
        {
            doorTileController = controller;
            InitializeComponent();
        }
    }
}
