using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public class DoorTileController
    {
        TileModel doorTileModel;// use model from tile
        DoorTileUI doorTileUI;

        public DoorTileController()
        {
            doorTileModel = new TileModel();
            doorTileUI = new DoorTileUI(this);
        }

        public DoorTileUI View
        {
            get { return doorTileUI; }
        }

        public TileModel Model
        {
            get { return this.doorTileModel; }
            set { this.doorTileModel = value; }
        }

    }
}
