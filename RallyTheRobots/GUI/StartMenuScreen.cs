using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RallyTheRobots
{
    public class StartMenuScreen : Screen
    {
        public StartMenuScreen(ContentManager contentManager, ScreenManager screenManager) : base(contentManager, screenManager) { }
        public override void Initialize()
        {
            AddBackground("startmenu.png");
            ButtonArea continueGameButton = new ButtonArea(_contentManager);
            continueGameButton.SetIdleImage("startmenu_continue_idle.png");
            continueGameButton.SetFocusedImage("startmenu_continue_focused.png");
            continueGameButton.Position = new Vector2(83, 414);
            AddButtonArea(continueGameButton);
            ButtonArea loadGameButton = new ButtonArea(_contentManager);
            loadGameButton.SetIdleImage("startmenu_load_idle.png");
            loadGameButton.SetFocusedImage("startmenu_load_focused.png");
            loadGameButton.Position = new Vector2(83, 519);
            loadGameButton.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<LoadMenuScreen>()));
            AddButtonArea(loadGameButton);
            ButtonArea newGameButton = new ButtonArea(_contentManager);
            newGameButton.SetIdleImage("startmenu_new_idle.png");
            newGameButton.SetFocusedImage("startmenu_new_focused.png");
            newGameButton.Position = new Vector2(83, 655);
            AddButtonArea(newGameButton);
            ButtonArea settingsButton = new ButtonArea(_contentManager);
            settingsButton.SetIdleImage("startmenu_settings_idle.png");
            settingsButton.SetFocusedImage("startmenu_settings_focused.png");
            settingsButton.Position = new Vector2(83, 790);
            AddButtonArea(settingsButton);
            ButtonArea exitButton = new ButtonArea(_contentManager);
            exitButton.SetIdleImage("startmenu_exit_idle.png");
            exitButton.SetFocusedImage("startmenu_exit_focused.png");
            exitButton.Position = new Vector2(83, 905);
            exitButton.SetButtonAction(new ExitToDesktopButtonAction());
            exitButton.HasShortcutWithGoBackButton = true;
            AddButtonArea(exitButton);
            SetFocusedButtonArea(continueGameButton);
            base.Initialize();
        }
        public override void Update(ScreenManager manager, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            base.Update(manager, gameTime, gameSettings, gameStatus);
        }
    }
}
