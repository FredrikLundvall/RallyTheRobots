using Microsoft.Xna.Framework;

namespace RallyTheRobots.GUI.Common
{
    public class PreviousRollingStateButtonAction : ButtonAction
    {
        ButtonArea _buttonArea;
        public PreviousRollingStateButtonAction(ButtonArea buttonArea)
        {
            _buttonArea = buttonArea;
        }
        public override void DoAction(ScreenManager manager, Screen screen, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            _buttonArea.PreviousRollingState();
        }
    }
}
