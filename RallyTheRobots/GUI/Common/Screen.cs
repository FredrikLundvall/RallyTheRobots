using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace RallyTheRobots.GUI.Common
{
    public class Screen
    {
        protected ContentManager _contentManager;
        protected ResolutionFactory _resolutionFactory;
        protected ScreenManager _screenManager;
        protected InputChecker _inputChecker;
        protected Vector2 _zeroPosition;
        protected string _backgroundName;
        protected Screen _anyButtonScreen;
        protected Screen _timeoutScreen;
        protected Screen _pauseButtonScreen;
        protected double _timeoutSeconds;
        protected TimeSpan _totalGameTimeEnter;
        protected TimeSpan _totalGameTimeFocusChange;
        protected ButtonAreaList _buttonAreaList;
        protected ButtonArea _focusedAtEnterButtonArea;
        protected ButtonAction _buttonPreviousVerticalAction = new FocusPreviousButtonAreaButtonAction();
        protected ButtonAction _buttonNextVerticalAction = new FocusNextButtonAreaButtonAction();
        protected ButtonAction _buttonPreviousHorizontalAction = null;
        protected ButtonAction _buttonNextHorizontalAction = null;
        protected Screen _previousScreen;

        public Screen()
        {
            _zeroPosition = new Vector2(0, 0);
            _buttonAreaList = new ButtonAreaList();
        }
        internal void SetContentManager(ContentManager contentManager)
        {
            if (_contentManager == null)
                _contentManager = contentManager;
        }
        internal void SetScreenManager(ScreenManager screenManager)
        {
            if (_screenManager == null)
                _screenManager = screenManager;
        }
        internal void SetResolution(ResolutionFactory resolutionFactory)
        {
            if (_resolutionFactory == null)
                _resolutionFactory = resolutionFactory;
            _buttonAreaList.SetResolution(_resolutionFactory);
        }
        internal void SetInputChecker(InputChecker inputChecker)
        {
            if (_inputChecker == null)
                _inputChecker = inputChecker;
            _buttonAreaList.SetInputChecker(inputChecker);
        }
        public virtual void Initialize()
        {
            _buttonAreaList.Initialize();
        }
        public virtual void SetFocusedAtEnterButtonArea(ButtonArea focusedButton)
        {
            _focusedAtEnterButtonArea = focusedButton;
        }
        public virtual void AddBackground(string backgroundName)
        {
            _backgroundName = backgroundName;
            _contentManager.AddTexture2D(_backgroundName);
        }
        public virtual void ScreenChangeOnAnyKey(Screen changeToScreen)
        {
            _anyButtonScreen = changeToScreen;
        }
        public virtual void ScreenChangeOnTimeout(Screen changeToScreen, double seconds)
        {
            _timeoutScreen = changeToScreen;
            _timeoutSeconds = seconds;
        }
        public virtual void ScreenChangeOnPauseKey(Screen changeToScreen)
        {
            _pauseButtonScreen = changeToScreen;
        }
        public virtual void SetScrollable(bool scrollable)
        {
            _buttonAreaList.Scrollable = scrollable;
        }
        public virtual void SetScrollCurrentOffset(Vector2 scrollCurrentOffset)
        {
            _buttonAreaList.ScrollCurrentOffset = scrollCurrentOffset;
        }
        public virtual void AddScrollUp(ButtonArea buttonArea)
        {
            buttonArea.SetContentManager(_contentManager);
            buttonArea.SetInputChecker(_inputChecker);
            buttonArea.SetButtonSelectAction(new ScrollUpAction());
            buttonArea.HasShortcutWithMouseWheelUp = true;
            _buttonAreaList.AddScrollUp(buttonArea);
        }
        public virtual void AddScrollDown(ButtonArea buttonArea)
        {
            buttonArea.SetContentManager(_contentManager);
            buttonArea.SetInputChecker(_inputChecker);
            buttonArea.SetButtonSelectAction(new ScrollDownAction());
            buttonArea.HasShortcutWithMouseWheelDown = true;
            _buttonAreaList.AddScrollDown(buttonArea);
        }
        public virtual void AddButtonArea(ButtonArea buttonArea)
        {
            buttonArea.SetContentManager(_contentManager);
            buttonArea.SetInputChecker(_inputChecker);
            _buttonAreaList.Add(buttonArea);
        }
        public virtual void EnterScreen(GameTime gameTime, GameSettings gameSettings, Screen oldScreen)
        {
            _previousScreen = oldScreen;
            _totalGameTimeEnter = gameTime.TotalGameTime;
            _totalGameTimeFocusChange = gameTime.TotalGameTime;
            if (_focusedAtEnterButtonArea != null)
                SetFocusedButtonArea(_focusedAtEnterButtonArea);
            else
                ChangeSelectedButtonAreaToFocused(gameTime);
        }
        public virtual void LeaveScreen(GameTime gameTime, GameSettings gameSettings, Screen newScreen)
        {
        }
        internal virtual void FocusPreviousButtonArea(GameTime gameTime, GameSettings gameSettings)
        {
            if (gameTime.TotalGameTime.TotalSeconds - _totalGameTimeFocusChange.TotalSeconds < gameSettings.GetFocusChangeTime())
                return;
            _totalGameTimeFocusChange = gameTime.TotalGameTime;
            SetFocusedButtonArea(_buttonAreaList.GetPreviousButtonArea());
        }
        internal virtual void FocusNextButtonArea(GameTime gameTime, GameSettings gameSettings)
        {
            if (gameTime.TotalGameTime.TotalSeconds - _totalGameTimeFocusChange.TotalSeconds < gameSettings.GetFocusChangeTime())
                return;
            _totalGameTimeFocusChange = gameTime.TotalGameTime;
            SetFocusedButtonArea(_buttonAreaList.GetNextButtonArea());
        }
        public virtual void ScrollDownButtonArea(GameTime gameTime)
        {
            _buttonAreaList.ScrollDown();
        }
        public virtual void ScrollUpButtonArea(GameTime gameTime)
        {
            _buttonAreaList.ScrollUp();
        }
        public virtual ButtonArea GetSelectedOrFocusedButtonArea()
        {
            return _buttonAreaList.GetSelectedOrFocusedButtonArea(null);
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
        public virtual void SetPreviousVerticalAction(ButtonAction buttonAction)
        {
            _buttonPreviousVerticalAction = buttonAction;
        }
        public virtual void SetNextVerticalAction(ButtonAction buttonAction)
        {
            _buttonNextVerticalAction = buttonAction;
        }
        public virtual void SetPreviousHorizontalAction(ButtonAction buttonAction)
        {
            _buttonPreviousHorizontalAction = buttonAction;
        }
        public virtual void SetNextHorizontalAction(ButtonAction buttonAction)
        {
            _buttonNextHorizontalAction = buttonAction;
        }
        public virtual Screen GetPreviousScreen()
        {
            return _previousScreen;
        }
        public virtual void Update(ScreenManager manager, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            if (_pauseButtonScreen != null && _inputChecker.InputFunctionWasTriggered(InputFunctionEnum.Pause, gameTime, gameSettings, 0))
                manager.ChangeScreen(gameTime, gameSettings, _pauseButtonScreen);
            if (_anyButtonScreen != null && _inputChecker.AnyButtonIsCurrentlyPressed(gameSettings))
                manager.ChangeScreen(gameTime, gameSettings, _anyButtonScreen);
            if (_timeoutScreen != null & gameTime.TotalGameTime.TotalSeconds - _totalGameTimeEnter.TotalSeconds > _timeoutSeconds)
                manager.ChangeScreen(gameTime, gameSettings, _timeoutScreen);
            if (_inputChecker.PreviousVerticalButtonIsCurrentlyPressed(gameSettings))
            {
                _buttonPreviousVerticalAction.DoAction(manager, this, gameTime, gameSettings, gameStatus);
            }
            else if (_inputChecker.NextVerticalButtonIsCurrentlyPressed(gameSettings))
            {
                _buttonNextVerticalAction.DoAction(manager, this, gameTime, gameSettings, gameStatus);
            }
            else
                _totalGameTimeFocusChange = new TimeSpan(0, 0, 0);

            if (_inputChecker.PreviousHorizontalButtonIsCurrentlyPressed(gameSettings))
            {
                _buttonPreviousHorizontalAction.DoAction(manager, this, gameTime, gameSettings, gameStatus);
            }
            else if (_inputChecker.NextHorizontalButtonIsCurrentlyPressed(gameSettings))
            {
                _buttonNextHorizontalAction.DoAction(manager, this, gameTime, gameSettings, gameStatus);
            }

            if (_inputChecker.InputFunctionWasTriggered(InputFunctionEnum.PrimarySelect, gameTime, gameSettings, 0))
                SelectFocusedButtonArea(gameTime);

            _buttonAreaList.Update(manager, this, gameTime, gameSettings, gameStatus);
            if (_inputChecker.HasMouseMoved(gameTime, gameSettings) || _inputChecker.HasMouseWheelMoved())
            {
                ButtonArea mouseOverButtonArea = _buttonAreaList.GetMouseOverButtonArea(gameTime, gameSettings, _resolutionFactory.GetResolution());
                if (mouseOverButtonArea != null)
                    SetFocusedButtonArea(mouseOverButtonArea);
                else
                    _buttonAreaList.SetAllButtonAreasIdle();
            }
        }
        public virtual void Draw(GameTime gameTime, GraphicsDevice graphicsDevice, GameSettings gameSettings, SpriteBatch spriteBatch)
        {
            Texture2D background = _contentManager.GetTexture2D(_backgroundName);
            if (background != null)
                spriteBatch.Draw(background, _zeroPosition, Color.White);
            _buttonAreaList.Draw(gameTime, graphicsDevice, gameSettings, spriteBatch);
        }
    }
}
