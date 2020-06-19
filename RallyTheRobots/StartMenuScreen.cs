using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace RallyTheRobots
{
    public class StartMenuScreen : Screen
    {
        //SplashScreen _splashScreen;
        public StartMenuScreen() : base()
        {
            //_splashScreen = splashScreen;
        }
        public override void LoadContent(GraphicsDevice graphicsDevice)
        {
            base.LoadContent(graphicsDevice);
            FileStream tempstream;

            tempstream = new FileStream("Content\\startmenu.png", FileMode.Open);
            _background = Texture2D.FromStream(graphicsDevice, tempstream);
            tempstream.Close();

        }
        public override void Update(ScreenManager manager, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            base.Update(manager, gameTime, gameSettings, gameStatus);
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                gameStatus.RunningStatus = RunningStatusEnum.Exiting;
        }
        public override void Draw(GameTime gameTime, GraphicsDevice graphicsDevice, GameSettings gameSettings, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, graphicsDevice, gameSettings, spriteBatch);
            spriteBatch.Draw(_background, _zeroPosition, Color.White);
        }
    }
}
