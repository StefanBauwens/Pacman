using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class PacDotModel: TileModel
    {
        protected bool _isEaten;
        protected int _dotPoints = 20;

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
