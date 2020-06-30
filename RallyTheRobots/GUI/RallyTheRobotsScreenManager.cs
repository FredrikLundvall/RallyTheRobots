using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots
{
    public class RallyTheRobotsScreenManager : ScreenManager
    {
        public RallyTheRobotsScreenManager(ContentManager contentManager) : base(contentManager) { }
        public override void Initialize()
        {
            AddScreen(new StartupScreen(_contentManager, this));
            AddScreen(new SplashScreen(_contentManager, this));
            AddScreen(new StartMenuScreen(_contentManager, this));
            AddScreen(new LoadMenuScreen(_contentManager, this));
            base.Initialize();
        }
    }
}
