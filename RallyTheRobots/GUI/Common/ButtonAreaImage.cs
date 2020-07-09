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
        protected List<Image> _imageList = new List<Image>();
        protected List<string> _rollingStateImageName = new List<string>();
        protected bool _disabledMissing = false;
        protected bool _focusedMissing = false;
        protected bool _selectedMissing = false;

        public virtual void Draw(GameTime gameTime, GraphicsDevice graphicsDevice, GameSettings gameSettings, SpriteBatch spriteBatch, Vector2 offset, Vector2 position, bool visible, bool disabled, ButtonStatusEnum status)
        {
            Vector2 imageOffset = new Vector2(0, 0);
            string buttonImageNameSuffix = GetCurrentExistingImageNameSuffix(visible, disabled, status);
            if (_imageList != null)
            {
                for(int i= 0; i < _imageList.Count; i++)
                {
                    Image image = _imageList[i];
                    Texture2D buttonImage = _contentManager.GetImage(image.ImageName + buttonImageNameSuffix);
                    if (buttonImage != null)
                    {
                        if (image.ImageType != ButtonAreaImageTypeEnum.Slider)
                            spriteBatch.Draw(buttonImage, position + offset + imageOffset, Color.White);
                        else
                        {
                            Rectangle sliderPartVisible;
                            if (image.ImageStackDirection == ButtonAreaImageStackDirectionEnum.Horizontal)
                                sliderPartVisible = new Rectangle((buttonImage.Width * 25) / 100, 0, (buttonImage.Width * 75) / 100, buttonImage.Height);
                            else
                                sliderPartVisible = new Rectangle(0, buttonImage.Height / 2, buttonImage.Width, buttonImage.Height / 2);
                            spriteBatch.Draw(buttonImage, position + offset + imageOffset, sliderPartVisible, Color.White);
                        }
                        if (i < _imageList.Count - 1 && _imageList[i + 1].ImageType != ButtonAreaImageTypeEnum.Overlay)
                            if(image.ImageStackDirection == ButtonAreaImageStackDirectionEnum.Horizontal)
                                imageOffset.X = imageOffset.X + buttonImage.Width;
                            else
                                imageOffset.Y = imageOffset.Y + buttonImage.Height;
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
            _imageList.Clear();
        }
        public virtual void AddImage(string imageName, ButtonAreaImageTypeEnum imageType = ButtonAreaImageTypeEnum.Normal, ButtonAreaImageStackDirectionEnum imageStackDirection = ButtonAreaImageStackDirectionEnum.Horizontal)
        {
            _imageList.Add(new Image(imageName, imageType, imageStackDirection));
        }
        protected virtual ButtonAreaStateImageEnum GetCurrentImageStateEnum(bool visible, bool disabled, ButtonStatusEnum status)
        {
            ButtonAreaStateImageEnum buttonImageState;
            if (!visible)
                buttonImageState = ButtonAreaStateImageEnum.Hidden;         
            else if (disabled && !_disabledMissing)
                buttonImageState = ButtonAreaStateImageEnum.Disabled;
            else if (status == ButtonStatusEnum.Selected && !_selectedMissing)
                buttonImageState = ButtonAreaStateImageEnum.Selected;
            else if ((status == ButtonStatusEnum.Focused || (status == ButtonStatusEnum.Selected && _selectedMissing)) && !_focusedMissing)
                buttonImageState = ButtonAreaStateImageEnum.Focused;
            else
                buttonImageState = ButtonAreaStateImageEnum.Idle;           
            return buttonImageState;
        }
        protected virtual string GetCurrentImageNameSuffix(ButtonAreaStateImageEnum buttonImageStateName)
        {
            string buttonImageNameSuffix;
            if (buttonImageStateName == ButtonAreaStateImageEnum.Hidden)
                buttonImageNameSuffix = null;
            else if (buttonImageStateName == ButtonAreaStateImageEnum.Disabled)
                buttonImageNameSuffix = "_disabled";
            else if (buttonImageStateName == ButtonAreaStateImageEnum.Focused)
                buttonImageNameSuffix = "_focused";
            else if (buttonImageStateName == ButtonAreaStateImageEnum.Selected)
                buttonImageNameSuffix = "_selected";
            else
                buttonImageNameSuffix = "_idle";
            return buttonImageNameSuffix;
        }
        private string GetCurrentExistingImageNameSuffix(bool visible, bool disabled, ButtonStatusEnum status)
        {
            ButtonAreaStateImageEnum imageType = GetCurrentImageStateEnum(visible, disabled, status);
            string buttonImageNameSuffix = GetCurrentImageNameSuffix(imageType); ;
            //Check if texture exists
            while (imageType == ButtonAreaStateImageEnum.Disabled || imageType == ButtonAreaStateImageEnum.Focused || imageType == ButtonAreaStateImageEnum.Selected)
            {
                if (_contentManager.GetImage(_imageList[0].ImageName + buttonImageNameSuffix) == null)
                {
                    if (imageType == ButtonAreaStateImageEnum.Disabled)
                        _disabledMissing = true;
                    else if (imageType == ButtonAreaStateImageEnum.Focused)
                        _focusedMissing = true;
                    else if (imageType == ButtonAreaStateImageEnum.Selected)
                        _selectedMissing = true;
                    else
                        break;
                    imageType = GetCurrentImageStateEnum(visible, disabled, status);
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
            if (_imageList != null && _imageList.Count > 0)
            {
                string buttonImageNameSuffix = GetCurrentExistingImageNameSuffix(visible, disabled, status);
                foreach (Image image in _imageList)
                {
                    Texture2D buttonImage = _contentManager.GetImage(image.ImageName + buttonImageNameSuffix);
                    if (buttonImage != null)
                    {
                        if (image.ImageType != ButtonAreaImageTypeEnum.Overlay)
                        {
                            if (image.ImageStackDirection == ButtonAreaImageStackDirectionEnum.Horizontal)
                            {
                                size.X = size.X + buttonImage.Width;
                                size.Y = (buttonImage.Height > size.Y) ? buttonImage.Height : size.Y;
                            }
                            else
                            {
                                size.X = (buttonImage.Width > size.X) ? buttonImage.Width : size.X;
                                size.Y = size.Y + buttonImage.Height;
                            }
                        }
                    }
                }
            }
            return size;
        }
        public virtual void Initialize()
        {
            foreach (Image image in _imageList)
            {
                _contentManager.AddImage(image.ImageName + "_idle");
                _contentManager.AddImage(image.ImageName + "_focused");
                _contentManager.AddImage(image.ImageName + "_selected");
                _contentManager.AddImage(image.ImageName + "_disabled");
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
