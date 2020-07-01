using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ResolutionBuddy;
using System.IO;

namespace RallyTheRobots
{
    public class StartupScreen : Screen
    {
        public StartupScreen(ContentManager contentManager, ScreenManager screenManager, IResolution resolution) : base(contentManager, screenManager, resolution) { }
        public override void Initialize()
        {
            AddBackground("startup.png");
            ScreenChangeOnTimeout(_screenManager.GetScreen<SplashScreen>(), 1.0);
            base.Initialize();
        }
    }
}
