using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class PacDotController
    {
        private PacDotModel pacDotModel;
        private ScoreUI scoreUI;

        public ScoreController()
        {
            this.scoreModel = new ScoreModel();
            this.scoreUI = new ScoreUI();
        }

        // returns view
        public ScoreUI view
        {
            get
            {
                return this.scoreUI;
            }
        }

        // executes when the observable is changed
        public void notify(int newNrDots)
        {
            // update model with new value
            this.scoreModel.score = newNrDots;

            // update view with new value
            this.scoreUI.updateScore(newNrDots);
        }
    }
}
