using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RallyTheRobots
{
    public class ScreenManager
    {
        private Screen _currentScreen;
        private List<Screen> _screenList= new List<Screen>(20);
        public ScreenManager()
        {
            Screen startup = new Screen();
            Screen splash = new Screen();
            StartMenuScreen startMenu = new StartMenuScreen();
            _screenList.Add(startup);
            _screenList.Add(splash);
            _screenList.Add(startMenu);
            //Startup
            startup.AddBackground("Content\\startup.png");
            startup.ScreenChangeOnTimeout(splash, 1.0);
            //Splash
            splash.AddBackground("Content\\splash.png");
            splash.ScreenChangeOnTimeout(startMenu, 3.0);
            splash.ScreenChangeOnAnyButton(startMenu);
            //Startmenu
            startMenu.AddBackground("Content\\startmenu.png");
            ButtonArea settingsButton = new ButtonArea();
            settingsButton.SetIdleImage("Content\\startmenu_settings_idle.png");
            settingsButton.SetFocusedImage("Content\\startmenu_settings_focused.png");
            settingsButton.Position = new Vector2(83, 790);
            startMenu.AddButtonArea(settingsButton);
            ButtonArea exitButton = new ButtonArea();
            exitButton.SetIdleImage("Content\\startmenu_exit_idle.png");
            exitButton.SetFocusedImage("Content\\startmenu_exit_focused.png");
            exitButton.Position = new Vector2(83, 905);
            startMenu.AddButtonArea(exitButton);
            startMenu.SetFocusedButtonArea(settingsButton);
            //Setup the starting screen
            _currentScreen = startup;
            _currentScreen.EnterScreen(new GameTime());
        }
        public void LoadContent(GraphicsDevice graphicsDevice)
        {
            foreach(Screen screen in _screenList)
            {
                screen.LoadContent(graphicsDevice);
            }
        }
        public void Update(GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            _currentScreen.Update(this, gameTime, gameSettings, gameStatus);
        }
        public void ChangeScreen(GameTime gameTime, Screen newScreen)
        {
            _currentScreen.LeaveScreen();
            _currentScreen = newScreen;
            _currentScreen.EnterScreen(gameTime);
        }
        public void Draw(GameTime gameTime, GraphicsDevice graphicsDevice, GameSettings gameSettings, SpriteBatch spriteBatch)
        {
            _currentScreen.Draw(gameTime, graphicsDevice, gameSettings, spriteBatch);
        }
    }
}
