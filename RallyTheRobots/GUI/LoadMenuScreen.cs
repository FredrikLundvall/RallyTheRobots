using Microsoft.Xna.Framework;
using ResolutionBuddy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots
{
    public class LoadMenuScreen : Screen
    {
        public override void Initialize()
        {
            //AddBackground("loadmenu.png");
            ButtonArea returnButton = new ButtonArea();
            returnButton.AddIdleImage("loadmenu_return_idle.png");
            returnButton.AddFocusedImage("loadmenu_return_focused.png");
            returnButton.Position = new Vector2(83, 120);
            returnButton.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<StartMenuScreen>()));
            returnButton.HasShortcutWithGoBackButton = true;
            AddButtonArea(returnButton);
            ButtonArea filelistButton1 = new ButtonArea();
            filelistButton1.AddIdleImage("loadmenu_snapshot_idle.png");
            filelistButton1.AddIdleImage("loadmenu_001_idle.png");
            filelistButton1.AddIdleImage("loadmenu_end_paranteses_idle.png");
            filelistButton1.AddFocusedImage("loadmenu_snapshot_focused.png");
            filelistButton1.AddFocusedImage("loadmenu_001_focused.png");
            filelistButton1.AddFocusedImage("loadmenu_end_paranteses_focused.png");
            filelistButton1.Position = new Vector2(83,270);
            filelistButton1.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<GameScreen>()));
            AddButtonArea(filelistButton1);
            ButtonArea filelistButton2 = new ButtonArea();
            filelistButton2.AddIdleImage("loadmenu_snapshot_idle.png");
            filelistButton2.AddIdleImage("loadmenu_002_idle.png");
            filelistButton2.AddIdleImage("loadmenu_end_paranteses_idle.png");
            filelistButton2.AddFocusedImage("loadmenu_snapshot_focused.png");
            filelistButton2.AddFocusedImage("loadmenu_002_focused.png");
            filelistButton2.AddFocusedImage("loadmenu_end_paranteses_focused.png");
            filelistButton2.Position = new Vector2(83, 420);
            filelistButton2.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<GameScreen>()));
            AddButtonArea(filelistButton2);
            ButtonArea filelistButton3 = new ButtonArea();
            filelistButton3.AddIdleImage("loadmenu_snapshot_idle.png");
            filelistButton3.AddIdleImage("loadmenu_003_idle.png");
            filelistButton3.AddIdleImage("loadmenu_end_paranteses_idle.png");
            filelistButton3.AddFocusedImage("loadmenu_snapshot_focused.png");
            filelistButton3.AddFocusedImage("loadmenu_003_focused.png");
            filelistButton3.AddFocusedImage("loadmenu_end_paranteses_focused.png");
            filelistButton3.Position = new Vector2(83, 570);
            filelistButton3.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<GameScreen>()));
            AddButtonArea(filelistButton3);
            ButtonArea filelistButton4 = new ButtonArea();
            filelistButton4.AddIdleImage("loadmenu_snapshot_idle.png");
            filelistButton4.AddIdleImage("loadmenu_004_idle.png");
            filelistButton4.AddIdleImage("loadmenu_end_paranteses_idle.png");
            filelistButton4.AddFocusedImage("loadmenu_snapshot_focused.png");
            filelistButton4.AddFocusedImage("loadmenu_004_focused.png");
            filelistButton4.AddFocusedImage("loadmenu_end_paranteses_focused.png");
            filelistButton4.Position = new Vector2(83, 720);
            filelistButton4.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<GameScreen>()));
            AddButtonArea(filelistButton4);
            ButtonArea filelistButton5 = new ButtonArea();
            filelistButton5.AddIdleImage("loadmenu_snapshot_idle.png");
            filelistButton5.AddIdleImage("loadmenu_005_idle.png");
            filelistButton5.AddIdleImage("loadmenu_end_paranteses_idle.png");
            filelistButton5.AddFocusedImage("loadmenu_snapshot_focused.png");
            filelistButton5.AddFocusedImage("loadmenu_005_focused.png");
            filelistButton5.AddFocusedImage("loadmenu_end_paranteses_focused.png");
            filelistButton5.Position = new Vector2(83, 870);
            filelistButton5.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<GameScreen>()));
            AddButtonArea(filelistButton5);
            ButtonArea filelistButton6 = new ButtonArea();
            filelistButton6.AddIdleImage("loadmenu_snapshot_idle.png");
            filelistButton6.AddIdleImage("loadmenu_006_idle.png");
            filelistButton6.AddIdleImage("loadmenu_end_paranteses_idle.png");
            filelistButton6.AddFocusedImage("loadmenu_snapshot_focused.png");
            filelistButton6.AddFocusedImage("loadmenu_006_focused.png");
            filelistButton6.AddFocusedImage("loadmenu_end_paranteses_focused.png");
            filelistButton6.Position = new Vector2(83, 1020);
            filelistButton6.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<GameScreen>()));
            AddButtonArea(filelistButton6);
            ButtonArea filelistButton7 = new ButtonArea();
            filelistButton7.AddIdleImage("loadmenu_snapshot_idle.png");
            filelistButton7.AddIdleImage("loadmenu_007_idle.png");
            filelistButton7.AddIdleImage("loadmenu_end_paranteses_idle.png");
            filelistButton7.AddFocusedImage("loadmenu_snapshot_focused.png");
            filelistButton7.AddFocusedImage("loadmenu_007_focused.png");
            filelistButton7.AddFocusedImage("loadmenu_end_paranteses_focused.png");
            filelistButton7.Position = new Vector2(83, 1170);
            filelistButton7.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<GameScreen>()));
            AddButtonArea(filelistButton7);

            ButtonArea scrollUpButton = new ButtonArea();
            scrollUpButton.AddIdleImage("loadmenu_up_idle.png");
            scrollUpButton.AddFocusedImage("loadmenu_up_focused.png");
            scrollUpButton.Position = new Vector2(83, 0);
            AddScrollUp(scrollUpButton);
            ButtonArea scrollDownButton = new ButtonArea();
            scrollDownButton.AddIdleImage("loadmenu_down_idle.png");
            scrollDownButton.AddFocusedImage("loadmenu_down_focused.png");
            scrollDownButton.Position = new Vector2(83, 870);
            AddScrollDown(scrollDownButton);

            SetScrollable(true);
            SetFocusedAtEnterButtonArea(returnButton);
            base.Initialize();
        }
    }
}
