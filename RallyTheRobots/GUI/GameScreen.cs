﻿using RallyTheRobots.GUI.Common;
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
            ScreenChangeOnTimeout(_screenManager.GetScreen<StartMenuScreen>(), 3.0);
            base.Initialize();
        }
    }
}
