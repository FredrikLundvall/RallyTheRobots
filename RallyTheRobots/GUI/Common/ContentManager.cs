using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

namespace RallyTheRobots.GUI.Common
{
    public class ContentManager
    {
        List<string> _texture2DNameList = new List<string>();
        Dictionary<string, Texture2D> _texture2DList = new Dictionary<string, Texture2D>();
        public void AddTexture2D(string name)
        {
            _texture2DNameList.Add(name);
        }
        public Texture2D GetTexture2D(string name)
        {
            Texture2D image = null;
            if (name != null)
                _texture2DList.TryGetValue(name, out image);
            return image;
        }
        public virtual void Initialize()
        {
        }
        public virtual void LoadContent(GraphicsDevice graphicsDevice)
        {
            FileStream tempstream;
            foreach (string name in _texture2DNameList)
            {
                if (name != "" & File.Exists("Content\\" + name + ".png"))
                {
                    tempstream = new FileStream("Content\\" + name + ".png", FileMode.Open);
                    _texture2DList[name] = Texture2D.FromStream(graphicsDevice, tempstream);
                    tempstream.Close();
                }
            }
        }
    }
}
