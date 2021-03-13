using RallyTheRobots.GUI.Common;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TestRallyTheRobots
{
    public class InputConnectorMock : InputConnector
    {
        public MouseState ManipulateMouseState = new MouseState();
        public KeyboardState ManipulateKeyboardState = new KeyboardState();
        public GamePadState[] ManipulateGamePadState = {new GamePadState(), new GamePadState(), new GamePadState(), new GamePadState()};

        public override MouseState GetMouseState()
        {
            return ManipulateMouseState;
        }
        public override KeyboardState GetKeyboardState()
        {
            return ManipulateKeyboardState;
        }
        public override GamePadState GetGamePadState(PlayerIndex playerIndex)
        {
            return ManipulateGamePadState[(int)playerIndex];
        }
    }
}
