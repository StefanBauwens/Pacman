using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class ReadyController
    {
        ReadyModel readyModel;
        ReadyUI readyUI;

        public ReadyController()
        {
            readyModel = new ReadyModel();
            readyUI = new ReadyUI();
        }

        public ReadyUI View
        {
            get { return readyUI; }
        }


        public void ReadyText(bool gameStarted)
        {
            if (gameStarted)
            {
                readyUI.readyLabel.Visible = false;
                readyModel.gameStarted = true;
            }
            
        }
    }
}
