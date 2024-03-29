﻿using Microsoft.Xna.Framework;
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
        protected ButtonArea _heightButton = new ButtonArea();
        protected ButtonArea _colourButton = new ButtonArea();
        protected ButtonArea _paletteButton = new ButtonArea();
        protected ButtonArea _addressButton = new ButtonArea();
        protected ButtonArea _modeButton = new ButtonArea();
        protected ButtonArea _upButton = new ButtonArea();
        protected ButtonArea _positionSlider = new ButtonArea();
        protected ButtonArea _downButton = new ButtonArea();
        protected int _width = 8;
        protected int _height = 8;
        protected int _currentVerticalSlider = 0;

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
            _widthButton.AddImage("bitmap_mg_width");
            _widthButton.AddImage("width_value", ButtonAreaImageNameTypeEnum.RollingStateCharacter, ButtonAreaImagePositioningEnum.Unmovable, ButtonAreaImageStackDirectionEnum.Horizontal, "s");
            _widthButton.Position = new Vector2(10, 565);
            _widthButton.SetButtonSelectAction(new NextRollingStateButtonAction(_widthButton));
            _widthButton.SetButtonAlternateSelectAction(new PreviousRollingStateButtonAction(_widthButton));
            AddButtonArea(_widthButton);

            _heightButton.AddRollingState("8");
            _heightButton.AddRollingState("16");
            _heightButton.AddRollingState("24");
            _heightButton.AddRollingState("32");
            _heightButton.AddRollingState("40");
            _heightButton.AddRollingState("48");
            _heightButton.AddRollingState("56");
            _heightButton.AddRollingState("64");
            _heightButton.AddImage("bitmap_mg_height");
            _heightButton.AddImage("height_value", ButtonAreaImageNameTypeEnum.RollingStateCharacter, ButtonAreaImagePositioningEnum.Unmovable, ButtonAreaImageStackDirectionEnum.Horizontal, "s");
            _heightButton.Position = new Vector2(10, 635);
            _heightButton.SetButtonSelectAction(new NextRollingStateButtonAction(_heightButton));
            _heightButton.SetButtonAlternateSelectAction(new PreviousRollingStateButtonAction(_heightButton));
            AddButtonArea(_heightButton);

            _colourButton.AddRollingState("2");
            _colourButton.AddRollingState("4");
            _colourButton.AddRollingState("8");
            _colourButton.AddRollingState("16");
            _colourButton.AddRollingState("32");
            _colourButton.AddImage("bitmap_mg_colour");
            _colourButton.AddImage("colour_value", ButtonAreaImageNameTypeEnum.RollingStateCharacter, ButtonAreaImagePositioningEnum.Unmovable, ButtonAreaImageStackDirectionEnum.Horizontal, "s");
            _colourButton.Position = new Vector2(10, 710);
            _colourButton.SetButtonSelectAction(new NextRollingStateButtonAction(_colourButton));
            _colourButton.SetButtonAlternateSelectAction(new PreviousRollingStateButtonAction(_colourButton));
            AddButtonArea(_colourButton);

            _paletteButton.AddRollingState("system");
            _paletteButton.AddRollingState("halftone");
            _paletteButton.AddRollingState("extended");
            _paletteButton.AddRollingState("full");
            _paletteButton.AddRollingState("realistic");
            _paletteButton.AddImage("bitmap_mg_palette");
            _paletteButton.AddImage("palette_value", ButtonAreaImageNameTypeEnum.RollingState, ButtonAreaImagePositioningEnum.Unmovable, ButtonAreaImageStackDirectionEnum.Horizontal, "bitmap_mg_");
            _paletteButton.Position = new Vector2(10, 785);
            _paletteButton.SetButtonSelectAction(new NextRollingStateButtonAction(_paletteButton));
            _paletteButton.SetButtonAlternateSelectAction(new PreviousRollingStateButtonAction(_paletteButton));
            AddButtonArea(_paletteButton);

            _addressButton.AddRollingState("low");
            _addressButton.AddRollingState("high");
            _addressButton.AddRollingState("expansion");
            _addressButton.AddRollingState("external");
            _addressButton.AddImage("bitmap_mg_address");
            _addressButton.AddImage("address_value", ButtonAreaImageNameTypeEnum.RollingState, ButtonAreaImagePositioningEnum.Unmovable, ButtonAreaImageStackDirectionEnum.Horizontal, "bitmap_mg_");
            _addressButton.Position = new Vector2(10, 865);
            _addressButton.SetButtonSelectAction(new NextRollingStateButtonAction(_addressButton));
            _addressButton.SetButtonAlternateSelectAction(new PreviousRollingStateButtonAction(_addressButton));
            AddButtonArea(_addressButton);

            _modeButton.AddRollingState("normal");
            _modeButton.AddRollingState("interlaced");
            _modeButton.AddImage("bitmap_mg_mode");
            _modeButton.AddImage("mode_value", ButtonAreaImageNameTypeEnum.RollingState, ButtonAreaImagePositioningEnum.Unmovable, ButtonAreaImageStackDirectionEnum.Horizontal, "bitmap_mg_");
            _modeButton.Position = new Vector2(10, 940);
            _modeButton.SetButtonSelectAction(new NextRollingStateButtonAction(_modeButton));
            _modeButton.SetButtonAlternateSelectAction(new PreviousRollingStateButtonAction(_modeButton));
            AddButtonArea(_modeButton);

            _upButton.AddImage("bitmap_mg_up");
            _upButton.Position = new Vector2(1100 + _width * 10, 5);
            _upButton.SetButtonSelectAction(new ChangeSliderValueButtonAction(_positionSlider, 0, -1));
            _upButton.SetTriggerTimeout(0.1);
            AddButtonArea(_upButton);

            _positionSlider.AddImage("bitmap_mg_slider_bar", ButtonAreaImageNameTypeEnum.Actual, ButtonAreaImagePositioningEnum.ValueVerticalSlider, ButtonAreaImageStackDirectionEnum.None);
            _positionSlider.AddImage("bitmap_mg_slider");
            _positionSlider.Position = new Vector2(1100 + _width * 10, 80);
            _positionSlider.SliderBorderTop = 45;
            _positionSlider.SliderBorderBottom = 45;
            _positionSlider.SetTriggerTimeout(0.05);
            AddButtonArea(_positionSlider);


            _downButton.AddImage("bitmap_mg_down");
            _downButton.Position = new Vector2(1100 + _width * 10, 975);
            _downButton.SetButtonSelectAction(new ChangeSliderValueButtonAction(_positionSlider, 0, 1));
            _downButton.SetTriggerTimeout(0.1);
            AddButtonArea(_downButton);

            ScreenChangeOnPauseKey(_screenManager.GetScreen<PauseMenuScreen>());
            SetFocusedButtonArea(_widthButton);
            SetPreviousHorizontalAction(new ChangeValueFocusedButtonAction(0, -1, DirectionEnum.Previous)); //Using the scroll previous horizontal, for sliding horizontal slider bar up and changing rolling state to previous
            SetNextHorizontalAction(new ChangeValueFocusedButtonAction(0, 1, DirectionEnum.Next)); //Using the scroll next horizontal, for sliding horizontal slider bar down and changing rolling state to next

            _contentManager.AddTexture2D("bitmap_mg_frame_top_left");
            _contentManager.AddTexture2D("bitmap_mg_frame_top");
            _contentManager.AddTexture2D("bitmap_mg_frame_top_right");
            _contentManager.AddTexture2D("bitmap_mg_frame_left");
            _contentManager.AddTexture2D("bitmap_mg_frame_bottom_left");
            _contentManager.AddTexture2D("bitmap_mg_frame_bottom");
            _contentManager.AddTexture2D("bitmap_mg_frame_bottom_right");
            _contentManager.AddTexture2D("bitmap_mg_frame_right");

            _contentManager.AddTexture2D("bitmap_mg_pixel_black");
            _contentManager.AddTexture2D("bitmap_mg_pixel_white");
            _contentManager.AddTexture2D("bitmap_mg_pixel_blue");
            _contentManager.AddTexture2D("bitmap_mg_pixel_red");
            _contentManager.AddTexture2D("bitmap_mg_pixel_yellow");
            _contentManager.AddTexture2D("bitmap_mg_pixel_green");
            _contentManager.AddTexture2D("bitmap_mg_pixel_gray");
            _contentManager.AddTexture2D("bitmap_mg_pixel_purple");
            base.Initialize();
        }
        public override void EnterScreen(GameTime gameTime, GameSettings gameSettings, Screen oldScreen)
        {
            _widthButton.SetCurrentRollingState(_width.ToString());
            _heightButton.SetCurrentRollingState(_height.ToString());
            _colourButton.SetCurrentRollingState("2");
            _paletteButton.SetCurrentRollingState("system");
            _addressButton.SetCurrentRollingState("low");
            _modeButton.SetCurrentRollingState("normal");
            _positionSlider.SetCurrentVerticalSliderValue(_currentVerticalSlider);

            base.EnterScreen(gameTime, gameSettings, oldScreen);
        }
        public override void Update(ScreenManager manager, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            int.TryParse(_widthButton.GetCurrentRollingState(), out _width);
            int.TryParse(_heightButton.GetCurrentRollingState(), out _height);
            _currentVerticalSlider = _positionSlider.GetCurrentVerticalValue();

            _upButton.Position = new Vector2(1100 + _width * 10, 5);
            _positionSlider.Position = new Vector2(1100 + _width * 10, 80);
            _downButton.Position = new Vector2(1100 + _width * 10, 975);

            base.Update(manager, gameTime, gameSettings, gameStatus);
        }
        public override void Draw(GameTime gameTime, GraphicsDevice graphicsDevice, GameSettings gameSettings, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, graphicsDevice, gameSettings, spriteBatch);

            GraphicsToolbox.DrawBitmap(spriteBatch, _contentManager, new Vector2(1005, 60), _width, 98, "bitmap_mg_pixel_black", "bitmap_mg_pixel_white", "bitmap_mg_pixel_blue", "bitmap_mg_pixel_red", "bitmap_mg_pixel_yellow", "bitmap_mg_pixel_green", "bitmap_mg_pixel_gray", "bitmap_mg_pixel_purple", _currentVerticalSlider);
            GraphicsToolbox.DrawFrame(spriteBatch, _contentManager, new Rectangle(960, 25, _width * 10 + 90, 1050), "bitmap_mg_frame_top_left", "bitmap_mg_frame_top", "bitmap_mg_frame_top_right", "bitmap_mg_frame_left", "bitmap_mg_frame_bottom_left", "bitmap_mg_frame_bottom", "bitmap_mg_frame_bottom_right", "bitmap_mg_frame_right");
            GraphicsToolbox.DrawFrame(spriteBatch, _contentManager, new Rectangle(940, 5, _width * 10 + 130, _height * 10 + 84), "bitmap_mg_frame_top_left", "bitmap_mg_frame_top", "bitmap_mg_frame_top_right", "bitmap_mg_frame_left", "bitmap_mg_frame_bottom_left", "bitmap_mg_frame_bottom", "bitmap_mg_frame_bottom_right", "bitmap_mg_frame_right");
        }
    }
}

