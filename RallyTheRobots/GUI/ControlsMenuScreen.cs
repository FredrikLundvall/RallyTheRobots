using Microsoft.Xna.Framework;
using RallyTheRobots.GUI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots.GUI
{
    public class ControlsMenuScreen : Screen
    {
        public override void Initialize()
        {
            AddBackground("controlsmenu");
            ButtonArea returnButton = new ButtonArea();
            returnButton.AddImage("return");
            returnButton.Position = new Vector2(83, 390);
            returnButton.SetButtonSelectAction(new ChangeToPreviousScreenAction());
            returnButton.HasShortcutWithGoBackButton = true;
            AddButtonArea(returnButton);
            base.Initialize();
        }
    }
}
