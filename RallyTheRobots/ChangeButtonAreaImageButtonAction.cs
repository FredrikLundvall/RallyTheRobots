using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots
{
    public class ChangeButtonAreaImageButtonAction : ButtonAction
    {
        ButtonArea _buttonArea;
        bool _isTrue;
        public ChangeButtonAreaImageButtonAction(ButtonArea buttonArea, bool isTrue)
        {
            _buttonArea = buttonArea;
            _isTrue = isTrue;
        }
        public override void DoAction(ScreenManager manager, Screen screen, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            _isTrue = !_isTrue;
            _buttonArea.ClearImages();
            _buttonArea.AddSuffixedImage("graphicsmenu_fullscreen");
            if (_isTrue)
                _buttonArea.AddSuffixedImage("true");
            else
                _buttonArea.AddSuffixedImage("false");
        }
    }
}
