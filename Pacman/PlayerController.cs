using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Pacman
{
    public class PlayerController
    {
        static public Keys key = Keys.Right;

        protected PlayerModel playerModel;
        protected PlayerUI playerUI;
        public ReadyController ready;
        protected List<dynamic> observers = new List<dynamic>();

        public const int KEYSPEED = 30; //how long a keypress stays active

        //bool alreadyMoving = false;
        //int counter;
        static public int keyDelay = 0;

        public PlayerController(ReadyController readyC)
        {
            playerModel = new PlayerModel();
            playerUI = new PlayerUI(this);
            ready = readyC;
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
            checkKeyAFewTimes(key);

            ready.isGameStarted();

            if (this.model.IsDead) //death scene
            {
                for (int i = 1; i <= 11; i++)
                {
                    object picture = Pacman.Properties.Resources.ResourceManager.GetObject("death" + i);
                    this.view.pictureBox1.Image = (System.Drawing.Image)picture;
                    this.view.pictureBox1.Update();
                    System.Threading.Thread.Sleep(150);                   
                }
                System.Threading.Thread.Sleep(150);
                this.notifyWorld();
                this.view.pictureBox1.Image = Pacman.Properties.Resources.pacmanright;
                this.view.pictureBox1.Update();
                this.model.IsDead = false;// pacman appears back             
            }

            //

            switch (this.model.Direction)
            {
                case PlayerModel.direction.up:
                    if (WorldModel.Map2D[this.model.Y - 1, this.model.X] != 1)
                    {
                        if (this.model.AlreadyMoving == false)
                        {
                            this.model.AlreadyMoving = true;
                            this.model.Counter = 0;
                        }
                        this.model.Counter++;
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
                        this.view.pictureBox1.Refresh();
                        if (this.model.Counter == 16)
                        {
                            this.model.Y--;
                            this.notifyObservers();
                            this.model.AlreadyMoving = false;
                        }
                    }
                    break;
                case PlayerModel.direction.right:
                    if (WorldModel.Map2D[this.model.Y, this.model.X + 1] != 1)
                    {
                        if (this.model.AlreadyMoving == false)
                        {
                            this.model.AlreadyMoving = true;
                            this.model.Counter = 0;
                        }
                        this.model.Counter++;
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
                        this.view.pictureBox1.Refresh();
                        if (this.model.Counter == 16)
                        {
                            if (this.model.X == (WorldModel.Map2D.GetLength(1)-2)) //if you're standing at the right edge of the map you must teleport
                            {
                                this.model.X = 1;
                                this.view.Left = 16;                              
                            }
                            else
                            {
                                this.model.X++;
                            }
                            this.notifyObservers();
                            this.model.AlreadyMoving = false;
                        }
                    }
                    break;
                case PlayerModel.direction.down:
                    if (WorldModel.Map2D[this.model.Y + 1, this.model.X] != 1)
                    {
                        if (this.model.AlreadyMoving == false)
                        {
                            this.model.AlreadyMoving = true;
                            this.model.Counter = 0;
                        }
                        this.model.Counter++;
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
                        this.view.pictureBox1.Refresh();
                        if (this.model.Counter == 16)
                        {
                            this.model.Y++;
                            this.notifyObservers();
                            this.model.AlreadyMoving = false;
                        }
                    }
                    break;
                case PlayerModel.direction.left:
                    if (WorldModel.Map2D[this.model.Y, this.model.X - 1] != 1)
                    {       
                        if (this.model.AlreadyMoving == false)
                        {
                            this.model.AlreadyMoving = true;
                            this.model.Counter = 0;
                        }
                        this.model.Counter++;
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
                        this.view.pictureBox1.Refresh();
                        if (this.model.Counter == 16)
                        {
                            if (this.model.X == 1) //if you're standing at the left edge of the map you must teleport
                            {
                                this.model.X = WorldModel.Map2D.GetLength(1)-2;
                                this.view.Left = this.model.X*16;
                            }
                            else
                            {
                                this.model.X--;
                            }
                            this.notifyObservers();
                            this.model.AlreadyMoving = false;
                        }
                    }
                    break;
            }
            //Console.WriteLine("Lastkeypressed: " + this.model.LastKeyPressed);
        }

        protected void animate()
        {
            this.model.Animation++;
            if(this.model.Animation >= 8)
            {
                this.model.Animation = 0;
            }
        }

        /*protected void refreshPic()
        {
            this.view.pictureBox1.Refresh();
        }*/

        public void notify(bool isDead)
        {
            this.model.IsDead = isDead;

            foreach (dynamic observer in this.observers)
            {
                if (observer is EnemyController)
                {
                    //hide all enemies
                    observer.Model.Counter = 0;
                    //observer.Model.Direction = EnemyModel.direction.right;
                    observer.Model.X = 18;
                    observer.Model.Y = 16;
                    observer.View.Left = -32;
                    observer.View.Top = -32;
                }
            }
        }

        protected void notifyObservers()
        {
            foreach (dynamic observer in this.observers)
            {
                if (!(observer is WorldController))
                {
                    observer.notify(this.model.X, this.model.Y, this.view.Left, this.view.Top); //gives coordinates of player to observers
                }
            }
        }

        protected void notifyWorld()
        {
            foreach (dynamic observer in this.observers)
            {
                if (observer is WorldController)
                {
                    observer.notify(true);
                }
            }
        }

        // Add observer to observer list
        public void subscribeObserver(dynamic observer)
        {
            this.observers.Add(observer);
        }

        public void checkKeyAFewTimes(Keys e)
        {
            this.model.LastKeyPressed = e;
            //keyDelay = KEYSPEED;

            if (keyDelay > 0) //add some keydelay so it's easier to turn around a corner
            {
                keyDelay--;
                checkKey(this.model.LastKeyPressed);
            }
            else
            {
                key = Keys.A;
            }
            //this.movePlayer();
        }

        public void checkKey(Keys e)//KeyEventArgs e)//PreviewKeyDownEventArgs e)
        {
            switch (e)//e.KeyCode)
            {
                case Keys.Up:
                    if ((WorldModel.Map2D[this.model.Y - 1, this.model.X] != 1) && (this.model.AlreadyMoving == false) && this.model.Direction != PlayerModel.direction.up) //if's here so you can't change direction if you can't go in that direction.
                    {
                        playerModel.Direction = PlayerModel.direction.up;
                    }
                    break;
                case Keys.Right:
                    if ((WorldModel.Map2D[this.model.Y, this.model.X + 1] != 1) && (this.model.AlreadyMoving == false) && this.model.Direction != PlayerModel.direction.right)
                    {
                        playerModel.Direction = PlayerModel.direction.right;
                    }
                    break;
                case Keys.Down:
                    if ((WorldModel.Map2D[this.model.Y + 1, this.model.X] != 1) && (this.model.AlreadyMoving == false) && this.model.Direction != PlayerModel.direction.down)
                    {
                        playerModel.Direction = PlayerModel.direction.down;
                    }
                    break;
                case Keys.Left:
                    if ((WorldModel.Map2D[this.model.Y, this.model.X - 1] != 1) && (this.model.AlreadyMoving == false) && this.model.Direction != PlayerModel.direction.left)
                    {
                        playerModel.Direction = PlayerModel.direction.left;
                    }
                    break;
            }
            //key = Keys.A; 
            //e.IsInputKey = true; //Use this only when using previewkeydown so that when using arrow keys you don't switch controls
        }

    }
}
