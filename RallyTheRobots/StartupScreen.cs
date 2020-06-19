using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace RallyTheRobots
{
    public class StartupScreen : Screen
    {
        public StartupScreen() : base() { }
        public override void LoadContent(GraphicsDevice graphicsDevice)
        {
            base.LoadContent(graphicsDevice);
            FileStream tempstream;

            tempstream = new FileStream("Content\\startup.png", FileMode.Open);
            _background = Texture2D.FromStream(graphicsDevice, tempstream);
            tempstream.Close();

        }
        public override Screen Update(ScreenManager manager, GameTime gameTime, GameSettings gameSettings)
        {
            base.Update(manager, gameTime, gameSettings);
            return this;
        }
        public override void Draw(GameTime gameTime, GraphicsDevice graphicsDevice, GameSettings gameSettings, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, graphicsDevice, gameSettings, spriteBatch);
            spriteBatch.Draw(_background, _zeroPosition, Color.White);
        }
    }
}
