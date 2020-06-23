using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots
{
    public class LoadMenuScreen : Screen
    {
        public LoadMenuScreen(ScreenManager screenManager) : base(screenManager) { }
        public override void Initialize()
        {
            AddBackground("Content\\loadmenu.png");
            ButtonArea returnButton = new ButtonArea();
            returnButton.SetIdleImage("Content\\loadmenu_return_idle.png");
            returnButton.SetFocusedImage("Content\\loadmenu_return_focused.png");
            returnButton.Position = new Vector2(83, 62);
            returnButton.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<StartMenuScreen>()));
            returnButton.HasShortcutWithGoBackButton = true;
            AddButtonArea(returnButton);
            ButtonArea filelistButton = new ButtonArea();
            filelistButton.SetIdleImage("Content\\loadmenu_filelist_idle.png");
            filelistButton.SetFocusedImage("Content\\loadmenu_filelist_focused.png");
            filelistButton.SetSelectedImage("Content\\loadmenu_filelist_selected.png");
            filelistButton.Position = new Vector2(83, 202);
            AddButtonArea(filelistButton);
            SetFocusedAtEnterButtonArea(returnButton);
        }
    }
}
