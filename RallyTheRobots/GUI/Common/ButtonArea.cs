﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots
{
    public class ButtonArea
    {
        protected Texture2D _idleImage;
        protected string _idleImagePath;
        protected Texture2D _disabledImage;
        protected string _disabledImagePath;
        protected Texture2D _focusedImage;
        protected string _focusedImagePath;
        protected Texture2D _selectedImage;
        protected string _selectedImagePath;
        public Vector2 Position;
        public bool Visible = true;
        public bool Disabled = false;
        //Maybe move this functionality to the screen (only one shortcut with GoBackButton per screen is probably a requirement)
        public bool HasShortcutWithGoBackButton = false;
        public ButtonStatusEnum Status = ButtonStatusEnum.Idle;
        protected ButtonAction _buttonAction = ButtonAction.GetEmptyButtonAction();

        public virtual void SetIdleImage(string imagePath)
        {
            _idleImagePath = imagePath;
        }
        public virtual void SetFocusedImage(string imagePath)
        {
            _focusedImagePath = imagePath;
        }
        public virtual void SetSelectedImage(string imagePath)
        {
            _selectedImagePath = imagePath;
        }
        public virtual void SetDisabledImage(string imagePath)
        {
            _disabledImagePath = imagePath;
        }
        public virtual void SetButtonAction(ButtonAction buttonAction)
        {
            _buttonAction = buttonAction;
        }
        public virtual void LoadContent(GraphicsDevice graphicsDevice)
        {
            FileStream tempstream;
            if (_idleImagePath != "" & File.Exists(_idleImagePath))
            {
                tempstream = new FileStream(_idleImagePath, FileMode.Open);
                _idleImage = Texture2D.FromStream(graphicsDevice, tempstream);
                tempstream.Close();
            }
            if (_focusedImagePath != "" & File.Exists(_focusedImagePath))
            {
                tempstream = new FileStream(_focusedImagePath, FileMode.Open);
                _focusedImage = Texture2D.FromStream(graphicsDevice, tempstream);
                tempstream.Close();
            }
            else
                _focusedImage = _idleImage;
            if (_selectedImagePath != "" & File.Exists(_selectedImagePath))
            {
                tempstream = new FileStream(_selectedImagePath, FileMode.Open);
                _selectedImage = Texture2D.FromStream(graphicsDevice, tempstream);
                tempstream.Close();
            }
            else
                _selectedImage = _idleImage;
            if (_disabledImagePath != "" & File.Exists(_disabledImagePath))
            {
                tempstream = new FileStream(_disabledImagePath, FileMode.Open);
                _disabledImage = Texture2D.FromStream(graphicsDevice, tempstream);
                tempstream.Close();
            }
            else
                _disabledImage = _idleImage;
        }
        public virtual void Update(ScreenManager manager, Screen screen, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            //Check if the button was released between the last triggering of DoAction
            //Move the _buttonIsHeldDown to the ScreenManager to keep it between screens
            if (InputChecker.ButtonForSelectIsCurrentlyPressed(gameSettings) || (HasShortcutWithGoBackButton && InputChecker.GoBackButtonIsCurrentlyPressed(gameSettings)))
            {
                if (!manager.ButtonForSelectIsHeldDown && Visible && !Disabled && (Status == ButtonStatusEnum.Focused || Status == ButtonStatusEnum.Selected || (HasShortcutWithGoBackButton && InputChecker.GoBackButtonIsCurrentlyPressed(gameSettings))))
                {
                    manager.ButtonForSelectIsHeldDown = true;
                    _buttonAction.DoAction(manager, screen, gameTime, gameSettings, gameStatus);
                }
            }
            else
                manager.ButtonForSelectIsHeldDown = false;

        }
        public virtual Vector2 GetSize()
        {
            Texture2D buttonImage = null;
            if (Visible)
            {
                buttonImage = _idleImage;
                if (Disabled)
                    buttonImage = _disabledImage;
                else if (Status == ButtonStatusEnum.Focused)
                    buttonImage = _focusedImage;
                else if (Status == ButtonStatusEnum.Selected)
                    buttonImage = _selectedImage;
            }
            if (buttonImage != null)
                return new Vector2(buttonImage.Width, buttonImage.Height);
            else
                return new Vector2(0, 0);
        }
        public virtual void Draw(GameTime gameTime, GraphicsDevice graphicsDevice, GameSettings gameSettings, SpriteBatch spriteBatch, Vector2 offset)
        {
            if (Visible)
            {
                Texture2D buttonImage = _idleImage;
                if(Disabled)
                   buttonImage = _disabledImage;
                else if (Status == ButtonStatusEnum.Focused)
                    buttonImage = _focusedImage;
                else if (Status == ButtonStatusEnum.Selected)
                    buttonImage = _selectedImage;
                if(buttonImage != null)
                    spriteBatch.Draw(buttonImage, Position + offset, Color.White);
            }
        }
    }
}