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
            left,
            idle
        }

        protected direction mDir = direction.right;
        protected bool mIsDead = false;
        protected bool mAlreadyMoving = false;

        protected Keys mLastKeyPressed;
        protected int mCounter = 0;
        protected int mAnimation = 1;

        public bool AlreadyMoving
        {
            get { return mAlreadyMoving; }
            set { mAlreadyMoving = value; }
        }

        public int Counter
        {
            get { return mCounter; }
            set { mCounter = value; }
        }

        public bool IsDead
        {
            get { return mIsDead; }
            set { mIsDead = value; }
        }

        public /*PreviewKeyDownEventArgs*/ /*KeyEventArgs*/ Keys LastKeyPressed
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
