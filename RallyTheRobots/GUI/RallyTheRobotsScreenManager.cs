using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots
{
    public class RallyTheRobotsScreenManager : ScreenManager
    {
        public RallyTheRobotsScreenManager(ContentManager contentManager): base(contentManager) { }
        public override void Initialize()
        {
            AddScreen(new StartupScreen(this));
            AddScreen(new SplashScreen(this));
            AddScreen(new StartMenuScreen(this));
            AddScreen(new LoadMenuScreen(this));
            base.Initialize();
        }
    }
}
