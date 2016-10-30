using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class BigDotController
    {
        private BigDotModel bigDotModel;
        private BigDotUI bigDotUI;
        protected List<dynamic> observers = new List<dynamic>();

        public BigDotController()
        {
            this.bigDotModel = new BigDotModel();
            this.bigDotUI = new BigDotUI(this);
        }

        // returns view
        public BigDotUI view
        {
            get
            {
                return this.bigDotUI;
            }
        }

        public BigDotModel Model
        {
            get { return bigDotModel; }
            set { bigDotModel = value;}
        }

        public void FlashImage()
        {
            if (!this.Model.isEaten)
            {
                animate();
                if (this.Model.Animation < 4)
                {
                    this.view.bigDotImage.Image = Pacman.Properties.Resources.bigdot;
                }
                else
                {
                    this.view.bigDotImage.Image = Pacman.Properties.Resources.black;
                }
                this.view.bigDotImage.Refresh();
            }          
        }

        protected void animate()
        {
            this.Model.Animation++;
            if (this.Model.Animation >= 8)
            {
                this.Model.Animation = 0;
            }
        }

        // add observer to observer list
        public void subscribeObserverToBigDot(dynamic observer)
        {
            this.observers.Add(observer);
        }

        // loop over observers and execute method that needs to be run 
        // when observable (= bigDot) changes
        protected void notifyObserversFromBigDot()
        {
            foreach (dynamic observer in this.observers)
            {
                observer.notify(bigDotModel.dotPoints); //change score with value of big dot
            }
        }

        // executes when the observable is changed
        public void notify(int xCoordinate, int yCoordinate, int notUsed, int notUsed2)
        {
            if (this.Model.X == xCoordinate && this.Model.Y == yCoordinate && !this.Model.isEaten)
            {
                this.view.updateImage(true);
                this.Model.isEaten = true;
                notifyObserversFromBigDot();
            }
        }
    }
}
