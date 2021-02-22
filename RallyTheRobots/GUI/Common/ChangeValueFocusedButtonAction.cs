using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots.GUI.Common
{
    public class ChangeValueFocusedButtonAction : ButtonAction
    {
        int _changeHorizontalStep;
        int _changeVerticalStep;
        public ChangeValueFocusedButtonAction(int changeHorizontalStep, int changeVerticalStep)
        {
            _changeHorizontalStep = changeHorizontalStep;
            _changeVerticalStep = changeVerticalStep;
        }
        public override void DoAction(ScreenManager manager, Screen screen, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            ButtonArea buttonArea = screen.GetSelectedOrFocusedButtonArea();
            if (buttonArea != null)
            {
                buttonArea.SetCurrentHorizontalValue(buttonArea.GetCurrentHorizontalValue() + _changeHorizontalStep);
                buttonArea.SetCurrentVerticalValue(buttonArea.GetCurrentVerticalValue() + _changeVerticalStep);
            }
        }
    }
}
