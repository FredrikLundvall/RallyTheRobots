using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

namespace RallyTheRobots
{
    public class ContentManager
    {
        List<string> _imageNameList = new List<string>();
        Dictionary<string, Texture2D> _imageList = new Dictionary<string, Texture2D>();
        public void AddImage(string name)
        {
            _imageNameList.Add(name);
        }
        public Texture2D GetImage(string name)
        {
            Texture2D image = null;
            if (name != null)
                _imageList.TryGetValue(name, out image);
            return image;
        }
        public virtual void Initialize()
        {
        }
        public virtual void LoadContent(GraphicsDevice graphicsDevice)
        {
            FileStream tempstream;
            foreach (string name in _imageNameList)
            {
                if (name != "" & File.Exists("Content\\" + name))
                {
                    tempstream = new FileStream("Content\\" + name, FileMode.Open);
                    _imageList[name] = Texture2D.FromStream(graphicsDevice, tempstream);
                    tempstream.Close();
                }
            }
        }
    }
}
