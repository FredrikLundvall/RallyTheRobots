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
            StartMenuScreen startMenu = new StartMenuScreen();
            SplashScreen splash = new SplashScreen(startMenu);
            StartupScreen startup = new StartupScreen(splash);
            _screenList.Add(startup);
            _screenList.Add(splash);
            _screenList.Add(startMenu);
            _currentScreen = startup;
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
        public void ChangeScreen(Screen newScreen)
        {
            _currentScreen.LeaveScreen();
            _currentScreen = newScreen;
            _currentScreen.EnterScreen();
        }
        public void Draw(GameTime gameTime, GraphicsDevice graphicsDevice, GameSettings gameSettings, SpriteBatch spriteBatch)
        {
            _currentScreen.Draw(gameTime, graphicsDevice, gameSettings, spriteBatch);
        }
    }
}
