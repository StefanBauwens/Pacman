using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class WorldController
    {
        //WorldModel model;
        WorldUI worldUI;

        public WorldController()
        {
            //model = new WorldModel();
            worldUI = new WorldUI(this);

            //draw the world
            for (int rows = 0; rows < WorldModel.Map2D.GetLength(0); rows++)
            {
                for (int colls = 0; colls < WorldModel.Map2D.GetLength(1); colls++)
                {
                    if (WorldModel.Map2D[rows, colls]==0)
                    {
                        PacDotController pacDot = new PacDotController();
                        pacDot.view.Top = rows * 16;
                        pacDot.view.Left = colls * 16;
                        this.view.Controls.Add(pacDot.view);
                    }
                    else
                    {
                        BigDotController bigDot = new BigDotController();
                        bigDot.view.Top = rows * 16;
                        bigDot.view.Left = colls * 16;
                        this.view.Controls.Add(bigDot.view);
                    }
                }
            }
        }

        public WorldUI view
        {
            get { return worldUI; }
        }
    }
}
