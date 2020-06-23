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
        public bool ButtonForSelectIsHeldDown = false;
        public ScreenManager()
        {
            _screenList.Add(new StartupScreen(this));
            _screenList.Add(new SplashScreen(this));
            _screenList.Add(new StartMenuScreen(this));
            _screenList.Add(new LoadMenuScreen(this));
            InitializeScreens();
            //Setup the starting screen
            _currentScreen = _screenList[0];
            _currentScreen.EnterScreen(new GameTime());
        }
        public void InitializeScreens()
        {
            foreach (Screen screen in _screenList)
            {
                screen.Initialize();
            }
        }
        public Screen GetScreen<T>() where T : Screen
        {
            foreach (Screen screen in _screenList)
            {
                if(screen is T)
                    return screen;
            }
            return null;
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
