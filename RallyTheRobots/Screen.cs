using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RallyTheRobots
{
    public class Screen
    {
        protected readonly ScreenEnum _screenEnum;
        public Screen(ScreenEnum screenEnum)
        {
            _screenEnum = screenEnum;
        }
        public virtual void Initialize()
        {
        }
        public virtual void EnterScreen()
        {         
        }
        public virtual void LeaveScreen()
        {
        }
        public virtual ScreenEnum Update(GameTime gameTime, GameSettings gameSettings)
        {
            return _screenEnum;
        }
        public virtual void Draw(GameTime gameTime, GraphicsDevice graphicsDevice, GameSettings gameSettings)
        {
        }
    }
}
