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
        PlayerController player;
        TileController beginTile;

        bool alreadyMoving = false;
        int counter;
        bool check;
        int x, y; //coordinates to check. Either player cooridnates or coordinates from begintile
        Random randGen;


        public EnemyController(PlayerController playerController, TileController mBeginTile) //constructor
        {
            this.enemyModel = new EnemyModel();
            this.enemyUI = new EnemyUI(this);
            this.player = playerController;
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
            startMovement:

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
                            //ADD PICTURES FOR EYES IF ISDEAD == TRUE 
                            //LOOK TO FIND MORE EFFICIENT WAY
                            if (this.Model.IsRunningAway == false)
                            {
                                this.View.enemyImage.Image = Pacman.Properties.Resources.enemy1up0;
                            }
                            else
                            {
                                this.View.enemyImage.Image = Pacman.Properties.Resources.blue0;
                            }
                        }
                        else
                        {
                            if (this.Model.IsRunningAway == false)
                            {
                                this.View.enemyImage.Image = Pacman.Properties.Resources.enemy1up1;
                            }
                            else
                            {
                                this.View.enemyImage.Image = Pacman.Properties.Resources.blue1;
                            }
                        }
                        refreshPic();
                        if (counter == 16)
                        {
                            this.Model.Y--;
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
                            if (this.Model.IsRunningAway == false) //checks if enemy should be blue(and running away) or not
                            {
                                this.View.enemyImage.Image = Pacman.Properties.Resources.enemy1right0;
                            }
                            else
                            {
                                this.View.enemyImage.Image = Pacman.Properties.Resources.blue0;
                            }
                        }
                        else
                        {
                            if (this.Model.IsRunningAway == false)
                            {
                                this.View.enemyImage.Image = Pacman.Properties.Resources.enemy1right1;
                            }
                            else
                            {
                                this.View.enemyImage.Image = Pacman.Properties.Resources.blue1;
                            }
                        }
                        refreshPic();
                        if (counter == 16)
                        {
                            this.Model.X++;
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
                            if (this.Model.IsRunningAway == false)
                            {
                                this.View.enemyImage.Image = Pacman.Properties.Resources.enemy1down0;
                            }
                            else
                            {
                                this.View.enemyImage.Image = Pacman.Properties.Resources.blue0;
                            }
                        }
                        else
                        {
                            if (this.Model.IsRunningAway == false)
                            {
                                this.View.enemyImage.Image = Pacman.Properties.Resources.enemy1down1;
                            }
                            else
                            {
                                this.View.enemyImage.Image = Pacman.Properties.Resources.blue1;
                            }
                        }
                        refreshPic();
                        if (counter == 16)
                        {
                            this.Model.Y++;
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
                            if (this.Model.IsRunningAway == false)
                            {
                                this.View.enemyImage.Image = Pacman.Properties.Resources.enemy1left0;
                            }
                            else
                            {
                                this.View.enemyImage.Image = Pacman.Properties.Resources.blue0;
                            }
                        }
                        else
                        {
                            if (this.Model.IsRunningAway == false)
                            {
                                this.View.enemyImage.Image = Pacman.Properties.Resources.enemy1left1;
                            }
                            else
                            {
                                this.View.enemyImage.Image = Pacman.Properties.Resources.blue1;
                            }

                        }
                        refreshPic();
                        if (counter == 16)
                        {
                            this.Model.X--;
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

            if (this.Model.IsDead == false) //if player is dead it needs to focus on begintile and else on player
            {
                x = player.model.X;
                y = player.model.Y;
            }
            else
            {
                x = beginTile.Model.X;
                y = beginTile.Model.Y;
            }

            if (WorldModel.Map2D[this.Model.Y, this.Model.X + 1] != 1 && this.Model.Direction != EnemyModel.direction.left) //checks if right is free
            {
                if (this.Model.IsRunningAway) //if enemy is blue it has to check to run the opposite direction of the player
                {
                    check = (x <= this.Model.X && alreadyMoving == false);
                }
                else
                {
                    check = (x >= this.Model.X && alreadyMoving == false); //if player is on the right of the enemy
                }  
                if (check) 
                {
                    directionsToGo.Add(1); //adds right to the list of possible directions to go
                    //directionsToGo.Add(1); //more chance to follow player
                    //directionsToGo.Add(1);
                }
                //directionsToGo.Add(1);
            }
            if (WorldModel.Map2D[this.Model.Y, this.Model.X - 1] != 1 && this.Model.Direction != EnemyModel.direction.right) //checks if left is free
            {
                if (this.Model.IsRunningAway) //if enemy is blue it has to check to run the opposite direction of the player
                {
                    check = (x >= this.Model.X && alreadyMoving == false);
                }
                else
                {
                    check = (x <= this.Model.X && alreadyMoving == false); //if player is on the left of the enemy
                }
                if (check) 
                {
                    directionsToGo.Add(3); //adds left to the list of possible directions to go
                    //directionsToGo.Add(3);
                    //directionsToGo.Add(3);
                }
                //directionsToGo.Add(3);
            }
            if (WorldModel.Map2D[this.Model.Y + 1, this.Model.X] != 1 && this.Model.Direction != EnemyModel.direction.up) //checks if down is free
            {
                if (this.Model.IsRunningAway) //if enemy is blue it has to check to run the opposite direction of the player
                {
                    check = (y <= this.Model.Y && alreadyMoving == false);
                }
                else
                {
                    check = (y >= this.Model.Y && alreadyMoving == false); //if player is lower than the enemy
                }
                if (check) 
                {              
                    directionsToGo.Add(2); //adds down to the list of possible directions to go
                    //directionsToGo.Add(2);
                    //directionsToGo.Add(2);
                }
                //directionsToGo.Add(2);
            }
            if (WorldModel.Map2D[this.Model.Y - 1, this.Model.X] != 1 && this.Model.Direction != EnemyModel.direction.down) //checks if up is free
            {
                if (this.Model.IsRunningAway) //if enemy is blue it has to check to run the opposite direction of the player
                {
                    check = (y >= this.Model.Y && alreadyMoving == false);
                }
                else
                {
                    check = (y <= this.Model.Y && alreadyMoving == false);//if player is higher than the enemy
                }
                if (check) 
                {                
                    directionsToGo.Add(0); //adds up to the list of possible directions to go
                    //directionsToGo.Add(0);
                    //directionsToGo.Add(0);
                }
                //directionsToGo.Add(0);
            }
            if (directionsToGo.Count == 0)
            {
                if (alreadyMoving == false)
                {
                    int randomNum;
                    do
                    {
                        randomNum = this.randGen.Next(0, 4);
                    }
                    while (this.Model.Direction == (EnemyModel.direction)((randomNum + 2) % 4)); //makes sure the enemy can't go back from the direction it comes from

                    this.Model.Direction = (EnemyModel.direction)randomNum;//(EnemyModel.direction)this.randGen.Next(0, 4); //gives a random direction
                    goto startMovement;
                }
            }
            else
            {
                if (alreadyMoving == false)
                {
                    this.Model.Direction = (EnemyModel.direction)directionsToGo[this.randGen.Next(directionsToGo.Count)];
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
