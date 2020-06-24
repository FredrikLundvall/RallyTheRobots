using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTheRobots
{
    public static class InputChecker
    {
        public static bool ButtonForSelectIsCurrentlyPressed(GameSettings gameSettings)
        {
            return GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed || GamePad.GetState(PlayerIndex.One).Triggers.Right > 0.3 || GamePad.GetState(PlayerIndex.One).Buttons.RightShoulder == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Enter) || Keyboard.GetState().IsKeyDown(Keys.E);
        }
        public static bool AnyButtonIsCurrentlyPressed(GameSettings gameSettings)
        {
            return Keyboard.GetState().GetPressedKeys().GetLength(0) > 0 || GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed || GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed || GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed || GamePad.GetState(PlayerIndex.One).Buttons.Y == ButtonState.Pressed || Mouse.GetState().LeftButton == ButtonState.Pressed || Mouse.GetState().RightButton == ButtonState.Pressed;
        }
        public static bool PreviousButtonIsCurrentlyPressed(GameSettings gameSettings)
        {
            return GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y > 0.3 || GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y > 0.3 || Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W);
        }
        public static bool NextButtonIsCurrentlyPressed(GameSettings gameSettings)
        {
            return GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < -0.3 || GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y < -0.3 || Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S);
        }
        public static bool GoBackButtonIsCurrentlyPressed(GameSettings gameSettings)
        {
            return GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape);
        }
    }
}
