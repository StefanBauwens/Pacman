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
        TileController beginTile;
        Random randGen;

        protected List<dynamic> observers = new List<dynamic>();

        int counter2 = 1;
        bool check;
        static public int blueEnemiesEaten = 0;
        static int amountEnemies = -1;
        const int TIMEBLUE = 250; //time that enemy stays blue

        object up0;
        object up1;
        public object right0;
        object right1;
        object down0;
        object down1;
        object left0;
        object left1;

        public EnemyController(TileController mBeginTile) //constructor
        {
            amountEnemies++;

            this.enemyModel = new EnemyModel();
            this.enemyUI = new EnemyUI(this);
            this.beginTile = mBeginTile;

            this.Model.Color = (EnemyModel.colorType)(((amountEnemies)%4) + 1); //new color for new enemy

            //sets all the sprites good for specific color
            up0 = Pacman.Properties.Resources.ResourceManager.GetObject("enemy" + (int)this.Model.Color + "up0");
            up1 = Pacman.Properties.Resources.ResourceManager.GetObject("enemy" + (int)this.Model.Color + "up1");
            right0 = Pacman.Properties.Resources.ResourceManager.GetObject("enemy" + (int)this.Model.Color + "right0");
            right1 = Pacman.Properties.Resources.ResourceManager.GetObject("enemy" + (int)this.Model.Color + "right1");
            down0 = Pacman.Properties.Resources.ResourceManager.GetObject("enemy" + (int)this.Model.Color + "down0");
            down1 = Pacman.Properties.Resources.ResourceManager.GetObject("enemy" + (int)this.Model.Color + "down1");
            left0 = Pacman.Properties.Resources.ResourceManager.GetObject("enemy" + (int)this.Model.Color + "left0");
            left1 = Pacman.Properties.Resources.ResourceManager.GetObject("enemy" + (int)this.Model.Color + "left1");

            this.View.enemyImage.Image = (System.Drawing.Image)right0;
            this.View.enemyImage.Refresh();
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
            if (this.Model.TimeBlue>0 && this.Model.IsRunningAway) 
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
                    EnemyController.blueEnemiesEaten = 0;
                    this.Model.IsRunningAway = false;
                }
            }

            bool isTouching = this.Collision();

            // if enemy is blue and gets eaten by pacman
            if (this.Model.IsRunningAway && !this.Model.IsDead && isTouching)
            {
                this.Model.IsRunningAway = false;
                this.Model.IsDead = true;
                this.Model.TimeBlue = 0;
                this.Model.Step = 2;
                fixSpeedChange();
                EnemyController.blueEnemiesEaten++;
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
                this.Model.TimeBlue = 0;
                this.Model.Step = 1;
                fixSpeedChange();
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
                        if (this.Model.AlreadyMoving == false)
                        {
                            this.Model.AlreadyMoving = true;
                            this.Model.Counter = 0;
                        }
                        this.Model.Counter += this.Model.Step;
                        this.View.Top -= this.Model.Step;
                        animate();
                        if (this.Model.Animation < 4)
                        {
                            if (this.Model.IsRunningAway)
                            {
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
                                this.View.enemyImage.Image = (System.Drawing.Image)up0;
                            }
                        }
                        else
                        {
                            if (this.Model.IsRunningAway)
                            {
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
                                this.View.enemyImage.Image = (System.Drawing.Image)up1;
                            }
                        }
                        refreshPic();
                        if (this.Model.Counter == 16)
                        {
                            this.Model.Y--;
                            this.Model.AlreadyMoving = false;
                        }
                    }
                    break;
                case EnemyModel.direction.right:
                    if (WorldModel.Map2D[this.Model.Y, this.Model.X + 1] != 1)
                    {
                        if (this.Model.AlreadyMoving == false)
                        {
                            this.Model.AlreadyMoving = true;
                            this.Model.Counter = 0;
                        }
                        this.Model.Counter += this.Model.Step;
                        this.View.Left += this.Model.Step;
                        animate();
                        if (this.Model.Animation < 4)
                        {
                            if (this.Model.IsRunningAway) //checks if enemy should be blue(and running away) or not
                            {
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
                                this.View.enemyImage.Image = (System.Drawing.Image)right0;
                            }
                        }
                        else
                        {
                            if (this.Model.IsRunningAway)
                            {
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
                                this.View.enemyImage.Image = (System.Drawing.Image)right1;
                            }
                        }
                        refreshPic();
                        if (this.Model.Counter == 16)
                        {
                            if (this.Model.X == (WorldModel.Map2D.GetLength(1) - 2)) 
                            {
                                this.Model.X = 1;
                                this.View.Left = 16;
                            }
                            else
                            {
                                this.Model.X++;
                            }
                            this.Model.AlreadyMoving = false;
                        }
                    }
                    break;
                case EnemyModel.direction.down:
                    if (WorldModel.Map2D[this.Model.Y + 1, this.Model.X] != 1)
                    {
                        if (this.Model.AlreadyMoving == false)
                        {
                            this.Model.AlreadyMoving = true;
                            this.Model.Counter = 0;
                        }
                        this.Model.Counter += this.Model.Step;
                        this.View.Top += this.Model.Step;
                        animate();
                        if (this.Model.Animation < 4)
                        {
                            if (this.Model.IsRunningAway)
                            {
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
                                this.View.enemyImage.Image = (System.Drawing.Image)down0;
                            }
                        }
                        else
                        {
                            if (this.Model.IsRunningAway)
                            {
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
                                this.View.enemyImage.Image = (System.Drawing.Image)down1;
                            }
                        }
                        refreshPic();
                        if (this.Model.Counter == 16)
                        {
                            this.Model.Y++;
                            this.Model.AlreadyMoving = false;
                        }
                    }
                    break;
                case EnemyModel.direction.left:
                    if (WorldModel.Map2D[this.Model.Y, this.Model.X - 1] != 1)
                    {
                        if (this.Model.AlreadyMoving == false)
                        {
                            this.Model.AlreadyMoving = true;
                            this.Model.Counter = 0;
                        }
                        this.Model.Counter += this.Model.Step;
                        this.View.Left -= this.Model.Step;
                        animate();
                        if (this.Model.Animation < 4)
                        {
                            if (this.Model.IsRunningAway)
                            {
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
                                this.View.enemyImage.Image = (System.Drawing.Image)left0;
                            }
                        }
                        else
                        {
                            if (this.Model.IsRunningAway)
                            {
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
                                this.View.enemyImage.Image = (System.Drawing.Image)left1; 
                            }

                        }
                        refreshPic();
                        if (this.Model.Counter == 16)
                        {
                            if (this.Model.X == 1) //if you're standing at the left edge of the map you must teleport
                            {
                                this.Model.X = WorldModel.Map2D.GetLength(1) - 2;
                                this.View.Left = this.Model.X * 16;
                            }
                            else
                            {
                                this.Model.X--;
                            }
                            this.Model.AlreadyMoving = false;
                        }
                    }        
                    break;
            }

            randGen = new Random();
            //check here which way to go

            List<int> directionsToGo = new List<int>();
            List<int> directionsToGo2 = new List<int>();
            int forcedDirection = 0;

            if (WorldModel.Map2D[this.Model.Y, this.Model.X + 1] != 1 && this.Model.Direction != EnemyModel.direction.left) //checks if right is free
            {
                if (this.Model.IsRunningAway) //if enemy is blue it has to check to run the opposite direction of the player
                {
                    check = (this.Model.XObserver <= this.Model.X && this.Model.AlreadyMoving == false);
                }
                else
                {
                    check = (this.Model.XObserver >= this.Model.X && this.Model.AlreadyMoving == false); //if player is on the right of the enemy
                }  
                if (check) 
                {
                    directionsToGo.Add(1); //adds right to the list of possible directions to go
                }
                if (check && this.Model.YObserver == this.Model.Y) //check to see if enemy and player are on the same line
                {
                    forcedDirection = 1;
                }
                directionsToGo2.Add(1);
            }
            if (WorldModel.Map2D[this.Model.Y, this.Model.X - 1] != 1 && this.Model.Direction != EnemyModel.direction.right) //checks if left is free
            {
                if (this.Model.IsRunningAway) //if enemy is blue it has to check to run the opposite direction of the player
                {
                    check = (this.Model.XObserver >= this.Model.X && this.Model.AlreadyMoving == false);
                }
                else
                {
                    check = (this.Model.XObserver <= this.Model.X && this.Model.AlreadyMoving == false); //if player is on the left of the enemy
                }
                if (check) 
                {
                    directionsToGo.Add(3); //adds left to the list of possible directions to go
                }
                if (check && this.Model.YObserver == this.Model.Y) //check to see if enemy and player are on the same line
                {
                    forcedDirection = 3;
                }
                directionsToGo2.Add(3);
            }
            if (WorldModel.Map2D[this.Model.Y + 1, this.Model.X] != 1 && this.Model.Direction != EnemyModel.direction.up) //checks if down is free
            {
                if (this.Model.IsRunningAway) //if enemy is blue it has to check to run the opposite direction of the player
                {
                    check = (this.Model.YObserver <= this.Model.Y && this.Model.AlreadyMoving == false);
                }
                else
                {
                    check = (this.Model.YObserver >= this.Model.Y && this.Model.AlreadyMoving == false); //if player is lower than the enemy
                }
                if (check) 
                {              
                    directionsToGo.Add(2); //adds down to the list of possible directions to go               
                }
                if (check && this.Model.XObserver == this.Model.X) //check to see if enemy and player are on the same line
                {
                    forcedDirection = 2;
                }
                directionsToGo2.Add(2);
            }
            if (WorldModel.Map2D[this.Model.Y - 1, this.Model.X] != 1 && this.Model.Direction != EnemyModel.direction.down) //checks if up is free
            {
                if (this.Model.IsRunningAway) //if enemy is blue it has to check to run the opposite direction of the player
                {
                    check = (this.Model.YObserver >= this.Model.Y && this.Model.AlreadyMoving == false);
                }
                else
                {
                    check = (this.Model.YObserver <= this.Model.Y && this.Model.AlreadyMoving == false);//if player is higher than the enemy
                }
                if (check) 
                {                
                    directionsToGo.Add(0); //adds up to the list of possible directions to go
                }
                if (check && this.Model.XObserver == this.Model.X) //check to see if enemy and player are on the same line
                {
                    forcedDirection = 0;
                }
                directionsToGo2.Add(0);
            }

            if (directionsToGo.Count == 0)
            {
                if (this.Model.AlreadyMoving == false)
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
                if (this.Model.AlreadyMoving == false)
                {
                    this.Model.Direction = (EnemyModel.direction)directionsToGo[this.randGen.Next(directionsToGo.Count)];
                }
            }
            if (forcedDirection != 0) //force the enemy to go in direction of the player if it can
            {
                this.Model.Direction = (EnemyModel.direction)forcedDirection;
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
        }

        protected void refreshPic()
        {
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
                        switch(EnemyController.blueEnemiesEaten)
                        {
                            case 1:
                                observer.notify(200); //for every blue enemy you eat score doubles
                                this.View.enemyImage.Image = Pacman.Properties.Resources.twohundred;
                                break;
                            case 2:
                                observer.notify(400);
                                this.View.enemyImage.Image = Pacman.Properties.Resources.fourhundred;
                                break;
                            case 3:
                                observer.notify(800);
                                this.View.enemyImage.Image = Pacman.Properties.Resources.eighthundred;
                                break;
                            case 4:
                                observer.notify(1600);
                                this.View.enemyImage.Image = Pacman.Properties.Resources.sixteenhundred;
                                break;
                            default:
                                observer.notify(1600);
                                this.View.enemyImage.Image = Pacman.Properties.Resources.sixteenhundred;
                                break;
                        }
                       
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

        protected void fixSpeedChange() //this fixes coordinate issues when switching from dead to alive or vice versa
        {
            if (this.Model.Counter > 0)
            {
                switch (this.Model.Direction)
                {
                    case EnemyModel.direction.up:
                        this.Model.Y--;
                        break;
                    case EnemyModel.direction.right:
                        this.Model.X++;
                        break;
                    case EnemyModel.direction.down:
                        this.Model.Y++;
                        break;
                    case EnemyModel.direction.left:
                        this.Model.X--;
                        break;
                }
                this.View.Left = this.Model.X * 16;
                this.View.Top = this.Model.Y * 16;
                this.Model.Counter = 0;
                this.Model.AlreadyMoving = false;
            }
        }

        public void notify(int number)
        {
            if (number == 50 && !this.Model.IsDead)
            {
                EnemyController.blueEnemiesEaten = 0;
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
