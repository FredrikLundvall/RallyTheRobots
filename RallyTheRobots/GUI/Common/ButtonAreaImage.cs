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
        protected List<string> _imageNameList = new List<string>();
        protected List<string> _rollingStateImageName = new List<string>();
        protected bool _disabledMissing = false;
        protected bool _focusedMissing = false;
        protected bool _selectedMissing = false;

        public virtual void Draw(GameTime gameTime, GraphicsDevice graphicsDevice, GameSettings gameSettings, SpriteBatch spriteBatch, Vector2 offset, Vector2 position, bool visible, bool disabled, ButtonStatusEnum status)
        {
            Vector2 imageOffset = new Vector2(0, 0);
            string buttonImageNameSuffix = GetCurrentExistingImageNameSuffix(visible, disabled, status);
            if (_imageNameList != null)
            {
                foreach (string name in _imageNameList)
                {
                    Texture2D buttonImage = _contentManager.GetImage(name + buttonImageNameSuffix);
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
        public virtual void AddRollingStatesAsImages(string rollingStateName)
        {
            _rollingStateImageName.Add(rollingStateName);
        }
        public virtual void SetImageToRollingState(string imageName, string currentRollingState)
        {
            ClearImages();
            AddImage(imageName);
            AddImage(currentRollingState);
        }
        public virtual void SetCharacterImageToRollingState(string imageName, string currentRollingState)
        {
            ClearImages();
            AddImage(imageName);
            foreach (char characterImageName in currentRollingState)
            {
                AddImage(characterImageName.ToString());
            }
        }
        public virtual void ClearImages()
        {
            _imageNameList.Clear();
        }
        public virtual void AddImage(string imageName)
        {
            _imageNameList.Add(imageName);
        }       
        protected virtual ButtonAreaImageTypeEnum GetCurrentImageTypeEnum(bool visible, bool disabled, ButtonStatusEnum status)
        {
            ButtonAreaImageTypeEnum buttonImageNameType;
            if (!visible)
                buttonImageNameType = ButtonAreaImageTypeEnum.Hidden;         
            else if (disabled && !_disabledMissing)
                buttonImageNameType = ButtonAreaImageTypeEnum.Disabled;
            else if (status == ButtonStatusEnum.Selected && !_selectedMissing)
                buttonImageNameType = ButtonAreaImageTypeEnum.Selected;
            else if ((status == ButtonStatusEnum.Focused || (status == ButtonStatusEnum.Selected && _selectedMissing)) && !_focusedMissing)
                buttonImageNameType = ButtonAreaImageTypeEnum.Focused;
            else
                buttonImageNameType = ButtonAreaImageTypeEnum.Idle;
            
            return buttonImageNameType;
        }
        protected virtual string GetCurrentImageNameSuffix(ButtonAreaImageTypeEnum buttonImageNameType)
        {
            string buttonImageNameSuffix;
            if (buttonImageNameType == ButtonAreaImageTypeEnum.Hidden)
                buttonImageNameSuffix = null;
            else if (buttonImageNameType == ButtonAreaImageTypeEnum.Disabled)
                buttonImageNameSuffix = "_disabled";
            else if (buttonImageNameType == ButtonAreaImageTypeEnum.Focused)
                buttonImageNameSuffix = "_focused";
            else if (buttonImageNameType == ButtonAreaImageTypeEnum.Selected)
                buttonImageNameSuffix = "_selected";
            else
                buttonImageNameSuffix = "_idle";
            return buttonImageNameSuffix;
        }
        private string GetCurrentExistingImageNameSuffix(bool visible, bool disabled, ButtonStatusEnum status)
        {
            ButtonAreaImageTypeEnum imageType = GetCurrentImageTypeEnum(visible, disabled, status);
            string buttonImageNameSuffix = GetCurrentImageNameSuffix(imageType); ;
            //Check if texture exists
            while (imageType == ButtonAreaImageTypeEnum.Disabled || imageType == ButtonAreaImageTypeEnum.Focused || imageType == ButtonAreaImageTypeEnum.Selected)
            {
                if (_contentManager.GetImage(_imageNameList[0] + buttonImageNameSuffix) == null)
                {
                    if (imageType == ButtonAreaImageTypeEnum.Disabled)
                        _disabledMissing = true;
                    else if (imageType == ButtonAreaImageTypeEnum.Focused)
                        _focusedMissing = true;
                    else if (imageType == ButtonAreaImageTypeEnum.Selected)
                        _selectedMissing = true;
                    else
                        break;
                    imageType = GetCurrentImageTypeEnum(visible, disabled, status);
                    buttonImageNameSuffix = GetCurrentImageNameSuffix(imageType);
                }
                else
                    break;
            }
            return buttonImageNameSuffix;
        }
        public virtual Vector2 GetSize(bool visible, bool disabled, ButtonStatusEnum status)
        {
            Vector2 size = new Vector2(0, 0);
            if (_imageNameList != null && _imageNameList.Count > 0)
            {
                string buttonImageNameSuffix = GetCurrentExistingImageNameSuffix(visible, disabled, status);
                foreach (string name in _imageNameList)
                {
                    Texture2D buttonImage = _contentManager.GetImage(name + buttonImageNameSuffix);
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
            foreach (string imageName in _imageNameList)
            {
                _contentManager.AddImage(imageName + "_idle");
                _contentManager.AddImage(imageName + "_focused");
                _contentManager.AddImage(imageName + "_selected");
                _contentManager.AddImage(imageName + "_disabled");
            }
            foreach (string imageName in _rollingStateImageName)
            {
                _contentManager.AddImage(imageName + "_idle");
                _contentManager.AddImage(imageName + "_focused");
                _contentManager.AddImage(imageName + "_selected");
                _contentManager.AddImage(imageName + "_disabled");
            }
        }
    }
}
