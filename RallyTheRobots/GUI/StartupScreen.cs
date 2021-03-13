using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RallyTheRobots.GUI.Common;

namespace RallyTheRobots.GUI
{
    public class StartupScreen : Screen
    {
        public override void Initialize()
        {
            AddBackground("startup");
            ScreenChangeOnTimeout(_screenManager.GetScreen<SplashScreen>(), 3.0);
            base.Initialize();
        }
    }
}
