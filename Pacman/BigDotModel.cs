using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class BigDotModel: TileModel
    {
        protected bool _isEaten = false; //if true --> pacdot will disappear
        protected int _dotPoints = 50;
        protected int mAnimation = 0;

        public int Animation
        {
            get { return mAnimation; }
            set { mAnimation = value; }
        }

        public BigDotModel()
        {
            CanWalkThrough = true;
        }

        public bool isEaten
        {
            get { return _isEaten; }
            set { _isEaten = value; }
        }

        public int dotPoints
        {
            get { return _dotPoints; }
        }
    }
}
