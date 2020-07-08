using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots
{
    public class SetButtonImageToPreviousRollingStateButtonAction : ButtonAction
    {
        ButtonArea _buttonArea;
        string _imageName;
        public SetButtonImageToPreviousRollingStateButtonAction(ButtonArea buttonArea, string imageName)
        {
            _buttonArea = buttonArea;
            _imageName = imageName;
        }
        public override void DoAction(ScreenManager manager, Screen screen, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            _buttonArea.PreviousRollingState();
            _buttonArea.SetImageToRollingState(_imageName);
        }
    }
}

