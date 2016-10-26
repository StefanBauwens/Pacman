using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class EnemyModel
    {
        public enum colorType { red, pink, orange, green }
        public enum direction
        {
            up,
            right,
            down,
            left
        }

        direction mDir = direction.right; //direction the AI is going from the beginning
        colorType mColor; //color of the enemy

        bool mIsRunningAway = true; //if true enemy is blue and running away from player
        bool mIsDead = false; //if the enemy gets eaten it must be heading to the box

        int mX = 1; //coordinates of the enemy
        int mY = 1;

        int mAnimation = 1;

        public int Animation
        {
            get { return mAnimation; }
            set { mAnimation = value; }
        }

        public colorType Color
        {
            get { return mColor; }
            set { mColor = value; }
        }

        public bool IsRunningAway
        {
            get { return mIsRunningAway; }
            set { mIsRunningAway = value; }
        }

        public bool IsDead
        {
            get { return mIsDead; }
            set { mIsDead = value; }
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
