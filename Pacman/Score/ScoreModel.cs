using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class ScoreModel
    {
        protected int _score = 0;

        public int score
        {
            get { return _score; }
            set { _score = value; }
        }

    }
}
