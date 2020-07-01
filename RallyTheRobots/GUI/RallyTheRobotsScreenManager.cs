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
        public RallyTheRobotsScreenManager(ContentManager contentManager, IResolution resolution) : base(contentManager, resolution) { }
        public override void Initialize()
        {
            AddScreen(new StartupScreen(_contentManager, this, _resolution));
            AddScreen(new SplashScreen(_contentManager, this, _resolution));
            AddScreen(new StartMenuScreen(_contentManager, this, _resolution));
            AddScreen(new LoadMenuScreen(_contentManager, this, _resolution));
            base.Initialize();
        }
    }
}
