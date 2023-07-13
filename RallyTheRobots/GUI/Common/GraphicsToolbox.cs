using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace RallyTheRobots.GUI.Common
{
    public static class GraphicsToolbox
    {
        public static void DrawFrame(SpriteBatch spriteBatch, ContentManager contentManager, Rectangle frame, string topLeft, string top, string topRight, string left, string bottomLeft, string bottom, string bottomRight, string right)
        {
            Texture2D topLeftTexture = contentManager.GetTexture2D(topLeft);
            if (topLeftTexture != null)
                spriteBatch.Draw(topLeftTexture, new Vector2(frame.Left, frame.Top), Color.White);

            //Repeat this draw and limit it
            Texture2D topTexture = contentManager.GetTexture2D(top);
            if (topTexture != null)
                spriteBatch.Draw(topTexture, new Vector2(frame.Left + topLeftTexture.Width, frame.Top), Color.White);

            Texture2D topRightTexture = contentManager.GetTexture2D(topRight);
            if (topRightTexture != null)
                spriteBatch.Draw(topRightTexture, new Vector2(frame.Right, frame.Top), Color.White);

            //Repeat this draw and limit it
            Texture2D leftTexture = contentManager.GetTexture2D(left);
            if (leftTexture != null)
                spriteBatch.Draw(leftTexture, new Vector2(frame.Left, frame.Top + topRightTexture.Height), Color.White);

            Texture2D bottomLeftTexture = contentManager.GetTexture2D(bottomLeft);
            if (bottomLeftTexture != null)
                spriteBatch.Draw(bottomLeftTexture, new Vector2(frame.Left, frame.Bottom), Color.White);

            //Repeat this draw and limit it
            Texture2D bottomTexture = contentManager.GetTexture2D(bottom);
            if (bottomTexture != null)
                spriteBatch.Draw(bottomTexture, new Vector2(frame.Left + bottomLeftTexture.Width, frame.Bottom), Color.White);

            Texture2D bottomRightTexture = contentManager.GetTexture2D(bottomRight);
            if (bottomRightTexture != null)
                spriteBatch.Draw(bottomRightTexture, new Vector2(frame.Right, frame.Bottom), Color.White);

            //Repeat this draw and limit it
            Texture2D rightTexture = contentManager.GetTexture2D(right);
            if (rightTexture != null)
                spriteBatch.Draw(rightTexture, new Vector2(frame.Right, frame.Top + rightTexture.Height), Color.White);
        }
    }
}
