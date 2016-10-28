using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class ReadyModel
    {
        protected bool _gameStarted = false;

        public bool gameStarted
        {
            get{ return _gameStarted; }
            set { _gameStarted = value; }
        }
    }
}
