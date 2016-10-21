using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class WorldController
    {
        WorldModel model;
        WorldUI worldUI;

        public WorldController()
        {
            model = new WorldModel();
            worldUI = new WorldUI(this);

            //draw the world
            for (int rows = 0; rows < model.Map2D.GetLength(0); rows++)
            {
                for (int colls = 0; colls < model.Map2D.GetLength(1); colls++)
                {

                }
            }
        }

        public WorldUI view
        {
            get { return worldUI; }
        }
    }
}
