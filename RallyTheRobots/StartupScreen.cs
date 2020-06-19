using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RallyTheRobots
{
    public class StartupScreen : Screen
    {
        public StartupScreen(ScreenEnum screenEnum) : base(screenEnum) { }
        public override ScreenEnum Update(GameTime gameTime, GameSettings gameSettings)
        {
            return _screenEnum;
        }
        public override void Draw(GameTime gameTime, GraphicsDevice graphicsDevice, GameSettings gameSettings)
        {
        }
    }
}
