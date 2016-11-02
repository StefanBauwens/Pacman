using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class TileModel
    {
        protected bool mCanWalkThrough;
        protected int mX;
        protected int mY;
        
        public int X
        {
            get { return mX; }
            set { mX = value; }
        }

        public int Y
        {
            get { return mY; }
            set { mY = value; }
        }

        public bool CanWalkThrough
        {
            get { return mCanWalkThrough; }
            set { mCanWalkThrough = value; }
        }
    }
}
