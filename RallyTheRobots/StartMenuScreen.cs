﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RallyTheRobots
{
    public class StartMenuScreen : Screen
    {
        public StartMenuScreen(ScreenManager screenManager) : base(screenManager) { }
        public override void Initialize()
        {
            AddBackground("Content\\startmenu.png");
            ButtonArea continueGameButton = new ButtonArea();
            continueGameButton.SetIdleImage("Content\\startmenu_continue_idle.png");
            continueGameButton.SetFocusedImage("Content\\startmenu_continue_focused.png");
            continueGameButton.Position = new Vector2(83, 414);
            AddButtonArea(continueGameButton);
            ButtonArea loadGameButton = new ButtonArea();
            loadGameButton.SetIdleImage("Content\\startmenu_load_idle.png");
            loadGameButton.SetFocusedImage("Content\\startmenu_load_focused.png");
            loadGameButton.Position = new Vector2(83, 519);
            loadGameButton.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<LoadMenuScreen>()));
            AddButtonArea(loadGameButton);
            ButtonArea newGameButton = new ButtonArea();
            newGameButton.SetIdleImage("Content\\startmenu_new_idle.png");
            newGameButton.SetFocusedImage("Content\\startmenu_new_focused.png");
            newGameButton.Position = new Vector2(83, 655);
            AddButtonArea(newGameButton);
            ButtonArea settingsButton = new ButtonArea();
            settingsButton.SetIdleImage("Content\\startmenu_settings_idle.png");
            settingsButton.SetFocusedImage("Content\\startmenu_settings_focused.png");
            settingsButton.Position = new Vector2(83, 790);
            AddButtonArea(settingsButton);
            ButtonArea exitButton = new ButtonArea();
            exitButton.SetIdleImage("Content\\startmenu_exit_idle.png");
            exitButton.SetFocusedImage("Content\\startmenu_exit_focused.png");
            exitButton.Position = new Vector2(83, 905);
            exitButton.SetButtonAction(new ExitToDesktopButtonAction());
            AddButtonArea(exitButton);
            SetFocusedButtonArea(continueGameButton);
        }
        public override void Update(ScreenManager manager, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            base.Update(manager, gameTime, gameSettings, gameStatus);
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                gameStatus.RunningStatus = RunningStatusEnum.Exiting;
        }
    }
}
