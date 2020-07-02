using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ResolutionBuddy;

namespace RallyTheRobots
{
    public class SplashScreen : Screen
    {
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