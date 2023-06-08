using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RallyTheRobots.GUI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots.GUI
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
            returnButton.SetButtonSelectAction(new ChangeToPreviousScreenAction());
            returnButton.HasShortcutWithGoBackButton = true;
            AddButtonArea(returnButton);
            _fullscreenButton.AddRollingState("true");
            _fullscreenButton.AddRollingState("false");
            _fullscreenButton.AddImage("graphicsmenu_fullscreen");
            _fullscreenButton.AddImage("graphicsmenu_fullscreen_true_or_false", ButtonAreaImageNameTypeEnum.RollingState);
            _fullscreenButton.Position = new Vector2(83, 540);
            _fullscreenButton.SetButtonSelectAction(new NextRollingStateButtonAction(_fullscreenButton));
            _fullscreenButton.SetButtonAlternateSelectAction(new PreviousRollingStateButtonAction(_fullscreenButton));
            AddButtonArea(_fullscreenButton);
            foreach (DisplayMode displayMode in GraphicsAdapter.DefaultAdapter.SupportedDisplayModes)
            {
                _resolutionButton.AddRollingState(string.Format("{0:D}x{1:D};", displayMode.Width, displayMode.Height));
            }
            _resolutionButton.AddImage("graphicsmenu_resolution");
            _resolutionButton.AddImage("graphicsmenu_resolution_width_x_height", ButtonAreaImageNameTypeEnum.RollingStateCharacter);
            _resolutionButton.Position = new Vector2(83, 690);
            _resolutionButton.SetButtonSelectAction(new NextRollingStateButtonAction(_resolutionButton));
            _resolutionButton.SetButtonAlternateSelectAction(new PreviousRollingStateButtonAction(_resolutionButton));
            AddButtonArea(_resolutionButton);
            ButtonArea applyButton = new ButtonArea();
            applyButton.AddImage("apply_settings");
            applyButton.Position = new Vector2(83, 840);
            applyButton.SetButtonSelectAction(new ApplySettingFromRollingStateButtonAction(_fullscreenButton, _resolutionButton));
            AddButtonArea(applyButton);
            SetFocusedButtonArea(returnButton);
            base.Initialize();
        }
        public override void EnterScreen(GameTime gameTime, GameSettings gameSettings, Screen oldScreen)
        {
            _fullscreenButton.SetCurrentRollingState(gameSettings.GetFullscreen() ? "true" : "false");

            _resolutionButton.SetCurrentRollingState(string.Format("{0:D}x{1:D};", gameSettings.GetWidth(), gameSettings.GetHeight()));
            base.EnterScreen(gameTime, gameSettings, oldScreen);
        }
    }
}
