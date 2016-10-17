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
        /*
        public void notify(int newNrLives)
        {
            this.scoreModel.score = newNrLives;
    
        }
        */
        //
        public void updateLives(int newNrLives)
        {
            if (newNrLives == 2)
            {
               // this.scoreUI.
            }
        }
    }
}
