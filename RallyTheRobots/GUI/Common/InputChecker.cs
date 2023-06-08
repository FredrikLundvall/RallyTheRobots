using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ResolutionBuddy;
using System;
using System.Collections.Generic;

namespace RallyTheRobots.GUI.Common
{
    public class InputChecker
    {
        private Point _currentMousePosition;
        private Point _oldMousePosition;
        private int _currentScrollWheelValue;
        private int _oldScrollWheelValue;
        private InputConnector _inputConnector;
        private Dictionary<InputFunctionEnum, InputButtonStatus> _inputFunctionStatusList;
        private Dictionary<MouseButtonEnum, InputButtonStatus> _mouseButtonStatusList;

        public virtual void Initialize()
        {
            if (_inputConnector == null)
                _inputConnector = new InputConnector();
            if (_inputFunctionStatusList == null)
                _inputFunctionStatusList = new Dictionary<InputFunctionEnum, InputButtonStatus>();
            if (_mouseButtonStatusList == null)
                _mouseButtonStatusList = new Dictionary<MouseButtonEnum, InputButtonStatus>();
            foreach (int i in Enum.GetValues(typeof(InputFunctionEnum)))
            {
                //Adding all InputFunctionEnums here
                _inputFunctionStatusList.Add((InputFunctionEnum)i, new InputButtonStatus(false, new TimeSpan(0)));
            }
            foreach (int i in Enum.GetValues(typeof(MouseButtonEnum)))
            {
                //Adding all MouseButtonEnums here
                _mouseButtonStatusList.Add((MouseButtonEnum)i, new InputButtonStatus(false, new TimeSpan(0)));
            }
            _oldScrollWheelValue = _inputConnector.GetMouseState().ScrollWheelValue;
            _oldMousePosition = _inputConnector.GetMouseState().Position;
        }
        public void SetInputConnector(InputConnector inputConnector)
        {
            if (_inputConnector == null)
                _inputConnector = inputConnector;
        }
        public void SetInputFunctionStatusList(Dictionary<InputFunctionEnum, InputButtonStatus> inputFunctionStatusList)
        {
            if (_inputFunctionStatusList == null)
                _inputFunctionStatusList = inputFunctionStatusList;
        }
        public void SetMouseButtonStatusList(Dictionary<MouseButtonEnum, InputButtonStatus> mouseButtonStatusList)
        {
            if (_mouseButtonStatusList == null)
                _mouseButtonStatusList = mouseButtonStatusList;
        }
        public virtual void BeforeUpdate(GameTime gameTime, GameSettings gameSettings)
        {
            _currentScrollWheelValue = _inputConnector.GetMouseState().ScrollWheelValue;
            _currentMousePosition = _inputConnector.GetMouseState().Position;
        }
        public virtual void AfterUpdate(GameTime gameTime, GameSettings gameSettings)
        {
            _oldScrollWheelValue = _currentScrollWheelValue;
            _oldMousePosition = _currentMousePosition;
        }
        public virtual bool InputFunctionWasTriggered(InputFunctionEnum inputFunction, GameTime gameTime, GameSettings gameSettings)
        {
            //Check for buttons pressed while avoiding cascading event in next screen
            var isPressed = InputFunctionIsCurrentlyPressed(inputFunction, gameSettings);
            if (isPressed)
            {             
                if (_inputFunctionStatusList[inputFunction].ButtonIsHeldDown && _inputFunctionStatusList[inputFunction].ButtonIsHeldDownAtElapsedTime != gameTime.ElapsedGameTime)
                {
                    isPressed = false;
                }
                else
                {
                    _inputFunctionStatusList[inputFunction] = new InputButtonStatus(true, gameTime.ElapsedGameTime);
                }
            }
            else
            {
                //The elapsed time isn't used, but preserving it anyway if some future use of last time pressed is needed
                _inputFunctionStatusList[inputFunction] = new InputButtonStatus(false, _inputFunctionStatusList[inputFunction].ButtonIsHeldDownAtElapsedTime);
            }
            return isPressed;
        }
        public virtual bool InputFunctionIsCurrentlyPressed(InputFunctionEnum inputFunction, GameSettings gameSettings)
        {
            //Check for buttons being pressed down right now
            //Broken down for debugging
            var isPressed = IsAnyOfTheseGamePadKeysPressed(_inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()), gameSettings.GetInputButtonsForFunction(inputFunction).GamepadButtons, gameSettings.GetTriggerThreshold());
            isPressed |= IsAnyOfTheseKeboardKeysPressed(gameSettings.GetInputButtonsForFunction(inputFunction).KeyboardKeys);
            return isPressed;
        }
        public virtual bool MouseButtonWasTriggered(MouseButtonEnum mouseButton, GameTime gameTime, GameSettings gameSettings)
        {
            //Check for buttons pressed while avoiding cascading event in next screen
            var isPressed = MoueseButtonIsCurrentlyPressed(mouseButton, gameSettings);
            if (isPressed)
            {
                if (_mouseButtonStatusList[mouseButton].ButtonIsHeldDown && _mouseButtonStatusList[mouseButton].ButtonIsHeldDownAtElapsedTime != gameTime.ElapsedGameTime)
                {
                    isPressed = false;
                }
                else
                {
                    _mouseButtonStatusList[mouseButton] = new InputButtonStatus(true, gameTime.ElapsedGameTime);
                }
            }
            else
            {
                //The elapsed time isn't used, but preserving it anyway if some future use of last time pressed is needed
                _mouseButtonStatusList[mouseButton] = new InputButtonStatus(false, _mouseButtonStatusList[mouseButton].ButtonIsHeldDownAtElapsedTime);
            }
            return isPressed;
        }
        public virtual bool MoueseButtonIsCurrentlyPressed(MouseButtonEnum mouseButton, GameSettings gameSettings)
        {
            //Check for buttons being pressed down right now
            switch (mouseButton)
            {
                case MouseButtonEnum.LeftButton: return _inputConnector.GetMouseState().LeftButton == ButtonState.Pressed;
                case MouseButtonEnum.RightButton: return _inputConnector.GetMouseState().RightButton == ButtonState.Pressed;
                case MouseButtonEnum.MiddleButton: return _inputConnector.GetMouseState().MiddleButton == ButtonState.Pressed;
                case MouseButtonEnum.XButton1: return _inputConnector.GetMouseState().XButton1 == ButtonState.Pressed;
                case MouseButtonEnum.XButton2: return _inputConnector.GetMouseState().XButton2 == ButtonState.Pressed;
            }
            return false;
        }
        public virtual bool AnyButtonIsCurrentlyPressed(GameSettings gameSettings)
        {
            return _inputConnector.GetKeyboardState().GetPressedKeys().GetLength(0) > 0 ||
                IsAnyOfTheseGamePadKeysPressed(_inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()), new Buttons[] { Buttons.A, Buttons.B, Buttons.X, Buttons.Y}, 0f) ||
                MoueseButtonIsCurrentlyPressed(MouseButtonEnum.LeftButton , gameSettings) ||
                MoueseButtonIsCurrentlyPressed(MouseButtonEnum.RightButton, gameSettings);
        }
        public virtual bool PreviousVerticalButtonIsCurrentlyPressed(GameSettings gameSettings)
        {
            return _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).DPad.Up == ButtonState.Pressed || 
                _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).ThumbSticks.Left.Y > 0.3 || 
                _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).ThumbSticks.Right.Y > 0.3 || 
                IsAnyOfTheseKeboardKeysPressed(gameSettings.GetInputButtonsForFunction(InputFunctionEnum.PreviousVertical).KeyboardKeys);
        }
        public virtual bool NextVerticalButtonIsCurrentlyPressed(GameSettings gameSettings)
        {
            return _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).DPad.Down == ButtonState.Pressed || 
                _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).ThumbSticks.Left.Y < -0.3 || 
                _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).ThumbSticks.Right.Y < -0.3 || 
                IsAnyOfTheseKeboardKeysPressed(gameSettings.GetInputButtonsForFunction(InputFunctionEnum.NextVertical).KeyboardKeys);
        }
        public virtual bool PreviousHorizontalButtonIsCurrentlyPressed(GameSettings gameSettings)
        {
            return _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).DPad.Left == ButtonState.Pressed || 
                _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).ThumbSticks.Left.X < -0.3 || 
                _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).ThumbSticks.Right.X < -0.3 || 
                IsAnyOfTheseKeboardKeysPressed(gameSettings.GetInputButtonsForFunction(InputFunctionEnum.PreviousHorizontal).KeyboardKeys);
        }
        public virtual bool NextHorizontalButtonIsCurrentlyPressed(GameSettings gameSettings)
        {
            return _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).DPad.Right == ButtonState.Pressed || 
                _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).ThumbSticks.Left.X > 0.3 || 
                _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).ThumbSticks.Right.X > 0.3 || 
                IsAnyOfTheseKeboardKeysPressed(gameSettings.GetInputButtonsForFunction(InputFunctionEnum.NextHorizontal).KeyboardKeys);
        }
        public virtual bool HasMouseMoved(GameTime gameTime, GameSettings gameSettings)
        {
            return _oldMousePosition != _currentMousePosition;
        }
        public virtual bool MouseIsCurrentlyOverButtonArea(ButtonArea buttonArea, Vector2 offset, IResolution resolution)
        {
            Point mouseScreenPosition = _currentMousePosition;
            Vector2 mousePosition = resolution.ScreenToGameCoord(new Vector2(mouseScreenPosition.X, mouseScreenPosition.Y));
            Vector2 buttonAreaSize = buttonArea.GetSize();
            return mousePosition.X >= buttonArea.Position.X + offset.X && mousePosition.X <= buttonArea.Position.X + offset.X + buttonAreaSize.X && mousePosition.Y >= buttonArea.Position.Y + offset.Y && mousePosition.Y <= buttonArea.Position.Y + offset.Y + buttonAreaSize.Y;
        }
        public virtual int HorizontalValueMouseSliderButtonArea(ButtonArea buttonArea, Vector2 offset, IResolution resolution)
        {
            Point mouseScreenPosition = _currentMousePosition;
            Vector2 mousePosition = resolution.ScreenToGameCoord(new Vector2(mouseScreenPosition.X, mouseScreenPosition.Y));
            Rectangle buttonAreaSliderRect = buttonArea.GetHorizontalSliderRectangle();
            if ((int)mousePosition.X < buttonAreaSliderRect.X + (int)offset.X - buttonArea.SliderBorderLeft || (int)mousePosition.X > buttonAreaSliderRect.X + (int)offset.X + buttonAreaSliderRect.Width + buttonArea.SliderBorderRight || buttonAreaSliderRect.Width == 0)
                return -2; //TODO: This value need explaining
            else if ((int)mousePosition.X <= buttonAreaSliderRect.X + (int)offset.X)
                return -1; //TODO: This value need explaining
            else if ((int)mousePosition.X >= buttonAreaSliderRect.X + (int)offset.X + buttonAreaSliderRect.Width)
                return 101; //TODO: This value need explaining
            else
                return (int)((mousePosition.X - (buttonAreaSliderRect.X + offset.X)) / buttonAreaSliderRect.Width * 100f + 0.5f); //TODO: This value should be explained too
        }
        public virtual bool HasMouseWheelMoved()
        {
            return _currentScrollWheelValue != _oldScrollWheelValue;
        }
        public virtual bool MouseWheelUpIsCurrentlyTurned()
        {
            return _currentScrollWheelValue > _oldScrollWheelValue;
        }
        public virtual bool MouseWheelDownIsCurrentlyTurned()
        {
            return _currentScrollWheelValue < _oldScrollWheelValue;
        }
        protected bool IsAnyOfTheseKeboardKeysPressed(Keys[] keyboardKeys)
        {
            foreach (Keys key in keyboardKeys)
            {
                if (_inputConnector.GetKeyboardState().IsKeyDown(key))
                {
                    return true;
                }
            }
            return false;
        }
        protected bool IsAnyOfTheseGamePadKeysPressed(GamePadState gamePadState, Buttons[] gamePadButtons, float triggerThreshold)
        {
            if (gamePadButtons == null)
                return false;
            Buttons combinedButtons = 0;
            foreach (Buttons button in gamePadButtons)
            {
                if (button == Buttons.RightTrigger)
                {
                    if (gamePadState.Triggers.Right > triggerThreshold)
                        return true;
                }
                else if (button == Buttons.LeftTrigger)
                {
                    if (gamePadState.Triggers.Left > triggerThreshold)
                        return true;
                }
                else
                    combinedButtons |= button;
            }
            return gamePadState.IsButtonDown(combinedButtons);
        }
    }
}
