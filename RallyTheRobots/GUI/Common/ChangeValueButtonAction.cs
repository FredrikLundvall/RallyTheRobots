using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots
{
    public class ChangeValueButtonAction : ButtonAction
    {
        ButtonArea _buttonArea;
        int _changeStep;
        public ChangeValueButtonAction(ButtonArea buttonArea, int changeStep)
        {
            _buttonArea = buttonArea;
            _changeStep = changeStep;
        }
        public override void DoAction(ScreenManager manager, Screen screen, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            _buttonArea.SetCurrentValue(_buttonArea.GetCurrentValue() + _changeStep);
        }
    }
}