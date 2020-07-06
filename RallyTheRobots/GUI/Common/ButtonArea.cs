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
        internal InputChecker _inputChecker;
        protected ButtonAreaImage _buttonAreaImage = new ButtonAreaImage();
        protected RollingState _rollingState = new RollingState();
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
            _buttonAreaImage.SetContentManager(contentManager);
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
        public virtual void SetButtonAction(ButtonAction buttonAction)
        {
            _buttonAction = buttonAction;
        }
        public virtual void Initialize()
        {
            _buttonAreaImage.Initialize();
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
            _buttonAreaImage.Draw(gameTime, graphicsDevice, gameSettings, spriteBatch, offset, Position, Visible, Disabled, Status);
        }
        public virtual void AddRollingStatesAsSuffixedImages(string idleSuffix = "_idle", string focusedSuffix = "_focused", string selectedSuffix = "_selected", string disabledSuffix = "_disabled")
        {
            foreach (string stateName in _rollingState.ToArray())
            {
                _buttonAreaImage.AddRollingStatesAsSuffixedImages(stateName, idleSuffix, focusedSuffix, selectedSuffix, disabledSuffix);
            }
        }
        public virtual void AddRollingStatesAsSuffixedCharacterImages(string idleSuffix = "_idle", string focusedSuffix = "_focused", string selectedSuffix = "_selected", string disabledSuffix = "_disabled")
        {
            foreach (string stateName in _rollingState.ToArray())
            {
                foreach (char characterImageName in stateName)
                {
                    _buttonAreaImage.AddRollingStatesAsSuffixedImages(characterImageName.ToString(), idleSuffix, focusedSuffix, selectedSuffix, disabledSuffix);
                }
            }
        }
        public virtual void SetImageToRollingState(string imageName)
        {
            _buttonAreaImage.SetImageToRollingState(imageName, GetCurrentRollingState());
        }
        public virtual void SetCharacterImageToRollingState(string imageName)
        {
            _buttonAreaImage.SetCharacterImageToRollingState(imageName, GetCurrentRollingState());
        }
        public virtual void ClearImages()
        {
            _buttonAreaImage.ClearImages();
        }
        public virtual void AddSuffixedImage(string imageName, string idleSuffix = "_idle", string focusedSuffix = "_focused", string selectedSuffix = "_selected", string disabledSuffix = "_disabled")
        {
            _buttonAreaImage.AddSuffixedImage(imageName, idleSuffix, focusedSuffix, selectedSuffix, disabledSuffix);
        }
        public virtual void AddSuffixedCharacterImage(string imageCharacterName, string idleSuffix = "_idle", string focusedSuffix = "_focused", string selectedSuffix = "_selected", string disabledSuffix = "_disabled")
        {
            foreach(char characterImageName in imageCharacterName)
                _buttonAreaImage.AddSuffixedImage(characterImageName.ToString(), idleSuffix, focusedSuffix, selectedSuffix, disabledSuffix);
        }
        public virtual void AddIdleImage(string imageName)
        {
            _buttonAreaImage.AddIdleImage(imageName);
        }
        public virtual void AddFocusedImage(string imageName)
        {
            _buttonAreaImage.AddFocusedImage(imageName);
        }
        public virtual void AddSelectedImage(string imageName)
        {
            _buttonAreaImage.AddSelectedImage(imageName);
        }
        public virtual void AddDisabledImage(string imageName)
        {
            _buttonAreaImage.AddDisabledImage(imageName);
        }
        public virtual Vector2 GetSize()
        {
            return _buttonAreaImage.GetSize(Visible, Disabled, Status);
        }
    }
}
