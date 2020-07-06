using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots
{
    public class ButtonAreaImage
    {
        internal ContentManager _contentManager;
        protected List<string> _idleImageName = new List<string>();
        protected List<string> _disabledImageName = new List<string>();
        protected List<string> _focusedImageName = new List<string>();
        protected List<string> _selectedImageName = new List<string>();
        protected List<string> _rollingStateImageName = new List<string>();

        public virtual void Draw(GameTime gameTime, GraphicsDevice graphicsDevice, GameSettings gameSettings, SpriteBatch spriteBatch, Vector2 offset, Vector2 position, bool visible, bool disabled, ButtonStatusEnum status)
        {
            Vector2 imageOffset = new Vector2(0, 0);
            List<string> currentImageNameList = GetCurrentImageNameList(visible, disabled, status);
            if (currentImageNameList != null)
            {
                foreach (string name in currentImageNameList)
                {
                    Texture2D buttonImage = _contentManager.GetImage(name);
                    if (buttonImage != null)
                    {
                        spriteBatch.Draw(buttonImage, position + offset + imageOffset, Color.White);
                        imageOffset.X = imageOffset.X + buttonImage.Width;
                    }
                }
            }
        }
        internal void SetContentManager(ContentManager contentManager)
        {
            if (_contentManager == null)
                _contentManager = contentManager;
        }
        public virtual void AddRollingStatesAsSuffixedImages(string[] rollingState, string idleSuffix = "_idle", string focusedSuffix = "_focused", string selectedSuffix = "_selected", string disabledSuffix = "_disabled")
        {
            foreach (string stateName in rollingState)
            {
                _rollingStateImageName.Add(stateName + idleSuffix);
                _rollingStateImageName.Add(stateName + focusedSuffix);
                _rollingStateImageName.Add(stateName + selectedSuffix);
                _rollingStateImageName.Add(stateName + disabledSuffix);
            }
        }
        public virtual void SetImageToRollingState(string imageName, string currentRollingState)
        {
            ClearImages();
            AddSuffixedImage(imageName);
            AddSuffixedImage(currentRollingState);
        }
        public virtual void ClearImages()
        {
            _idleImageName.Clear();
            _disabledImageName.Clear();
            _focusedImageName.Clear();
            _selectedImageName.Clear();
        }
        public virtual void AddSuffixedImage(string imageName, string idleSuffix = "_idle", string focusedSuffix = "_focused", string selectedSuffix = "_selected", string disabledSuffix = "_disabled")
        {
            _idleImageName.Add(imageName + idleSuffix);
            _focusedImageName.Add(imageName + focusedSuffix);
            _selectedImageName.Add(imageName + selectedSuffix);
            _disabledImageName.Add(imageName + disabledSuffix);
        }
        public virtual void AddIdleImage(string imageName)
        {
            _idleImageName.Add(imageName);
        }
        public virtual void AddFocusedImage(string imageName)
        {
            _focusedImageName.Add(imageName);
        }
        public virtual void AddSelectedImage(string imageName)
        {
            _selectedImageName.Add(imageName);
        }
        public virtual void AddDisabledImage(string imageName)
        {
            _disabledImageName.Add(imageName);
        }
        protected virtual List<string> GetCurrentImageNameList(bool visible, bool disabled, ButtonStatusEnum status)
        {
            List<string> buttonImageNameList = null;
            if (visible)
            {
                if (disabled)
                    buttonImageNameList = _disabledImageName;
                else if (status == ButtonStatusEnum.Focused)
                    buttonImageNameList = _focusedImageName;
                else if (status == ButtonStatusEnum.Selected)
                    buttonImageNameList = _selectedImageName;
                if (buttonImageNameList == null || buttonImageNameList.Count == 0)
                    buttonImageNameList = _idleImageName;
            }
            return buttonImageNameList;
        }
        public virtual Vector2 GetSize(bool visible, bool disabled, ButtonStatusEnum status)
        {
            Vector2 size = new Vector2(0, 0);
            List<string> currentImageNameList = GetCurrentImageNameList(visible, disabled, status);
            if (currentImageNameList != null)
            {
                foreach (string name in currentImageNameList)
                {
                    Texture2D buttonImage = _contentManager.GetImage(name);
                    if (buttonImage != null)
                    {
                        size.Y = (buttonImage.Height > size.Y) ? buttonImage.Height : size.Y;
                        size.X = size.X + buttonImage.Width;
                    }
                }
            }
            return size;
        }
        public virtual void Initialize()
        {
            foreach (string imageName in _idleImageName)
                _contentManager.AddImage(imageName);
            foreach (string imageName in _focusedImageName)
                _contentManager.AddImage(imageName);
            foreach (string imageName in _selectedImageName)
                _contentManager.AddImage(imageName);
            foreach (string imageName in _disabledImageName)
                _contentManager.AddImage(imageName);
            foreach (string imageName in _rollingStateImageName)
                _contentManager.AddImage(imageName);
        }
    }
}
