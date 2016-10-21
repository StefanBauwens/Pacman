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
                        this.view.Top -= 16;
                    }
                    break;
                case PlayerModel.direction.right:
                    if (WorldModel.Map2D[this.model.Y, this.model.X + 1] != 1)
                    {
                        this.model.X++;
                        this.view.Left += 16;
                    }
                    break;
                case PlayerModel.direction.down:
                    if (WorldModel.Map2D[this.model.Y + 1, this.model.X] != 1)
                    {
                        this.model.Y++;
                        this.view.Top += 16;
                    }
                    break;
                case PlayerModel.direction.left:
                    if (WorldModel.Map2D[this.model.Y, this.model.X - 1] != 1)
                    {
                        this.model.X--;
                        this.view.Left -= 16;
                    }
                    break;
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
