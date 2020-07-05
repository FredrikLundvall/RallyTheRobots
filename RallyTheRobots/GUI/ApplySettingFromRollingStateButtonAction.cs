using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots
{
    public class ApplySettingFromRollingStateButtonAction : ButtonAction
    {
        ButtonArea _fullscreenButtonArea;
        public ApplySettingFromRollingStateButtonAction(ButtonArea fullscreenButtonArea)
        {
            _fullscreenButtonArea = fullscreenButtonArea;
        }
        public override void DoAction(ScreenManager manager, Screen screen, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            gameSettings.SetFullscreen(_fullscreenButtonArea.GetCurrentRollingState() == "true");
        }
    }
}
