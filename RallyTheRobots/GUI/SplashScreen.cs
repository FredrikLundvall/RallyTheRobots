using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RallyTheRobots
{
    public class SplashScreen : Screen
    {
        public SplashScreen(ContentManager contentManager, ScreenManager screenManager) : base(contentManager, screenManager) {}
        public override void Initialize()
        {
            AddBackground("splash.png");
            Screen startMenu = _screenManager.GetScreen<StartMenuScreen>();
            ScreenChangeOnTimeout(startMenu, 3.0);
            ScreenChangeOnAnyButton(startMenu);
            base.Initialize();
        }
    }
}