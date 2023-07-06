using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots.GUI.Common
{
    public class NextRollingStateButtonAction : ButtonAction
    {
        ButtonArea _buttonArea;
        public NextRollingStateButtonAction(ButtonArea buttonArea)
        {
            _buttonArea = buttonArea;
        }
        public override void DoAction(ScreenManager manager, Screen screen, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            _buttonArea.NextRollingState();
        }
    }
}
