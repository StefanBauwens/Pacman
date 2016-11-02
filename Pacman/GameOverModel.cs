using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class GameOverModel
    {
        protected bool _isGameOver = false;

        public bool isGameOver
        {
            get{ return _isGameOver; }
            set{ _isGameOver = value; }
        }
    }
}
