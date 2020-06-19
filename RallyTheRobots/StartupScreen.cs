﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace RallyTheRobots
{
    public class StartupScreen : Screen
    {
        SplashScreen _splashScreen;
        public StartupScreen(SplashScreen splashScreen) : base()
        {
            _splashScreen = splashScreen;
        }
        public override void LoadContent(GraphicsDevice graphicsDevice)
        {
            base.LoadContent(graphicsDevice);
            FileStream tempstream;

            tempstream = new FileStream("Content\\startup.png", FileMode.Open);
            _background = Texture2D.FromStream(graphicsDevice, tempstream);
            tempstream.Close();

        }
        public override void Update(ScreenManager manager, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            base.Update(manager, gameTime, gameSettings, gameStatus);
            if(gameTime.TotalGameTime.Seconds > 3)
                manager.ChangeScreen(_splashScreen);
        }
        public override void Draw(GameTime gameTime, GraphicsDevice graphicsDevice, GameSettings gameSettings, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, graphicsDevice, gameSettings, spriteBatch);
            spriteBatch.Draw(_background, _zeroPosition, Color.White);
        }
    }
}
