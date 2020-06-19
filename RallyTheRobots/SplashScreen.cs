using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace RallyTheRobots
{
    public class SplashScreen : Screen
    {
        private StartMenuScreen _startMenuScreen;
        public SplashScreen(StartMenuScreen startMenuScreen) : base()
        {
            _startMenuScreen = startMenuScreen;
        }
        public override void LoadContent(GraphicsDevice graphicsDevice)
        {
            base.LoadContent(graphicsDevice);
            FileStream tempstream;

            tempstream = new FileStream("Content\\splash.png", FileMode.Open);
            _background = Texture2D.FromStream(graphicsDevice, tempstream);
            tempstream.Close();

        }
        public override void Update(ScreenManager manager, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            base.Update(manager, gameTime, gameSettings, gameStatus);
            
            if (gameTime.TotalGameTime.Seconds > 6 || Keyboard.GetState().GetPressedKeys().GetLength(0) > 0 || GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed || GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed || GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed || GamePad.GetState(PlayerIndex.One).Buttons.Y == ButtonState.Pressed || Mouse.GetState().LeftButton == ButtonState.Pressed || Mouse.GetState().RightButton == ButtonState.Pressed)
                manager.ChangeScreen(_startMenuScreen);
        }
        public override void Draw(GameTime gameTime, GraphicsDevice graphicsDevice, GameSettings gameSettings, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, graphicsDevice, gameSettings, spriteBatch);
            spriteBatch.Draw(_background, _zeroPosition, Color.White);
        }
    }
}