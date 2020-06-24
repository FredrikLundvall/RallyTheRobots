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

        public void Add(ButtonArea aButtonArea)
        {
            _buttonAreaList.Add(aButtonArea);
        }

        public virtual void LoadContent(GraphicsDevice graphicsDevice)
        {
            foreach (ButtonArea button in _buttonAreaList)
            {
                button.LoadContent(graphicsDevice);
            }
        }

        public virtual void Update(ScreenManager manager, Screen aScreen, GameTime gameTime, GameSettings gameSettings, GameStatus gameStatus)
        {
            foreach (ButtonArea button in _buttonAreaList)
            {
                button.Update(manager, aScreen, gameTime, gameSettings, gameStatus);
            }
        }

        public ButtonArea GetPreviousButtonArea()
        {
            ButtonArea previousButton = null;
            for (int i = 0; i < _buttonAreaList.Count; i++)
            {
                if (_buttonAreaList[i].Status == ButtonStatusEnum.Focused || _buttonAreaList[i].Status == ButtonStatusEnum.Selected)
                    break;
                else if (_buttonAreaList[i].Visible && !_buttonAreaList[i].Disabled)
                    previousButton = _buttonAreaList[i];
            }
            if (previousButton == null)
            {
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

        public ButtonArea GetNextButtonArea()
        {
            ButtonArea nextButton = null;
            for (int i = _buttonAreaList.Count - 1; i >= 0; i--)
            {
                if (_buttonAreaList[i].Status == ButtonStatusEnum.Focused || _buttonAreaList[i].Status == ButtonStatusEnum.Selected)
                    break;
                else if (_buttonAreaList[i].Visible && !_buttonAreaList[i].Disabled)
                    nextButton = _buttonAreaList[i];
            }
            if (nextButton == null)
            {
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

        public ButtonArea GetSelectedOrFocusedButtonArea(ButtonArea selectedButton)
        {
            for (int i = 0; i < _buttonAreaList.Count; i++)
            {
                if (_buttonAreaList[i].Status == ButtonStatusEnum.Selected || _buttonAreaList[i].Status == ButtonStatusEnum.Focused)
                {
                    selectedButton = _buttonAreaList[i];
                    break;
                }
            }

            return selectedButton;
        }

        public ButtonArea GetFocusedButtonArea(ButtonArea focusedButton)
        {
            for (int i = 0; i < _buttonAreaList.Count; i++)
            {
                if (_buttonAreaList[i].Status == ButtonStatusEnum.Focused)
                {
                    focusedButton = _buttonAreaList[i];
                    break;
                }
            }

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

        public virtual void Draw(GameTime gameTime, GraphicsDevice graphicsDevice, GameSettings gameSettings, SpriteBatch spriteBatch)
        {
            foreach (ButtonArea button in _buttonAreaList)
            {
                button.Draw(gameTime, graphicsDevice, gameSettings, spriteBatch);
            }
        }

    }
}
