using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots
{
    public class SoundMenuScreen : Screen
    {
        public override void Initialize()
        {
            AddBackground("soundmenu.png");
            ButtonArea returnButton = new ButtonArea();
            returnButton.AddIdleImage("loadmenu_return_idle.png");
            returnButton.AddFocusedImage("loadmenu_return_focused.png");
            returnButton.Position = new Vector2(83, 390);
            returnButton.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<SettingsMenuScreen>()));
            returnButton.HasShortcutWithGoBackButton = true;
            AddButtonArea(returnButton);
            base.Initialize();
        }
    }
}
