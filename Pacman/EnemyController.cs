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

        bool alreadyMoving = false;
        int counter;
        Random randGen;


        public EnemyController(PlayerController playerController)//, TileController beginTile) //constructor
        {
            this.enemyModel = new EnemyModel();
            this.enemyUI = new EnemyUI(this);
            this.player = playerController;
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
            bool wall = false;
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
                            this.View.enemyImage.Image = Pacman.Properties.Resources.enemy1up0;
                        }
                        else
                        {
                            this.View.enemyImage.Image = Pacman.Properties.Resources.enemy1up1;
                        }
                        refreshPic();
                        if (counter == 16)
                        {
                            this.Model.Y--;
                            alreadyMoving = false;
                        }
                        wall = false;
                    }
                    else
                    {
                        wall = true;
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
                            this.View.enemyImage.Image = Pacman.Properties.Resources.enemy1right0;
                        }
                        else
                        {
                            this.View.enemyImage.Image = Pacman.Properties.Resources.enemy1right1;
                        }
                        refreshPic();
                        if (counter == 16)
                        {
                            this.Model.X++;
                            alreadyMoving = false;
                        }
                        wall = false;
                    }
                    else
                    {
                        wall = true;
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
                            this.View.enemyImage.Image = Pacman.Properties.Resources.enemy1down0;
                        }
                        else
                        {
                            this.View.enemyImage.Image = Pacman.Properties.Resources.enemy1down1;
                        }
                        refreshPic();
                        if (counter == 16)
                        {
                            this.Model.Y++;
                            alreadyMoving = false;
                        }
                        wall = false;
                    }
                    else
                    {
                        wall = true;
                    }
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
                            this.View.enemyImage.Image = Pacman.Properties.Resources.enemy1left0;
                        }
                        else
                        {
                            this.View.enemyImage.Image = Pacman.Properties.Resources.enemy1left1;
                        }
                        refreshPic();
                        if (counter == 16)
                        {
                            this.Model.X--;
                            alreadyMoving = false;
                        }
                        wall = false;
                    }
                    else
                    {
                        wall = true;
                    }
                    break;
            }
            randGen = new Random();
            //check here which way to go

            List<int> directionsToGo = new List<int>();
            if (player.model.X >= this.Model.X && alreadyMoving == false) //if player is on the right of the enemy
            {
                if (WorldModel.Map2D[this.Model.Y, this.Model.X + 1] != 1) //checks if right is free
                {
                    directionsToGo.Add(1); //adds right to the list of possible directions to go
                }
            }
            if (player.model.X <= this.Model.X && alreadyMoving == false) //if player is on the left of the enemy
            {
                if (WorldModel.Map2D[this.Model.Y, this.Model.X - 1] != 1) //checks if left is free
                {
                    directionsToGo.Add(3); //adds left to the list of possible directions to go
                }
            }
            if (player.model.Y >= this.Model.Y && alreadyMoving == false) //if player is lower than the enemy
            {
                if (WorldModel.Map2D[this.Model.Y + 1, this.Model.X] != 1) //checks if down is free
                {
                    directionsToGo.Add(2); //adds down to the list of possible directions to go
                }
            }
            if (player.model.Y <= this.Model.Y && alreadyMoving == false) //if player is higher than the enemy
            {
                if (WorldModel.Map2D[this.Model.Y - 1, this.Model.X] != 1) //checks if up is free
                {
                    directionsToGo.Add(0); //adds up to the list of possible directions to go
                }
            }
            if (directionsToGo.Count == 0)
            {
                if (alreadyMoving == false)
                {
                    this.Model.Direction = (EnemyModel.direction)this.randGen.Next(0, 4); //gives a random direction
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
        
            /*if (wall == true && alreadyMoving == false)
            {                
                this.Model.Direction = (EnemyModel.direction)this.randGen.Next(0, 4); //gives a random direction
                goto startMovement;
            }*/


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
