using Microsoft.Xna.Framework;

namespace RallyTheRobots
{
    public class SettingsMenuScreen : Screen
    {
        public override void Initialize()
        {
            AddBackground("settingsmenu.png");
            ButtonArea returnButton = new ButtonArea();
            returnButton.AddIdleImage("loadmenu_return_idle.png");
            returnButton.AddFocusedImage("loadmenu_return_focused.png");
            returnButton.Position = new Vector2(83, 390);
            returnButton.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<StartMenuScreen>()));
            returnButton.HasShortcutWithGoBackButton = true;
            AddButtonArea(returnButton);
            ButtonArea graphicsMenuButton = new ButtonArea();
            graphicsMenuButton.AddIdleImage("settingsmenu_graphics_idle.png");
            graphicsMenuButton.AddFocusedImage("settingsmenu_graphics_focused.png");
            graphicsMenuButton.Position = new Vector2(83, 550);
            graphicsMenuButton.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<GraphicsMenuScreen>()));
            AddButtonArea(graphicsMenuButton);
            ButtonArea soundMenuButton = new ButtonArea();
            soundMenuButton.AddIdleImage("settingsmenu_sound_idle.png");
            soundMenuButton.AddFocusedImage("settingsmenu_sound_focused.png");
            soundMenuButton.Position = new Vector2(83, 720);
            soundMenuButton.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<SoundMenuScreen>()));
            AddButtonArea(soundMenuButton);
            ButtonArea controlsMenuButton = new ButtonArea();
            controlsMenuButton.AddIdleImage("settingsmenu_controls_idle.png");
            controlsMenuButton.AddFocusedImage("settingsmenu_controls_focused.png");
            controlsMenuButton.Position = new Vector2(83, 870);
            controlsMenuButton.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<ControlsMenuScreen>()));
            AddButtonArea(controlsMenuButton);
            SetFocusedButtonArea(returnButton);
            base.Initialize();
        }
    }
}
