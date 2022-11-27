using System;
using Microsoft.Xna.Framework;
using RallyTheRobots.GUI.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots.GUI
{
    public class ApplySettingFromSliderButtonAction : Common.ButtonAction
    {
        ButtonArea _masterVolumeButton;
        ButtonArea _musicVolumeButton;
        public ApplySettingFromSliderButtonAction(ButtonArea masterVolumeButton, ButtonArea musicVolumeButton)
        {
            _masterVolumeButton = masterVolumeButton;
            _musicVolumeButton = musicVolumeButton;
        }
        public override void DoAction(ScreenManager manager, Screen screen, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            gameSettings.SetMasterVolume(_masterVolumeButton.GetCurrentHorizontalValue());
            gameSettings.SetMusicVolume(_musicVolumeButton.GetCurrentHorizontalValue());
        }
    }

}
