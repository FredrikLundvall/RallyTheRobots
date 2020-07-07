using Microsoft.Xna.Framework;

namespace RallyTheRobots
{
    public class SettingsMenuScreen : Screen
    {
        public override void Initialize()
        {
            //AddBackground("settingsmenu");
            ButtonArea returnButton = new ButtonArea();
            returnButton.AddSuffixedImage("return");
            returnButton.Position = new Vector2(83, 390);
            returnButton.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<StartMenuScreen>()));
            returnButton.HasShortcutWithGoBackButton = true;
            AddButtonArea(returnButton);
            ButtonArea graphicsMenuButton = new ButtonArea();
            graphicsMenuButton.AddSuffixedImage("settingsmenu_graphics");
            graphicsMenuButton.Position = new Vector2(83, 540);
            graphicsMenuButton.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<GraphicsMenuScreen>()));
            AddButtonArea(graphicsMenuButton);
            ButtonArea soundMenuButton = new ButtonArea();
            soundMenuButton.AddSuffixedImage("settingsmenu_sound");
            soundMenuButton.Position = new Vector2(83, 690);
            soundMenuButton.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<SoundMenuScreen>()));
            AddButtonArea(soundMenuButton);
            ButtonArea controlsMenuButton = new ButtonArea();
            controlsMenuButton.AddSuffixedImage("settingsmenu_controls");
            controlsMenuButton.Position = new Vector2(83, 840);
            controlsMenuButton.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<ControlsMenuScreen>()));
            AddButtonArea(controlsMenuButton);
            SetFocusedButtonArea(returnButton);
            base.Initialize();
        }
    }
}
