using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ResolutionBuddy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots
{
    public class InputChecker
    {
        private  Point _currentMousePosition;
        private  Point _oldMousePosition;
        private  int _currentScrollWheelValue;
        private  int _oldScrollWheelValue;
        public virtual void Initialize()
        {
            _oldScrollWheelValue = Mouse.GetState().ScrollWheelValue;
            _oldMousePosition = Mouse.GetState().Position;
        }
        public virtual void BeforeUpdate(GameTime gameTime, GameSettings gameSettings)
        {
            _currentScrollWheelValue = Mouse.GetState().ScrollWheelValue;
            _currentMousePosition = Mouse.GetState().Position;
        }
        public virtual void AfterUpdate(GameTime gameTime, GameSettings gameSettings)
        {
            _oldScrollWheelValue = _currentScrollWheelValue;
            _oldMousePosition = _currentMousePosition;
        }
        public virtual bool ButtonForSelectIsCurrentlyPressed(GameSettings gameSettings)
        {
            return GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed || GamePad.GetState(PlayerIndex.One).Triggers.Right > 0.3 || GamePad.GetState(PlayerIndex.One).Buttons.RightShoulder == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Enter) || Keyboard.GetState().IsKeyDown(Keys.E);
        }
        public virtual bool ButtonForAlternateSelectIsCurrentlyPressed(GameSettings gameSettings)
        {
            return GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed || GamePad.GetState(PlayerIndex.One).Triggers.Left > 0.3 || GamePad.GetState(PlayerIndex.One).Buttons.LeftShoulder == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Back) || Keyboard.GetState().IsKeyDown(Keys.F);
        }
        public virtual bool ButtonForSelectMouseIsCurrentlyPressed(GameSettings gameSettings)
        {
            return Mouse.GetState().LeftButton == ButtonState.Pressed;
        }
        public virtual bool ButtonForAlternateSelectMouseIsCurrentlyPressed(GameSettings gameSettings)
        {
            return Mouse.GetState().RightButton == ButtonState.Pressed;
        }
        public virtual bool ButtonForAlernateSelectMouseIsCurrentlyPressed(GameSettings gameSettings)
        {
            return Mouse.GetState().RightButton == ButtonState.Pressed;
        }
        public virtual bool AnyButtonIsCurrentlyPressed(GameSettings gameSettings)
        {
            return Keyboard.GetState().GetPressedKeys().GetLength(0) > 0 || GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed || GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed || GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed || GamePad.GetState(PlayerIndex.One).Buttons.Y == ButtonState.Pressed || Mouse.GetState().LeftButton == ButtonState.Pressed || Mouse.GetState().RightButton == ButtonState.Pressed;
        }
        public virtual bool PreviousVerticalButtonIsCurrentlyPressed(GameSettings gameSettings)
        {
            return GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y > 0.3 || GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y > 0.3 || Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W);
        }
        public virtual bool NextVerticalButtonIsCurrentlyPressed(GameSettings gameSettings)
        {
            return GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < -0.3 || GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y < -0.3 || Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S);
        }
        public virtual bool PreviousHorizontalButtonIsCurrentlyPressed(GameSettings gameSettings)
        {
            return GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X > 0.3 || GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X > 0.3 || Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A);
        }
        public virtual bool NextHorizontalButtonIsCurrentlyPressed(GameSettings gameSettings)
        {
            return GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X < -0.3 || GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X < -0.3 || Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D);
        }
        public virtual bool GoBackButtonIsCurrentlyPressed(GameSettings gameSettings)
        {
            return GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape);
        }
        public virtual bool HasMouseMoved(GameTime gameTime, GameSettings gameSettings)
        {
            return _oldMousePosition != _currentMousePosition;
        }
        public virtual bool MouseIsCurrentlyOverButtonArea(ButtonArea buttonArea, Vector2 offset, IResolution resolution)
        {
            Point mouseScreenPosition = _currentMousePosition;
            Vector2 mousePosition = resolution.ScreenToGameCoord(new Vector2(mouseScreenPosition.X, mouseScreenPosition.Y));
            Vector2 buttonAreaSize = buttonArea.GetSize();
            return mousePosition.X >= buttonArea.Position.X + offset.X && mousePosition.X <= buttonArea.Position.X + offset.X + buttonAreaSize.X && mousePosition.Y >= buttonArea.Position.Y + offset.Y && mousePosition.Y <= buttonArea.Position.Y + offset.Y + buttonAreaSize.Y;
        }
        public virtual int HorizontalValueMouseSliderButtonArea(ButtonArea buttonArea, Vector2 offset, IResolution resolution)
        {
            Point mouseScreenPosition = _currentMousePosition;
            Vector2 mousePosition = resolution.ScreenToGameCoord(new Vector2(mouseScreenPosition.X, mouseScreenPosition.Y));
            Rectangle buttonAreaSliderRect = buttonArea.GetHorizontalSliderRectangle();
            if ((int)mousePosition.X < buttonAreaSliderRect.X + (int)offset.X - buttonArea.SliderBorderLeft || (int)mousePosition.X > buttonAreaSliderRect.X + (int)offset.X + buttonAreaSliderRect.Width + buttonArea.SliderBorderRight || buttonAreaSliderRect.Width == 0)
                return -2;
            else if ((int)mousePosition.X <= buttonAreaSliderRect.X + (int)offset.X)
                return -1;
            else if ((int)mousePosition.X >= buttonAreaSliderRect.X + (int)offset.X + buttonAreaSliderRect.Width)
                return 101;
            else 
                return (int)(((mousePosition.X - ((float)buttonAreaSliderRect.X + offset.X)) / (float) buttonAreaSliderRect.Width) * 100f + 0.5f);
        }
        public virtual bool HasMouseWheelMoved()
        {
            return _currentScrollWheelValue != _oldScrollWheelValue;
        }
        public virtual bool MouseWheelUpIsCurrentlyTurned()
        {
            return _currentScrollWheelValue > _oldScrollWheelValue;
        }
        public virtual bool MouseWheelDownIsCurrentlyTurned()
        {
            return _currentScrollWheelValue < _oldScrollWheelValue;
        }
    }
}
