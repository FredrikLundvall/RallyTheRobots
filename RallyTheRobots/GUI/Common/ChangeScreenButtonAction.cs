using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots.GUI.Common
{
    public class ChangeScreenButtonAction : ButtonAction
    {
        Screen _newScreen;
        public ChangeScreenButtonAction(Screen newScreen)
        {
            _newScreen = newScreen;
        }
        public override void DoAction(ScreenManager manager, Screen screen, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            manager.ChangeScreen(gameTime, gameSettings, _newScreen);
            var effect = manager.GetContentManager().GetSoundEffect("click");
            if (effect != null)
                effect.Play();
        }
    }
}
