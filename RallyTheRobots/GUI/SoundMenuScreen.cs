using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots
{
    public class SoundMenuScreen : Screen
    {
        protected ButtonArea _masterVolumeButton = new ButtonArea();
        public override void Initialize()
        {
            //AddBackground("soundmenu");
            ButtonArea returnButton = new ButtonArea();
            returnButton.AddSuffixedImage("return");
            returnButton.Position = new Vector2(83, 390);
            returnButton.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<SettingsMenuScreen>()));
            returnButton.HasShortcutWithGoBackButton = true;
            AddButtonArea(returnButton);
            for(int i = 0; i <= 100; i++)
            {
                _masterVolumeButton.AddRollingState(string.Format("{0:D};", i));
            }
            _masterVolumeButton.AddRollingStatesAsSuffixedCharacterImages();
            _masterVolumeButton.SetCharacterImageToRollingState("soundmenu_mastervolume");
            _masterVolumeButton.Position = new Vector2(83, 540);
            _masterVolumeButton.SetButtonAction(new SetButtonCharacterImageToRollingStateButtonAction(_masterVolumeButton, "soundmenu_mastervolume"));
            AddButtonArea(_masterVolumeButton);
            ButtonArea musicVolumeButton = new ButtonArea();
            musicVolumeButton.AddSuffixedImage("soundmenu_musicvolume");
            musicVolumeButton.AddSuffixedImage("slider");
            musicVolumeButton.Position = new Vector2(83, 690);
            //musicVolumeButton.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<SettingsMenuScreen>()));
            AddButtonArea(musicVolumeButton);
            ButtonArea applyButton = new ButtonArea();
            applyButton.AddSuffixedImage("apply_settings");
            applyButton.Position = new Vector2(83, 840);
            //applyButton.SetButtonAction(new ApplySettingFromRollingStateButtonAction(_fullscreenButton, _resolutionButton));
            AddButtonArea(applyButton);
            SetFocusedButtonArea(returnButton);
            base.Initialize();
        }
        public override void EnterScreen(GameTime gameTime, GameSettings gameSettings)
        {
            _masterVolumeButton.SetCurrentRollingState(string.Format("{0:D};", 100));
            _masterVolumeButton.SetCharacterImageToRollingState("soundmenu_mastervolume");
            base.EnterScreen(gameTime, gameSettings);
        }
    }
}
