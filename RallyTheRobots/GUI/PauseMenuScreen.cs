using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RallyTheRobots.GUI.Common;


namespace RallyTheRobots.GUI
{
    public class PauseMenuScreen : Screen
    {
        public override void Initialize()
        {
            AddBackground("pausemenu");
            ButtonArea continueGameButton = new ButtonArea();
            continueGameButton.AddImage("pausemenu_continue");
            continueGameButton.Position = new Vector2(83, 250);
            continueGameButton.SetButtonSelectAction(new ChangeToPreviousScreenAction());
            //continueGameButton.SetButtonSelectAction(new ChangeScreenButtonAction(_screenManager.GetScreen<GameScreen>()));
            AddButtonArea(continueGameButton);
            ButtonArea settingsButton = new ButtonArea();
            settingsButton.AddImage("pausemenu_settings");
            settingsButton.Position = new Vector2(83, 350);
            settingsButton.SetButtonSelectAction(new ChangeScreenButtonAction(_screenManager.GetScreen<SettingsMenuScreen>()));
            AddButtonArea(settingsButton);
            ButtonArea saveGameButton = new ButtonArea();
            saveGameButton.AddImage("pausemenu_save");
            saveGameButton.Position = new Vector2(83, 450);
            saveGameButton.SetButtonSelectAction(new ChangeScreenButtonAction(_screenManager.GetScreen<LoadMenuScreen>()));
            AddButtonArea(saveGameButton);
            ButtonArea loadGameButton = new ButtonArea();
            loadGameButton.AddImage("pausemenu_load");
            loadGameButton.Position = new Vector2(83,550);
            loadGameButton.SetButtonSelectAction(new ChangeScreenButtonAction(_screenManager.GetScreen<LoadMenuScreen>()));
            AddButtonArea(loadGameButton);
            ButtonArea exitButtonMain = new ButtonArea();
            exitButtonMain.AddImage("pausemenu_exit_main");
            exitButtonMain.Position = new Vector2(83, 650);
            exitButtonMain.SetButtonSelectAction(new ChangeScreenButtonAction(_screenManager.GetScreen<StartMenuScreen>()));
            AddButtonArea(exitButtonMain);
            ButtonArea exitButtonDesktop = new ButtonArea();
            exitButtonDesktop.AddImage("pausemenu_exit_desktop");
            exitButtonDesktop.Position = new Vector2(83, 750);
            exitButtonDesktop.SetButtonSelectAction(new ExitToDesktopButtonAction());
            AddButtonArea(exitButtonDesktop);
            SetFocusedButtonArea(continueGameButton);
            base.Initialize();
        }
    }
}
