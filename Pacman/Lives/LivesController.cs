using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class LivesController
    {
        private LivesModel livesModel;
        private LivesUI livesUI;
        protected List<dynamic> observers = new List<dynamic>();

        public LivesController()
        {
            this.livesModel = new LivesModel();
            this.livesUI = new LivesUI();
        }

        public LivesUI view
        {
            get { return this.livesUI; }
        }

        public LivesModel Model
        {
            get { return this.livesModel; }
            set { this.livesModel = value; }
        }

        // add observer to observer list
        public void subscribeObserverToLives(dynamic observer)
        {
            this.observers.Add(observer);
        }

        // loop over observers and execute method that needs to be run 
        // when observable (= Lives) changes
        protected void notifyObserversFromLives()
        {
            foreach (dynamic observer in this.observers)
            {
                observer.notify(livesModel.lives); 
            }
        }

        // executes when the observable is changed
        public void notify(bool hasEatenPacman)
        {
            
            if(hasEatenPacman)
            {
                // update model with new value
                int newNrLives = --this.livesModel.lives; // -- before variable so newLives gets updated immediately with the lower lives
                Console.WriteLine(newNrLives);
                // update view with new amount of pictures (lives)
                this.updateLives(newNrLives);
                // text game over visible               
                notifyObserversFromLives();// game over              
            }       
        }

        // update view by changing images of lives (lives --> black)
        public void updateLives(int newNrLives)
        {
            if (newNrLives == 3)
            {
                this.view.imageLifeRight.Image = Properties.Resources.pacmanLives;
                this.view.imageLifeMiddle.Image = Properties.Resources.pacmanLives;
                this.view.imageLifeLeft.Image = Properties.Resources.pacmanLives;
            }
            else if (newNrLives == 2)
            {
                this.view.imageLifeRight.Image = Properties.Resources.black;
                this.view.imageLifeRight.Refresh();
            }
            else if (newNrLives == 1)
            {
                this.view.imageLifeMiddle.Image = Properties.Resources.black;
                this.view.imageLifeMiddle.Refresh();
            }
            else if (newNrLives == 0)
            {
                this.view.imageLifeLeft.Image = Properties.Resources.black;
                this.view.imageLifeLeft.Refresh();
            }
        }

    }
}
