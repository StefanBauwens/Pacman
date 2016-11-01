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

        bool mIsRunningAway = false; //if true enemy is blue and running away from player
        bool mIsDead = false; //if the enemy gets eaten it must be heading to the box
        bool mHasEatenPacman = false; // if pacman gets eaten by enemy
        bool mIsWhite = false; //if it's white(when blue flashing white to indicate it's going to become back normal)
        bool mAlreadyMoving = false;

        int mX = 1; //coordinates of the enemy
        int mY = 1;
        int mXObserver, mYObserver; //coordinates to check. Either player cooridnates or coordinates from begintile
        int mXDetailed, mYDetailed; //detailed coordinates, coordinates of the pixels and not just of the place in the map

        int mTimeBlue = 0; //time that enemies stay blue
        int mAnimation = 1;
        int mCounter = 0;

        int mStep = 1;

        public int Step //when dead and running to the beginngtile the step changes to 2 to speed it up
        {
            get { return mStep; }
            set { mStep = value; }
        }

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

        public bool IsWhite
        {
            get { return mIsWhite; }
            set { mIsWhite = value; }
        }

        public int TimeBlue
        {
            get { return mTimeBlue; }
            set { mTimeBlue = value; }
        }

        public int XDetailed
        {
            get { return mXDetailed; }
            set { mXDetailed = value; }
        }

        public int YDetailed
        {
            get { return mYDetailed; }
            set { mYDetailed = value; }
        }

        public int XObserver
        {
            get { return mXObserver; }
            set { mXObserver = value; }
        }

        public int YObserver
        {
            get { return mYObserver; }
            set { mYObserver = value; }
        }

        
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

        public bool HasEatenPacman
        {
            get { return mHasEatenPacman; }
            set { mHasEatenPacman = value; }
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
