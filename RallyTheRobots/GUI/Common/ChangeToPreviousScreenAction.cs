using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots.GUI.Common
{
    internal class ChangeToPreviousScreenAction: ButtonAction
    {
        public override void DoAction(ScreenManager manager, Screen screen, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            manager.ChangeToPreviousScreen(gameTime, gameSettings, screen);
        }            
    }
}
