using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots
{
    public class NextRollingStateButtonAction : ButtonAction
    {
        ButtonArea _buttonArea;
        bool _isRollingState2;
        public NextRollingStateButtonAction(ButtonArea buttonArea, bool isRollingState2 = false)
        {
            _buttonArea = buttonArea;
            _isRollingState2 = isRollingState2;
        }
        public override void DoAction(ScreenManager manager, Screen screen, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            if(_isRollingState2)
                _buttonArea.NextRollingState2();
            else
                _buttonArea.NextRollingState();
        }
    }
}
