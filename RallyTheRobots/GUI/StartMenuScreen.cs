using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ResolutionBuddy;

namespace RallyTheRobots
{
    public class StartMenuScreen : Screen
    {
        public override void Initialize()
        {
            AddBackground("startmenu.png");
            ButtonArea continueGameButton = new ButtonArea();
            continueGameButton.AddIdleImage("startmenu_continue_idle.png");
            continueGameButton.AddFocusedImage("startmenu_continue_focused.png");
            continueGameButton.Position = new Vector2(83, 414);
            continueGameButton.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<GameScreen>()));
            AddButtonArea(continueGameButton);
            ButtonArea loadGameButton = new ButtonArea();
            loadGameButton.AddIdleImage("startmenu_load_idle.png");
            loadGameButton.AddFocusedImage("startmenu_load_focused.png");
            loadGameButton.Position = new Vector2(83, 519);
            loadGameButton.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<LoadMenuScreen>()));
            AddButtonArea(loadGameButton);
            ButtonArea newGameButton = new ButtonArea();
            newGameButton.AddIdleImage("startmenu_new_idle.png");
            newGameButton.AddFocusedImage("startmenu_new_focused.png");
            newGameButton.Position = new Vector2(83, 655);
            newGameButton.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<GameScreen>()));
            AddButtonArea(newGameButton);
            ButtonArea settingsButton = new ButtonArea();
            settingsButton.AddIdleImage("startmenu_settings_idle.png");
            settingsButton.AddFocusedImage("startmenu_settings_focused.png");
            settingsButton.Position = new Vector2(83, 790);
            settingsButton.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<SettingsMenuScreen>()));
            AddButtonArea(settingsButton);
            ButtonArea exitButton = new ButtonArea();
            exitButton.AddIdleImage("startmenu_exit_idle.png");
            exitButton.AddFocusedImage("startmenu_exit_focused.png");
            exitButton.Position = new Vector2(83, 905);
            exitButton.SetButtonAction(new ExitToDesktopButtonAction());
            //exitButton.HasShortcutWithGoBackButton = true;
            AddButtonArea(exitButton);
            SetFocusedButtonArea(continueGameButton);
            base.Initialize();
        }
    }
}
