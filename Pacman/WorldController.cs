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

            List<EnemyController> enemies = new List<EnemyController>(); 
            List<BigDotController> bigdots = new List<BigDotController>();

            //draw the world
            PlayerController player = new PlayerController();//adds player
            player.model.X = 9;
            player.model.Y = 11;
            player.view.Top = 176; 
            player.view.Left = 144;
            this.view.Controls.Add(player.view);

            TileController beginTile = new TileController(); //adds begintile for enemies 
            beginTile.Model.X = 9;
            beginTile.Model.Y = 9;

            ScoreController score = new ScoreController(); //adds score
            score.view.Top = 340;
            this.view.Controls.Add(score.view);

            LivesController lives = new LivesController(); //adds lives to the form
            lives.view.Top = 340;
            lives.view.Left = 50;
            this.view.Controls.Add(lives.view);

            for (int rows = 0; rows < WorldModel.Map2D.GetLength(0); rows++)
            {
                for (int colls = 0; colls < WorldModel.Map2D.GetLength(1); colls++)
                {
                    switch (WorldModel.Map2D[rows, colls])
                    {
                        case 0:
                            PacDotController pacDot = new PacDotController();
                            player.subscribeObserver(pacDot); //subscribes to player
                            pacDot.subscribeObserverToPacDot(score);
                            pacDot.view.Top = rows * 16;
                            pacDot.view.Left = colls * 16;
                            pacDot.Model.X = colls;
                            pacDot.Model.Y = rows;
                            this.view.Controls.Add(pacDot.view);
                            break;
                        case 1:
                            TileController wall = new TileController();
                            wall.Model.X = colls;
                            wall.Model.Y = rows;
                            wall.View.Top = rows * 16;
                            wall.View.Left = colls * 16;
                            wall.View.pictureBox1.Image = Pacman.Properties.Resources.wall2;//wallsprite;
                            this.view.Controls.Add(wall.View);

                            /*BigDotController bigDot = new BigDotController();
                            bigDot.view.Top = rows * 16;
                            bigDot.view.Left = colls * 16;
                            this.view.Controls.Add(bigDot.view);*/
                            break;
                        case 2:
                            TileController blackTile = new TileController(); //adds a blacktile first for under the enemy
                            blackTile.Model.X = colls;
                            blackTile.Model.Y = rows;
                            blackTile.View.Top = rows * 16;
                            blackTile.View.Left = colls * 16;
                            this.view.Controls.Add(blackTile.View);

                            EnemyController blinky = new EnemyController(beginTile);
                            enemies.Add(blinky); //add to the enemies list
                            player.subscribeObserver(blinky);
                            blinky.subscribeObserverToEnemey(lives);
                            blinky.subscribeObserverToEnemy(player);
                            blinky.View.Top = rows * 16;
                            blinky.View.Left = colls * 16;
                            blinky.Model.X = colls;
                            blinky.Model.Y = rows;                           
                            this.view.Controls.Add(blinky.View);
                            blinky.View.BringToFront(); //make sure enemy layer is over tiles so it's visible
                            break;
                        case 3:
                            BigDotController bigDot = new BigDotController();
                            bigdots.Add(bigDot); //add to the list
                            player.subscribeObserver(bigDot);
                            bigDot.subscribeObserverToBigDot(score);
                            bigDot.view.Top = rows * 16;
                            bigDot.view.Left = colls * 16;
                            bigDot.Model.X = colls;
                            bigDot.Model.Y = rows;
                            this.view.Controls.Add(bigDot.view);
                            break;
                    }
                }
            }

            for (int i = 0; i < bigdots.Count; i++) //Subscribe all the enemies to each bigdot
            {
                for (int j = 0; j < enemies.Count; j++)
                {
                    bigdots[i].subscribeObserverToBigDot(enemies[j]);
                }
            }

        }

        public WorldUI view
        {
            get { return worldUI; }
        }
    }
}
