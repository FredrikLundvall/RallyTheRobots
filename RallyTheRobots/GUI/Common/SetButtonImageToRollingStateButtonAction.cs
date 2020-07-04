using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots
{
    public class SetButtonImageToRollingStateButtonAction : ButtonAction
    {
        ButtonArea _buttonArea;
        string _imageName;
        public SetButtonImageToRollingStateButtonAction(ButtonArea buttonArea, string imageName)
        {
            _buttonArea = buttonArea;
            _imageName = imageName;
        }
        public override void DoAction(ScreenManager manager, Screen screen, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            _buttonArea.AdvanceRollingState();
            _buttonArea.ClearImages();
            _buttonArea.AddSuffixedImage(_imageName);
            _buttonArea.AddSuffixedImage(_buttonArea.GetCurrentRollingState());
        }
    }
}
