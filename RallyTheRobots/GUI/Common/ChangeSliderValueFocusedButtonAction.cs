using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots.GUI.Common
{
    public class ChangeSliderValueFocusedButtonAction : ButtonAction
    {
        int _changeHorizontalSliderStep;
        int _changeVerticalSliderStep;
        public ChangeSliderValueFocusedButtonAction(int changeHorizontalSliderStep, int changeVerticalSliderStep)
        {
            _changeHorizontalSliderStep = changeHorizontalSliderStep;
            _changeVerticalSliderStep = changeVerticalSliderStep;
        }
        public override void DoAction(ScreenManager manager, Screen screen, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            ButtonArea buttonArea = screen.GetSelectedOrFocusedButtonArea();
            if (buttonArea != null)
            {
                buttonArea.SetCurrentHorizontalSliderValue(buttonArea.GetCurrentHorizontalValue() + _changeHorizontalSliderStep);
                buttonArea.SetCurrentVerticalSliderValue(buttonArea.GetCurrentVerticalValue() + _changeVerticalSliderStep);
            }
        }
    }
}
