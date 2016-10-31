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

        public GameOverUI view
        {
            get { return gameOverUI; }
        }

        public void GameOverTextVisible(bool visible)
        {
            gameOverUI.gameOverLabel.Visible = visible;
        }

        public void notify(int nrLives)
        {
            
            if(nrLives == 0)
            {
                gameOverModel.isGameOver = true;
                gameOverUI.gameOverLabel.Visible = true;
            }
        }

        
    }
}
