using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots
{
    public class LoadMenuScreen : Screen
    {
        public LoadMenuScreen(ScreenManager screenManager) : base(screenManager) { }
        public override void Initialize()
        {
            AddBackground("Content\\loadmenu.png");
            ScreenChangeOnAnyButton(_screenManager.GetScreen<StartMenuScreen>());
        }
    }
}
