﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots.GUI.Common
{
    public class ButtonAreaImage
    {
        internal ContentManager _contentManager;
        protected List<ImageSettings> _imageList = new List<ImageSettings>();
        protected List<string> _rollingStateImageName = new List<string>();
        protected bool _disabledMissing = false;
        protected bool _focusedMissing = false;
        protected bool _selectedMissing = false;
        public virtual void Draw(GameTime gameTime, GraphicsDevice graphicsDevice, GameSettings gameSettings, SpriteBatch spriteBatch, Vector2 offset, Vector2 position, bool visible, bool disabled, ButtonStatusEnum status, string currentRollingState, int currentHorizontalValue, int currentVerticalValue, int borderLeft, int borderRight, int borderTop, int borderBottom)
        {
            Vector2 imageOffset = Vector2.Zero;
            ForEveryTexture2D(
                (image, texture) =>
                {
                    imageOffset = DrawTexture(spriteBatch, offset, position, imageOffset, image, texture, currentHorizontalValue, currentVerticalValue, borderLeft, borderRight, borderTop, borderBottom);
                }, 
                visible, 
                disabled, 
                status, 
                currentRollingState
            );
        }
        public virtual Vector2 GetSize(bool visible, bool disabled, ButtonStatusEnum status, string currentRollingState)
        {
            Vector2 size = Vector2.Zero;
            ForEveryTexture2D(
                (image, texture) =>
                {
                    size = GetTextureSize(size, image, texture);
                }, 
                visible, 
                disabled, 
                status, 
                currentRollingState
            );
            return size;
        }
        public virtual Rectangle GetHorizontalSliderRectangle(int borderLeft, int borderRight, Vector2 position, bool visible, bool disabled, ButtonStatusEnum status, string currentRollingState)
        {
            Vector2 imageOffset = position;
            imageOffset.X = imageOffset.X + borderLeft;
            Rectangle sliderRect = new Rectangle(0, 0, 0, 0);
            ForEveryTexture2D(
                (image, texture) =>
                {
                    imageOffset = GetHorizontalTextureRectangle(imageOffset, ref sliderRect, image, texture);
                    if (!sliderRect.IsEmpty)
                        return;
                }, 
                visible, 
                disabled, 
                status, 
                currentRollingState
            );
            if (!sliderRect.IsEmpty)
                sliderRect.Width = sliderRect.Width - (borderLeft + borderRight);
            return sliderRect;
        }
        public virtual Rectangle GetVerticalSliderRectangle(int borderTop, int borderBottom, Vector2 position, bool visible, bool disabled, ButtonStatusEnum status, string currentRollingState)
        {
            Vector2 imageOffset = position;
            imageOffset.Y = imageOffset.Y + borderTop;
            Rectangle sliderRect = new Rectangle(0, 0, 0, 0);
            ForEveryTexture2D(
                (image, texture) =>
                {
                    imageOffset = GetVerticalTextureRectangle(imageOffset, ref sliderRect, image, texture);
                    if (!sliderRect.IsEmpty)
                        return;
                },
                visible,
                disabled,
                status,
                currentRollingState
            );
            if (!sliderRect.IsEmpty)
                sliderRect.Height = sliderRect.Height - (borderTop + borderBottom);
            return sliderRect;
        }
        private void ForEveryTexture2D(Action<ImageSettings, Texture2D> action, bool visible, bool disabled, ButtonStatusEnum status, string currentRollingState)
        {
            if (_imageList != null && _imageList.Count > 0)
            {
                string buttonImageNameSuffix = GetCurrentExistingImageNameSuffix(visible, disabled, status);
                foreach (ImageSettings image in _imageList)
                {
                    string imageName = GetImageName(image.ImageNameType, image.ImageName, currentRollingState);
                    int numberOfChars = GetNumberOfChars(image.ImageNameType, imageName.Length);
                    for (int i = 0; i < imageName.Length; i += numberOfChars)
                    {
                        string characterImageName = imageName.Substring(i, numberOfChars);
                        Texture2D texture = _contentManager.GetTexture2D(image.ImageNamePrefix + characterImageName + buttonImageNameSuffix);
                        action(image, texture);
                    }
                }
            }
        }
        private string GetImageName(ButtonAreaImageNameTypeEnum imageNameType, string image, string currentRollingState)
        {
            if (imageNameType == ButtonAreaImageNameTypeEnum.Actual || imageNameType == ButtonAreaImageNameTypeEnum.Character)
            {
                return image;
            }
            else
            {
                return currentRollingState;
            }
        }
        private int GetNumberOfChars(ButtonAreaImageNameTypeEnum imageNameType, int imageNameLength)
        {
            return (imageNameType == ButtonAreaImageNameTypeEnum.Actual || imageNameType == ButtonAreaImageNameTypeEnum.RollingState) ? imageNameLength : 1;
        }
        private static Vector2 GetTextureSize(Vector2 size, ImageSettings image, Texture2D buttonTexture)
        {
            if (buttonTexture != null)
            {
                if (image.ImageStackDirection == ButtonAreaImageStackDirectionEnum.Horizontal)
                {
                    size.X = size.X + buttonTexture.Width;
                    size.Y = buttonTexture.Height > size.Y ? buttonTexture.Height : size.Y;
                }
                else if (image.ImageStackDirection == ButtonAreaImageStackDirectionEnum.Vertical)
                {
                    size.X = buttonTexture.Width > size.X ? buttonTexture.Width : size.X;
                    size.Y = size.Y + buttonTexture.Height;
                }
            }
            return size;
        }
        protected virtual Vector2 DrawTexture(SpriteBatch spriteBatch, Vector2 offset, Vector2 position, Vector2 imageOffset, ImageSettings image, Texture2D buttonTexture, int currentHorizontalValue, int currentVerticalValue, int borderLeft, int borderRight, int borderTop, int borderBottom)
        {
            if (buttonTexture != null)
            {
                if (image.ImagePositioning == ButtonAreaImagePositioningEnum.Unmovable)
                    spriteBatch.Draw(buttonTexture, position + offset + imageOffset, Color.White);
                else
                {
                    Rectangle sliderPartVisible = new Rectangle(0, 0, buttonTexture.Width, buttonTexture.Height);
                    if (image.ImagePositioning == ButtonAreaImagePositioningEnum.ValueHorizontalSlider)
                    {
                        int sliderWidth = (buttonTexture.Width - (borderLeft + borderRight)) * currentHorizontalValue / 100 + borderLeft + borderRight;
                        sliderPartVisible = new Rectangle(buttonTexture.Width - sliderWidth, 0, sliderWidth, buttonTexture.Height);
                    }
                    else if (image.ImagePositioning == ButtonAreaImagePositioningEnum.ValueVerticalSlider)
                    {
                        int sliderHeight = (buttonTexture.Height - (borderTop + borderBottom)) * currentVerticalValue / 100 + borderTop + borderBottom;
                        sliderPartVisible = new Rectangle(0, buttonTexture.Height - sliderHeight, buttonTexture.Width, sliderHeight);
                    }
                    spriteBatch.Draw(buttonTexture, position + offset + imageOffset, sliderPartVisible, Color.White);
                }
                if (image.ImageStackDirection == ButtonAreaImageStackDirectionEnum.Horizontal)
                    imageOffset.X = imageOffset.X + buttonTexture.Width;
                else if (image.ImageStackDirection == ButtonAreaImageStackDirectionEnum.Vertical)
                    imageOffset.Y = imageOffset.Y + buttonTexture.Height;
            }
            return imageOffset;
        }
        private static Vector2 GetHorizontalTextureRectangle(Vector2 imageOffset, ref Rectangle sliderRect, ImageSettings image, Texture2D buttonTexture)
        {
            if (buttonTexture != null)
            {
                if (image.ImagePositioning == ButtonAreaImagePositioningEnum.ValueHorizontalSlider)
                    sliderRect = new Rectangle((int)imageOffset.X, (int)imageOffset.Y, buttonTexture.Width, buttonTexture.Height);
                if (image.ImageStackDirection == ButtonAreaImageStackDirectionEnum.Horizontal)
                    imageOffset.X = imageOffset.X + buttonTexture.Width;
                else if (image.ImageStackDirection == ButtonAreaImageStackDirectionEnum.Vertical)
                    imageOffset.Y = imageOffset.Y + buttonTexture.Height;
            }
            return imageOffset;
        }
        private static Vector2 GetVerticalTextureRectangle(Vector2 imageOffset, ref Rectangle sliderRect, ImageSettings image, Texture2D buttonTexture)
        {
            if (buttonTexture != null)
            {
                if (image.ImagePositioning == ButtonAreaImagePositioningEnum.ValueVerticalSlider)
                    sliderRect = new Rectangle((int)imageOffset.X, (int)imageOffset.Y, buttonTexture.Width, buttonTexture.Height);
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
        public virtual string GetRollingStateImagePrefix()
        {
            if (_imageList != null && _imageList.Count > 0)
            {
                foreach (ImageSettings image in _imageList)
                {
                    if (image.ImageNamePrefix != "")
                        return image.ImageNamePrefix;
                }
            }
            return "";
        }
        public virtual void ClearImages()
        {
            _imageList.Clear();
        }
        public virtual void AddImage(string imageName, ButtonAreaImageNameTypeEnum imageNameType = ButtonAreaImageNameTypeEnum.Actual, ButtonAreaImagePositioningEnum imageType = ButtonAreaImagePositioningEnum.Unmovable, ButtonAreaImageStackDirectionEnum imageStackDirection = ButtonAreaImageStackDirectionEnum.Horizontal, string imageCharacterNameSuffix = "")
        {
            _imageList.Add(new ImageSettings(imageName, imageNameType, imageType, imageStackDirection, imageCharacterNameSuffix));
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
            else if ((status == ButtonStatusEnum.Focused || status == ButtonStatusEnum.Selected && _selectedMissing) && !_focusedMissing)
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
