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
            //AddBackground("loadmenu");
            ButtonArea returnButton = new ButtonArea();
            returnButton.AddSuffixedImage("return");
            returnButton.Position = new Vector2(83, 120);
            returnButton.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<StartMenuScreen>()));
            returnButton.HasShortcutWithGoBackButton = true;
            AddButtonArea(returnButton);
            ButtonArea filelistButton1 = new ButtonArea();
            filelistButton1.AddSuffixedImage("loadmenu_snapshot");
            filelistButton1.AddSuffixedImage("0");
            filelistButton1.AddSuffixedImage("1");
            filelistButton1.AddSuffixedImage("end_paranteses");
            filelistButton1.Position = new Vector2(83,270);
            filelistButton1.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<GameScreen>()));
            AddButtonArea(filelistButton1);
            ButtonArea filelistButton2 = new ButtonArea();
            filelistButton2.AddSuffixedImage("loadmenu_snapshot");
            filelistButton2.AddSuffixedImage("0");
            filelistButton2.AddSuffixedImage("2");
            filelistButton2.AddSuffixedImage("end_paranteses");
            filelistButton2.Position = new Vector2(83, 420);
            filelistButton2.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<GameScreen>()));
            AddButtonArea(filelistButton2);
            ButtonArea filelistButton3 = new ButtonArea();
            filelistButton3.AddSuffixedImage("loadmenu_snapshot");
            filelistButton3.AddSuffixedImage("0");
            filelistButton3.AddSuffixedImage("3");
            filelistButton3.AddSuffixedImage("end_paranteses");
            filelistButton3.Position = new Vector2(83, 570);
            filelistButton3.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<GameScreen>()));
            AddButtonArea(filelistButton3);
            ButtonArea filelistButton4 = new ButtonArea();
            filelistButton4.AddSuffixedImage("loadmenu_snapshot");
            filelistButton4.AddSuffixedImage("0");
            filelistButton4.AddSuffixedImage("4");
            filelistButton4.AddSuffixedImage("end_paranteses");
            filelistButton4.Position = new Vector2(83, 720);
            filelistButton4.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<GameScreen>()));
            AddButtonArea(filelistButton4);
            ButtonArea filelistButton5 = new ButtonArea();
            filelistButton5.AddSuffixedImage("loadmenu_snapshot");
            filelistButton5.AddSuffixedImage("0");
            filelistButton5.AddSuffixedImage("5");
            filelistButton5.AddSuffixedImage("end_paranteses");
            filelistButton5.Position = new Vector2(83, 870);
            filelistButton5.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<GameScreen>()));
            AddButtonArea(filelistButton5);
            ButtonArea filelistButton6 = new ButtonArea();
            filelistButton6.AddSuffixedImage("loadmenu_snapshot");
            filelistButton6.AddSuffixedImage("0");
            filelistButton6.AddSuffixedImage("6");
            filelistButton6.AddSuffixedImage("end_paranteses");
            filelistButton6.Position = new Vector2(83, 1020);
            filelistButton6.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<GameScreen>()));
            AddButtonArea(filelistButton6);
            ButtonArea filelistButton7 = new ButtonArea();
            filelistButton7.AddSuffixedImage("loadmenu_snapshot");
            filelistButton7.AddSuffixedImage("0");
            filelistButton7.AddSuffixedImage("7");
            filelistButton7.AddSuffixedImage("end_paranteses");
            filelistButton7.Position = new Vector2(83, 1170);
            filelistButton7.SetButtonAction(new ChangeScreenButtonAction(_screenManager.GetScreen<GameScreen>()));
            AddButtonArea(filelistButton7);

            ButtonArea scrollUpButton = new ButtonArea();
            scrollUpButton.AddSuffixedImage("loadmenu_up");
            scrollUpButton.Position = new Vector2(83, 0);
            AddScrollUp(scrollUpButton);
            ButtonArea scrollDownButton = new ButtonArea();
            scrollDownButton.AddSuffixedImage("loadmenu_down");
            scrollDownButton.Position = new Vector2(83, 870);
            AddScrollDown(scrollDownButton);

            SetScrollable(true);
            SetFocusedAtEnterButtonArea(returnButton);
            base.Initialize();
        }
    }
}
