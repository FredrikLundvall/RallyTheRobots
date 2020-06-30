﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;

namespace RallyTheRobots
{
    public class Screen
    {
        const double FOCUS_CHANGE_TIME = 0.4;
        protected Vector2 _zeroPosition;
        protected Texture2D _background;
        protected string _backgroundPath;
        protected Screen _anyButtonScreen;
        protected Screen _timeoutScreen;
        protected double _timeoutSeconds;
        protected TimeSpan _totalGameTimeEnter;
        protected TimeSpan _totalGameTimeFocusChange;
        protected ButtonAreaList _buttonAreaList;
        protected ScreenManager _screenManager;
        protected ButtonArea _focusedAtEnterButtonArea;

        public Screen(ScreenManager screenManager)
        {
            _screenManager = screenManager;
            _zeroPosition = new Vector2(0, 0);
            _buttonAreaList = new ButtonAreaList();
        }
        public virtual void Initialize()
        {
        }
        public virtual void SetFocusedAtEnterButtonArea(ButtonArea focusedButton)
        {
            _focusedAtEnterButtonArea = focusedButton;
        }
        public virtual void AddBackground(string backgroundPath)
        {
            _backgroundPath = backgroundPath;
        }
        public virtual void ScreenChangeOnAnyButton(Screen changeToScreen)
        {
            _anyButtonScreen = changeToScreen;
        }
        public virtual void ScreenChangeOnTimeout(Screen changeToScreen, double seconds)
        {
            _timeoutScreen = changeToScreen;
            _timeoutSeconds = seconds;
        }
        public virtual void SetScrollable(bool scrollable)
        {
            _buttonAreaList.Scrollable = scrollable;
        }
        //public virtual void SetScrollVisbleSize(Vector2 scrollVisibleSize)
        //{
        //    _buttonAreaList.ScrollVisibleSize = scrollVisibleSize;
        //}
        public virtual void SetScrollCurrentOffset(Vector2 scrollCurrentOffset)
        {
            _buttonAreaList.ScrollCurrentOffset = scrollCurrentOffset;
        }
        public virtual void AddScrollUp(ButtonArea aButtonArea)
        {
            _buttonAreaList.AddScrollUp(aButtonArea);
        }

        public virtual void AddScrollDown(ButtonArea aButtonArea)
        {
            _buttonAreaList.AddScrollDown(aButtonArea);
        }

        public virtual void AddButtonArea(ButtonArea buttonArea)
        {
            _buttonAreaList.Add(buttonArea);
        }
        public virtual void LoadContent(GraphicsDevice graphicsDevice)
        {
            FileStream tempstream;
            if (_backgroundPath != "" & File.Exists(_backgroundPath))
            {
                tempstream = new FileStream(_backgroundPath, FileMode.Open);
                _background = Texture2D.FromStream(graphicsDevice, tempstream);
                tempstream.Close();
            }
            _buttonAreaList.LoadContent(graphicsDevice);
        }
        public virtual void EnterScreen(GameTime gameTime)
        {
            _totalGameTimeEnter = gameTime.TotalGameTime;
            _totalGameTimeFocusChange = gameTime.TotalGameTime;
            if (_focusedAtEnterButtonArea != null)
                SetFocusedButtonArea(_focusedAtEnterButtonArea);
            else
                ChangeSelectedButtonAreaToFocused(gameTime);
        }
        public virtual void LeaveScreen()
        {
        }
        public virtual void Update(ScreenManager manager, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            if (!InputChecker.ButtonForSelectIsCurrentlyPressed(gameSettings) && !InputChecker.GoBackButtonIsCurrentlyPressed(gameSettings))
                manager.ButtonForSelectIsHeldDown = false;
            if (!manager.ButtonForSelectIsHeldDown && _anyButtonScreen != null && InputChecker.AnyButtonIsCurrentlyPressed(gameSettings))
                manager.ChangeScreen(gameTime, _anyButtonScreen);
            if (_timeoutScreen != null & (gameTime.TotalGameTime.TotalSeconds - _totalGameTimeEnter.TotalSeconds) > _timeoutSeconds)
                manager.ChangeScreen(gameTime, _timeoutScreen);

            if (InputChecker.PreviousButtonIsCurrentlyPressed(gameSettings))
                FocusPreviousButtonArea(gameTime);
            else if (InputChecker.NextButtonIsCurrentlyPressed(gameSettings))
                FocusNextButtonArea(gameTime);
            else
                _totalGameTimeFocusChange = new TimeSpan(0,0,0);

            if (!manager.ButtonForSelectIsHeldDown && InputChecker.ButtonForSelectIsCurrentlyPressed(gameSettings))
                SelectFocusedButtonArea(gameTime);

            _buttonAreaList.Update(manager, this, gameTime, gameSettings, gameStatus);
        }
        protected virtual void FocusPreviousButtonArea(GameTime gameTime)
        {
            if ((gameTime.TotalGameTime.TotalSeconds - _totalGameTimeFocusChange.TotalSeconds) < FOCUS_CHANGE_TIME)
                return;
            _totalGameTimeFocusChange = gameTime.TotalGameTime;
            SetFocusedButtonArea(_buttonAreaList.GetPreviousButtonArea());
        }

        protected virtual void FocusNextButtonArea(GameTime gameTime)
        {
            if ((gameTime.TotalGameTime.TotalSeconds - _totalGameTimeFocusChange.TotalSeconds) < FOCUS_CHANGE_TIME)
                return;
            _totalGameTimeFocusChange = gameTime.TotalGameTime;
            SetFocusedButtonArea(_buttonAreaList.GetNextButtonArea());
        }

        protected virtual void ChangeSelectedButtonAreaToFocused(GameTime gameTime)
        {
            ButtonArea selectedButton = null;
            selectedButton = _buttonAreaList.GetSelectedOrFocusedButtonArea(selectedButton);
            if (selectedButton != null)
                SetFocusedButtonArea(selectedButton);
        }

        protected virtual void SelectFocusedButtonArea(GameTime gameTime)
        {
            ButtonArea focusedButton = null;
            focusedButton = _buttonAreaList.GetFocusedButtonArea(focusedButton);
            if (focusedButton != null)
                SetSelectedButtonArea(focusedButton);
        }

        public virtual void SetFocusedButtonArea(ButtonArea focusedButton)
        {
            _buttonAreaList.SetStatusButtonArea(focusedButton, ButtonStatusEnum.Focused);
        }
        public virtual void SetSelectedButtonArea(ButtonArea selectedButton)
        {
            _buttonAreaList.SetStatusButtonArea(selectedButton, ButtonStatusEnum.Selected);
        }
        public virtual void Draw(GameTime gameTime, GraphicsDevice graphicsDevice, GameSettings gameSettings, SpriteBatch spriteBatch)
        {
            if(_background != null)
                spriteBatch.Draw(_background, _zeroPosition, Color.White);
            _buttonAreaList.Draw(gameTime, graphicsDevice, gameSettings, spriteBatch);
        }
    }
}