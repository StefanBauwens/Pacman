using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        protected direction mDir = direction.right;
        protected int mAnimation = 1;
        protected bool mIsDead = false;
        protected PreviewKeyDownEventArgs mLastKeyPressed;

        public bool IsDead
        {
            get { return mIsDead; }
            set { mIsDead = value; }
        }

        public PreviewKeyDownEventArgs LastKeyPressed
        {
            get { return mLastKeyPressed; }
            set { mLastKeyPressed = value; }
        }

        public int Animation
        {
            get { return mAnimation; }
            set { mAnimation = value; }
        }

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
