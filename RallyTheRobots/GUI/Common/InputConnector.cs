﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace RallyTheRobots.GUI.Common
{
    public class InputConnector
    {
        public virtual MouseState GetMouseState()
        {
            return Mouse.GetState();
        }
        public virtual KeyboardState GetKeyboardState()
        {
            return Keyboard.GetState();
        }
        public virtual GamePadState GetGamePadState(PlayerIndex playerIndex)
        {
            return GamePad.GetState(playerIndex);
        }
    }
}
