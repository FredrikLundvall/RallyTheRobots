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
            continueGameButton.AddSuffixedImage("startmenu_continue");
            continueGameButton.Position = new Vector2(83, 414);
            continueGameButton.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<GameScreen>()));
            AddButtonArea(continueGameButton);
            ButtonArea loadGameButton = new ButtonArea();
            loadGameButton.AddSuffixedImage("startmenu_load");
            loadGameButton.Position = new Vector2(83, 519);
            loadGameButton.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<LoadMenuScreen>()));
            AddButtonArea(loadGameButton);
            ButtonArea newGameButton = new ButtonArea();
            newGameButton.AddSuffixedImage("startmenu_new");
            newGameButton.Position = new Vector2(83, 655);
            newGameButton.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<GameScreen>()));
            AddButtonArea(newGameButton);
            ButtonArea settingsButton = new ButtonArea();
            settingsButton.AddSuffixedImage("startmenu_settings");
            settingsButton.Position = new Vector2(83, 790);
            settingsButton.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<SettingsMenuScreen>()));
            AddButtonArea(settingsButton);
            ButtonArea exitButton = new ButtonArea();
            exitButton.AddSuffixedImage("startmenu_exit");
            exitButton.Position = new Vector2(83, 905);
            exitButton.SetButtonAction(new ExitToDesktopButtonAction());
            //exitButton.HasShortcutWithGoBackButton = true;
            AddButtonArea(exitButton);
            SetFocusedButtonArea(continueGameButton);
            base.Initialize();
        }
    }
}
