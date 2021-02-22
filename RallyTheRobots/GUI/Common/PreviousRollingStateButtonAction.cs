using Microsoft.Xna.Framework;

namespace RallyTheRobots.GUI.Common
{
    public class PreviousRollingStateButtonAction : ButtonAction
    {
        ButtonArea _buttonArea;
        bool _isRollingState2;
        public PreviousRollingStateButtonAction(ButtonArea buttonArea, bool isRollingState2 = false)
        {
            _buttonArea = buttonArea;
            _isRollingState2 = isRollingState2;
        }
        public override void DoAction(ScreenManager manager, Screen screen, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            if (_isRollingState2)
                _buttonArea.PreviousRollingState2();
            else
                _buttonArea.PreviousRollingState2();
        }
    }
}
