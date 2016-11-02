using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Pacman
{
    public class GameOverController
    {
        GameOverModel gameOverModel;
        GameOverUI gameOverUI;

        List<dynamic> observers = new List<dynamic>();

        public GameOverController()
        {
            gameOverModel = new GameOverModel();
            gameOverUI = new GameOverUI(this);
        }

        public GameOverUI view
        {
            get { return gameOverUI; }
            set { gameOverUI = value; }
        }

        public GameOverModel Model
        {
            get { return gameOverModel; }
            set { gameOverModel = value; }
        }

        public void GameOverTextVisible(bool visible)
        {
            gameOverUI.gameOverLabel.Visible = visible;
        }

        public void notify(int nrLives)
        {           
            if(nrLives == 0)
            {
                this.view.BringToFront();
                gameOverModel.isGameOver = true;
                gameOverUI.gameOverLabel.Visible = true;
                NotifyObservers();               
            }
        }

        public void SubscribeObserver(dynamic observer)
        {
            observers.Add(observer);
        }

        public void NotifyObservers()
        {
            foreach (dynamic observer in observers)
            {
                observer.notify();
            }
        }



    }
}
