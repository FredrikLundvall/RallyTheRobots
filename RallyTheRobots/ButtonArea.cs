using Microsoft.Xna.Framework;
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
            if ((Visible && !Disabled && Status == ButtonStatusEnum.Focused) && (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed || GamePad.GetState(PlayerIndex.One).Triggers.Right > 0.3 || GamePad.GetState(PlayerIndex.One).Buttons.RightShoulder == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Enter) || Keyboard.GetState().IsKeyDown(Keys.E)))
                _buttonAction.DoAction(manager, screen, gameTime, gameSettings, gameStatus);
        }
        public virtual void Draw(GameTime gameTime, GraphicsDevice graphicsDevice, GameSettings gameSettings, SpriteBatch spriteBatch)
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
                    spriteBatch.Draw(buttonImage, Position, Color.White);
            }
        }
    }
}
