using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
            returnButton.AddImage("return");
            returnButton.Position = new Vector2(83, 390);
            returnButton.SetButtonSelectAction(new ChangeScreenButtonAction(_screenManager.GetScreen<SettingsMenuScreen>()));
            returnButton.HasShortcutWithGoBackButton = true;
            AddButtonArea(returnButton);
            _fullscreenButton.AddRollingState("true");
            _fullscreenButton.AddRollingState("false");
            _fullscreenButton.AddRollingStatesAsImages();
            _fullscreenButton.SetImageToRollingState("graphicsmenu_fullscreen");
            _fullscreenButton.Position = new Vector2(83, 540);
            _fullscreenButton.SetButtonSelectAction(new SetButtonImageToNextRollingStateButtonAction(_fullscreenButton, "graphicsmenu_fullscreen"));
            AddButtonArea(_fullscreenButton);
            foreach (DisplayMode displayMode in GraphicsAdapter.DefaultAdapter.SupportedDisplayModes)
            {
                _resolutionButton.AddRollingState(string.Format("{0:D}x{1:D};", displayMode.Width, displayMode.Height));
            }
            _resolutionButton.AddRollingStatesAsCharacterImages();
            _resolutionButton.SetCharacterImageToRollingState("graphicsmenu_resolution");
            _resolutionButton.Position = new Vector2(83, 690);
            _resolutionButton.SetButtonSelectAction(new SetButtonCharacterImageToNextRollingStateButtonAction(_resolutionButton, "graphicsmenu_resolution"));
            AddButtonArea(_resolutionButton);
            ButtonArea applyButton = new ButtonArea();
            applyButton.AddImage("apply_settings");
            applyButton.Position = new Vector2(83, 840);
            applyButton.SetButtonSelectAction(new ApplySettingFromRollingStateButtonAction(_fullscreenButton, _resolutionButton));
            AddButtonArea(applyButton);
            SetFocusedButtonArea(returnButton);
            base.Initialize();
        }
        public override void EnterScreen(GameTime gameTime, GameSettings gameSettings)
        {
            _fullscreenButton.SetCurrentRollingState(gameSettings.GetFullscreen() ? "true" : "false");
            _fullscreenButton.SetImageToRollingState("graphicsmenu_fullscreen");
            
            _resolutionButton.SetCurrentRollingState(string.Format("{0:D}x{1:D};", gameSettings.GetWidth(), gameSettings.GetHeight()));
            _resolutionButton.SetCharacterImageToRollingState("graphicsmenu_resolution");
            base.EnterScreen(gameTime, gameSettings);
        }
    }
}
