using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Pacman
{

    public class WorldController
    {
        //WorldModel model;
        WorldUI worldUI;
        ReadyController ready;
        PlayerController player;
        TileController beginTile;
        ScoreController score;
        LivesController lives;
        GameOverController gameOver;
        List<BigDotController> bigdots;

        List<EnemyController> enemies;

        //static public object locker = new object();

        public WorldController()
        {
            //model = new WorldModel();
            worldUI = new WorldUI(this);

            enemies = new List<EnemyController>(); 
            bigdots = new List<BigDotController>();

            //draw the world
            ready = new ReadyController(); //adds ready text
            ready.view.Top = 177;
            ready.view.Left = 125;
            this.view.Controls.Add(ready.view);
        
            player = new PlayerController(ready);//adds player
            player.subscribeObserver(this);
            this.DrawPlayer();
            this.view.Controls.Add(player.view);
            //WorldModel.Player = player;


            beginTile = new TileController(); //adds begintile for enemies 
            beginTile.Model.X = 9;
            beginTile.Model.Y = 9;

            score = new ScoreController(); //adds score
            score.view.Top = 340;
            this.view.Controls.Add(score.view);

            lives = new LivesController(); //adds lives to the form
            lives.view.Top = 340;
            lives.view.Left = 190;
            this.view.Controls.Add(lives.view);
            
            gameOver = new GameOverController(); //adds game over text
            gameOver.view.Top = 177;
            gameOver.view.Left = 111;
            this.view.Controls.Add(gameOver.view);
            lives.subscribeObserverToLives(gameOver);
            gameOver.GameOverTextVisible(false);


            drawMap();
            DrawEnemies(false);

            for (int i = 0; i < bigdots.Count; i++) //Subscribe all the enemies to each bigdot
            {
                for (int j = 0; j < enemies.Count; j++)
                {
                    bigdots[i].subscribeObserverToBigDot(enemies[j]);                  
                }
            }

        }


        public void drawMap()
        {
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
                            break;
                        /*case 2:
                            TileController blackTile = new TileController(); //adds a blacktile first for under the enemy
                            blackTile.Model.X = colls;
                            blackTile.Model.Y = rows;
                            blackTile.View.Top = rows * 16;
                            blackTile.View.Left = colls * 16;
                            this.view.Controls.Add(blackTile.View);

                            EnemyController blinky = new EnemyController(beginTile);
                            enemies.Add(blinky); //add to the enemies list
                            player.subscribeObserver(blinky);
                            blinky.subscribeObserverToEnemy(lives);
                            blinky.subscribeObserverToEnemy(player);
                            blinky.subscribeObserverToEnemy(score);
                            blinky.View.Top = rows * 16;
                            blinky.View.Left = colls * 16;
                            blinky.Model.X = colls;
                            blinky.Model.Y = rows;
                            this.view.Controls.Add(blinky.View);
                            blinky.View.BringToFront(); //make sure enemy layer is over tiles so it's visible
                            break;*/
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
                        case 4:
                            TileController blackTile1 = new TileController(); //adds a blacktile first for under the enemy
                            blackTile1.Model.X = colls;
                            blackTile1.Model.Y = rows;
                            blackTile1.View.Top = rows * 16;
                            blackTile1.View.Left = colls * 16;
                            this.view.Controls.Add(blackTile1.View);
                            break;
                    }
                }
            }
        }

        public void DrawEnemies(bool reDrawEnemies)
        {
            int tempCount = 0;
            for (int rows = 0; rows < WorldModel.Map2D.GetLength(0); rows++)
            {
                for (int colls = 0; colls < WorldModel.Map2D.GetLength(1); colls++)
                {
                    switch (WorldModel.Map2D[rows, colls])
                    {
                        case 2:
                            if (reDrawEnemies)
                            {
                                enemies[tempCount].Model.X = colls;
                                enemies[tempCount].Model.Y = rows;
                                enemies[tempCount].View.Top = rows * 16;
                                enemies[tempCount].View.Left = colls * 16;
                                enemies[tempCount].Model.Direction = EnemyModel.direction.right;
                                enemies[tempCount].Model.HasEatenPacman = false;
                                enemies[tempCount].Model.AlreadyMoving = false;
                                enemies[tempCount].Model.TimeBlue = 0;
                                enemies[tempCount].Model.IsDead = false;                              
                                enemies[tempCount].Model.IsRunningAway = false;
                                enemies[tempCount].Model.Step = 1;
                                EnemyController.blueEnemiesEaten = 0;
                                enemies[tempCount].View.enemyImage.Image = Pacman.Properties.Resources.enemy1right0;
                                enemies[tempCount].View.enemyImage.Refresh();
                                enemies[tempCount].notify(player.model.X, player.model.Y, player.model.X * 16, player.model.Y * 16);
                                tempCount++;                             
                            }
                            else
                            {
                                TileController blackTile = new TileController(); //adds a blacktile first for under the enemy
                                blackTile.Model.X = colls;
                                blackTile.Model.Y = rows;
                                blackTile.View.Top = rows * 16;
                                blackTile.View.Left = colls * 16;
                                this.view.Controls.Add(blackTile.View);

                                EnemyController blinky = new EnemyController(beginTile);
                                enemies.Add(blinky); //add to the enemies list
                                player.subscribeObserver(blinky);
                                blinky.subscribeObserverToEnemy(lives);
                                blinky.subscribeObserverToEnemy(player);
                                blinky.subscribeObserverToEnemy(score);
                                blinky.View.Top = rows * 16;
                                blinky.View.Left = colls * 16;
                                blinky.Model.X = colls;
                                blinky.Model.Y = rows;
                                this.view.Controls.Add(blinky.View);
                                blinky.View.BringToFront(); //make sure enemy layer is over tiles so it's visible
                            }
                            break;
                    }
                }
            }
        }

        public void DrawPlayer()
        {
            player.model.Counter = 0;
            player.model.X = 9;
            player.model.Y = 15;//11;
            player.view.Top = 240;//176;
            player.view.Left = 144;
            player.model.IsDead = false;
            player.model.AlreadyMoving = false;
            player.model.Direction = PlayerModel.direction.right;
            player.ready.Model.gameStarted = false;
            player.ready.view.Visible = true;
        }

        public WorldUI view
        {
            get { return worldUI; }
        }

        public void notify(bool reDrawEnemies) //if redrawenemies is true it will MOVE the enemies and not make new instances
        {
            DrawEnemies(reDrawEnemies);
            DrawPlayer(); //redraws the player as well
        }
    }
}
