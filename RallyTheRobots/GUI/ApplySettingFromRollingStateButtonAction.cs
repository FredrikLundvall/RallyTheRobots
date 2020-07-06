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
        ButtonArea _resolutionButtonArea;
        public ApplySettingFromRollingStateButtonAction(ButtonArea fullscreenButtonArea, ButtonArea resolutionButtonArea)
        {
            _fullscreenButtonArea = fullscreenButtonArea;
            _resolutionButtonArea = resolutionButtonArea;
        }
        public override void DoAction(ScreenManager manager, Screen screen, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            gameSettings.SetFullscreen(_fullscreenButtonArea.GetCurrentRollingState() == "true");
            string resolutionString = _resolutionButtonArea.GetCurrentRollingState();
            resolutionString = resolutionString.Remove(resolutionString.Length - 1);
            int splitPos = resolutionString.IndexOf('x');
            int.TryParse(resolutionString.Substring(0, Math.Max(splitPos, 0)), out int width);
            int.TryParse(resolutionString.Substring(Math.Max(splitPos, 0) + 1), out int height);
            gameSettings.SetWidth(width);
            gameSettings.SetHeight(height);
        }
    }
}
