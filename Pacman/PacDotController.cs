using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class PacDotController
    {
        private PacDotModel pacDotModel;
        private PacDotUI pacDotUI;
        protected List<dynamic> observers = new List<dynamic>();

        public PacDotController()
        {
            this.pacDotModel = new PacDotModel();
            this.pacDotUI = new PacDotUI();
        }

        // returns view
        public PacDotUI view
        {
            get
            {
                return this.pacDotUI;
            }
        }

        // add observer to observer list
        public void subscribeObserverToPacDot(dynamic observer)
        {
            this.observers.Add(observer);
        }

        // loop over observers and execute method that needs to be run 
        // when observable (= pacDot) changes
        protected void notifyObserversFromPacDot()
        {
            foreach (dynamic observer in this.observers)
            {
                observer.notify(pacDotModel.dotPoints); //change score with value of pac dot
            }
        }


        // executes when the observable is changed
        public void notify(bool isEaten)
        {

            // update view with images
            this.pacDotUI.updateImage(isEaten);

            notifyObserversFromPacDot();

        }

    }
}
