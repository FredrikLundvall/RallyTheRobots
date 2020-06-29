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
            ButtonArea filelistButton1 = new ButtonArea();
            filelistButton1.SetIdleImage("Content\\loadmenu_snapshot_idle.png");
            filelistButton1.SetFocusedImage("Content\\loadmenu_snapshot_focused.png");
            filelistButton1.Position = new Vector2(83, 230);
            AddButtonArea(filelistButton1);
            ButtonArea filelistButton2 = new ButtonArea();
            filelistButton2.SetIdleImage("Content\\loadmenu_snapshot_idle.png");
            filelistButton2.SetFocusedImage("Content\\loadmenu_snapshot_focused.png");
            filelistButton2.Position = new Vector2(83, 380);
            AddButtonArea(filelistButton2);
            ButtonArea filelistButton3 = new ButtonArea();
            filelistButton3.SetIdleImage("Content\\loadmenu_snapshot_idle.png");
            filelistButton3.SetFocusedImage("Content\\loadmenu_snapshot_focused.png");
            filelistButton3.Position = new Vector2(83, 550);
            AddButtonArea(filelistButton3);
            ButtonArea filelistButton4 = new ButtonArea();
            filelistButton4.SetIdleImage("Content\\loadmenu_snapshot_idle.png");
            filelistButton4.SetFocusedImage("Content\\loadmenu_snapshot_focused.png");
            filelistButton4.Position = new Vector2(83, 710);
            AddButtonArea(filelistButton4);
            ButtonArea filelistButton5 = new ButtonArea();
            filelistButton5.SetIdleImage("Content\\loadmenu_snapshot_idle.png");
            filelistButton5.SetFocusedImage("Content\\loadmenu_snapshot_focused.png");
            filelistButton5.Position = new Vector2(83, 865);
            AddButtonArea(filelistButton5);
            ButtonArea filelistButton6 = new ButtonArea();
            filelistButton6.SetIdleImage("Content\\loadmenu_snapshot_idle.png");
            filelistButton6.SetFocusedImage("Content\\loadmenu_snapshot_focused.png");
            filelistButton6.Position = new Vector2(83, 1020);
            AddButtonArea(filelistButton6);
            ButtonArea filelistButton7 = new ButtonArea();
            filelistButton7.SetIdleImage("Content\\loadmenu_snapshot_idle.png");
            filelistButton7.SetFocusedImage("Content\\loadmenu_snapshot_focused.png");
            filelistButton7.Position = new Vector2(83, 1175);
            AddButtonArea(filelistButton7);

            ButtonArea scrollUpButton = new ButtonArea();
            scrollUpButton.SetIdleImage("Content\\loadmenu_up_idle.png");
            scrollUpButton.SetFocusedImage("Content\\loadmenu_up_focused.png");
            AddScrollUp(scrollUpButton);
            ButtonArea scrollDownButton = new ButtonArea();
            scrollDownButton.SetIdleImage("Content\\loadmenu_down_idle.png");
            scrollDownButton.SetFocusedImage("Content\\loadmenu_down_focused.png");
            AddScrollDown(scrollDownButton);

            SetScrollable(true);
            SetScrollVisbleSize(new Vector2(1920, 1080));
            SetFocusedAtEnterButtonArea(returnButton);
            base.Initialize();
        }
    }
}
