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
                observer.notify(livesModel.lives); // false = ready; true = game over
            }
        }

        // executes when the observable is changed
        public void notify(bool hasEatenPacman)
        {
            
            if(hasEatenPacman)
            {
                // update model with new value
                int newNrLives = this.livesModel.lives--;
                Console.WriteLine(newNrLives);
                // update view with new amount of pictures (lives)
                this.livesUI.updateLives(newNrLives);

                // text game over visible
                if (newNrLives == 0)
                {
                    notifyObserversFromLives();// game over
                }
            }

            
        }
        
    }
}
