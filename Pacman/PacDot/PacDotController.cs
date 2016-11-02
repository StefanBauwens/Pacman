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

        static public int pacDotAmmount = 0; //how many pacdots there are
        static public int pacDotsEaten = 0;

        public PacDotController()
        {
            pacDotAmmount++; //every time a new pacot is instantiated the total ammount goes up
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
        
        public PacDotModel Model
        {
            get { return pacDotModel; }
            set { pacDotModel = value; }
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
                if (!(observer is WorldController))
                {
                    observer.notify(pacDotModel.dotPoints); //change score with value of pac dot
                }
                else
                {
                    observer.notify(pacDotsEaten);
                }
            }
        }

        // executes when the observable is changed
        public void notify(int xCoordinate, int yCoordinate, int notUsed, int notUsed2)
        {
            if (this.Model.X == xCoordinate && this.Model.Y == yCoordinate && !this.Model.isEaten)
            {
                this.pacDotUI.updateImage(true);
                this.Model.isEaten = true;
                pacDotsEaten++; //adds one to pacdots eaten
                notifyObserversFromPacDot();  // update view with images
            }
        }

    }
}
