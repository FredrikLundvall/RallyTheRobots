﻿using Microsoft.Xna.Framework;
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
        protected ButtonAction _buttonSelectAction = ButtonAction.GetEmptyButtonAction();
        protected ButtonAction _buttonAlternateSelectAction = ButtonAction.GetEmptyButtonAction();

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
        public virtual void NextRollingState()
        {
            _rollingState.NextState();
        }
        public virtual void PreviousRollingState()
        {
            _rollingState.PreviousState();
        }
        public virtual void SetButtonSelectAction(ButtonAction buttonAction)
        {
            _buttonSelectAction = buttonAction;
        }
        public virtual void SetButtonAlternateSelectAction(ButtonAction buttonAction)
        {
            _buttonAlternateSelectAction = buttonAction;
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
                    _buttonSelectAction.DoAction(manager, screen, gameTime, gameSettings, gameStatus);
                }
            }
            //Exception for the press of mousebutton outside the ButtonArea
            else if (!_inputChecker.ButtonForSelectMouseIsCurrentlyPressed(gameSettings))
                manager.ButtonForSelectIsHeldDown = false;
            //Check if the alternate button was released between the last triggering of DoAction
            if (_inputChecker.ButtonForAlternateSelectIsCurrentlyPressed(gameSettings) || (_inputChecker.ButtonForAlternateSelectMouseIsCurrentlyPressed(gameSettings) && _inputChecker.MouseIsCurrentlyOverButtonArea(this, offset, resolution)))
            {
                if (!manager.ButtonForAlternateSelectIsHeldDown && Visible && !Disabled && (Status == ButtonStatusEnum.Focused || Status == ButtonStatusEnum.Selected || (HasShortcutWithGoBackButton && _inputChecker.GoBackButtonIsCurrentlyPressed(gameSettings)) || (HasShortcutWithMouseWheelUp && _inputChecker.MouseWheelUpIsCurrentlyTurned()) || (HasShortcutWithMouseWheelDown && _inputChecker.MouseWheelDownIsCurrentlyTurned())))
                {
                    manager.ButtonForAlternateSelectIsHeldDown = true;
                    _buttonAlternateSelectAction.DoAction(manager, screen, gameTime, gameSettings, gameStatus);
                }
            }
            //Exception for the press of mousebutton outside the ButtonArea
            else if (!_inputChecker.ButtonForAlternateSelectMouseIsCurrentlyPressed(gameSettings))
                manager.ButtonForAlternateSelectIsHeldDown = false;

        }
        public virtual void Draw(GameTime gameTime, GraphicsDevice graphicsDevice, GameSettings gameSettings, SpriteBatch spriteBatch, Vector2 offset)
        {
            _buttonAreaImage.Draw(gameTime, graphicsDevice, gameSettings, spriteBatch, offset, Position, Visible, Disabled, Status);
        }
        public virtual void AddRollingStatesAsImages()
        {
            foreach (string stateName in _rollingState.ToArray())
            {
                _buttonAreaImage.AddRollingStatesAsImages(stateName);
            }
        }
        public virtual void AddRollingStatesAsCharacterImages()
        {
            foreach (string stateName in _rollingState.ToArray())
            {
                foreach (char characterImageName in stateName)
                {
                    _buttonAreaImage.AddRollingStatesAsImages(characterImageName.ToString());
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
        public virtual void AddImage(string imageName)
        {
            _buttonAreaImage.AddImage(imageName);
        }
        public virtual void AddCharacterImage(string imageCharacterName)
        {
            foreach (char characterImageName in imageCharacterName)
                _buttonAreaImage.AddImage(characterImageName.ToString());
        }
        public virtual Vector2 GetSize()
        {
            return _buttonAreaImage.GetSize(Visible, Disabled, Status);
        }
    }
}
