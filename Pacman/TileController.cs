using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class TileController
    {
        TileModel tileModel;
        TileUI tileUI;

        public TileController()
        {
            tileModel = new TileModel();
            tileUI = new TileUI(this);
        }

        public TileUI View
        {
            get { return this.tileUI; }
        }
    }
}
