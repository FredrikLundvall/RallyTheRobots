using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace RallyTheRobots
{
    public class StartupScreen : Screen
    {
        public StartupScreen(ScreenManager screenManager) : base(screenManager) { }
        public override void Initialize()
        {
            AddBackground("Content\\startup.png");
            ScreenChangeOnTimeout(_screenManager.GetScreen<SplashScreen>(), 1.0);
        }
    }
}
