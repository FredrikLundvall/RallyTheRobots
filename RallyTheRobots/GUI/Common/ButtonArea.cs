using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RallyTheRobots.GUI.Common;
using ResolutionBuddy;
using System;

namespace RallyTheRobots
{
    public class ButtonArea
    {
        internal InputChecker _inputChecker;
        protected ButtonAreaImage _buttonAreaImage = new ButtonAreaImage();
        protected RollingState _rollingState = new RollingState();
        public Vector2 Position;
        public int SliderBorderLeft;
        public int SliderBorderRight;
        public int SliderBorderTop;
        public int SliderBorderBottom;
        public bool Visible = true;
        public bool Disabled = false;
        //Maybe move this functionality to the screen (only one shortcut with GoBackButton per screen is probably a requirement)
        public bool HasShortcutWithGoBackButton = false;
        public bool HasShortcutWithMouseWheelUp = false;
        public bool HasShortcutWithMouseWheelDown = false;
        public ButtonStatusEnum Status = ButtonStatusEnum.Idle;
        protected ButtonAction _buttonSelectAction = ButtonAction.GetEmptyButtonAction();
        protected ButtonAction _buttonAlternateSelectAction = ButtonAction.GetEmptyButtonAction();
        protected int _currentHorizontalValue = 0;
        protected int _currentVerticalValue = 0;

