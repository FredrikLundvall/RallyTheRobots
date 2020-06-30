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
        protected readonly ContentManager _contentManager;
        //protected Texture2D _idleImage;
        protected string _idleImageName;
        //protected Texture2D _disabledImage;
        protected string _disabledImageName;
        //protected Texture2D _focusedImage;
        protected string _focusedImageName;
        //protected Texture2D _selectedImage;
        protected string _selectedImageName;
        public Vector2 Position;
        public bool Visible = true;
        public bool Disabled = false;
        //Maybe move this functionality to the screen (only one shortcut with GoBackButton per screen is probably a requirement)
        public bool HasShortcutWithGoBackButton = false;
        public ButtonStatusEnum Status = ButtonStatusEnum.Idle;
        protected ButtonAction _buttonAction = ButtonAction.GetEmptyButtonAction();


        public ButtonArea(ContentManager contentManager)
        {
            _contentManager = contentManager;
        }
        public virtual void SetIdleImage(string imageName)
        {
            _idleImageName = imageName;
            _contentManager.AddImage(_idleImageName);
        }
        public virtual void SetFocusedImage(string imageName)
        {
            _focusedImageName = imageName;
            _contentManager.AddImage(_focusedImageName);
        }
        public virtual void SetSelectedImage(string imageName)
        {
            _selectedImageName = imageName;
            _contentManager.AddImage(_selectedImageName);
        }
        public virtual void SetDisabledImage(string imagePath)
        {
            _disabledImageName = imagePath;
            _contentManager.AddImage(_disabledImageName);
        }
        public virtual void SetButtonAction(ButtonAction buttonAction)
        {
            _buttonAction = buttonAction;
        }
        public virtual void LoadContent(GraphicsDevice graphicsDevice)
        {
        }
        protected virtual Texture2D GetCurrentImage()
        {
            Texture2D buttonImage = null;
            if (Visible)
            {
                if (Disabled)
                    buttonImage = _contentManager.GetImage(_disabledImageName);
                else if (Status == ButtonStatusEnum.Focused)
                    buttonImage = _contentManager.GetImage(_focusedImageName);
                else if (Status == ButtonStatusEnum.Selected)
                    buttonImage = _contentManager.GetImage(_selectedImageName);
                if(buttonImage == null)
                    buttonImage = _contentManager.GetImage(_idleImageName);
            }
            return buttonImage;
        }
        public virtual Vector2 GetSize()
        {
            Texture2D buttonImage = GetCurrentImage();
            if (buttonImage != null)
                return new Vector2(buttonImage.Width, buttonImage.Height);
            else
                return new Vector2(0, 0);
        }
        public virtual void Initialize()
        {
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
        public virtual void Draw(GameTime gameTime, GraphicsDevice graphicsDevice, GameSettings gameSettings, SpriteBatch spriteBatch, Vector2 offset)
        {
            Texture2D buttonImage = GetCurrentImage();
            if(buttonImage != null)
                spriteBatch.Draw(buttonImage, Position + offset, Color.White);
        }
    }
}
