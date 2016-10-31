using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public class PlayerController
    {
        protected PlayerModel playerModel;
        protected PlayerUI playerUI;
        //PLAYER = OBSERVABLE
        protected List<dynamic> observers = new List<dynamic>();

        //const int SLOWDOWN = 1500000; //raise this number to slow down pacman
        const int KEYSPEED = 30; //how long a keypress stays active

        bool alreadyMoving = false;
        int counter;
        int keyDelay = 0;

        public PlayerController()
        {
            playerModel = new PlayerModel();
            playerUI = new PlayerUI(this);
        }

        public PlayerUI view
        {
            get { return this.playerUI; }
        }

        public PlayerModel model
        {
            get { return playerModel; }
            set { playerModel = value; }
        }

        public void movePlayer()
        {
            if (this.model.IsDead) //death scene
            {
                for (int i = 1; i <= 11; i++)
                {
                    object picture = Pacman.Properties.Resources.ResourceManager.GetObject("death" + i);
                    this.view.pictureBox1.Image = (System.Drawing.Image)picture;
                    System.Threading.Thread.Sleep(150);
                    refreshPic();
                }
                this.model.IsDead = false;// pacman appears back
            }

            if (keyDelay > 0) //add some keydelay so it's easier to turn around a corner
            {
                keyDelay--;
                checkKey(this.model.LastKeyPressed);
            }

            switch (this.model.Direction)
            {
                case PlayerModel.direction.up:
                    if (WorldModel.Map2D[this.model.Y - 1, this.model.X] != 1)
                    {
                        if (alreadyMoving == false)
                        {
                            alreadyMoving = true;
                            counter = 0;
                        }
                        counter++;
                        this.view.Top -= 1;
                        animate();
                        if (this.model.Animation < 4)
                        {
                            this.view.pictureBox1.Image = Pacman.Properties.Resources.pacmanup;
                        }
                        else
                        {
                            this.view.pictureBox1.Image = Pacman.Properties.Resources.pacmanup1;
                        }
                        refreshPic();
                        if (counter == 16)
                        {
                            this.model.Y--;
                            this.notifyObservers();
                            alreadyMoving = false;
                        }
                    }
                    break;
                case PlayerModel.direction.right:
                    if (WorldModel.Map2D[this.model.Y, this.model.X + 1] != 1)
                    {
                        if (alreadyMoving == false)
                        {
                            alreadyMoving = true;
                            counter = 0;
                        }
                        counter++;
                        this.view.Left += 1;
                        animate();
                        if (this.model.Animation < 4)
                        {
                            this.view.pictureBox1.Image = Pacman.Properties.Resources.pacmanright;
                        }
                        else
                        {
                            this.view.pictureBox1.Image = Pacman.Properties.Resources.pacmanright1;
                        }
                        refreshPic();
                        if (counter == 16)
                        {
                            this.model.X++;
                            this.notifyObservers();
                            alreadyMoving = false;
                        }
                    }
                    break;
                case PlayerModel.direction.down:
                    if (WorldModel.Map2D[this.model.Y + 1, this.model.X] != 1)
                    {
                        if (alreadyMoving == false)
                        {
                            alreadyMoving = true;
                            counter = 0;
                        }
                        counter++;
                        this.view.Top += 1;
                        animate();
                        if (this.model.Animation < 4)
                        {
                            this.view.pictureBox1.Image = Pacman.Properties.Resources.pacmandown;
                        }
                        else
                        {
                            this.view.pictureBox1.Image = Pacman.Properties.Resources.pacmandown1;
                        }
                        refreshPic();
                        if (counter == 16)
                        {
                            this.model.Y++;
                            this.notifyObservers();
                            alreadyMoving = false;
                        }
                    }
                    break;
                case PlayerModel.direction.left:
                    if (WorldModel.Map2D[this.model.Y, this.model.X - 1] != 1)
                    {
                        if (alreadyMoving == false)
                        {
                            alreadyMoving = true;
                            counter = 0;
                        }
                        counter++;
                        this.view.Left -= 1;
                        animate();
                        if (this.model.Animation < 4)
                        {
                            this.view.pictureBox1.Image = Pacman.Properties.Resources.pacmanleft;
                        }
                        else
                        {
                            this.view.pictureBox1.Image = Pacman.Properties.Resources.pacmanleft1;
                        }
                        refreshPic();
                        if (counter == 16)
                        {
                            this.model.X--;
                            this.notifyObservers();
                            alreadyMoving = false;
                        }
                    }
                    break;
            }
        }

        protected void animate()
        {
            this.model.Animation++;
            if(this.model.Animation >= 8)
            {
                this.model.Animation = 0;
            }
        }

        protected void refreshPic()
        {
            this.view.pictureBox1.Refresh();
        }

        public void notify(bool isDead)
        {
            this.model.IsDead = isDead;

            foreach (dynamic observer in this.observers)
            {
                if (observer is EnemyController)
                {
                    //hide all enemies
                    observer.Model.X = 1;//18;
                    observer.Model.Y = 1;//16;
                    observer.View.Left = 16;//-32;
                    observer.View.Top = 16;//-32;
                }
            }
        }

        protected void notifyObservers()
        {
            foreach (dynamic observer in this.observers)
            {
                observer.notify(this.model.X, this.model.Y, this.view.Left, this.view.Top); //gives coordinates of player to observers
            }
        }

        // Add observer to observer list
        public void subscribeObserver(dynamic observer)
        {
            this.observers.Add(observer);
        }

        public void checkKeyAFewTimes(PreviewKeyDownEventArgs e)
        {
            this.model.LastKeyPressed = e;
            keyDelay = KEYSPEED;
            this.movePlayer();
        }

        public void checkKey(PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if ((WorldModel.Map2D[this.model.Y - 1, this.model.X] != 1) && (alreadyMoving== false)) //if's here so you can't change direction if you can't go in that direction.
                    {
                        playerModel.Direction = PlayerModel.direction.up;
                    }
                    break;
                case Keys.Right:
                    if ((WorldModel.Map2D[this.model.Y, this.model.X + 1] != 1) && (alreadyMoving == false))
                    {
                        playerModel.Direction = PlayerModel.direction.right;
                    }
                    break;
                case Keys.Down:
                    if ((WorldModel.Map2D[this.model.Y + 1, this.model.X] != 1) && (alreadyMoving == false))
                    {
                        playerModel.Direction = PlayerModel.direction.down;
                    }
                    break;
                case Keys.Left:
                    if ((WorldModel.Map2D[this.model.Y, this.model.X - 1] != 1) && (alreadyMoving == false))
                    {
                        playerModel.Direction = PlayerModel.direction.left;
                    }
                    break;
            }
            
            e.IsInputKey = true;

        }

    }
}
