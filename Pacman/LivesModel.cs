using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class LivesModel
    {
        protected int _lives = 3;

        public int lives
        {
            get{ return _lives; }
            set{ _lives = value; }
        }
    }
}
