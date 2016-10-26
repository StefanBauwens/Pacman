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
        protected List<dynamic> observers = new List<dynamic>();

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
        public void notify(bool isEaten)
        {

            // update view with images
            this.bigDotUI.updateImage(isEaten);

            // notify observers with new score
            notifyObserversFromBigDot();
        }
    }
}
