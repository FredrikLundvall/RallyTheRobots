﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RallyTheRobots
{
    public class ScreenManager
    {
        public readonly ContentManager ContentManager;
        protected Screen _currentScreen;
        protected List<Screen> _screenList= new List<Screen>(20);
        public bool ButtonForSelectIsHeldDown = false;
        public ScreenManager(ContentManager contentManager)
        {
            ContentManager = contentManager;
        }
        public virtual void AddScreen(Screen aScreen)
        {
            _screenList.Add(aScreen);
        }
        public virtual void Initialize()
        {
            ContentManager.Initialize();
            InitializeScreens();
            //Setup the starting screen
            _currentScreen = _screenList[0];
            _currentScreen.EnterScreen(new GameTime());
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
                if(screen is T)
                    return screen;
            }
            return null;
        }
        public virtual void LoadContent(GraphicsDevice graphicsDevice)
        {
            ContentManager.LoadContent(graphicsDevice);
            foreach (Screen screen in _screenList)
            {
                screen.LoadContent(graphicsDevice);
            }
        }
        public virtual void Update(GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            _currentScreen.Update(this, gameTime, gameSettings, gameStatus);
        }
        public virtual void ChangeScreen(GameTime gameTime, Screen newScreen)
        {
            _currentScreen.LeaveScreen();
            _currentScreen = newScreen;
            _currentScreen.EnterScreen(gameTime);
        }
        public virtual void Draw(GameTime gameTime, GraphicsDevice graphicsDevice, GameSettings gameSettings, SpriteBatch spriteBatch)
        {
            _currentScreen.Draw(gameTime, graphicsDevice, gameSettings, spriteBatch);
        }
    }
}