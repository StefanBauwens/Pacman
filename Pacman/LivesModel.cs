using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class LivesModel
    {
        protected int _lives;

        public int lives
        {
            get{ return _lives; }
            set{ _lives = value; }
        }
    }
}
