using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    public interface IControl
    {
        void Pause();
        void TurnLeft();
        void TurnRight();
        void TurnUp();
        void TurnDown();
        
    }
}
