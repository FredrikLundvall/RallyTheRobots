using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using MemDumpDigger;
using Microsoft.Xna.Framework;

namespace RallyTheRobots
{
    public class ImageToStream
    {
        public static void WriteImageToFile(GraphicsDevice graphicsDevice, String inputFileName, String outputFileName)
        {
            if (inputFileName != "" & File.Exists(inputFileName) && outputFileName != "")
            {
                FileStream inputStream = new FileStream(inputFileName, FileMode.Open, FileAccess.Read);
                Texture2D image = Texture2D.FromStream(graphicsDevice, inputStream);
                Color[] colors = new Color[image.Width * image.Height];
                image.GetData(colors);
                inputStream.Close();
                FileStream outputStream = new FileStream(outputFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BitmapFinder bitmapFinder = new BitmapFinder(outputStream);
                bitmapFinder.Width = (uint) image.Width;
                bitmapFinder.Height = (uint) image.Height;
                bitmapFinder.PixelBits = 1;
                bitmapFinder.UsePalette = true;
                bitmapFinder.PaletteColor.Add(0, Color.Black);
                bitmapFinder.PaletteColor.Add(1, Color.White);
                bitmapFinder.WriteFileFromArrayOfColors(colors, 0);
            }
        }
    }
}
