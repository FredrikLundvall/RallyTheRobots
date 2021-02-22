using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots.GUI.Common
{
    class InputConnector
    {
        public static MouseState GetMouseState()
        {
            return Mouse.GetState();
        }
        public static KeyboardState GetKeyboardState()
        {
            return Keyboard.GetState();
        }
        public static GamePadState GetGamePadState(PlayerIndex playerIndex)
        {
            return GamePad.GetState(playerIndex);
        }
    }
}
