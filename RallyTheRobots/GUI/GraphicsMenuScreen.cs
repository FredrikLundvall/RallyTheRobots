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
        public override void Initialize()
        {
            //AddBackground("graphicsmenu.png");
            ButtonArea returnButton = new ButtonArea();
            returnButton.AddSuffixedImage("return");
            returnButton.Position = new Vector2(83, 270);
            returnButton.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<SettingsMenuScreen>()));
            returnButton.HasShortcutWithGoBackButton = true;
            AddButtonArea(returnButton);
            _fullscreenButton.AddRollingState("true");
            _fullscreenButton.AddRollingState("false");
            _fullscreenButton.AddRollingStatesAsSuffixedImages();
            //_fullscreenButton.SetCurrentRollingState("true");
            _fullscreenButton.SetImageToRollingState("graphicsmenu_fullscreen");
            _fullscreenButton.Position = new Vector2(83, 420);
            _fullscreenButton.SetButtonAction(new SetButtonImageToRollingStateButtonAction(_fullscreenButton, "graphicsmenu_fullscreen"));
            AddButtonArea(_fullscreenButton);
            ButtonArea resolutionButton = new ButtonArea();
            resolutionButton.AddSuffixedImage("graphicsmenu_resolution");
            resolutionButton.AddSuffixedImage("1");
            resolutionButton.AddSuffixedImage("9");
            resolutionButton.AddSuffixedImage("2");
            resolutionButton.AddSuffixedImage("0");
            resolutionButton.AddSuffixedImage("x");
            resolutionButton.AddSuffixedImage("1");
            resolutionButton.AddSuffixedImage("0");
            resolutionButton.AddSuffixedImage("8");
            resolutionButton.AddSuffixedImage("0");
            resolutionButton.AddSuffixedImage(";");
            resolutionButton.Position = new Vector2(83, 570);
            //fullscreenButton.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<SettingsMenuScreen>()));
            AddButtonArea(resolutionButton);
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
