using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class PlayerModel
    {
        int mX = 1; //coordinates player
        int mY = 1;

        public enum direction
        {
            up,
            right,
            down,
            left
        }

        direction mDir = direction.right;

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

        public direction Direction
        {
            get { return mDir; }
            set { mDir = value; }
        }

    }
}
