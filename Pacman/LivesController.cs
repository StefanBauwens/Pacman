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
            if (newNrLives == 2)
            {
                this.livesUI.imageLifeRight.Image = Properties.Resources.black;   
            }
            else if (newNrLives == 1)
            {
                this.livesUI.imageLifeMiddle.Image = Properties.Resources.black;
            }
            else if (newNrLives == 0)
            {
                this.livesUI.imageLifeLeft.Image = Properties.Resources.black;
            }
            // update model with new value
            this.livesModel.lives = newNrLives;
        }
        
    }
}
