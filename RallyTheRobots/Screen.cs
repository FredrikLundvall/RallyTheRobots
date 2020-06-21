using Microsoft.Xna.Framework;
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
        protected List<ButtonArea> _buttonAreaList;
        protected ScreenManager _screenManager;
        public Screen(ScreenManager screenManager)
        {
            _screenManager = screenManager;
            _zeroPosition = new Vector2(0, 0);
            _buttonAreaList = new List<ButtonArea>(30);
        }
        public virtual void Initialize()
        {
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
            foreach(ButtonArea button in _buttonAreaList)
            {
                button.LoadContent(graphicsDevice);
            }
        }
        public virtual void EnterScreen(GameTime gameTime)
        {
            _totalGameTimeEnter = gameTime.TotalGameTime;
            _totalGameTimeFocusChange = gameTime.TotalGameTime;
        }
        public virtual void LeaveScreen()
        {
        }
        public virtual void Update(ScreenManager manager, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            if (_anyButtonScreen != null & (Keyboard.GetState().GetPressedKeys().GetLength(0) > 0 || GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed || GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed || GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed || GamePad.GetState(PlayerIndex.One).Buttons.Y == ButtonState.Pressed || Mouse.GetState().LeftButton == ButtonState.Pressed || Mouse.GetState().RightButton == ButtonState.Pressed))
                manager.ChangeScreen(gameTime, _anyButtonScreen);
            if (_timeoutScreen != null & (gameTime.TotalGameTime.TotalSeconds - _totalGameTimeEnter.TotalSeconds) > _timeoutSeconds)
                manager.ChangeScreen(gameTime, _timeoutScreen);

            if (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y > 0.3 || GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y > 0.3 || Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W))
                FocusPreviousButtonArea(gameTime);
            else if (GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < -0.3 || GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y < -0.3 || Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S))
                FocusNextButtonArea(gameTime);
            else
                _totalGameTimeFocusChange = new TimeSpan(0,0,0);
            foreach (ButtonArea button in _buttonAreaList)
            {
                button.Update(manager, this, gameTime, gameSettings, gameStatus);
            }
        }
        protected virtual void FocusPreviousButtonArea(GameTime gameTime)
        {
            if ((gameTime.TotalGameTime.TotalSeconds - _totalGameTimeFocusChange.TotalSeconds) < FOCUS_CHANGE_TIME)
                return;
            _totalGameTimeFocusChange = gameTime.TotalGameTime;
            ButtonArea previousButton = null;
            for(int i = 0; i < _buttonAreaList.Count; i++)
            {
                if (_buttonAreaList[i].Status == ButtonStatusEnum.Focused)
                    break;
                else if(_buttonAreaList[i].Visible && !_buttonAreaList[i].Disabled)
                    previousButton = _buttonAreaList[i];
            }
            if (previousButton == null)
            {
                for (int i = _buttonAreaList.Count - 1; i >= 0; i--)
                {
                    if (_buttonAreaList[i].Visible && !_buttonAreaList[i].Disabled)
                    {
                        previousButton = _buttonAreaList[i];
                        break;
                    }
                }
            }
            SetFocusedButtonArea(previousButton);
        }
        protected virtual void FocusNextButtonArea(GameTime gameTime)
        {
            if ((gameTime.TotalGameTime.TotalSeconds - _totalGameTimeFocusChange.TotalSeconds) < FOCUS_CHANGE_TIME)
                return;
            _totalGameTimeFocusChange = gameTime.TotalGameTime;
            ButtonArea nextButton = null;
            for (int i = _buttonAreaList.Count - 1; i >= 0; i--)
            {
                if (_buttonAreaList[i].Status == ButtonStatusEnum.Focused)
                    break;
                else if (_buttonAreaList[i].Visible && !_buttonAreaList[i].Disabled)
                    nextButton = _buttonAreaList[i];
            }
            if (nextButton == null)
            {
                for (int i = 0; i < _buttonAreaList.Count; i++)
                {
                    if (_buttonAreaList[i].Visible && !_buttonAreaList[i].Disabled)
                    {
                        nextButton = _buttonAreaList[i];
                        break;
                    }
                }
            }
            SetFocusedButtonArea(nextButton);
        }
        public virtual void SetFocusedButtonArea(ButtonArea focusedButton)
        {
            SetStatusButtonArea(focusedButton, ButtonStatusEnum.Focused);
        }
        public virtual void SetSelectedButtonArea(ButtonArea selectedButton)
        {
            SetStatusButtonArea(selectedButton, ButtonStatusEnum.Selected);
        }
        protected virtual void SetStatusButtonArea(ButtonArea actualButton, ButtonStatusEnum newStatus)
        {
            foreach (ButtonArea button in _buttonAreaList)
            {
                if (button == actualButton && button.Visible && !button.Disabled)
                    button.Status = newStatus;
                else
                    button.Status = ButtonStatusEnum.Idle;
            }
        }
        public virtual void Draw(GameTime gameTime, GraphicsDevice graphicsDevice, GameSettings gameSettings, SpriteBatch spriteBatch)
        {
            if(_background != null)
                spriteBatch.Draw(_background, _zeroPosition, Color.White);
            foreach (ButtonArea button in _buttonAreaList)
            {
                button.Draw(gameTime, graphicsDevice, gameSettings, spriteBatch);
            }
        }
    }
}
