﻿using RallyTheRobots.GUI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots.GUI
{
    public class BitmapMinigameScreen : Screen
    {
        public override void Initialize()
        {
            AddBackground("bitmap_minigame");
            ScreenChangeOnPauseKey(_screenManager.GetScreen<PauseMenuScreen>());
            base.Initialize();
        }
    }
}

