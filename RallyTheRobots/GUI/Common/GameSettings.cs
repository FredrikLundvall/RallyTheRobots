using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace RallyTheRobots.GUI.Common
{
    public class GameSettings
    {
        protected bool _graphicsChanged = false;
        protected bool _fullscreen = true;
        protected int _width = 1920;
        protected int _height = 1080;
        protected Keys[] _keyboardKeysForSelect = new Keys[] {Keys.Enter, Keys.E};
        protected PlayerIndex _gamePadPlayerIndex = PlayerIndex.One;
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
        public void SetKeyboardKeysForSelect(Keys[] keyboardKeysForSelect)
        {
            _keyboardKeysForSelect = keyboardKeysForSelect;
        }
        public Keys[] GetKeyboardKeysForSelect()
        {
            return _keyboardKeysForSelect;
        }
    }
}
