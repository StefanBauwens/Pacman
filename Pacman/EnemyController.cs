using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class EnemyController
    {
        EnemyModel enemyModel;
        EnemyUI enemyUI;
        //PlayerController player;
        TileController beginTile;
        //ENEMY = OBSERVER

        bool alreadyMoving = false;
        int counter;
        bool check;

        Random randGen;


        public EnemyController(/*PlayerController playerController,*/ TileController mBeginTile) //constructor
        {
            this.enemyModel = new EnemyModel();
            this.enemyUI = new EnemyUI(this);
            //this.player = playerController;
            this.beginTile = mBeginTile;
        }

        public EnemyUI View
        {
            get { return enemyUI; }
        }

        public EnemyModel Model
        {
            get { return enemyModel; }
            set { enemyModel = value; }
        }

        public void moveEnemy()
        {
            //startMovement:

            if (this.Model.IsRunningAway)
            {
                this.View.timer1.Interval = 17;
            }
            else
            {
                this.View.timer1.Interval = 15;
            }

            switch (this.Model.Direction)
            {
                case EnemyModel.direction.up:
                    if (WorldModel.Map2D[this.Model.Y - 1, this.Model.X] != 1)
                    {
                        if (alreadyMoving == false)
                        {
                            alreadyMoving = true;
                            counter = 0;
                        }
                        counter++;
                        this.View.Top -= 1;
                        animate();
                        if (this.Model.Animation < 4)
                        {
                            if (this.Model.IsRunningAway)// == false)
                            {
                                //this.View.enemyImage.Image = Pacman.Properties.Resources.enemy1up0;
                                this.View.enemyImage.Image = Pacman.Properties.Resources.blue0;
                            }
                            else if (this.Model.IsDead)
                            {
                                this.View.enemyImage.Image = Pacman.Properties.Resources.eyesup;
                            }
                            else
                            {
                                this.View.enemyImage.Image = Pacman.Properties.Resources.enemy1up0;
                                //this.View.enemyImage.Image = Pacman.Properties.Resources.blue0;
                            }
                        }
                        else
                        {
                            if (this.Model.IsRunningAway)// == false)
                            {
                                //this.View.enemyImage.Image = Pacman.Properties.Resources.enemy1up1;
                                this.View.enemyImage.Image = Pacman.Properties.Resources.blue1;
                            }
                            else if (this.Model.IsDead)
                            {
                                this.View.enemyImage.Image = Pacman.Properties.Resources.eyesup;
                            }
                            else
                            {
                                //this.View.enemyImage.Image = Pacman.Properties.Resources.blue1;
                                this.View.enemyImage.Image = Pacman.Properties.Resources.enemy1up1;
                            }
                        }
                        refreshPic();
                        if (counter == 16)
                        {
                            this.Model.Y--;
                            //Console.WriteLine(this.Model.Direction);

                            alreadyMoving = false;
                        }
                    }
                    break;
                case EnemyModel.direction.right:
                    if (WorldModel.Map2D[this.Model.Y, this.Model.X + 1] != 1)
                    {
                        if (alreadyMoving == false)
                        {
                            alreadyMoving = true;
                            counter = 0;
                        }
                        counter++;
                        this.View.Left += 1;
                        animate();
                        if (this.Model.Animation < 4)
                        {
                            if (this.Model.IsRunningAway)// == false) //checks if enemy should be blue(and running away) or not
                            {
                                //this.View.enemyImage.Image = Pacman.Properties.Resources.enemy1right0;
                                this.View.enemyImage.Image = Pacman.Properties.Resources.blue0;
                            }
                            else if (this.Model.IsDead)
                            {
                                this.View.enemyImage.Image = Pacman.Properties.Resources.eyesright;
                            }
                            else
                            {
                                //this.View.enemyImage.Image = Pacman.Properties.Resources.blue0;
                                this.View.enemyImage.Image = Pacman.Properties.Resources.enemy1right0;
                            }
                        }
                        else
                        {
                            if (this.Model.IsRunningAway)// == false)
                            {
                                //this.View.enemyImage.Image = Pacman.Properties.Resources.enemy1right1;
                                this.View.enemyImage.Image = Pacman.Properties.Resources.blue1;
                            }
                            else if (this.Model.IsDead)
                            {
                                this.View.enemyImage.Image = Pacman.Properties.Resources.eyesright;
                            }
                            else
                            {
                                //this.View.enemyImage.Image = Pacman.Properties.Resources.blue1;
                                this.View.enemyImage.Image = Pacman.Properties.Resources.enemy1right1;
                            }
                        }
                        refreshPic();
                        if (counter == 16)
                        {
                            this.Model.X++;
                            //Console.WriteLine(this.Model.Direction);

                            alreadyMoving = false;
                        }
                    }
                    break;
                case EnemyModel.direction.down:
                    if (WorldModel.Map2D[this.Model.Y + 1, this.Model.X] != 1)
                    {
                        if (alreadyMoving == false)
                        {
                            alreadyMoving = true;
                            counter = 0;
                        }
                        counter++;
                        this.View.Top += 1;
                        animate();
                        if (this.Model.Animation < 4)
                        {
                            if (this.Model.IsRunningAway)// == false)
                            {
                                //this.View.enemyImage.Image = Pacman.Properties.Resources.enemy1down0;
                                this.View.enemyImage.Image = Pacman.Properties.Resources.blue0;
                            }
                            else if (this.Model.IsDead)
                            {
                                this.View.enemyImage.Image = Pacman.Properties.Resources.eyesdown;
                            }
                            else
                            {
                                //this.View.enemyImage.Image = Pacman.Properties.Resources.blue0;
                                this.View.enemyImage.Image = Pacman.Properties.Resources.enemy1down0;
                            }
                        }
                        else
                        {
                            if (this.Model.IsRunningAway)// == false)
                            {
                                //this.View.enemyImage.Image = Pacman.Properties.Resources.enemy1down1;
                                this.View.enemyImage.Image = Pacman.Properties.Resources.blue1;
                            }
                            else if (this.Model.IsDead)
                            {
                                this.View.enemyImage.Image = Pacman.Properties.Resources.eyesdown;
                            }
                            else
                            {
                                //this.View.enemyImage.Image = Pacman.Properties.Resources.blue1;
                                this.View.enemyImage.Image = Pacman.Properties.Resources.enemy1down1;
                            }
                        }
                        refreshPic();
                        if (counter == 16)
                        {
                            this.Model.Y++;
                            //Console.WriteLine(this.Model.Direction);

                            alreadyMoving = false;
                        }
                        //wall = false;
                    }
                    /*else
                    {
                        wall = true;
                    }*/
                    break;
                case EnemyModel.direction.left:
                    if (WorldModel.Map2D[this.Model.Y, this.Model.X - 1] != 1)
                    {
                        if (alreadyMoving == false)
                        {
                            alreadyMoving = true;
                            counter = 0;
                        }
                        counter++;
                        this.View.Left -= 1;
                        animate();
                        if (this.Model.Animation < 4)
                        {
                            if (this.Model.IsRunningAway)// == false)
                            {
                                //this.View.enemyImage.Image = Pacman.Properties.Resources.enemy1left0;
                                this.View.enemyImage.Image = Pacman.Properties.Resources.blue0;
                            }
                            else if (this.Model.IsDead)
                            {
                                this.View.enemyImage.Image = Pacman.Properties.Resources.eyesleft;
                            }
                            else
                            {
                                //this.View.enemyImage.Image = Pacman.Properties.Resources.blue0;
                                this.View.enemyImage.Image = Pacman.Properties.Resources.enemy1left0;
                            }
                        }
                        else
                        {
                            if (this.Model.IsRunningAway)// == false)
                            {
                                //this.View.enemyImage.Image = Pacman.Properties.Resources.enemy1left1;
                                this.View.enemyImage.Image = Pacman.Properties.Resources.blue1;
                            }
                            else if (this.Model.IsDead)
                            {
                                this.View.enemyImage.Image = Pacman.Properties.Resources.eyesleft;
                            }
                            else
                            {
                                //this.View.enemyImage.Image = Pacman.Properties.Resources.blue1;
                                this.View.enemyImage.Image = Pacman.Properties.Resources.enemy1left1;
                            }

                        }
                        refreshPic();
                        if (counter == 16)
                        {
                            this.Model.X--;
                            //Console.WriteLine(this.Model.Direction);
                            alreadyMoving = false;
                        }
                        //wall = false;
                    }
                    /*else
                    {
                        wall = true;
                    }*/
                    break;
            }
            randGen = new Random();
            //check here which way to go

            List<int> directionsToGo = new List<int>();
            List<int> directionsToGo2 = new List<int>();
            /*if (this.Model.IsDead == false) //if player is dead it needs to focus on begintile and else on player
            {
                x = player.model.X;
                y = player.model.Y;
            }
            else*/
            if (this.Model.IsDead == true) //if player is dead it needs to focus on begintile
            {
                this.Model.XObserver = beginTile.Model.X;
                this.Model.YObserver = beginTile.Model.Y;
            }

            if (WorldModel.Map2D[this.Model.Y, this.Model.X + 1] != 1 && this.Model.Direction != EnemyModel.direction.left) //checks if right is free
            {
                if (this.Model.IsRunningAway) //if enemy is blue it has to check to run the opposite direction of the player
                {
                    check = (this.Model.XObserver <= this.Model.X && alreadyMoving == false);
                }
                else
                {
                    check = (this.Model.XObserver >= this.Model.X && alreadyMoving == false); //if player is on the right of the enemy
                }  
                if (check) 
                {
                    directionsToGo.Add(1); //adds right to the list of possible directions to go
                    //directionsToGo.Add(1); //more chance to follow player
                    //directionsToGo.Add(1);
                }
                directionsToGo2.Add(1);
            }
            if (WorldModel.Map2D[this.Model.Y, this.Model.X - 1] != 1 && this.Model.Direction != EnemyModel.direction.right) //checks if left is free
            {
                if (this.Model.IsRunningAway) //if enemy is blue it has to check to run the opposite direction of the player
                {
                    check = (this.Model.XObserver >= this.Model.X && alreadyMoving == false);
                }
                else
                {
                    check = (this.Model.XObserver <= this.Model.X && alreadyMoving == false); //if player is on the left of the enemy
                }
                if (check) 
                {
                    directionsToGo.Add(3); //adds left to the list of possible directions to go
                }
                directionsToGo2.Add(3);
            }
            if (WorldModel.Map2D[this.Model.Y + 1, this.Model.X] != 1 && this.Model.Direction != EnemyModel.direction.up) //checks if down is free
            {
                if (this.Model.IsRunningAway) //if enemy is blue it has to check to run the opposite direction of the player
                {
                    check = (this.Model.YObserver <= this.Model.Y && alreadyMoving == false);
                }
                else
                {
                    check = (this.Model.YObserver >= this.Model.Y && alreadyMoving == false); //if player is lower than the enemy
                }
                if (check) 
                {              
                    directionsToGo.Add(2); //adds down to the list of possible directions to go               
                }
                directionsToGo2.Add(2);
            }
            if (WorldModel.Map2D[this.Model.Y - 1, this.Model.X] != 1 && this.Model.Direction != EnemyModel.direction.down) //checks if up is free
            {
                if (this.Model.IsRunningAway) //if enemy is blue it has to check to run the opposite direction of the player
                {
                    check = (this.Model.YObserver >= this.Model.Y && alreadyMoving == false);
                }
                else
                {
                    check = (this.Model.YObserver <= this.Model.Y && alreadyMoving == false);//if player is higher than the enemy
                }
                if (check) 
                {                
                    directionsToGo.Add(0); //adds up to the list of possible directions to go
                }
                directionsToGo2.Add(0);
            }

            if (directionsToGo.Count == 0)
            {
                /*if (alreadyMoving == false)
                {
                    int randomNum;
                    do
                    {
                        randomNum = this.randGen.Next(0, 4);
                    }
                    while (this.Model.Direction == (EnemyModel.direction)((randomNum + 2) % 4)); //makes sure the enemy can't go back from the direction it comes from
                    //Console.WriteLine(randomNum);
                    this.Model.Direction = (EnemyModel.direction)randomNum;//gives a random direction
                    //goto startMovement;
                }*/
                if (alreadyMoving == false)
                {
                    if (directionsToGo2.Count !=0)
                    {
                        this.Model.Direction = (EnemyModel.direction)directionsToGo2[this.randGen.Next(directionsToGo2.Count)];
                    }
                    else
                    {
                        this.Model.Direction = (EnemyModel.direction)(((int)this.Model.Direction + 2) % 4);
                    }
                }
            }
            else
            {
                if (alreadyMoving == false)
                {
                    //Console.WriteLine(this.Model.Direction);
                    Console.WriteLine();
                    this.Model.Direction = (EnemyModel.direction)directionsToGo[this.randGen.Next(directionsToGo.Count)];
                    //goto startMovement;
                }
            }
        }

        protected void animate()
        {
            this.Model.Animation++;
            if (this.Model.Animation >= 8)
            {
                this.Model.Animation = 0;
            }
        }

        // Method that gets executed when the observable is changed
        public void notify(int xCoordinate, int yCoordinate)
        {
            this.Model.XObserver = xCoordinate; //gets the coordinates which it should follow(or run away from)
            this.Model.YObserver = yCoordinate;
            if (this.Model.IsRunningAway && this.Model.X == this.Model.XObserver && this.Model.Y == this.Model.YObserver)
            {
                this.Model.IsRunningAway = false;
                this.Model.IsDead = true;
            }
            // Update model with new value
            /*this.scoreModel.score = newDiceValue;

            // Update view with new value
            this.scoreUI.updateScore(newDiceValue);*/
        }

        protected void refreshPic()
        {
            /*for (int j = 0; j < SLOWDOWN; j++)
            {

            }*/
            this.View.enemyImage.Refresh();
        }

        public void notify(bool isRunningAway, bool isDead)
        {
            
            this.enemyUI.updateImage(isRunningAway);
            
        }

    }
}
