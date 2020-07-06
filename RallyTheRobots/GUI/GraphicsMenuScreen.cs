using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots
{
    public class GraphicsMenuScreen : Screen
    {
        protected ButtonArea _fullscreenButton = new ButtonArea();
        protected ButtonArea _resolutionButton = new ButtonArea();
        public override void Initialize()
        {
            //AddBackground("graphicsmenu");
            ButtonArea returnButton = new ButtonArea();
            returnButton.AddSuffixedImage("return");
            returnButton.Position = new Vector2(83, 270);
            returnButton.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<SettingsMenuScreen>()));
            returnButton.HasShortcutWithGoBackButton = true;
            AddButtonArea(returnButton);
            _fullscreenButton.AddRollingState("true");
            _fullscreenButton.AddRollingState("false");
            _fullscreenButton.AddRollingStatesAsSuffixedImages();
            _fullscreenButton.SetImageToRollingState("graphicsmenu_fullscreen");
            _fullscreenButton.Position = new Vector2(83, 420);
            _fullscreenButton.SetButtonAction(new SetButtonImageToRollingStateButtonAction(_fullscreenButton, "graphicsmenu_fullscreen"));
            AddButtonArea(_fullscreenButton);
            _resolutionButton.AddSuffixedImage("graphicsmenu_resolution");
            _resolutionButton.AddSuffixedImage("1");
            _resolutionButton.AddSuffixedImage("9");
            _resolutionButton.AddSuffixedImage("2");
            _resolutionButton.AddSuffixedImage("0");
            _resolutionButton.AddSuffixedImage("x");
            _resolutionButton.AddSuffixedImage("1");
            _resolutionButton.AddSuffixedImage("0");
            _resolutionButton.AddSuffixedImage("8");
            _resolutionButton.AddSuffixedImage("0");
            _resolutionButton.AddSuffixedImage(";");
            _resolutionButton.Position = new Vector2(83, 570);
            //fullscreenButton.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<SettingsMenuScreen>()));
            AddButtonArea(_resolutionButton);
            ButtonArea applyButton = new ButtonArea();
            applyButton.AddSuffixedImage("apply_settings");
            applyButton.Position = new Vector2(83, 720);
            applyButton.SetButtonAction(new ApplySettingFromRollingStateButtonAction(_fullscreenButton));
            AddButtonArea(applyButton);
            SetFocusedButtonArea(returnButton);
            base.Initialize();
        }
        public override void EnterScreen(GameTime gameTime, GameSettings gameSettings)
        {
            if (gameSettings.GetFullscreen())
                _fullscreenButton.SetCurrentRollingState("true");
            else
                _fullscreenButton.SetCurrentRollingState("false");
            _fullscreenButton.SetImageToRollingState("graphicsmenu_fullscreen");
            base.EnterScreen(gameTime, gameSettings);
        }
    }
}
