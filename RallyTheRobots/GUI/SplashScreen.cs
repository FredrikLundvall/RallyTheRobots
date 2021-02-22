using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RallyTheRobots.GUI.Common;
using ResolutionBuddy;

namespace RallyTheRobots.GUI
{
    public class SplashScreen : Screen
    {
        public override void Initialize()
        {
            AddBackground("splash");
            Screen startMenu = _screenManager.GetScreen<StartMenuScreen>();
            ScreenChangeOnTimeout(startMenu, 3.0);
            ScreenChangeOnAnyKey(startMenu);
            base.Initialize();
        }
    }
}