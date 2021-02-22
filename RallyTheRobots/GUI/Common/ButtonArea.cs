using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RallyTheRobots.GUI;
using RallyTheRobots.GUI.Common;
using ResolutionBuddy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots
{
    public class ButtonArea
    {
        internal InputChecker _inputChecker;
        protected ButtonAreaImage _buttonAreaImage = new ButtonAreaImage();
        protected RollingState _rollingState = new RollingState();
        protected RollingState _rollingState2 = new RollingState();
        public Vector2 Position;
        public int SliderBorderLeft;
        public int SliderBorderRight;
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
        public virtual void AddRollingState2(string rollingState)
        {
            _rollingState2.AddState(rollingState);
        }
        public virtual string GetCurrentRollingState2()
        {
            return _rollingState2.GetCurrentState();
        }
        public virtual void SetCurrentRollingState2(string rollingState)
        {
            _rollingState2.SetCurrentState(rollingState);
        }
        public virtual void NextRollingState2()
        {
            _rollingState2.NextState();
        }
        public virtual void PreviousRollingState2()
        {
            _rollingState2.PreviousState();
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
            if (_buttonAreaImage.ReferencingRollingStateAsImage())
            {
                foreach (string stateName in _rollingState.ToArray())
                {
                    _buttonAreaImage.AddRollingStatesAsImages(stateName);
                }
            }
            if (_buttonAreaImage.ReferencingRollingStateAsCharacterImage())
            {
                foreach (string stateName in _rollingState.ToArray())
                {
                    foreach (char characterImageName in stateName)
                    {
                        _buttonAreaImage.AddRollingStatesAsImages(characterImageName.ToString());
                    }
                }
            }
            if (_buttonAreaImage.ReferencingRollingState2AsImage())
            {
                foreach (string stateName in _rollingState2.ToArray())
                {
                    _buttonAreaImage.AddRollingStatesAsImages(stateName);
                }
            }
            if (_buttonAreaImage.ReferencingRollingState2AsCharacterImage())
            {
                foreach (string stateName in _rollingState2.ToArray())
                {
                    foreach (char characterImageName in stateName)
                    {
                        _buttonAreaImage.AddRollingStatesAsImages(characterImageName.ToString());
                    }
                }
            }
            _buttonAreaImage.Initialize();
        }
        public void SetCurrentHorizontalValue(int currentValue)
        {
            _currentHorizontalValue = currentValue;
        }
        public int GetCurrentHorizontalValue()
        {
            return _currentHorizontalValue;
        }
        public void SetCurrentVerticalValue(int currentValue)
        {
            _currentVerticalValue = currentValue;
        }
        public int GetCurrentVerticalValue()
        {
            return _currentVerticalValue;
        }
        public virtual void Update(ScreenManager manager, Screen screen, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus, Vector2 offset, IResolution resolution)
        {
            //Check if the button was released between the last triggering of DoAction
            if (_inputChecker.ButtonForSelectIsCurrentlyPressed(gameSettings) || (_inputChecker.ButtonForSelectMouseIsCurrentlyPressed(gameSettings) && _inputChecker.MouseIsCurrentlyOverButtonArea(this, offset, resolution)) || (HasShortcutWithGoBackButton && _inputChecker.GoBackButtonIsCurrentlyPressed(gameSettings)) || (HasShortcutWithMouseWheelUp && _inputChecker.MouseWheelUpIsCurrentlyTurned()) || (HasShortcutWithMouseWheelDown && _inputChecker.MouseWheelDownIsCurrentlyTurned()))
            {
                if (!manager.ButtonForSelectIsHeldDown && Visible && !Disabled && (Status == ButtonStatusEnum.Focused || Status == ButtonStatusEnum.Selected || (HasShortcutWithGoBackButton && _inputChecker.GoBackButtonIsCurrentlyPressed(gameSettings)) || (HasShortcutWithMouseWheelUp && _inputChecker.MouseWheelUpIsCurrentlyTurned()) || (HasShortcutWithMouseWheelDown && _inputChecker.MouseWheelDownIsCurrentlyTurned())))
                {
                    manager.ButtonForSelectIsHeldDown = true;
                    _buttonSelectAction.DoAction(manager, screen, gameTime, gameSettings, gameStatus);
                }
                int horizontalSlider = _inputChecker.HorizontalValueMouseSliderButtonArea(this, offset, resolution);
                if (horizontalSlider != -2)
                    _currentHorizontalValue = Math.Max(Math.Min(horizontalSlider, 100), 0);
            }
            //Press of mousebutton outside the ButtonArea is treated differently
            else if (!_inputChecker.ButtonForSelectMouseIsCurrentlyPressed(gameSettings))
                manager.ButtonForSelectIsHeldDown = false;
            //Check if the alternate button was released between the last triggering of DoAction
            if (_inputChecker.ButtonForAlternateSelectIsCurrentlyPressed(gameSettings) || (_inputChecker.ButtonForAlternateSelectMouseIsCurrentlyPressed(gameSettings) && _inputChecker.MouseIsCurrentlyOverButtonArea(this, offset, resolution)))
            {
                if (!manager.ButtonForAlternateSelectIsHeldDown && Visible && !Disabled && (Status == ButtonStatusEnum.Focused || Status == ButtonStatusEnum.Selected || (HasShortcutWithGoBackButton && _inputChecker.GoBackButtonIsCurrentlyPressed(gameSettings)) || (HasShortcutWithMouseWheelUp && _inputChecker.MouseWheelUpIsCurrentlyTurned()) || (HasShortcutWithMouseWheelDown && _inputChecker.MouseWheelDownIsCurrentlyTurned())))
                {
                    manager.ButtonForAlternateSelectIsHeldDown = true;
                    _buttonAlternateSelectAction.DoAction(manager, screen, gameTime, gameSettings, gameStatus);
                }
            }
            //Press of mousebutton outside the ButtonArea is treated differently
            else if (!_inputChecker.ButtonForAlternateSelectMouseIsCurrentlyPressed(gameSettings))
                manager.ButtonForAlternateSelectIsHeldDown = false;
            _currentHorizontalValue = Math.Min(Math.Max(_currentHorizontalValue, 0), 100);
            _currentVerticalValue = Math.Min(Math.Max(_currentHorizontalValue, 0), 100);
        }
        public virtual void Draw(GameTime gameTime, GraphicsDevice graphicsDevice, GameSettings gameSettings, SpriteBatch spriteBatch, Vector2 offset)
        {
            _buttonAreaImage.Draw(gameTime, graphicsDevice, gameSettings, spriteBatch, offset, Position, Visible, Disabled, Status, _rollingState.GetCurrentState(), _rollingState2.GetCurrentState(), _currentHorizontalValue, _currentVerticalValue, SliderBorderLeft, SliderBorderRight);
        }
        public virtual void ClearImages()
        {
            _buttonAreaImage.ClearImages();
        }
        public virtual void AddImage(string imageName, ButtonAreaImageNameTypeEnum imageNameType = ButtonAreaImageNameTypeEnum.Actual, ButtonAreaImagePositioningEnum imageType = ButtonAreaImagePositioningEnum.Unmovable, ButtonAreaImageStackDirectionEnum imageStackDirection = ButtonAreaImageStackDirectionEnum.Horizontal)
        {
            _buttonAreaImage.AddImage(imageName, imageNameType, imageType, imageStackDirection);
        }
        public virtual Vector2 GetSize()
        {
            return _buttonAreaImage.GetSize(Visible, Disabled, Status, _rollingState.GetCurrentState(), _rollingState2.GetCurrentState());
        }
        public virtual Rectangle GetHorizontalSliderRectangle()
        {
            return _buttonAreaImage.GetHorizontalSliderRectangle(SliderBorderLeft, SliderBorderRight, Position, Visible, Disabled, Status, _rollingState.GetCurrentState());
        }
    }
}
