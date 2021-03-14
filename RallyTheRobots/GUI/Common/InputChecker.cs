using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ResolutionBuddy;

namespace RallyTheRobots.GUI.Common
{
    public class InputChecker
    {
        private Point _currentMousePosition;
        private Point _oldMousePosition;
        private int _currentScrollWheelValue;
        private int _oldScrollWheelValue;
        private bool _buttonForSelectIsHeldDown;
        private bool _buttonForAlternateSelectIsHeldDown;
        private bool _buttonForSelectClicked;
        private bool _buttonForAlternateSelectClicked;
        private InputConnector _inputConnector;
        public virtual void Initialize()
        {
            if (_inputConnector == null)
                _inputConnector = new InputConnector();
            _oldScrollWheelValue = _inputConnector.GetMouseState().ScrollWheelValue;
            _oldMousePosition = _inputConnector.GetMouseState().Position;
            _buttonForSelectIsHeldDown = false;
            _buttonForAlternateSelectIsHeldDown = false;
            _buttonForSelectClicked = false;
            _buttonForAlternateSelectClicked = false;
        }
        public void SetInputConnector(InputConnector inputConnector)
        {
            if (_inputConnector == null)
                _inputConnector = inputConnector;
        }
        public virtual void BeforeUpdate(GameTime gameTime, GameSettings gameSettings)
        {
            _currentScrollWheelValue = _inputConnector.GetMouseState().ScrollWheelValue;
            _currentMousePosition = _inputConnector.GetMouseState().Position;
            //Check if the button was released between the last updates
            if (!ButtonForSelectIsCurrentlyPressed(gameSettings) && !ButtonForSelectMouseIsCurrentlyPressed(gameSettings))
                _buttonForSelectIsHeldDown = false;
            _buttonForSelectClicked = false;
            if (ButtonForSelectIsCurrentlyPressed(gameSettings) || ButtonForSelectMouseIsCurrentlyPressed(gameSettings))
            {
                if (!_buttonForSelectIsHeldDown)
                {
                    _buttonForSelectIsHeldDown = true;
                    _buttonForSelectClicked = true;
                }
            }
            //Check if the alternate button was released between the last updates
            if (!ButtonForAlternateSelectIsCurrentlyPressed(gameSettings) && !ButtonForAlternateSelectMouseIsCurrentlyPressed(gameSettings))
                _buttonForAlternateSelectIsHeldDown = false;
            _buttonForAlternateSelectClicked = false;
            if (ButtonForAlternateSelectIsCurrentlyPressed(gameSettings) || ButtonForAlternateSelectMouseIsCurrentlyPressed(gameSettings))
            {
                if (!_buttonForAlternateSelectIsHeldDown)
                {
                    _buttonForAlternateSelectIsHeldDown = true;
                    _buttonForAlternateSelectClicked = true;
                }
            }
        }
        public virtual void AfterUpdate(GameTime gameTime, GameSettings gameSettings)
        {
            _oldScrollWheelValue = _currentScrollWheelValue;
            _oldMousePosition = _currentMousePosition;
        }
        public virtual bool ButtonForSelectIsCurrentlyPressed(GameSettings gameSettings)
        {
            return _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).Buttons.A == ButtonState.Pressed || _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).Triggers.Right > 0.3 || _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).Buttons.RightShoulder == ButtonState.Pressed || IsAnyOfTheseKeboardKeysPressed(gameSettings.GetKeyboardKeysForSelect());
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
        public virtual bool ButtonForAlternateSelectIsCurrentlyPressed(GameSettings gameSettings)
        {
            return _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).Buttons.B == ButtonState.Pressed || _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).Triggers.Left > 0.3 || _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).Buttons.LeftShoulder == ButtonState.Pressed || IsAnyOfTheseKeboardKeysPressed(gameSettings.GetKeyboardKeysForAlternateSelect());
        }
        public virtual bool ButtonForSelectClicked(GameSettings gameSettings)
        {
            return _buttonForSelectClicked;
        }
        public virtual bool ButtonForAlternateSelectClicked(GameSettings gameSettings)
        {
            return _buttonForAlternateSelectClicked;
        }
        public virtual bool ButtonForSelectMouseIsCurrentlyPressed(GameSettings gameSettings)
        {
            return _inputConnector.GetMouseState().LeftButton == ButtonState.Pressed;
        }
        public virtual bool ButtonForAlternateSelectMouseIsCurrentlyPressed(GameSettings gameSettings)
        {
            return _inputConnector.GetMouseState().RightButton == ButtonState.Pressed;
        }
        public virtual bool AnyButtonIsCurrentlyPressed(GameSettings gameSettings)
        {
            return _inputConnector.GetKeyboardState().GetPressedKeys().GetLength(0) > 0 || _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).Buttons.A == ButtonState.Pressed || _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).Buttons.B == ButtonState.Pressed || _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).Buttons.X == ButtonState.Pressed || _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).Buttons.Y == ButtonState.Pressed || _inputConnector.GetMouseState().LeftButton == ButtonState.Pressed || _inputConnector.GetMouseState().RightButton == ButtonState.Pressed;
        }
        public virtual bool PreviousVerticalButtonIsCurrentlyPressed(GameSettings gameSettings)
        {
            return _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).DPad.Up == ButtonState.Pressed || _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).ThumbSticks.Left.Y > 0.3 || _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).ThumbSticks.Right.Y > 0.3 || IsAnyOfTheseKeboardKeysPressed(gameSettings.GetKeyboardKeysForPreviousVertical());
        }
        public virtual bool NextVerticalButtonIsCurrentlyPressed(GameSettings gameSettings)
        {
            return _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).DPad.Down == ButtonState.Pressed || _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).ThumbSticks.Left.Y < -0.3 || _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).ThumbSticks.Right.Y < -0.3 || IsAnyOfTheseKeboardKeysPressed(gameSettings.GetKeyboardKeysForNextVertical());
        }
        public virtual bool PreviousHorizontalButtonIsCurrentlyPressed(GameSettings gameSettings)
        {
            return _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).DPad.Left == ButtonState.Pressed || _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).ThumbSticks.Left.X < -0.3 || _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).ThumbSticks.Right.X < -0.3 || IsAnyOfTheseKeboardKeysPressed(gameSettings.GetKeyboardKeysForPreviousHorizontal());
        }
        public virtual bool NextHorizontalButtonIsCurrentlyPressed(GameSettings gameSettings)
        {
            return _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).DPad.Right == ButtonState.Pressed || _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).ThumbSticks.Left.X > 0.3 || _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).ThumbSticks.Right.X > 0.3 || IsAnyOfTheseKeboardKeysPressed(gameSettings.GetKeyboardKeysForNextHorizontal());
        }
        public virtual bool GoBackButtonIsCurrentlyPressed(GameSettings gameSettings)
        {
            return _inputConnector.GetGamePadState(gameSettings.GetGamePadPlayerIndex()).Buttons.Back == ButtonState.Pressed || IsAnyOfTheseKeboardKeysPressed(gameSettings.GetKeyboardKeysForGoBack());
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
                return -2;
            else if ((int)mousePosition.X <= buttonAreaSliderRect.X + (int)offset.X)
                return -1;
            else if ((int)mousePosition.X >= buttonAreaSliderRect.X + (int)offset.X + buttonAreaSliderRect.Width)
                return 101;
            else
                return (int)((mousePosition.X - (buttonAreaSliderRect.X + offset.X)) / buttonAreaSliderRect.Width * 100f + 0.5f);
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
    }
}
