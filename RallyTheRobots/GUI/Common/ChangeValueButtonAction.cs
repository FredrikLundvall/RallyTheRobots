using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots.GUI.Common
{
    public class ChangeValueButtonAction : ButtonAction
    {
        ButtonArea _buttonArea;
        int _changeHorizontalStep;
        int _changeVerticalStep;

        public ChangeValueButtonAction(ButtonArea buttonArea, int changeHorizontalStep, int changeVerticalStep)
        {
            _buttonArea = buttonArea;
            _changeHorizontalStep = changeHorizontalStep;
            _changeVerticalStep = changeVerticalStep;
        }
        public override void DoAction(ScreenManager manager, Screen screen, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            _buttonArea.SetCurrentHorizontalValue(_buttonArea.GetCurrentHorizontalValue() + _changeHorizontalStep);
            _buttonArea.SetCurrentVerticalValue(_buttonArea.GetCurrentVerticalValue() + _changeVerticalStep);
        }
    }
}