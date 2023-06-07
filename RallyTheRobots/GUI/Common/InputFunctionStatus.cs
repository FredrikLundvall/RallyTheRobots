using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots.GUI
{
    public struct InputFunctionStatus
    {
        public bool ButtonIsHeldDown;
        public TimeSpan ButtonIsHeldDownAtElapsedTime;

        public InputFunctionStatus(bool buttonIsHeldDown, TimeSpan buttonIsHeldDownAtElapsedTime)
        {
            ButtonIsHeldDown = buttonIsHeldDown;
            ButtonIsHeldDownAtElapsedTime = buttonIsHeldDownAtElapsedTime;
        }
    }
}
