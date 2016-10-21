using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class MessageBoxController
    {
        MessageBoxModel messageBoxModel;
        MessageBoxUI messageBoxUI;

        public MessageBoxController()
        {
            messageBoxModel = new MessageBoxModel();
            messageBoxUI = new MessageBoxUI(this);
        }

        public MessageBoxUI View
        {
            get { return messageBoxUI; }
        }


        public void notify(bool startBtnClicked, bool isDead)
        {
            // update message from model
            if(startBtnClicked)
            {
                this.messageBoxModel.Message = "READY?";
            }
            else if(isDead)
            {
                this.messageBoxModel.Message = "GAME OVER";
            }

            //update message in view
            this.messageBoxUI.updateText(messageBoxModel.Message);
        }
    }
}
