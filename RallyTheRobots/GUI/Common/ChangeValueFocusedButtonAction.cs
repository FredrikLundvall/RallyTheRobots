using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots
{
    public class ChangeValueFocusedButtonAction : ButtonAction
    {
        int _changeStep;
        public ChangeValueFocusedButtonAction(int changeStep)
        {
            _changeStep = changeStep;
        }
        public override void DoAction(ScreenManager manager, Screen screen, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            ButtonArea buttonArea = screen.GetSelectedOrFocusedButtonArea();
            if (buttonArea != null)
                buttonArea.SetCurrentValue(buttonArea.GetCurrentValue() + _changeStep);
        }
    }
}
