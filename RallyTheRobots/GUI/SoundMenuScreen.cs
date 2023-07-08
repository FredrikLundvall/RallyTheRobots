using Microsoft.Xna.Framework;
using RallyTheRobots.GUI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots.GUI
{
    public class SoundMenuScreen : Screen
    {
        protected ButtonArea _masterVolumeButton = new ButtonArea();
        protected ButtonArea _musicVolumeButton = new ButtonArea();
        public override void Initialize()
        {
            //AddBackground("soundmenu");
            ButtonArea returnButton = new ButtonArea();
            returnButton.AddImage("return");
            returnButton.Position = new Vector2(83, 390);
            returnButton.SetButtonSelectAction(new ChangeToPreviousScreenAction());
            returnButton.HasShortcutWithGoBackButton = true;
            AddButtonArea(returnButton);

            _masterVolumeButton.AddImage("soundmenu_mastervolume");
            _masterVolumeButton.AddImage("slider_bar", ButtonAreaImageNameTypeEnum.Actual, ButtonAreaImagePositioningEnum.ValueHorizontalSlider, ButtonAreaImageStackDirectionEnum.None);
            _masterVolumeButton.AddImage("slider");
            _masterVolumeButton.AddImage(";", ButtonAreaImageNameTypeEnum.Character);
            _masterVolumeButton.Position = new Vector2(83, 540);
            _masterVolumeButton.SliderBorderLeft = 24;
            _masterVolumeButton.SliderBorderRight = 24;

            //_masterVolumeButton.SetButtonSelectAction(new ChangeValueButtonAction(_masterVolumeButton, 1, 0));
            //_masterVolumeButton.SetButtonAlternateSelectAction(new ChangeValueButtonAction(_masterVolumeButton, -1, 0));
            AddButtonArea(_masterVolumeButton);
            _musicVolumeButton.AddImage("soundmenu_musicvolume");
            _musicVolumeButton.AddImage("slider_bar", ButtonAreaImageNameTypeEnum.Actual, ButtonAreaImagePositioningEnum.ValueHorizontalSlider, ButtonAreaImageStackDirectionEnum.None);
            _musicVolumeButton.AddImage("slider");
            _musicVolumeButton.AddImage(";", ButtonAreaImageNameTypeEnum.Character);
            _musicVolumeButton.Position = new Vector2(83, 690);
            _musicVolumeButton.SliderBorderLeft = 24;
            _musicVolumeButton.SliderBorderRight = 24;
            //_musicVolumeButton.SetButtonSelectAction(new ChangeValueButtonAction(_musicVolumeButton, 1, 0));
            //_musicVolumeButton.SetButtonAlternateSelectAction(new ChangeValueButtonAction(_musicVolumeButton, -1, 0));
            AddButtonArea(_musicVolumeButton);

            ButtonArea applyButton = new ButtonArea();
            applyButton.AddImage("apply_settings");
            applyButton.Position = new Vector2(83, 840);
            applyButton.SetButtonSelectAction(new ApplySettingFromSliderButtonAction(_masterVolumeButton, _musicVolumeButton));
            AddButtonArea(applyButton);
            SetFocusedButtonArea(returnButton);
            base.Initialize();
        }
        public override void EnterScreen(GameTime gameTime, GameSettings gameSettings, Screen oldScreen)
        {       
            _masterVolumeButton.SetCurrentHorizontalValue(gameSettings.GetMasterVolume());
            _musicVolumeButton.SetCurrentHorizontalValue(gameSettings.GetMusicVolume());
            base.EnterScreen(gameTime, gameSettings, oldScreen);
        }
    }
}
