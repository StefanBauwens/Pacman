using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class EnemyModel
    {
        public enum colorType { red, pink, orange, green }
        colorType mColor; //color of the enemy

        bool mIsRunningAway = false; //if true enemy is blue and running away from player
        bool mIsDead = false; //if the enemy gets eaten it must be heading to the box

        int mX; //coordinates of the enemy
        int mY;

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

    }
}