        internal void SetContentManager(ContentManager contentManager)
        {
            _buttonAreaImage.SetContentManager(contentManager);
        }
        internal void SetInputChecker(InputChecker inputChecker)
        {
            if (_inputChecker == null)
                _inputChecker = inputChecker;
        }
        public virtual void AddRollingState(string rollingState)
        {
            _rollingState.AddState(rollingState);
        }
        public virtual string GetCurrentRollingState()
        {
            return _rollingState.GetCurrentState();
        }
        public virtual void SetCurrentRollingState(string rollingState)
        {
            _rollingState.SetCurrentState(rollingState);
        }
        public virtual void NextRollingState()
        {
            _rollingState.NextState();
        }
        public virtual void PreviousRollingState()
        {
            _rollingState.PreviousState();
        }
        public virtual void SetButtonSelectAction(ButtonAction buttonAction)
        {
            _buttonSelectAction = buttonAction;
        }
        public virtual void SetButtonAlternateSelectAction(ButtonAction buttonAction)
        {
            _buttonAlternateSelectAction = buttonAction;
        }
        public virtual void Initialize()
        {
            string rollingStateImagePrefix = _buttonAreaImage.GetRollingStateImagePrefix();
            if (_buttonAreaImage.ReferencingRollingStateAsImage())
            {
                foreach (string stateName in _rollingState.ToArray())
                {
                    _buttonAreaImage.AddRollingStatesAsImages(rollingStateImagePrefix + stateName);
                }
            }
            if (_buttonAreaImage.ReferencingRollingStateAsCharacterImage())
            {
                foreach (string stateName in _rollingState.ToArray())
                {
                    foreach (char characterImageName in stateName)
                    {
                        _buttonAreaImage.AddRollingStatesAsImages(rollingStateImagePrefix + characterImageName.ToString());
                    }
                }
            }
            _buttonAreaImage.Initialize();
        }
        public void SetCurrentHorizontalSliderValue(int currentValue)
        {
            _currentHorizontalValue = currentValue;
        }
        public int GetCurrentHorizontalValue()
        {
            return _currentHorizontalValue;
        }
        public void SetCurrentVerticalSliderValue(int currentValue)
        {
            _currentVerticalValue = currentValue;
        }
        public int GetCurrentVerticalValue()
        {
            return _currentVerticalValue;
        }
        public virtual void Update(ScreenManager manager, Screen screen, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus, Vector2 offset, IResolution resolution)
        {
            if (_inputChecker.InputFunctionWasTriggered(InputFunctionEnum.PrimarySelect, gameTime, gameSettings) || (_inputChecker.MouseButtonWasTriggered(MouseButtonEnum.LeftButton, gameTime, gameSettings) && _inputChecker.MouseIsCurrentlyOverButtonArea(this, offset, resolution)) || (HasShortcutWithGoBackButton && _inputChecker.InputFunctionWasTriggered(InputFunctionEnum.GoBack, gameTime, gameSettings)) || (HasShortcutWithMouseWheelUp && _inputChecker.MouseWheelUpIsCurrentlyTurned()) || (HasShortcutWithMouseWheelDown && _inputChecker.MouseWheelDownIsCurrentlyTurned()))
            {
                if (Visible && !Disabled && (Status == ButtonStatusEnum.Focused || Status == ButtonStatusEnum.Selected || (HasShortcutWithGoBackButton && _inputChecker.InputFunctionWasTriggered(InputFunctionEnum.GoBack, gameTime, gameSettings)) || (HasShortcutWithMouseWheelUp && _inputChecker.MouseWheelUpIsCurrentlyTurned()) || (HasShortcutWithMouseWheelDown && _inputChecker.MouseWheelDownIsCurrentlyTurned())))
                {
                    _buttonSelectAction.DoAction(manager, screen, gameTime, gameSettings, gameStatus);
                }
                int horizontalSlider = _inputChecker.HorizontalValueMouseSliderButtonArea(this, offset, resolution);
                if (horizontalSlider != -2) // -2 means it was outside the borders of the slider
                    _currentHorizontalValue = Math.Max(Math.Min(horizontalSlider, 100), 0);
                int verticalSlider = _inputChecker.VerticalValueMouseSliderButtonArea(this, offset, resolution);
                if (verticalSlider != -2)  // -2 means it was outside the borders of the slider
                    _currentVerticalValue = Math.Max(Math.Min(verticalSlider, 100), 0);
            }
            if (_inputChecker.InputFunctionWasTriggered(InputFunctionEnum.AlternateSelect, gameTime, gameSettings) || (_inputChecker.MouseButtonWasTriggered(MouseButtonEnum.RightButton, gameTime, gameSettings) && _inputChecker.MouseIsCurrentlyOverButtonArea(this, offset, resolution)))
            {
                if (Visible && !Disabled && (Status == ButtonStatusEnum.Focused || Status == ButtonStatusEnum.Selected || (HasShortcutWithGoBackButton && _inputChecker.InputFunctionWasTriggered(InputFunctionEnum.GoBack, gameTime, gameSettings)) || (HasShortcutWithMouseWheelUp && _inputChecker.MouseWheelUpIsCurrentlyTurned()) || (HasShortcutWithMouseWheelDown && _inputChecker.MouseWheelDownIsCurrentlyTurned())))
                {
                    _buttonAlternateSelectAction.DoAction(manager, screen, gameTime, gameSettings, gameStatus);
                }
            }
            _currentHorizontalValue = Math.Min(Math.Max(_currentHorizontalValue, 0), 100);
            _currentVerticalValue = Math.Min(Math.Max(_currentVerticalValue, 0), 100);
        }
        public virtual void Draw(GameTime gameTime, GraphicsDevice graphicsDevice, GameSettings gameSettings, SpriteBatch spriteBatch, Vector2 offset)
        {
            _buttonAreaImage.Draw(gameTime, graphicsDevice, gameSettings, spriteBatch, offset, Position, Visible, Disabled, Status, _rollingState.GetCurrentState(), _currentHorizontalValue, _currentVerticalValue, SliderBorderLeft, SliderBorderRight, SliderBorderTop, SliderBorderBottom);
        }
        public virtual void ClearImages()
        {
            _buttonAreaImage.ClearImages();
        }
        public virtual void AddImage(string imageName, ButtonAreaImageNameTypeEnum imageNameType = ButtonAreaImageNameTypeEnum.Actual, ButtonAreaImagePositioningEnum imageType = ButtonAreaImagePositioningEnum.Unmovable, ButtonAreaImageStackDirectionEnum imageStackDirection = ButtonAreaImageStackDirectionEnum.Horizontal, string imageCharacterNameSuffix = "")
        {
            _buttonAreaImage.AddImage(imageName, imageNameType, imageType, imageStackDirection, imageCharacterNameSuffix);
        }
        public virtual Vector2 GetSize()
        {
            return _buttonAreaImage.GetSize(Visible, Disabled, Status, _rollingState.GetCurrentState());
        }
        public virtual Rectangle GetHorizontalSliderRectangle()
        {
            return _buttonAreaImage.GetHorizontalSliderRectangle(SliderBorderLeft, SliderBorderRight, Position, Visible, Disabled, Status, _rollingState.GetCurrentState());
        }
        public virtual Rectangle GetVerticalSliderRectangle()
        {
            return _buttonAreaImage.GetVerticalSliderRectangle(SliderBorderTop, SliderBorderBottom, Position, Visible, Disabled, Status, _rollingState.GetCurrentState());
        }
    }
}
