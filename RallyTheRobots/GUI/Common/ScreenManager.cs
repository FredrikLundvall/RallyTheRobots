using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ResolutionBuddy;

namespace RallyTheRobots.GUI.Common
{
    public class ScreenManager
    {
        protected ContentManager _contentManager;
        protected ResolutionFactory _resolutionFactory;
        protected InputChecker _inputChecker;
        protected Screen _currentScreen;
        protected List<Screen> _screenList = new List<Screen>(20);
        public ScreenManager()
        {
        }
        internal void SetContentManager(ContentManager contentManager)
        {
            if (_contentManager == null)
                _contentManager = contentManager;
        }
        internal ContentManager GetContentManager()
        {
            return _contentManager;
        }
        internal void SetResolution(ResolutionFactory resolutionFactory)
        {
            if (_resolutionFactory == null)
                _resolutionFactory = resolutionFactory;
        }
        internal void SetInputChecker(InputChecker inputChecker)
        {
            if (_inputChecker == null)
                _inputChecker = inputChecker;
        }
        public virtual void AddScreen(Screen aScreen)
        {
            aScreen.SetContentManager(_contentManager);
            aScreen.SetScreenManager(this);
            aScreen.SetResolution(_resolutionFactory);
            aScreen.SetInputChecker(_inputChecker);
            _screenList.Add(aScreen);
        }
        public virtual void Initialize()
        {
            _inputChecker.Initialize();
            InitializeScreens();
            //Setup the starting screen
            _currentScreen = _screenList[0];
        }
        protected virtual void InitializeScreens()
        {
            foreach (Screen screen in _screenList)
            {
                screen.Initialize();
            }
        }
        public virtual Screen GetScreen<T>() where T : Screen
        {
            foreach (Screen screen in _screenList)
            {
                if (screen is T)
                    return screen;
            }
            return null;
        }
        public virtual void EnterStartScreen(GameTime gameTime, GameSettings gameSettings)
        {
            _currentScreen.EnterScreen(gameTime, gameSettings, null);
        }
        public virtual void Update(GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            _inputChecker.BeforeUpdate(gameTime, gameSettings);
            _currentScreen.Update(this, gameTime, gameSettings, gameStatus);
            _inputChecker.AfterUpdate(gameTime, gameSettings);
            if (gameSettings.IsGraphicsChanged())
            {
                _resolutionFactory.CreateResolution(gameSettings);
                gameSettings.GraphicsChangeApplied();
            }
        }
        public virtual void ChangeScreen(GameTime gameTime, GameSettings gameSettings, Screen newScreen)
        {
            if (newScreen == null)
            {
                //TODO: some kind of log here
                return;
            }
            _currentScreen.LeaveScreen(gameTime, gameSettings, newScreen);
            var oldScreen = _currentScreen;
            _currentScreen = newScreen;
            _currentScreen.EnterScreen(gameTime, gameSettings, oldScreen);
        }
        public virtual void ChangeToPreviousScreen(GameTime gameTime, GameSettings gameSettings, Screen newScreen)
        {
            if (newScreen == null)
            {
                //TODO: some kind of log here
                return;
            }
            _currentScreen.LeaveScreen(gameTime, gameSettings, newScreen);
            _currentScreen = newScreen.GetPreviousScreen();
            _currentScreen.EnterScreen(gameTime, gameSettings, _currentScreen.GetPreviousScreen());//Don't change the previous screen
        }
        public virtual void Draw(GameTime gameTime, GraphicsDevice graphicsDevice, GameSettings gameSettings, SpriteBatch spriteBatch)
        {
            _currentScreen.Draw(gameTime, graphicsDevice, gameSettings, spriteBatch);
        }
    }
}
