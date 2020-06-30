using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots
{
    public class ContentManager
    {
        Dictionary<string, Texture2D> _imageList = new Dictionary<string, Texture2D>();
        public void AddImage(string name)
        {
            _imageList.Add(name, null);
        }
        public Texture2D GetImage(string name)
        {
            _imageList.TryGetValue(name, out Texture2D image);
            return image;
        }
        public virtual void Initialize()
        {
        }
        public virtual void LoadContent(GraphicsDevice graphicsDevice)
        {
            FileStream tempstream;
            foreach (string name in _imageList.Keys)
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
