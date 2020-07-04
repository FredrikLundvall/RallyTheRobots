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
        protected bool isFullscreen = false;
        public override void Initialize()
        {
            //AddBackground("graphicsmenu.png");
            ButtonArea returnButton = new ButtonArea();
            returnButton.AddSuffixedImage("return");
            returnButton.Position = new Vector2(83, 270);
            returnButton.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<SettingsMenuScreen>()));
            returnButton.HasShortcutWithGoBackButton = true;
            AddButtonArea(returnButton);
            ButtonArea fullscreenButton = new ButtonArea();
            fullscreenButton.AddSuffixedImage("graphicsmenu_fullscreen");
            if(isFullscreen)
                fullscreenButton.AddSuffixedImage("true");
            else
                fullscreenButton.AddSuffixedImage("false");
            _contentManager.AddImage("true_idle.png");
            _contentManager.AddImage("true_focused.png");
            _contentManager.AddImage("false_idle.png");
            _contentManager.AddImage("false_focused.png");
            fullscreenButton.Position = new Vector2(83, 420);
            fullscreenButton.SetButtonAction(new ChangeButtonAreaImageButtonAction(fullscreenButton, isFullscreen));
            AddButtonArea(fullscreenButton);
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
            //fullscreenButton.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<SettingsMenuScreen>()));
            AddButtonArea(applyButton);
            SetFocusedButtonArea(returnButton);
            base.Initialize();
        }
    }
}
