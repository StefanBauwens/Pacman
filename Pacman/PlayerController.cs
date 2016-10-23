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
        PlayerModel playerModel;
        PlayerUI playerUI;

        public PlayerController()
        {
            playerModel = new PlayerModel();
            playerUI = new PlayerUI(this);
        }

        public PlayerUI view
        {
            get { return this.playerUI; }
        }

        protected PlayerModel model
        {
            get { return playerModel; }
            set { playerModel = value; }
        }

        public void movePlayer()
        {
            switch(this.model.Direction)
            {
                case PlayerModel.direction.up:
                    if (WorldModel.Map2D[this.model.Y - 1, this.model.X] != 1)
                    {
                        this.model.Y--;
                        for (int i = 0; i < 16; i++)
                        {
                            this.view.Top -= 1;
                            animate();
                            if (this.model.Animation < 8)
                            {
                                this.view.pictureBox1.Image = Pacman.Properties.Resources.pacmanup;
                            }
                            else
                            {
                                this.view.pictureBox1.Image = Pacman.Properties.Resources.pacmanup1;
                            }
                            this.view.pictureBox1.Refresh();
                        }
                    }
                    break;
                case PlayerModel.direction.right:
                    if (WorldModel.Map2D[this.model.Y, this.model.X + 1] != 1)
                    {
                        this.model.X++;
                        for (int i = 0; i < 16; i++)
                        {
                            this.view.Left += 1;
                            animate();
                            if (this.model.Animation < 8)
                            {
                                this.view.pictureBox1.Image = Pacman.Properties.Resources.pacmanright;
                            }
                            else
                            {
                                this.view.pictureBox1.Image = Pacman.Properties.Resources.pacmanright1;
                            }
                            this.view.pictureBox1.Refresh();
                        }
                    }
                    break;
                case PlayerModel.direction.down:
                    if (WorldModel.Map2D[this.model.Y + 1, this.model.X] != 1)
                    {
                        this.model.Y++;
                        for (int i = 0; i < 16; i++)
                        {
                            this.view.Top += 1;
                            animate();
                            if (this.model.Animation < 8)
                            {
                                this.view.pictureBox1.Image = Pacman.Properties.Resources.pacmandown;
                            }
                            else
                            {
                                this.view.pictureBox1.Image = Pacman.Properties.Resources.pacmandown1;
                            }
                            this.view.pictureBox1.Refresh();
                        }
                    }
                    break;
                case PlayerModel.direction.left:
                    if (WorldModel.Map2D[this.model.Y, this.model.X - 1] != 1)
                    {
                        this.model.X--;
                        for (int i = 0; i < 16; i++)
                        {
                            this.view.Left -= 1;
                            animate();
                            if (this.model.Animation < 8)
                            {
                                this.view.pictureBox1.Image = Pacman.Properties.Resources.pacmanleft;
                            }
                            else
                            {
                                this.view.pictureBox1.Image = Pacman.Properties.Resources.pacmanleft1;
                            }
                            this.view.pictureBox1.Refresh();
                        }
                    }
                    break;
            }
        }

        protected void animate()
        {
            this.model.Animation++;
            if(this.model.Animation >= 16)
            {
                this.model.Animation = 0;
            }
        }

        public void checkKey(PreviewKeyDownEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Up:
                    if (WorldModel.Map2D[this.model.Y - 1, this.model.X] != 1) //if's here so you can't change direction if you can't go in that direction.
                    {
                        playerModel.Direction = PlayerModel.direction.up;
                    }
                    break;
                case Keys.Right:
                    if (WorldModel.Map2D[this.model.Y, this.model.X + 1] != 1)
                    {
                        playerModel.Direction = PlayerModel.direction.right;
                    }
                    break;
                case Keys.Down:
                    if (WorldModel.Map2D[this.model.Y + 1, this.model.X] != 1)
                    {
                        playerModel.Direction = PlayerModel.direction.down;
                    }
                    break;
                case Keys.Left:
                    if (WorldModel.Map2D[this.model.Y, this.model.X - 1] != 1)
                    {
                        playerModel.Direction = PlayerModel.direction.left;
                    }
                    break;
            }
            e.IsInputKey = true;

        }

    }
}
