using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots
{
    public class ButtonAreaList
    {
        protected List<ButtonArea> _buttonAreaList = new List<ButtonArea>(30);
        public bool Scrollable = false;
        public Vector2 ScrollCurrentOffset = new Vector2(0, 0);
        protected ButtonArea _scrollUpButtonArea;
        protected ButtonArea _scrollDownButtonArea;

        public virtual void Add(ButtonArea aButtonArea)
        {
            _buttonAreaList.Add(aButtonArea);
        }

        public virtual void AddScrollUp(ButtonArea aButtonArea)
        {
            _scrollUpButtonArea = aButtonArea;
        }

        public virtual void AddScrollDown(ButtonArea aButtonArea)
        {
            _scrollDownButtonArea = aButtonArea;
        }

        public virtual void LoadContent(GraphicsDevice graphicsDevice)
        {
            foreach (ButtonArea button in _buttonAreaList)
            {
                button.LoadContent(graphicsDevice);
            }
            if(_scrollDownButtonArea != null)
                _scrollDownButtonArea.LoadContent(graphicsDevice);
            if (_scrollUpButtonArea != null)
                _scrollUpButtonArea.LoadContent(graphicsDevice);
        }

        public virtual ButtonArea GetPreviousButtonArea()
        {
            ButtonArea previousButton = null;
            //Find the last button from the start before the selected one
            for (int i = 0; i < _buttonAreaList.Count; i++)
            {
                if (_buttonAreaList[i].Status == ButtonStatusEnum.Focused || _buttonAreaList[i].Status == ButtonStatusEnum.Selected)
                    break;
                else if (_buttonAreaList[i].Visible && !_buttonAreaList[i].Disabled)
                    previousButton = _buttonAreaList[i];
            }
            if (previousButton == null)
            {
                //Reset offset
                ScrollCurrentOffset = new Vector2(0, 0);
                //Find the first button from the end that´s visible and enabled
                for (int i = _buttonAreaList.Count - 1; i >= 0; i--)
                {
                    if (_buttonAreaList[i].Visible && !_buttonAreaList[i].Disabled)
                    {
                        previousButton = _buttonAreaList[i];
                        break;
                    }
                }
            }

            return previousButton;
        }

        public virtual ButtonArea GetNextButtonArea()
        {
            ButtonArea nextButton = null;
            //Find the last button from the end before the selected one
            for (int i = _buttonAreaList.Count - 1; i >= 0; i--)
            {
                if (_buttonAreaList[i].Status == ButtonStatusEnum.Focused || _buttonAreaList[i].Status == ButtonStatusEnum.Selected)
                    break;
                else if (_buttonAreaList[i].Visible && !_buttonAreaList[i].Disabled)
                    nextButton = _buttonAreaList[i];
            }
            if (nextButton == null)
            {
                //Reset offset
                ScrollCurrentOffset = new Vector2(0, 0);
                //Find the first button from the start that´s visible and enabled
                for (int i = 0; i < _buttonAreaList.Count; i++)
                {
                    if (_buttonAreaList[i].Visible && !_buttonAreaList[i].Disabled)
                    {
                        nextButton = _buttonAreaList[i];
                        break;
                    }
                }
            }

            return nextButton;
        }

        protected virtual int GetFocusedButtonAreaIndex(bool orSelected = false)
        {
            int selectedIndex = -1;
            for (int i = 0; i < _buttonAreaList.Count; i++)
            {
                if (_buttonAreaList[i].Status == ButtonStatusEnum.Focused || (orSelected &&_buttonAreaList[i].Status == ButtonStatusEnum.Selected))
                {
                    selectedIndex = i;
                    break;
                }
            }
            return selectedIndex;
        }

        public virtual ButtonArea GetSelectedOrFocusedButtonArea(ButtonArea selectedButton)
        {
            int selectedIndex = GetFocusedButtonAreaIndex(true);
            if(selectedIndex >= 0)
                selectedButton = _buttonAreaList[selectedIndex];
            return selectedButton;
        }

        public virtual ButtonArea GetFocusedButtonArea(ButtonArea focusedButton)
        {
            int selectedIndex = GetFocusedButtonAreaIndex(false);
            if (selectedIndex >= 0)
                focusedButton = _buttonAreaList[selectedIndex];
            return focusedButton;
        }

        public virtual void SetStatusButtonArea(ButtonArea actualButton, ButtonStatusEnum newStatus)
        {
            foreach (ButtonArea button in _buttonAreaList)
            {
                if (button == actualButton && button.Visible && !button.Disabled)
                    button.Status = newStatus;
                else
                    button.Status = ButtonStatusEnum.Idle;
            }
        }
        protected virtual void CheckIfScrollUpOrDown()
        {
            if (Scrollable)
            {
                _scrollDownButtonArea.Visible = false;
                _scrollUpButtonArea.Visible = false;
                if (_buttonAreaList[_buttonAreaList.Count - 1].Position.Y + _buttonAreaList[_buttonAreaList.Count - 1].GetSize().Y + ScrollCurrentOffset.Y >= _scrollDownButtonArea.Position.Y)
                    _scrollDownButtonArea.Visible = true;
                if (_buttonAreaList[0].Position.Y + ScrollCurrentOffset.Y <= _scrollUpButtonArea.Position.Y + _scrollUpButtonArea.GetSize().Y)
                    _scrollUpButtonArea.Visible = true;
                int focusedIndex = GetFocusedButtonAreaIndex(true);
                if (focusedIndex >= 0)
                {
                    ButtonArea focusedButton = _buttonAreaList[focusedIndex];
                    if (focusedButton != null)
                    {
                        if (focusedButton.Position.Y + focusedButton.GetSize().Y + ScrollCurrentOffset.Y >= _scrollDownButtonArea.Position.Y)
                        {
                            ButtonArea aboveFocusedButton = _buttonAreaList[focusedIndex - 1];
                            //Scroll down
                            ScrollCurrentOffset.Y -= (focusedButton.Position.Y + focusedButton.GetSize().Y) - (aboveFocusedButton.Position.Y + aboveFocusedButton.GetSize().Y);
                        }
                        else if (focusedButton.Position.Y + ScrollCurrentOffset.Y < _scrollUpButtonArea.Position.Y + _scrollUpButtonArea.GetSize().Y)
                        {
                            ButtonArea belowFocusedButton = _buttonAreaList[focusedIndex + 1];
                            //Scroll up
                            ScrollCurrentOffset.Y += (belowFocusedButton.Position.Y + belowFocusedButton.GetSize().Y) - (focusedButton.Position.Y + focusedButton.GetSize().Y);
                        }
                    }
                }
            }
        }
        public virtual void Update(ScreenManager manager, Screen aScreen, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            CheckIfScrollUpOrDown();
            foreach (ButtonArea button in _buttonAreaList)
            {
                button.Update(manager, aScreen, gameTime, gameSettings, gameStatus);
            }
        }

        public virtual void Draw(GameTime gameTime, GraphicsDevice graphicsDevice, GameSettings gameSettings, SpriteBatch spriteBatch)
        {
            if (Scrollable)
            {
                foreach (ButtonArea button in _buttonAreaList)
                {
                    if (button.Position.Y + button.GetSize().Y + ScrollCurrentOffset.Y < _scrollDownButtonArea.Position.Y && button.Position.Y + ScrollCurrentOffset.Y > _scrollUpButtonArea.Position.Y + _scrollUpButtonArea.GetSize().Y)
                        button.Draw(gameTime, graphicsDevice, gameSettings, spriteBatch, ScrollCurrentOffset);
                }
                _scrollUpButtonArea.Draw(gameTime, graphicsDevice, gameSettings, spriteBatch, new Vector2(0, 0));
                _scrollDownButtonArea.Draw(gameTime, graphicsDevice, gameSettings, spriteBatch, new Vector2(0, 0));
            }
            else
            {
                foreach (ButtonArea button in _buttonAreaList)
                {
                    button.Draw(gameTime, graphicsDevice, gameSettings, spriteBatch, ScrollCurrentOffset);
                }
            }

        }

    }
}
