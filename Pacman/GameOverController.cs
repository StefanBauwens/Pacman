using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class GameOverController
    {
        GameOverModel gameOverModel;
        GameOverUI gameOverUI;

        public GameOverController()
        {
            gameOverModel = new GameOverModel();
            gameOverUI = new GameOverUI(this);
        }

        public GameOverUI View
        {
            get { return gameOverUI; }
        }


        public void notify(int nrLives)
        {
            if(nrLives == 0)
            {
                gameOverUI.gameOverLabel.Visible = true; //if player dead --> show game over
                gameOverModel.isGameOver = true;
            }
            else
            {
                gameOverUI.gameOverLabel.Visible = false;
            }
        }
    }
}
