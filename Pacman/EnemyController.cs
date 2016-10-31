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
        //ENEMY observable from lives
        protected List<dynamic> observers = new List<dynamic>();


        bool alreadyMoving = false;
        int counter;
        int counter2 = 1;
        bool check;

        const int TIMEBLUE = 250; //time that enemy stays blue
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
            if (this.Model.TimeBlue>0) 
            {
                this.Model.TimeBlue--;
                if (this.Model.TimeBlue< 40) //check if blue should start flashing white to indicate it's going to stop running away
                {
                    counter2++;
                    if (counter2 > 16)
                    {
                        counter2 = 1;
                    }
                    if (counter2 <= 8)
                    {
                        this.Model.IsWhite = false;
                    }
                    else
                    {
                        this.Model.IsWhite = true;
                    }
                }
                if (this.Model.TimeBlue == 0) //if times up, the blue enemy becomes back normal
                {
                    this.Model.IsRunningAway = false;
                }
            }


            /*if (this.View.Left >= this.Model.XDetailed && this.View.Left <= (this.Model.XDetailed + 16) && this.View.Top >= this.Model.YDetailed && this.View.Top <= (this.Model.YDetailed + 16))
            {
                isTouching = true;
            }
            if ((this.View.Left + 16) >= this.Model.XDetailed && (this.View.Left + 16) <= (this.Model.XDetailed + 16) && this.View.Top >= this.Model.YDetailed && this.View.Top <= (this.Model.YDetailed + 16))
            {
                isTouching = true;
            }
            if (this.View.Left >= this.Model.XDetailed && this.View.Left <= (this.Model.XDetailed + 16) && (this.View.Top + 16) >= this.Model.YDetailed && (this.View.Top + 16) <= (this.Model.YDetailed + 16))
            {
                isTouching = true;
            }
            if ((this.View.Left + 16) >= this.Model.XDetailed && (this.View.Left + 16) <= (this.Model.XDetailed + 16) && (this.View.Top + 16) >= this.Model.YDetailed && (this.View.Top + 16) <= (this.Model.YDetailed + 16))
            {
                isTouching = true;
            }*/

            //Good collision detection with player
            bool isTouching = this.Collision();

            /*if (this.Model.X == this.Model.XObserver && this.View.Top > (this.Model.YDetailed+4) && this.View.Top< (this.Model.YDetailed+12)) // +4 and 12(16 -4) to have 4 pixels slack
            {
                isTouching = true;
            }
            if (this.Model.X == this.Model.XObserver && (this.View.Top+16) > (this.Model.YDetailed+4) && (this.View.Top+16) < (this.Model.YDetailed + 12))
            {
                isTouching = true;
            }
            if (this.Model.Y == this.Model.YObserver && this.View.Left > (this.Model.XDetailed+4) && this.View.Left < (this.Model.XDetailed + 12))
            {
                isTouching = true;
            }
            if (this.Model.Y == this.Model.YObserver && (this.View.Left+16) > (this.Model.XDetailed+4) && (this.View.Left+16) < (this.Model.XDetailed + 12))
            {
                isTouching = true;
            }
            if (this.Model.Y == this.Model.YObserver && this.Model.X == this.Model.XObserver)
            {
                isTouching = true;
            }*/

            // if enemy is blue and gets eaten by pacman
            if (this.Model.IsRunningAway && !this.Model.IsDead && isTouching)
            {
                this.Model.IsRunningAway = false;
                this.Model.IsDead = true;
                this.notifyObserversFromEnemy();
            }

            // if pacman gets eaten by enemy
            if (!this.Model.IsRunningAway && !this.Model.IsDead && isTouching && this.Model.XObserver!=beginTile.Model.X && this.Model.XObserver!=beginTile.Model.Y)
            {
                this.Model.HasEatenPacman = true;
                notifyObserversFromEnemy();
            }

            if (this.Model.IsDead == true) //if enemy is dead it needs to focus on begintile
            {
                this.Model.XObserver = beginTile.Model.X;
                this.Model.YObserver = beginTile.Model.Y;
                this.Model.XDetailed = beginTile.Model.X * 16;
                this.Model.YDetailed = beginTile.Model.Y * 16;
            }

            isTouching = Collision();

            if (this.Model.IsDead && isTouching)
            {
                this.Model.IsDead = false;
            }


            //startMovement:
            if (this.Model.IsRunningAway)
            {
                this.View.timer1.Interval = 17; //slow down enemy if he is blue
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
                                if (this.Model.IsWhite)
                                {
                                    this.View.enemyImage.Image = Pacman.Properties.Resources.white0;
                                }
                                else
                                {
                                    this.View.enemyImage.Image = Pacman.Properties.Resources.blue0;
                                }
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
                                if (this.Model.IsWhite)
                                {
                                    this.View.enemyImage.Image = Pacman.Properties.Resources.white1;
                                }
                                else
                                {
                                    this.View.enemyImage.Image = Pacman.Properties.Resources.blue1;
                                }
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
                                if (this.Model.IsWhite)
                                {
                                    this.View.enemyImage.Image = Pacman.Properties.Resources.white0;
                                }
                                else
                                {
                                    this.View.enemyImage.Image = Pacman.Properties.Resources.blue0;
                                }
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
                                if (this.Model.IsWhite)
                                {
                                    this.View.enemyImage.Image = Pacman.Properties.Resources.white1;
                                }
                                else
                                {
                                    this.View.enemyImage.Image = Pacman.Properties.Resources.blue1;
                                }
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
                                if (this.Model.IsWhite)
                                {
                                    this.View.enemyImage.Image = Pacman.Properties.Resources.white0;
                                }
                                else
                                {
                                    this.View.enemyImage.Image = Pacman.Properties.Resources.blue0;
                                }
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
                                if (this.Model.IsWhite)
                                {
                                    this.View.enemyImage.Image = Pacman.Properties.Resources.white1;
                                }
                                else
                                {
                                    this.View.enemyImage.Image = Pacman.Properties.Resources.blue1;
                                }
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
                                if (this.Model.IsWhite)
                                {
                                    this.View.enemyImage.Image = Pacman.Properties.Resources.white0;
                                }
                                else
                                {
                                    this.View.enemyImage.Image = Pacman.Properties.Resources.blue0;
                                }
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
                                if (this.Model.IsWhite)
                                {
                                    this.View.enemyImage.Image = Pacman.Properties.Resources.white1;
                                }
                                else
                                {
                                    this.View.enemyImage.Image = Pacman.Properties.Resources.blue1;
                                }
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
        public void notify(int xCoordinate, int yCoordinate, int xDetailed, int yDetailed)
        {
            this.Model.XObserver = xCoordinate; //gets the coordinates which it should follow(or run away from)
            this.Model.YObserver = yCoordinate;

            this.Model.XDetailed = xDetailed; //used for precise collision detection
            this.Model.YDetailed = yDetailed;

            /*if (this.Model.IsDead)
            {
                this.Model.IsDead = false; 
            }*/
            
            // if enemy is blue and gets eaten by pacman
            /*if (this.Model.IsRunningAway && this.Model.X == this.Model.XObserver && this.Model.Y == this.Model.YObserver)
            {
                this.Model.IsRunningAway = false;
                this.Model.IsDead = true;
            }
            
            // if pacman gets eaten by enemy
            if(this.Model.IsRunningAway == false && !this.Model.IsDead && this.Model.X == this.Model.XObserver && this.Model.Y == this.Model.YObserver)
            {
                notifyObserversFromEnemy();  
            }*/
            
        }

        protected void refreshPic()
        {
            /*for (int j = 0; j < SLOWDOWN; j++)
            {

            }*/
            this.View.enemyImage.Refresh();
        }

        // add observer to observer list
        public void subscribeObserverToEnemy(dynamic observer)
        {
            this.observers.Add(observer);
        }

        // loop over observers and execute method that needs to be run 
        // when observable (= enemy) changes
        protected void notifyObserversFromEnemy()
        {
            foreach (dynamic observer in this.observers)
            {
                if (this.Model.IsDead)
                {
                    if (observer is ScoreController)
                    {
                        observer.notify(200);
                        this.View.enemyImage.Image = Pacman.Properties.Resources.twohundred;
                        this.View.enemyImage.Refresh();
                        System.Threading.Thread.Sleep(300);
                    }
                }
                else
                {
                    if (!(observer is ScoreController) && this.enemyModel.HasEatenPacman)
                    {
                        observer.notify(enemyModel.HasEatenPacman);
                    }
                }
            }
        }


        public void notify(int number)//bool isRunningAway, bool isDead)
        {
            if (number == 50 && !this.Model.IsDead)
            {
                //this.enemyUI.updateImage(isRunningAway);
                this.Model.IsRunningAway = true;
                this.Model.IsWhite = false;
                this.Model.TimeBlue = TIMEBLUE; //time that the enemy is running away before he turns back normal
            }
        }

        public bool Collision() //checks for collision with begintile or player
        {
            bool isTouching = false;

            if (this.Model.X == this.Model.XObserver && this.View.Top > (this.Model.YDetailed + 4) && this.View.Top < (this.Model.YDetailed + 12)) // +4 and 12(16 -4) to have 4 pixels slack
            {
                isTouching = true;
            }
            if (this.Model.X == this.Model.XObserver && (this.View.Top + 16) > (this.Model.YDetailed + 4) && (this.View.Top + 16) < (this.Model.YDetailed + 12))
            {
                isTouching = true;
            }
            if (this.Model.Y == this.Model.YObserver && this.View.Left > (this.Model.XDetailed + 4) && this.View.Left < (this.Model.XDetailed + 12))
            {
                isTouching = true;
            }
            if (this.Model.Y == this.Model.YObserver && (this.View.Left + 16) > (this.Model.XDetailed + 4) && (this.View.Left + 16) < (this.Model.XDetailed + 12))
            {
                isTouching = true;
            }
            if (this.Model.Y == this.Model.YObserver && this.Model.X == this.Model.XObserver)
            {
                isTouching = true;
            }
            return isTouching;
        }

    }
}
