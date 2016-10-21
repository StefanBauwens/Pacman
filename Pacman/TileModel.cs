using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class TileModel
    {
        protected bool mCanWalkThrough;

        public bool CanWalkThrough
        {
            get { return mCanWalkThrough; }
            set { mCanWalkThrough = value; }
        }
    }
}
