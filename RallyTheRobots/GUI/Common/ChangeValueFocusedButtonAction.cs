﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots.GUI.Common
{
    public class ChangeValueFocusedButtonAction : ButtonAction
    {
        int _changeHorizontalSliderStep;
        int _changeVerticalSliderStep;
        DirectionEnum _rollingStateChange;
        public ChangeValueFocusedButtonAction(int changeHorizontalSliderStep, int changeVerticalSliderStep, DirectionEnum rollingStateChange)
        {
            _changeHorizontalSliderStep = changeHorizontalSliderStep;
            _changeVerticalSliderStep = changeVerticalSliderStep;
            _rollingStateChange = rollingStateChange;
        }
        public override void DoAction(ScreenManager manager, Screen screen, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            ButtonArea buttonArea = screen.GetSelectedOrFocusedButtonArea();
            if (buttonArea != null)
            {
                buttonArea.SetCurrentHorizontalSliderValue(buttonArea.GetCurrentHorizontalValue() + _changeHorizontalSliderStep);
                buttonArea.SetCurrentVerticalSliderValue(buttonArea.GetCurrentVerticalValue() + _changeVerticalSliderStep);
                if(_rollingStateChange == DirectionEnum.Next)
                    buttonArea.NextRollingState(gameTime, gameSettings);
                else if (_rollingStateChange == DirectionEnum.Previous)
                    buttonArea.PreviousRollingState(gameTime, gameSettings);
            }
        }
    }
}

