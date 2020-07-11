using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots
{
    public class FocusNextButtonAreaButtonAction : ButtonAction
    {
        //Screen _screen;
        //public FocusNextButtonAreaButtonAction(Screen screen)
        //{
        //    _screen = screen;
        //}
        public override void DoAction(ScreenManager manager, Screen screen, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            screen.FocusNextButtonArea(gameTime);
        }
    }
}
