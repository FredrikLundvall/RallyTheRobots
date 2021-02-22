using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots.GUI.Common
{
    public class ButtonAction
    {
        private static ButtonAction _emptyButtonAction = new ButtonAction();
        public virtual void DoAction(ScreenManager manager, Screen screen, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
        }
        public static ButtonAction GetEmptyButtonAction()
        {
            return _emptyButtonAction;
        }
    }
}
