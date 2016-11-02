using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

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

        List<TileController> tiles;
        List<PacDotController> pacdots;

        //static public object locker = new object();

        public WorldController()
        {
            //model = new WorldModel();
            worldUI = new WorldUI(this);

            enemies = new List<EnemyController>(); 
            bigdots = new List<BigDotController>();
            tiles = new List<TileController>();
            pacdots = new List<PacDotController>();

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
            gameOver.SubscribeObserver(this);
            gameOver.GameOverTextVisible(false);


            drawMap(true);
            DrawEnemies(false);

            for (int i = 0; i < bigdots.Count; i++) //Subscribe all the enemies to each bigdot
            {
                for (int j = 0; j < enemies.Count; j++)
                {
                    bigdots[i].subscribeObserverToBigDot(enemies[j]);                  
                }
            }

        }


        public void drawMap(bool newMap)
        {
            int pacdotCount = 0;
            int bigdotCount = 0;
            int tilesCount = 0;

            for (int rows = 0; rows < WorldModel.Map2D.GetLength(0); rows++)
            {
                for (int colls = 0; colls < WorldModel.Map2D.GetLength(1); colls++)
                {
                    switch (WorldModel.Map2D[rows, colls])
                    {
                        case 0:
                            if (newMap)
                            {
                                PacDotController pacDot = new PacDotController();
                                player.subscribeObserver(pacDot); //subscribes to player
                                pacDot.subscribeObserverToPacDot(score);
                                pacDot.subscribeObserverToPacDot(this); //subscribes the worldcontroller to pacdot
                                pacDot.view.Top = rows * 16;
                                pacDot.view.Left = colls * 16;
                                pacDot.Model.X = colls;
                                pacDot.Model.Y = rows;
                                this.pacdots.Add(pacDot);
                                this.view.Controls.Add(pacDot.view);
                            }
                            else
                            {
                                PacDotUI temp = new PacDotUI();
                                pacdots[pacdotCount].view.pacDotImage.Image = temp.pacDotImage.Image;
                                pacdots[pacdotCount].Model.isEaten = false;
                                PacDotController.pacDotsEaten = 0;
                                pacdotCount++;
                            }
                            break;
                        case 1:
                            if (newMap)
                            {
                                TileController wall = new TileController();
                                wall.Model.X = colls;
                                wall.Model.Y = rows;
                                wall.View.Top = rows * 16;
                                wall.View.Left = colls * 16;
                                wall.View.pictureBox1.Image = Pacman.Properties.Resources.wall2;//wallsprite;  
                                this.tiles.Add(wall);
                                this.view.Controls.Add(wall.View);
                            }
                            else
                            {
                                if (WorldModel.FlashWhite)
                                {
                                    tiles[tilesCount].View.pictureBox1.Image = Pacman.Properties.Resources.wall3;
                                    tiles[tilesCount].View.pictureBox1.Refresh();
                                }
                                else
                                {
                                    tiles[tilesCount].View.pictureBox1.Image = Pacman.Properties.Resources.wall2;
                                    tiles[tilesCount].View.pictureBox1.Refresh();
                                }
                                tilesCount++;
                            }

                            break;
                        case 3:
                            if (newMap)
                            {
                                BigDotController bigDot = new BigDotController();
                                bigdots.Add(bigDot); //add to the list
                                player.subscribeObserver(bigDot);
                                bigDot.subscribeObserverToBigDot(score);
                                bigDot.view.Top = rows * 16;
                                bigDot.view.Left = colls * 16;
                                bigDot.Model.X = colls;
                                bigDot.Model.Y = rows;                               
                                this.view.Controls.Add(bigDot.view);
                            }
                            else
                            {
                                bigdots[bigdotCount].Model.isEaten = false;
                                bigdotCount++;
                            }                           
                            break;
                        case 4:
                            if (newMap)
                            {
                                TileController blackTile1 = new TileController();//blacktile
                                blackTile1.Model.X = colls;
                                blackTile1.Model.Y = rows;
                                blackTile1.View.Top = rows * 16;
                                blackTile1.View.Left = colls * 16;
                                tiles.Add(blackTile1);
                                this.view.Controls.Add(blackTile1.View);
                            }
                            else
                            {
                                tilesCount++;
                            }
                            
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
            DrawPlayer(); //redraws the player as well
            DrawEnemies(reDrawEnemies);
        }

        public void notify(int pacdotsEaten) 
        {
            //Console.WriteLine("Pacdotseaten : " + pacdotsEaten + "/" + PacDotController.pacDotAmmount);
            if (pacdotsEaten == PacDotController.pacDotAmmount)
            {
                for (int i = 0; i < 5; i++)//flashes wingame
                {
                    bool flashOrNot = (i % 2) != 0; //creates a bool that goes true then false, etc..
                    WorldModel.FlashWhite = flashOrNot;
                    drawMap(false); //REdraw map. Without creating new instances
                    Thread.Sleep(500);
                }
                DrawEnemies(true); //start over
                DrawPlayer();
            }
        }

        public void notify() //is called normally only by gameover
        {
            gameOver.view.gameOverLabel.Refresh();
            Thread.Sleep(3000);           
            gameOver.view.SendToBack();
            gameOver.view.gameOverLabel.Visible = false;
            gameOver.Model.isGameOver = false;

            lives.Model.lives = 3;
            lives.updateLives(lives.Model.lives);
            score.Model.score = 0;
            score.notify(0);
            drawMap(false);
            DrawEnemies(true);
            DrawPlayer();

        }
    }
}
