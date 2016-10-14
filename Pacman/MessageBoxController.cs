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
        MessageBoxUI messageUI;

        public MessageBoxController()
        {
            messageBoxModel = new MessageBoxModel();
            messageUI = new MessageBoxUI(this);
        }

        public MessageBoxUI View
        {
            get { return messageUI; }
        }
    }
}
