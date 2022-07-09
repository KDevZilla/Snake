using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    public class ControlPushButtonArgument:EventArgs 
    {
     
        private enButton _Button;
        public enButton Button
        {
            get { return _Button; }
        }
        public ControlPushButtonArgument(enButton pButton)
        {
            _Button = pButton;
        }
    }
    public delegate void PlayerPushButtonEvent(ControlPushButtonArgument arg);

    public class Controller
    {
        //public event EventHandler TestEvent;
        public void Push( enButton eButton)
        {
            
            

            if (PushEvent != null)
            {
                ControlPushButtonArgument Arg = new ControlPushButtonArgument(eButton);
                PushEvent(Arg);
            }
        }
        public event PlayerPushButtonEvent PushEvent;
    }
}
