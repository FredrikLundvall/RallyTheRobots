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
            _screenList.Add(new StartupScreen());
            _currentScreen = _screenList[0];
        }
        public void LoadContent(GraphicsDevice graphicsDevice)
        {
            foreach(Screen screen in _screenList)
            {
                screen.LoadContent(graphicsDevice);
            }
        }
        public void Update(GameTime gameTime, GameSettings gameSettings)
        {
            _currentScreen.Update(this, gameTime, gameSettings);
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
