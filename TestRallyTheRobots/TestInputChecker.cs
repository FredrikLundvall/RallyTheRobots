using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using RallyTheRobots.GUI.Common;

namespace TestRallyTheRobots
{
    [TestClass]
    public class TestInputChecker
    {
        [TestMethod]
        public void WhenKeyboardKeyIsPushed_AnyButtonIsCurrentlyPressed_ReturnsTrue()
        {
            var inputChecker = new InputChecker();
            var inputConnectorMock = new InputConnectorMock();
            var gameSettings = new GameSettings();
            inputChecker.SetInputConnector(inputConnectorMock);
            inputConnectorMock.ManipulateKeyboardState = new KeyboardState(new Keys[] { Keys.A });
            Assert.IsTrue(inputChecker.AnyButtonIsCurrentlyPressed(gameSettings));
            inputConnectorMock.ManipulateKeyboardState = new KeyboardState(new Keys[] { Keys.NumPad2, Keys.Home });
            Assert.IsTrue(inputChecker.AnyButtonIsCurrentlyPressed(gameSettings));
            inputConnectorMock.ManipulateKeyboardState = new KeyboardState(new Keys[] { Keys.Enter });
            Assert.IsTrue(inputChecker.AnyButtonIsCurrentlyPressed(gameSettings));
        }
        [TestMethod]
        public void WhenNoKeyboardKeyIsPushed_AnyButtonIsCurrentlyPressed_ReturnsFalse()
        {
            var inputChecker = new InputChecker();
            var inputConnectorMock = new InputConnectorMock();
            var gameSettings = new GameSettings();
            inputChecker.SetInputConnector(inputConnectorMock);
            inputConnectorMock.ManipulateKeyboardState = new KeyboardState(new Keys[] {});
            Assert.IsFalse(inputChecker.AnyButtonIsCurrentlyPressed(gameSettings));
        }
        [TestMethod]
        public void WhenButtonForSelectIsPushed_ButtonForSelectIsCurrentlyPressed_ReturnsTrue()
        {
            var inputChecker = new InputChecker();
            var inputConnectorMock = new InputConnectorMock();
            var gameSettings = new GameSettings();
            inputChecker.SetInputConnector(inputConnectorMock);
            gameSettings.SetKeyboardKeysForSelect(new Keys[] { Keys.Enter, Keys.E });
            inputConnectorMock.ManipulateKeyboardState = new KeyboardState(new Keys[] { Keys.Enter });
            Assert.IsTrue(inputChecker.ButtonForSelectIsCurrentlyPressed(gameSettings));
            gameSettings.SetKeyboardKeysForSelect(new Keys[] { Keys.F1 });
            inputConnectorMock.ManipulateKeyboardState = new KeyboardState(new Keys[] { Keys.F1 });
            Assert.IsTrue(inputChecker.ButtonForSelectIsCurrentlyPressed(gameSettings));
        }
        [TestMethod]
        public void WhenNoButtonForSelectIsPushed_ButtonForSelectIsCurrentlyPressed_ReturnsFalse()
        {
            var inputChecker = new InputChecker();
            var inputConnectorMock = new InputConnectorMock();
            var gameSettings = new GameSettings();
            inputChecker.SetInputConnector(inputConnectorMock);
            gameSettings.SetKeyboardKeysForSelect(new Keys[] { Keys.Enter, Keys.E });
            inputConnectorMock.ManipulateKeyboardState = new KeyboardState(new Keys[] { Keys.Escape });
            Assert.IsFalse(inputChecker.ButtonForSelectIsCurrentlyPressed(gameSettings));
            gameSettings.SetKeyboardKeysForSelect(new Keys[] { Keys.F1 });
            inputConnectorMock.ManipulateKeyboardState = new KeyboardState(new Keys[] {});
            Assert.IsFalse(inputChecker.ButtonForSelectIsCurrentlyPressed(gameSettings));
        }
    }
}
