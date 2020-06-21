using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RallyTheRobots
{
    public class SplashScreen : Screen
    {
        public SplashScreen(ScreenManager screenManager) : base(screenManager) {}
        public override void Initialize()
        {
            AddBackground("Content\\splash.png");
            Screen startMenu = _screenManager.GetScreen<StartMenuScreen>();
            ScreenChangeOnTimeout(startMenu, 3.0);
            ScreenChangeOnAnyButton(startMenu);
        }
    }
}