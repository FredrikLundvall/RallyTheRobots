using Microsoft.Xna.Framework;

namespace RallyTheRobots
{
    public class SetButtonCharacterImageToPreviousRollingStateButtonAction : ButtonAction
    {
        ButtonArea _buttonArea;
        string _imageName;
        public SetButtonCharacterImageToPreviousRollingStateButtonAction(ButtonArea buttonArea, string imageName)
        {
            _buttonArea = buttonArea;
            _imageName = imageName;
        }
        public override void DoAction(ScreenManager manager, Screen screen, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            _buttonArea.PreviousRollingState();
            _buttonArea.SetCharacterImageToRollingState(_imageName);
        }
    }
}
