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
        protected List<ImageSettings> _imageList = new List<ImageSettings>();
        protected List<string> _rollingStateImageName = new List<string>();
        protected bool _disabledMissing = false;
        protected bool _focusedMissing = false;
        protected bool _selectedMissing = false;

        public virtual void Draw(GameTime gameTime, GraphicsDevice graphicsDevice, GameSettings gameSettings, SpriteBatch spriteBatch, Vector2 offset, Vector2 position, bool visible, bool disabled, ButtonStatusEnum status, string currentRollingState)
        {
            Vector2 imageOffset = new Vector2(0, 0);
            if (_imageList != null && _imageList.Count > 0)
            {
                string buttonImageNameSuffix = GetCurrentExistingImageNameSuffix(visible, disabled, status);
                foreach(ImageSettings image in _imageList)
                {
                    string imageName = (image.ImageNameType == ButtonAreaImageNameTypeEnum.Actual || image.ImageNameType == ButtonAreaImageNameTypeEnum.Character) ? image.ImageName : currentRollingState;
                    int numberOfChars = (image.ImageNameType == ButtonAreaImageNameTypeEnum.Actual || image.ImageNameType == ButtonAreaImageNameTypeEnum.RollingState) ? imageName.Length : 1;
                    for(int i = 0; i < imageName.Length; i += numberOfChars)
                    {
                        string characterImageName = imageName.Substring(i, numberOfChars);
                        Texture2D texture = _contentManager.GetTexture2D(characterImageName + buttonImageNameSuffix);
                        imageOffset = DrawTexture(spriteBatch, offset, position, imageOffset, image, texture);
                    }
                }
            }
        }
        public virtual Vector2 GetSize(bool visible, bool disabled, ButtonStatusEnum status, string currentRollingState)
        {
            Vector2 size = new Vector2(0, 0);
            if (_imageList != null && _imageList.Count > 0)
            {
                string buttonImageNameSuffix = GetCurrentExistingImageNameSuffix(visible, disabled, status);
                foreach (ImageSettings image in _imageList)
                {
                    string imageName = (image.ImageNameType == ButtonAreaImageNameTypeEnum.Actual || image.ImageNameType == ButtonAreaImageNameTypeEnum.Character) ? image.ImageName : currentRollingState;
                    int numberOfChars = (image.ImageNameType == ButtonAreaImageNameTypeEnum.Actual || image.ImageNameType == ButtonAreaImageNameTypeEnum.RollingState) ? imageName.Length : 1;
                    for (int i = 0; i < imageName.Length; i += numberOfChars)
                    {
                        string characterImageName = imageName.Substring(i, numberOfChars);
                        Texture2D texture = _contentManager.GetTexture2D(characterImageName + buttonImageNameSuffix);
                        size = GetTextureSize(size, image, texture);
                    }
                }
            }
            return size;
        }
        private static Vector2 GetTextureSize(Vector2 size, ImageSettings image, Texture2D buttonTexture)
        {
            if (buttonTexture != null)
            {
                if (image.ImageStackDirection == ButtonAreaImageStackDirectionEnum.Horizontal)
                {
                    size.X = size.X + buttonTexture.Width;
                    size.Y = (buttonTexture.Height > size.Y) ? buttonTexture.Height : size.Y;
                }
                else if(image.ImageStackDirection == ButtonAreaImageStackDirectionEnum.Vertical)
                {
                    size.X = (buttonTexture.Width > size.X) ? buttonTexture.Width : size.X;
                    size.Y = size.Y + buttonTexture.Height;
                }
            }
            return size;
        }
        protected virtual Vector2 DrawTexture(SpriteBatch spriteBatch, Vector2 offset, Vector2 position, Vector2 imageOffset, ImageSettings image, Texture2D buttonTexture)
        {
            if (buttonTexture != null)
            {
                if (image.ImagePositioning == ButtonAreaImagePositioningEnum.Unmovable)
                    spriteBatch.Draw(buttonTexture, position + offset + imageOffset, Color.White);
                else
                {
                    Rectangle sliderPartVisible = new Rectangle(0, 0, buttonTexture.Width, buttonTexture.Height);
                    if (image.ImagePositioning == ButtonAreaImagePositioningEnum.HorizontalSlider)
                        sliderPartVisible = new Rectangle((buttonTexture.Width * 25) / 100, 0, (buttonTexture.Width * 75) / 100, buttonTexture.Height);
                    else if (image.ImagePositioning == ButtonAreaImagePositioningEnum.VerticalSlider)
                        sliderPartVisible = new Rectangle(0, buttonTexture.Height / 2, buttonTexture.Width, buttonTexture.Height / 2);
                    spriteBatch.Draw(buttonTexture, position + offset + imageOffset, sliderPartVisible, Color.White);
                }
                if (image.ImageStackDirection == ButtonAreaImageStackDirectionEnum.Horizontal)
                    imageOffset.X = imageOffset.X + buttonTexture.Width;
                else if (image.ImageStackDirection == ButtonAreaImageStackDirectionEnum.Vertical)
                    imageOffset.Y = imageOffset.Y + buttonTexture.Height;
            }
            return imageOffset;
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
        public virtual bool ReferencingRollingStateAsImage()
        {
            if (_imageList != null && _imageList.Count > 0)
            {
                foreach (ImageSettings image in _imageList)
                {
                    if (image.ImageNameType == ButtonAreaImageNameTypeEnum.RollingState)
                        return true;                            
                }
            }
            return false;
        }
        public virtual bool ReferencingRollingStateAsCharacterImage()
        {
            if (_imageList != null && _imageList.Count > 0)
            {
                foreach (ImageSettings image in _imageList)
                {
                    if (image.ImageNameType == ButtonAreaImageNameTypeEnum.RollingStateCharacter)
                        return true;
                }
            }
            return false;
        }
        public virtual void ClearImages()
        {
            _imageList.Clear();
        }
        public virtual void AddImage(string imageName, ButtonAreaImageNameTypeEnum imageNameType = ButtonAreaImageNameTypeEnum.Actual, ButtonAreaImagePositioningEnum imageType = ButtonAreaImagePositioningEnum.Unmovable, ButtonAreaImageStackDirectionEnum imageStackDirection = ButtonAreaImageStackDirectionEnum.Horizontal)
        {
            _imageList.Add(new ImageSettings(imageName, imageNameType, imageType, imageStackDirection));
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
                if (_contentManager.GetTexture2D(_imageList[0].ImageName + buttonImageNameSuffix) == null)
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
        public virtual void Initialize()
        {
            foreach (ImageSettings image in _imageList)
            {
                _contentManager.AddTexture2D(image.ImageName + "_idle");
                _contentManager.AddTexture2D(image.ImageName + "_focused");
                _contentManager.AddTexture2D(image.ImageName + "_selected");
                _contentManager.AddTexture2D(image.ImageName + "_disabled");
            }
            foreach (string imageName in _rollingStateImageName)
            {
                _contentManager.AddTexture2D(imageName + "_idle");
                _contentManager.AddTexture2D(imageName + "_focused");
                _contentManager.AddTexture2D(imageName + "_selected");
                _contentManager.AddTexture2D(imageName + "_disabled");
            }
        }
    }
}
