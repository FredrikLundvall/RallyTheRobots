using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots
{
    public class SetButtonCharacterImageToRollingStateButtonAction : ButtonAction
    {
        ButtonArea _buttonArea;
        string _imageName;
        public SetButtonCharacterImageToRollingStateButtonAction(ButtonArea buttonArea, string imageName)
        {
            _buttonArea = buttonArea;
            _imageName = imageName;
        }
        public override void DoAction(ScreenManager manager, Screen screen, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            _buttonArea.NextRollingState();
            _buttonArea.SetCharacterImageToRollingState(_imageName);
        }
    }
}
