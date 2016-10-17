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
                    this.model.Y--;
                    this.view.Top -=16;
                    break;
                case PlayerModel.direction.right:
                    this.model.X++;
                    this.view.Left +=16;
                    break;
                case PlayerModel.direction.down:
                    this.model.Y++;
                    this.view.Top +=16;
                    break;
                case PlayerModel.direction.left:
                    this.model.X--;
                    this.view.Left -=16;
                    break;
            }
        }

        public void checkKey(PreviewKeyDownEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Up:
                    playerModel.Direction = PlayerModel.direction.up;
                    break;
                case Keys.Right:
                    playerModel.Direction = PlayerModel.direction.right;
                    break;
                case Keys.Down:
                    playerModel.Direction = PlayerModel.direction.down;
                    break;
                case Keys.Left:
                    playerModel.Direction = PlayerModel.direction.left;
                    break;
            }
        }

    }
}
