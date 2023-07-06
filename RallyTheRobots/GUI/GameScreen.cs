using RallyTheRobots.GUI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots.GUI
{
    public class GameScreen : Screen
    {
        public override void Initialize()
        {
            AddBackground("ingame");
            ScreenChangeOnTimeout(_screenManager.GetScreen<BitmapMinigameScreen>(), 3.0);
            ScreenChangeOnPauseKey(_screenManager.GetScreen<PauseMenuScreen>());
            base.Initialize();
        }
    }
}
