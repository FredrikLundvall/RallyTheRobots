using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots.GUI
{
    public struct InputButtonStatus
    {
        public bool ButtonIsHeldDown;
        public TimeSpan ButtonIsHeldDownAtElapsedTime;

        public InputButtonStatus(bool buttonIsHeldDown, TimeSpan buttonIsHeldDownAtElapsedTime)
        {
            ButtonIsHeldDown = buttonIsHeldDown;
            ButtonIsHeldDownAtElapsedTime = buttonIsHeldDownAtElapsedTime;
        }
    }
}
