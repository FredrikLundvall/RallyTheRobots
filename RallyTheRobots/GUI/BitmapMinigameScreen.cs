using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RallyTheRobots.GUI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots.GUI
{
    public class BitmapMinigameScreen : Screen
    {
        protected ButtonArea _widthButton = new ButtonArea();
        public override void Initialize()
        {
            AddBackground("bitmap_minigame");

            _widthButton.AddRollingState("8");
            _widthButton.AddRollingState("16");
            _widthButton.AddRollingState("24");
            _widthButton.AddRollingState("32");
            _widthButton.AddRollingState("40");
            _widthButton.AddRollingState("48");
            _widthButton.AddRollingState("56");
            _widthButton.AddRollingState("64");
            _widthButton.AddImage("width");
            _widthButton.AddImage("width_value", ButtonAreaImageNameTypeEnum.RollingStateCharacter);
            _widthButton.Position = new Vector2(10, 570);
            _widthButton.SetButtonSelectAction(new NextRollingStateButtonAction(_widthButton));
            _widthButton.SetButtonAlternateSelectAction(new PreviousRollingStateButtonAction(_widthButton));
            AddButtonArea(_widthButton);

            ScreenChangeOnPauseKey(_screenManager.GetScreen<PauseMenuScreen>());
            SetFocusedButtonArea(_widthButton);
            base.Initialize();
        }
        public override void EnterScreen(GameTime gameTime, GameSettings gameSettings, Screen oldScreen)
        {
            _widthButton.SetCurrentRollingState("8");

            base.EnterScreen(gameTime, gameSettings, oldScreen);
        }
    }
}

