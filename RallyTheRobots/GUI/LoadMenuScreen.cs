using Microsoft.Xna.Framework;
using RallyTheRobots.GUI.Common;
using ResolutionBuddy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots.GUI
{
    public class LoadMenuScreen : Screen
    {
        public override void Initialize()
        {
            //AddBackground("loadmenu");
            ButtonArea returnButton = new ButtonArea();
            returnButton.AddImage("return");
            returnButton.Position = new Vector2(83, 120);
            returnButton.SetButtonSelectAction(new ChangeToPreviousScreenAction());
            returnButton.HasShortcutWithGoBackButton = true;
            AddButtonArea(returnButton);
            ButtonArea filelistButton1 = new ButtonArea();
            filelistButton1.AddImage("loadmenu_snapshot");
            filelistButton1.AddImage("0");
            filelistButton1.AddImage("1");
            filelistButton1.AddImage("end_paranteses");
            filelistButton1.Position = new Vector2(83, 270);
            filelistButton1.SetButtonSelectAction(new ChangeScreenButtonAction(_screenManager.GetScreen<GameScreen>()));
            AddButtonArea(filelistButton1);
            ButtonArea filelistButton2 = new ButtonArea();
            filelistButton2.AddImage("loadmenu_snapshot");
            filelistButton2.AddImage("0");
            filelistButton2.AddImage("2");
            filelistButton2.AddImage("end_paranteses");
            filelistButton2.Position = new Vector2(83, 420);
            filelistButton2.SetButtonSelectAction(new ChangeScreenButtonAction(_screenManager.GetScreen<GameScreen>()));
            AddButtonArea(filelistButton2);
            ButtonArea filelistButton3 = new ButtonArea();
            filelistButton3.AddImage("loadmenu_snapshot");
            filelistButton3.AddImage("0");
            filelistButton3.AddImage("3");
            filelistButton3.AddImage("end_paranteses");
            filelistButton3.Position = new Vector2(83, 570);
            filelistButton3.SetButtonSelectAction(new ChangeScreenButtonAction(_screenManager.GetScreen<GameScreen>()));
            AddButtonArea(filelistButton3);
            ButtonArea filelistButton4 = new ButtonArea();
            filelistButton4.AddImage("loadmenu_snapshot");
            filelistButton4.AddImage("0");
            filelistButton4.AddImage("4");
            filelistButton4.AddImage("end_paranteses");
            filelistButton4.Position = new Vector2(83, 720);
            filelistButton4.SetButtonSelectAction(new ChangeScreenButtonAction(_screenManager.GetScreen<GameScreen>()));
            AddButtonArea(filelistButton4);
            ButtonArea filelistButton5 = new ButtonArea();
            filelistButton5.AddImage("loadmenu_snapshot");
            filelistButton5.AddImage("0");
            filelistButton5.AddImage("5");
            filelistButton5.AddImage("end_paranteses");
            filelistButton5.Position = new Vector2(83, 870);
            filelistButton5.SetButtonSelectAction(new ChangeScreenButtonAction(_screenManager.GetScreen<GameScreen>()));
            AddButtonArea(filelistButton5);
            ButtonArea filelistButton6 = new ButtonArea();
            filelistButton6.AddImage("loadmenu_snapshot");
            filelistButton6.AddImage("0");
            filelistButton6.AddImage("6");
            filelistButton6.AddImage("end_paranteses");
            filelistButton6.Position = new Vector2(83, 1020);
            filelistButton6.SetButtonSelectAction(new ChangeScreenButtonAction(_screenManager.GetScreen<GameScreen>()));
            AddButtonArea(filelistButton6);
            ButtonArea filelistButton7 = new ButtonArea();
            filelistButton7.AddImage("loadmenu_snapshot");
            filelistButton7.AddImage("0");
            filelistButton7.AddImage("7");
            filelistButton7.AddImage("end_paranteses");
            filelistButton7.Position = new Vector2(83, 1170);
            filelistButton7.SetButtonSelectAction(new ChangeScreenButtonAction(_screenManager.GetScreen<GameScreen>()));
            AddButtonArea(filelistButton7);

            ButtonArea scrollUpButton = new ButtonArea();
            scrollUpButton.AddImage("loadmenu_up");
            scrollUpButton.Position = new Vector2(83, 0);
            AddScrollUp(scrollUpButton);
            ButtonArea scrollDownButton = new ButtonArea();
            scrollDownButton.AddImage("loadmenu_down");
            scrollDownButton.Position = new Vector2(83, 870);
            AddScrollDown(scrollDownButton);

            SetScrollable(true);
            SetFocusedAtEnterButtonArea(returnButton);
            base.Initialize();
        }
    }
}
