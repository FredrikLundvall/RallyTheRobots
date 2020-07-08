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
            AddBackground("startmenu");
            ButtonArea continueGameButton = new ButtonArea();
            continueGameButton.AddImage("startmenu_continue");
            continueGameButton.Position = new Vector2(83, 414);
            continueGameButton.SetButtonSelectAction(new ChangeScreenButtonAction(_screenManager.GetScreen<GameScreen>()));
            AddButtonArea(continueGameButton);
            ButtonArea loadGameButton = new ButtonArea();
            loadGameButton.AddImage("startmenu_load");
            loadGameButton.Position = new Vector2(83, 519);
            loadGameButton.SetButtonSelectAction(new ChangeScreenButtonAction(_screenManager.GetScreen<LoadMenuScreen>()));
            AddButtonArea(loadGameButton);
            ButtonArea newGameButton = new ButtonArea();
            newGameButton.AddImage("startmenu_new");
            newGameButton.Position = new Vector2(83, 655);
            newGameButton.SetButtonSelectAction(new ChangeScreenButtonAction(_screenManager.GetScreen<GameScreen>()));
            AddButtonArea(newGameButton);
            ButtonArea settingsButton = new ButtonArea();
            settingsButton.AddImage("startmenu_settings");
            settingsButton.Position = new Vector2(83, 790);
            settingsButton.SetButtonSelectAction(new ChangeScreenButtonAction(_screenManager.GetScreen<SettingsMenuScreen>()));
            AddButtonArea(settingsButton);
            ButtonArea exitButton = new ButtonArea();
            exitButton.AddImage("startmenu_exit");
            exitButton.Position = new Vector2(83, 905);
            exitButton.SetButtonSelectAction(new ExitToDesktopButtonAction());
            //exitButton.HasShortcutWithGoBackButton = true;
            AddButtonArea(exitButton);
            SetFocusedButtonArea(continueGameButton);
            base.Initialize();
        }
    }
}
