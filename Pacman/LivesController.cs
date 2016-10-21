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

        public LivesController()
        {
            this.livesModel = new LivesModel();
            this.livesUI = new LivesUI();
        }

        public LivesUI view
        {
            get { return this.livesUI; }
        }
        
        // executes when the observable is changed
        public void notify(int newNrLives)
        {
            
            // update view with new amount of pictures (lives)
            this.livesUI.updateLives(newNrLives);
            
            // update model with new value
            this.livesModel.lives = newNrLives;
        }
        
    }
}
