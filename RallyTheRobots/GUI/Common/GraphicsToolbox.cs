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
            Texture2D topTexture = contentManager.GetTexture2D(top);
            Texture2D topRightTexture = contentManager.GetTexture2D(topRight);
            Texture2D leftTexture = contentManager.GetTexture2D(left);
            Texture2D bottomLeftTexture = contentManager.GetTexture2D(bottomLeft);
            Texture2D bottomTexture = contentManager.GetTexture2D(bottom);
            Texture2D rightTexture = contentManager.GetTexture2D(right);
            Texture2D bottomRightTexture = contentManager.GetTexture2D(bottomRight);
            int topLeftWidth = 0;
            int topLeftHeight = 0;
            int topRightWidth = 0;
            int topRightHeight = 0;
            int bottomLeftWidth = 0;
            int bottomLeftHeight = 0;
            int bottomRightWidth = 0;
            int bottomRightHeight = 0;
            //Top left corner
            if (topLeftTexture != null)
            {
                topLeftWidth = topLeftTexture.Width;
                topLeftHeight = topLeftTexture.Height;
            }
            //Top right corner
            if (topRightTexture != null)
            {
                topRightWidth = topRightTexture.Width;
                topRightHeight = topRightTexture.Height;
            }
            //Bottom left corner
            if (bottomLeftTexture != null)
            {
                bottomLeftWidth = bottomLeftTexture.Width;
                bottomLeftHeight = bottomLeftTexture.Height;
            }
            //Bottom right corner
            if (bottomRightTexture != null)
            {
                bottomRightWidth = bottomRightTexture.Width;
                bottomRightHeight = bottomRightTexture.Height;
            }
            //Top line
            if (topTexture != null)
            {
                //Repeat this draw and limit it. Flip every other horizontally 
                SpriteEffects flip = SpriteEffects.None;
                Rectangle? limit = null;
                for (int x = frame.Left + topLeftWidth; x + topRightWidth < frame.Right; x += topTexture.Width)
                {
                    if (x + topTexture.Width > frame.Right - topRightWidth)
                        limit = new Rectangle(0, 0, topTexture.Width - (topTexture.Width - (frame.Right - topRightWidth - x)), topTexture.Height);
                    spriteBatch.Draw(topTexture, new Vector2(x, frame.Top), limit, Color.White, 0f, new Vector2(0, 0), 1.0f, flip, 0f);
                    flip = (flip == SpriteEffects.None) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
                }
            }
            //Bottom line
            if (bottomTexture != null)
            {
                //Repeat this draw and limit it. Flip every other horizontally 
                SpriteEffects flip = SpriteEffects.None;
                Rectangle? limit = null;
                for (int x = frame.Left + bottomLeftWidth; x + bottomRightWidth < frame.Right; x += bottomTexture.Width)
                {
                    if (x + bottomTexture.Width > frame.Right - bottomRightWidth)
                        limit = new Rectangle(0, 0, topTexture.Width - (topTexture.Width - (frame.Right - topRightWidth - x)), topTexture.Height);
                    spriteBatch.Draw(bottomTexture, new Vector2(x, frame.Bottom - bottomTexture.Height), limit, Color.White, 0f, new Vector2(0, 0), 1.0f, flip, 0f);
                    flip = (flip == SpriteEffects.None) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
                }
            }
            //Left line
            if (leftTexture != null)
            {
                //Repeat this draw and limit it. Flip every other vertically 
                SpriteEffects flip = SpriteEffects.None;
                Rectangle? limit = null;
                for (int y = frame.Top + topLeftHeight; y + bottomLeftHeight < frame.Bottom; y += leftTexture.Height)
                {
                    if (y + leftTexture.Height > frame.Bottom - bottomLeftHeight)
                        limit = new Rectangle(0, 0, leftTexture.Width, leftTexture.Height - (leftTexture.Height - (frame.Bottom - bottomLeftHeight - y)));
                    spriteBatch.Draw(leftTexture, new Vector2(frame.Left, y), limit, Color.White, 0f, new Vector2(0, 0), 1.0f, flip, 0f);
                    flip = (flip == SpriteEffects.None) ? SpriteEffects.FlipVertically : SpriteEffects.None;
                }
            }
            //Right line
            if (rightTexture != null)
            {
                //Repeat this draw and limit it. Flip every other vertically 
                SpriteEffects flip = SpriteEffects.None;
                Rectangle? limit = null;
                for (int y = frame.Top + topRightHeight; y + bottomRightHeight < frame.Bottom; y += rightTexture.Height)
                {
                    if (y + rightTexture.Height > frame.Bottom - bottomRightHeight)
                        limit = new Rectangle(0, 0, rightTexture.Width, rightTexture.Height - (rightTexture.Height - (frame.Bottom - bottomRightHeight - y)));
                    spriteBatch.Draw(rightTexture, new Vector2(frame.Right - rightTexture.Width, y), limit, Color.White, 0f, new Vector2(0, 0), 1.0f, flip, 0f);
                    flip = (flip == SpriteEffects.None) ? SpriteEffects.FlipVertically : SpriteEffects.None;
                }
            }
            //Top left corner
            if (topLeftTexture != null)
            {
                spriteBatch.Draw(topLeftTexture, new Vector2(frame.Left, frame.Top), Color.White);
            }
            //Top right corner
            if (topRightTexture != null)
            {
                spriteBatch.Draw(topRightTexture, new Vector2(frame.Right - topRightTexture.Width, frame.Top), Color.White);
            }
            //Bottom left corner
            if (bottomLeftTexture != null)
            {
                spriteBatch.Draw(bottomLeftTexture, new Vector2(frame.Left, frame.Bottom - bottomLeftTexture.Height), Color.White);
            }
            //Bottom right corner
            if (bottomRightTexture != null)
            {
                spriteBatch.Draw(bottomRightTexture, new Vector2(frame.Right - bottomRightTexture.Width, frame.Bottom - bottomRightTexture.Height), Color.White);
            }
        }
        public static void DrawBitmap(SpriteBatch spriteBatch, ContentManager contentManager, Vector2 position, int width, int height, string blackPixel, string whitePixel, string bluePixel, string redPixel, string yellowPixel, string greenPixel, string grayPixel, string purplePixel, int currentRow)
        {
            Texture2D blackPixelTexture = contentManager.GetTexture2D(blackPixel);
            Texture2D whitePixelTexture = contentManager.GetTexture2D(whitePixel);
            Texture2D bluePixelTexture = contentManager.GetTexture2D(bluePixel);
            Texture2D redPixelTexture = contentManager.GetTexture2D(redPixel);
            Texture2D yellowPixelTexture = contentManager.GetTexture2D(yellowPixel);
            Texture2D greenPixelTexture = contentManager.GetTexture2D(greenPixel);
            Texture2D grayPixelTexture = contentManager.GetTexture2D(grayPixel);
            Texture2D purplePixelTexture = contentManager.GetTexture2D(purplePixel);
            Random ran = new Random(42);

            //Scroll forward in the "memory"
            for(int i = 0; i < currentRow * width; i++)
            {
                ran.Next(0, 2);
                ran.Next(0, 2);
                ran.Next(0, 2);
            }

            if (whitePixelTexture != null)
            {
                int pixelWidth = blackPixelTexture.Width;
                int pixelHeight = blackPixelTexture.Height;
                SpriteEffects flip = SpriteEffects.None;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int colour = ran.Next(0, 8);
                        int flipHoriz = ran.Next(0, 2);
                        int flipVert = ran.Next(0, 2);
                        Texture2D texture = blackPixelTexture;
                        flip = SpriteEffects.None;
                        if (flipHoriz == 1)
                            flip |= SpriteEffects.FlipHorizontally;
                        if (flipVert == 1)
                            flip |= SpriteEffects.FlipVertically;
                        if (colour == 0)
                            texture = blackPixelTexture;
                        else if (colour == 1)
                            texture = whitePixelTexture;
                        else if (colour == 2)
                            texture = bluePixelTexture;
                        else if (colour == 3)
                            texture = redPixelTexture;
                        else if (colour == 4)
                            texture = yellowPixelTexture;
                        else if (colour == 5)
                            texture = greenPixelTexture;
                        else if (colour == 6)
                            texture = grayPixelTexture;
                        else if (colour == 7)
                            texture = purplePixelTexture;

                        spriteBatch.Draw(texture, new Vector2(position.X + x * pixelWidth, position.Y + y * pixelHeight), null, Color.White, 0f, new Vector2(0, 0), 1.0f, flip, 0f);
                    }
                }
            }
        }
    }
}
