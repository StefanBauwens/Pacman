using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class TileModel
    {
        bool mCanWalkThrough;

        public bool CanWakThrough
        {
            get { return mCanWalkThrough; }
            set { mCanWalkThrough = value; }
        }
    }
}
