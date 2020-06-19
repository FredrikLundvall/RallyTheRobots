using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RallyTheRobots
{
    public class Screen
    {
        protected Vector2 _zeroPosition;
        protected Texture2D _background;
        public Screen()
        {
            _zeroPosition = new Vector2(0, 0);
        }
        public virtual void LoadContent(GraphicsDevice graphicsDevice)
        {
        }
        public virtual void EnterScreen()
        {         
        }
        public virtual void LeaveScreen()
        {
        }
        public virtual void Update(ScreenManager manager, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
        }
        public virtual void Draw(GameTime gameTime, GraphicsDevice graphicsDevice, GameSettings gameSettings, SpriteBatch spriteBatch)
        {
        }
    }
}
