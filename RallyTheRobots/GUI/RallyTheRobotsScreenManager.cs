using ResolutionBuddy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots
{
    public class RallyTheRobotsScreenManager : ScreenManager
    {
        public override void Initialize()
        {
            AddScreen(new StartupScreen());
            AddScreen(new SplashScreen());
            AddScreen(new StartMenuScreen());
            AddScreen(new LoadMenuScreen());
            AddScreen(new GameScreen());
            base.Initialize();
        }
    }
}
