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
        protected int _masterVolume = 100;
        protected int _musicVolume = 1080;
        protected float _triggerThreshold = 0.3f;
        protected PlayerIndex _gamePadPlayerIndex = PlayerIndex.One;
        protected Dictionary<InputFunctionEnum, InputButtonSetting> _inputButtonsForFunction = new Dictionary<InputFunctionEnum, InputButtonSetting>()
        {
            {InputFunctionEnum.PrimarySelect, new InputButtonSetting { KeyboardKeys = new Keys[] { Keys.Enter, Keys.E }, GamepadButtons = new Buttons[] {Buttons.A, Buttons.RightShoulder, Buttons.RightTrigger } } },
            {InputFunctionEnum.AlternateSelect, new InputButtonSetting { KeyboardKeys = new Keys[] { Keys.Space, Keys.F } } },
            {InputFunctionEnum.PreviousVertical, new InputButtonSetting { KeyboardKeys = new Keys[] { Keys.Up, Keys.W } } },
            {InputFunctionEnum.NextVertical, new InputButtonSetting { KeyboardKeys = new Keys[] { Keys.Down, Keys.S } } },
            {InputFunctionEnum.PreviousHorizontal, new InputButtonSetting { KeyboardKeys = new Keys[] { Keys.Left, Keys.A } } },
            {InputFunctionEnum.NextHorizontal, new InputButtonSetting { KeyboardKeys = new Keys[] { Keys.Right, Keys.D } } },
            {InputFunctionEnum.GoBack, new InputButtonSetting { KeyboardKeys = new Keys[] { Keys.Escape } } },
            {InputFunctionEnum.Pause, new InputButtonSetting { KeyboardKeys = new Keys[] { Keys.Escape }, GamepadButtons = new Buttons[] { Buttons.Start } } }
        };
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
        public void SetMasterVolume(int masterVolume)
        {
             _masterVolume = masterVolume;
        }
        public int GetMasterVolume()
        {
            return _masterVolume;
        }
        public void SetMusicVolume(int musicVolume)
        {
            _musicVolume = musicVolume;
        }
        public int GetMusicVolume()
        {
            return _musicVolume;
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
        public float GetTriggerThreshold()
        {
            return _triggerThreshold;
        }
    }
}
