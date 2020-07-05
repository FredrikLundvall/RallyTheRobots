using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ResolutionBuddy;
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
        internal ContentManager _contentManager;
        internal InputChecker _inputChecker;
        protected List<string> _idleImageName = new List<string>();
        protected List<string> _disabledImageName = new List<string>();
        protected List<string> _focusedImageName = new List<string>();
        protected List<string> _selectedImageName = new List<string>();
        protected RollingState _rollingState = new RollingState();
        protected List<string> _rollingStateImageName = new List<string>();
        public Vector2 Position;
        public bool Visible = true;
        public bool Disabled = false;
        //Maybe move this functionality to the screen (only one shortcut with GoBackButton per screen is probably a requirement)
        public bool HasShortcutWithGoBackButton = false;
        public bool HasShortcutWithMouseWheelUp = false;
        public bool HasShortcutWithMouseWheelDown = false;
        public ButtonStatusEnum Status = ButtonStatusEnum.Idle;
        protected ButtonAction _buttonAction = ButtonAction.GetEmptyButtonAction();

        internal void SetContentManager(ContentManager contentManager)
        {
            if (_contentManager == null)
                _contentManager = contentManager;
        }
        internal void SetInputChecker(InputChecker inputChecker)
        {
            if (_inputChecker == null)
                _inputChecker = inputChecker;
        }
        public virtual void AddRollingState(string rollingState)
        {
            _rollingState.AddState(rollingState);
        }
        public virtual string GetCurrentRollingState()
        {
            return _rollingState.GetCurrentState();
        }
        public virtual void SetCurrentRollingState(string rollingState)
        {
            _rollingState.SetCurrentState(rollingState);
        }
        public virtual void AdvanceRollingState()
        {
            _rollingState.AdvanceState();
        }
        public virtual void AddRollingStatesAsSuffixedImages(string idleSuffix = "_idle.png", string focusedSuffix = "_focused.png", string selectedSuffix = "_selected.png", string disabledSuffix = "_disabled.png")
        {
            _rollingState.ToArray();
            foreach (string stateName in _rollingState.ToArray())
            {
                _rollingStateImageName.Add(stateName + idleSuffix);
                _rollingStateImageName.Add(stateName + focusedSuffix);
                _rollingStateImageName.Add(stateName + selectedSuffix);
                _rollingStateImageName.Add(stateName + disabledSuffix);
            }
        }
        public virtual void SetImageToRollingState(string imageName)
        {
            ClearImages();
            AddSuffixedImage(imageName);
            AddSuffixedImage(GetCurrentRollingState());
        }
        public virtual void ClearImages()
        {
            _idleImageName.Clear();
            _disabledImageName.Clear();
            _focusedImageName.Clear();
            _selectedImageName.Clear();
        }
        public virtual void AddSuffixedImage(string imageName, string idleSuffix = "_idle.png", string focusedSuffix = "_focused.png", string selectedSuffix = "_selected.png", string disabledSuffix = "_disabled.png")
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
        public virtual void SetButtonAction(ButtonAction buttonAction)
        {
            _buttonAction = buttonAction;
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
            foreach(string imageName in _idleImageName)
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
        public virtual void Update(ScreenManager manager, Screen screen, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus, Vector2 offset, IResolution resolution)
        {
            //Check if the button was released between the last triggering of DoAction
            if (_inputChecker.ButtonForSelectIsCurrentlyPressed(gameSettings) || (_inputChecker.ButtonForSelectMouseIsCurrentlyPressed(gameSettings) && _inputChecker.MouseIsCurrentlyOverButtonArea(this, offset, resolution)) || (HasShortcutWithGoBackButton && _inputChecker.GoBackButtonIsCurrentlyPressed(gameSettings)) || (HasShortcutWithMouseWheelUp && _inputChecker.MouseWheelUpIsCurrentlyTurned()) || (HasShortcutWithMouseWheelDown && _inputChecker.MouseWheelDownIsCurrentlyTurned()))
            {
                if (!manager.ButtonForSelectIsHeldDown && Visible && !Disabled && (Status == ButtonStatusEnum.Focused || Status == ButtonStatusEnum.Selected || (HasShortcutWithGoBackButton && _inputChecker.GoBackButtonIsCurrentlyPressed(gameSettings)) || (HasShortcutWithMouseWheelUp && _inputChecker.MouseWheelUpIsCurrentlyTurned()) || (HasShortcutWithMouseWheelDown && _inputChecker.MouseWheelDownIsCurrentlyTurned())))
                {
                    manager.ButtonForSelectIsHeldDown = true;
                    _buttonAction.DoAction(manager, screen, gameTime, gameSettings, gameStatus);
                }
            }
            //Exception for the press of mousebutton outside the ButtonArea
            else if (!_inputChecker.ButtonForSelectMouseIsCurrentlyPressed(gameSettings))
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
