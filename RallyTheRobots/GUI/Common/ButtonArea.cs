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
        protected List<string> _idleImageName = new List<string>();
        protected List<string> _disabledImageName = new List<string>();
        protected List<string> _focusedImageName = new List<string>();
        protected List<string> _selectedImageName = new List<string>();
        public Vector2 Position;
        public bool Visible = true;
        public bool Disabled = false;
        //Maybe move this functionality to the screen (only one shortcut with GoBackButton per screen is probably a requirement)
        public bool HasShortcutWithGoBackButton = false;
        public bool HasShortcutWithMouseWheelUp = false;
        public bool HasShortcutWithMouseWheelDown = false;
        public ButtonStatusEnum Status = ButtonStatusEnum.Idle;
        protected ButtonAction _buttonAction = ButtonAction.GetEmptyButtonAction();

        public ButtonArea(ContentManager contentManager)
        {
            _contentManager = contentManager;
        }
        public virtual void AddIdleImage(string imageName)
        {
            _idleImageName.Add(imageName);
            _contentManager.AddImage(imageName);
        }
        public virtual void AddFocusedImage(string imageName)
        {
            _focusedImageName.Add(imageName);
            _contentManager.AddImage(imageName);
        }
        public virtual void AddSelectedImage(string imageName)
        {
            _selectedImageName.Add(imageName);
            _contentManager.AddImage(imageName);
        }
        public virtual void AddDisabledImage(string imageName)
        {
            _disabledImageName.Add(imageName);
            _contentManager.AddImage(imageName);
        }
        public virtual void SetButtonAction(ButtonAction buttonAction)
        {
            _buttonAction = buttonAction;
        }
        public virtual void LoadContent(GraphicsDevice graphicsDevice)
        {
        }
        protected virtual List<string> GetCurrentImageNameList()
        {
            List<string> buttonImageNameList = null;
            if (Visible)
            {
                if (Disabled)
                    buttonImageNameList = _disabledImageName;
                else if (Status == ButtonStatusEnum.Focused)
                    buttonImageNameList = _focusedImageName;
                else if (Status == ButtonStatusEnum.Selected)
                    buttonImageNameList = _selectedImageName;
                if(buttonImageNameList == null || buttonImageNameList.Count == 0)
                    buttonImageNameList = _idleImageName;
            }
            return buttonImageNameList;
        }
        public virtual Vector2 GetSize()
        {
            Vector2 size = new Vector2(0, 0);
            List<string> currentImageNameList = GetCurrentImageNameList();
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
        }
        public virtual void Update(ScreenManager manager, Screen screen, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            //Check if the button was released between the last triggering of DoAction
            //TODO: Move the _buttonIsHeldDown to the ScreenManager to keep it between screens
            if (InputChecker.ButtonForSelectIsCurrentlyPressed(gameSettings) || (HasShortcutWithGoBackButton && InputChecker.GoBackButtonIsCurrentlyPressed(gameSettings)) || (HasShortcutWithMouseWheelUp && InputChecker.MouseWheelUpIsCurrentlyTurned()) || (HasShortcutWithMouseWheelDown && InputChecker.MouseWheelDownIsCurrentlyTurned()))
            {
                if (!manager.ButtonForSelectIsHeldDown && Visible && !Disabled && (Status == ButtonStatusEnum.Focused || Status == ButtonStatusEnum.Selected || (HasShortcutWithGoBackButton && InputChecker.GoBackButtonIsCurrentlyPressed(gameSettings)) || (HasShortcutWithMouseWheelUp && InputChecker.MouseWheelUpIsCurrentlyTurned()) || (HasShortcutWithMouseWheelDown && InputChecker.MouseWheelDownIsCurrentlyTurned())))
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
            Vector2 imageOffset = new Vector2(0, 0);
            List<string> currentImageNameList = GetCurrentImageNameList();
            if (currentImageNameList != null)
            {
                foreach (string name in currentImageNameList)
                {
                    Texture2D buttonImage = _contentManager.GetImage(name);
                    if (buttonImage != null)
                    {
                        spriteBatch.Draw(buttonImage, Position + offset + imageOffset, Color.White);
                        imageOffset.X = imageOffset.X + buttonImage.Width;
                    }
                }
            }
        }
    }
}
