using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RallyTheRobots
{
    public class ScreenManager
    {
        private ScreenEnum _screen = ScreenEnum.StartupScreen;
        public GameSettings Settings = new GameSettings();
        private Dictionary<ScreenEnum, Screen> _screenList= new Dictionary<ScreenEnum, Screen>(20);
        public ScreenManager()
        {
            _screenList.Add(ScreenEnum.StartupScreen, new StartupScreen(ScreenEnum.StartupScreen));
        }
        private Screen getCurrentScreen()
        {
            return _screenList[_screen];
        }
        public void Update(GameTime gameTime, GameSettings gameSettings)
        {
            ScreenEnum possiblyNewScreen = getCurrentScreen().Update(gameTime,gameSettings);
            if (possiblyNewScreen != _screen)
            {
                getCurrentScreen().LeaveScreen();
                _screen = possiblyNewScreen;
                getCurrentScreen().EnterScreen();
            }
        }
        public void Draw(GameTime gameTime, GraphicsDevice graphicsDevice, GameSettings gameSettings)
        {
            getCurrentScreen().Draw(gameTime, graphicsDevice, gameSettings);
        }
    }
}
