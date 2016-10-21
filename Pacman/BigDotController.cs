using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class BigDotController
    {
        private BigDotModel bigDotModel;
        private BigDotUI bigDotUI;

        public BigDotController()
        {
            this.bigDotModel = new BigDotModel();
            this.bigDotUI = new BigDotUI();
        }

        // returns view
        public BigDotUI view
        {
            get
            {
                return this.bigDotUI;
            }
        }

        // executes when the observable is changed
        public void notify(bool isEaten)
        {

            // update view with images
            this.bigDotUI.updateImage(isEaten);
        }
    }
}
