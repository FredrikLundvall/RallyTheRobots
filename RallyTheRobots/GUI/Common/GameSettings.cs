using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace RallyTheRobots.GUI.Common
{
    public class GameSettings
    {
        protected bool _graphicsChanged = false;
        protected bool _fullscreen = true;
        protected int _width = 1920;
        protected int _height = 1080;
        protected PlayerIndex _gamePadPlayerIndex = PlayerIndex.One;
        protected Dictionary<InputFunctionEnum, InputButtonSetting> _inputButtonsForFunction = new Dictionary<InputFunctionEnum, InputButtonSetting>()
        {
            {InputFunctionEnum.PrimarySelect, new InputButtonSetting { KeyboardKeys = new Keys[] { Keys.Enter, Keys.E }, GamepadButtons = new Buttons[] {Buttons.A, Buttons.RightShoulder, Buttons.RightTrigger } } },
            {InputFunctionEnum.AlternateSelect, new InputButtonSetting { KeyboardKeys = new Keys[] { Keys.Back, Keys.F } } },
            {InputFunctionEnum.PreviousVertical, new InputButtonSetting { KeyboardKeys = new Keys[] { Keys.Up, Keys.W } } },
            {InputFunctionEnum.NextVertical, new InputButtonSetting { KeyboardKeys = new Keys[] { Keys.Down, Keys.S } } },
            {InputFunctionEnum.PreviousHorizontal, new InputButtonSetting { KeyboardKeys = new Keys[] { Keys.Left, Keys.A } } },
            {InputFunctionEnum.NextHorizontal, new InputButtonSetting { KeyboardKeys = new Keys[] { Keys.Right, Keys.D } } },
            {InputFunctionEnum.GoBack, new InputButtonSetting { KeyboardKeys = new Keys[] { Keys.Escape } } }
        };
        //protected GamePadButtons
        //protected Keys[] _keyboardKeysForSelect = new Keys[] {Keys.Enter, Keys.E};
        //protected Keys[] _keyboardKeysForAlternateSelect = new Keys[] { Keys.Back, Keys.F };
        //protected Keys[] _keyboardKeysForPreviousVertical = new Keys[] { Keys.Up, Keys.W };
        //protected Keys[] _keyboardKeysForNextVertical = new Keys[] { Keys.Down, Keys.S };
        //protected Keys[] _keyboardKeysForPreviousHorizontal = new Keys[] { Keys.Left, Keys.A };
        //protected Keys[] _keyboardKeysForNextHorizontal = new Keys[] { Keys.Right, Keys.D };
        //protected Keys[] _keyboardKeysForGoBack = new Keys[] { Keys.Escape };
        public void SetFullscreen(bool fullscreen)
        {
            _graphicsChanged = _graphicsChanged || fullscreen != _fullscreen;
            _fullscreen = fullscreen;
        }
        public bool GetFullscreen()
        {
            return _fullscreen;
        }
        public bool IsGraphicsChanged()
        {
            return _graphicsChanged;
        }
        public void GraphicsChangeApplied()
        {
            _graphicsChanged = false;
        }
        public void SetWidth(int width)
        {
            _graphicsChanged = _graphicsChanged || width != _width;
            _width = width;
        }
        public void SetHeight(int height)
        {
            _graphicsChanged = _graphicsChanged || height != _height;
            _height = height;
        }
        public int GetWidth()
        {
            return _width;
        }
        public int GetHeight()
        {
            return _height;
        }
        public PlayerIndex GetGamePadPlayerIndex()
        {
            return _gamePadPlayerIndex;
        }
        public void SetGamePadPlayerIndex(PlayerIndex gamePadPlayerIndex)
        {
            _gamePadPlayerIndex = gamePadPlayerIndex;
        }
        public void SetInputButtonsForFunction(InputFunctionEnum inputFunction, InputButtonSetting inputButtonsForSelect)
        {
            _inputButtonsForFunction[inputFunction] = inputButtonsForSelect;
        }
        public InputButtonSetting GetInputButtonsForFunction(InputFunctionEnum inputFunction)
        {
            return _inputButtonsForFunction[inputFunction];
        }
        //public void SetKeyboardKeysForSelect(Keys[] keyboardKeysForSelect)
        //{
        //    _keyboardKeysForSelect = keyboardKeysForSelect;
        //}
        //public Keys[] GetKeyboardKeysForSelect()
        //{
        //    return _keyboardKeysForSelect;
        //}
        //public void SetKeyboardKeysForAlternateSelect(Keys[] keyboardKeysForAlternateSelect)
        //{
        //    _keyboardKeysForAlternateSelect = keyboardKeysForAlternateSelect;
        //}
        //public Keys[] GetKeyboardKeysForAlternateSelect()
        //{
        //    return _keyboardKeysForAlternateSelect;
        //}
        //public void SetKeyboardKeysForPreviousVertical(Keys[] keyboardKeysForPreviousVertical)
        //{
        //    _keyboardKeysForPreviousVertical = keyboardKeysForPreviousVertical;
        //}
        //public Keys[] GetKeyboardKeysForPreviousVertical()
        //{
        //    return _keyboardKeysForPreviousVertical;
        //}
        //public void SetKeyboardKeysForNextVertical(Keys[] keyboardKeysForNextVertical)
        //{
        //    _keyboardKeysForNextVertical = keyboardKeysForNextVertical;
        //}
        //public Keys[] GetKeyboardKeysForNextVertical()
        //{
        //    return _keyboardKeysForNextVertical;
        //}
        //public void SetKeyboardKeysForPreviousHorizontal(Keys[] keyboardKeysForPreviousHorizontal)
        //{
        //    _keyboardKeysForPreviousHorizontal = keyboardKeysForPreviousHorizontal;
        //}
        //public Keys[] GetKeyboardKeysForPreviousHorizontal()
        //{
        //    return _keyboardKeysForPreviousHorizontal;
        //}
        //public void SetKeyboardKeysForNextHorizontal(Keys[] keyboardKeysForNextHorizontal)
        //{
        //    _keyboardKeysForNextHorizontal = keyboardKeysForNextHorizontal;
        //}
        //public Keys[] GetKeyboardKeysForNextHorizontal()
        //{
        //    return _keyboardKeysForNextHorizontal;
        //}
        //public void SetKeyboardKeysForGoBack(Keys[] keyboardKeysForGoBack)
        //{
        //    _keyboardKeysForGoBack = keyboardKeysForGoBack;
        //}
        //public Keys[] GetKeyboardKeysForGoBack()
        //{
        //    return _keyboardKeysForGoBack;
        //}
    }
}
