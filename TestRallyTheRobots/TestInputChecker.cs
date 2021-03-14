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
            inputConnectorMock.ManipulateKeyboardState = new KeyboardState(new Keys[] { Keys.E });
            Assert.IsTrue(inputChecker.AnyButtonIsCurrentlyPressed(gameSettings));
            inputConnectorMock.ManipulateKeyboardState = new KeyboardState(new Keys[] { Keys.Back, Keys.F });
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
        [TestMethod]
        public void WhenButtonForAlternateSelectIsPushed_ButtonForAlternateSelectIsCurrentlyPressed_ReturnsTrue()
        {
            var inputChecker = new InputChecker();
            var inputConnectorMock = new InputConnectorMock();
            var gameSettings = new GameSettings();
            inputChecker.SetInputConnector(inputConnectorMock);
            gameSettings.SetKeyboardKeysForAlternateSelect(new Keys[] { Keys.Back, Keys.F });
            inputConnectorMock.ManipulateKeyboardState = new KeyboardState(new Keys[] { Keys.Back });
            Assert.IsTrue(inputChecker.ButtonForAlternateSelectIsCurrentlyPressed(gameSettings));
            gameSettings.SetKeyboardKeysForAlternateSelect(new Keys[] { Keys.F1 });
            inputConnectorMock.ManipulateKeyboardState = new KeyboardState(new Keys[] { Keys.F1 });
            Assert.IsTrue(inputChecker.ButtonForAlternateSelectIsCurrentlyPressed(gameSettings));
        }
        [TestMethod]
        public void WhenNoButtonForAlternateSelectIsPushed_ButtonForAlternateSelectIsCurrentlyPressed_ReturnsFalse()
        {
            var inputChecker = new InputChecker();
            var inputConnectorMock = new InputConnectorMock();
            var gameSettings = new GameSettings();
            inputChecker.SetInputConnector(inputConnectorMock);
            gameSettings.SetKeyboardKeysForAlternateSelect(new Keys[] { Keys.Back, Keys.F });
            inputConnectorMock.ManipulateKeyboardState = new KeyboardState(new Keys[] { Keys.Escape });
            Assert.IsFalse(inputChecker.ButtonForAlternateSelectIsCurrentlyPressed(gameSettings));
            gameSettings.SetKeyboardKeysForAlternateSelect(new Keys[] { Keys.F1 });
            inputConnectorMock.ManipulateKeyboardState = new KeyboardState(new Keys[] { });
            Assert.IsFalse(inputChecker.ButtonForAlternateSelectIsCurrentlyPressed(gameSettings));
        }
        [TestMethod]
        public void WhenButtonForPreviousVerticalIsPushed_PreviousVerticalButtonIsCurrentlyPressed_ReturnsTrue()
        {
            var inputChecker = new InputChecker();
            var inputConnectorMock = new InputConnectorMock();
            var gameSettings = new GameSettings();
            inputChecker.SetInputConnector(inputConnectorMock);
            gameSettings.SetKeyboardKeysForPreviousVertical(new Keys[] { Keys.W });
            inputConnectorMock.ManipulateKeyboardState = new KeyboardState(new Keys[] { Keys.W });
            Assert.IsTrue(inputChecker.PreviousVerticalButtonIsCurrentlyPressed(gameSettings));
        }
        [TestMethod]
        public void WhenNoButtonForPreviousVerticalIsPushed_PreviousVerticalButtonIsCurrentlyPressed_ReturnsFalse()
        {
            var inputChecker = new InputChecker();
            var inputConnectorMock = new InputConnectorMock();
            var gameSettings = new GameSettings();
            inputChecker.SetInputConnector(inputConnectorMock);
            gameSettings.SetKeyboardKeysForPreviousVertical(new Keys[] { Keys.W });
            inputConnectorMock.ManipulateKeyboardState = new KeyboardState(new Keys[] { Keys.S });
            Assert.IsFalse(inputChecker.PreviousVerticalButtonIsCurrentlyPressed(gameSettings));
        }
        [TestMethod]
        public void WhenButtonForNextVerticalIsPushed_NextVerticalButtonIsCurrentlyPressed_ReturnsTrue()
        {
            var inputChecker = new InputChecker();
            var inputConnectorMock = new InputConnectorMock();
            var gameSettings = new GameSettings();
            inputChecker.SetInputConnector(inputConnectorMock);
            gameSettings.SetKeyboardKeysForNextVertical(new Keys[] { Keys.S });
            inputConnectorMock.ManipulateKeyboardState = new KeyboardState(new Keys[] { Keys.S });
            Assert.IsTrue(inputChecker.NextVerticalButtonIsCurrentlyPressed(gameSettings));
        }
        [TestMethod]
        public void WhenNoButtonForNextVerticalIsPushed_NextVerticalButtonIsCurrentlyPressed_ReturnsFalse()
        {
            var inputChecker = new InputChecker();
            var inputConnectorMock = new InputConnectorMock();
            var gameSettings = new GameSettings();
            inputChecker.SetInputConnector(inputConnectorMock);
            gameSettings.SetKeyboardKeysForNextVertical(new Keys[] { Keys.S });
            inputConnectorMock.ManipulateKeyboardState = new KeyboardState(new Keys[] { Keys.D });
            Assert.IsFalse(inputChecker.NextVerticalButtonIsCurrentlyPressed(gameSettings));
        }
        [TestMethod]
        public void WhenButtonForPreviousHorizontalIsPushed_PreviousHorizontalButtonIsCurrentlyPressed_ReturnsTrue()
        {
            var inputChecker = new InputChecker();
            var inputConnectorMock = new InputConnectorMock();
            var gameSettings = new GameSettings();
            inputChecker.SetInputConnector(inputConnectorMock);
            gameSettings.SetKeyboardKeysForPreviousHorizontal(new Keys[] { Keys.A });
            inputConnectorMock.ManipulateKeyboardState = new KeyboardState(new Keys[] { Keys.A });
            Assert.IsTrue(inputChecker.PreviousHorizontalButtonIsCurrentlyPressed(gameSettings));
        }
        [TestMethod]
        public void WhenNoButtonForPreviousHorizontalIsPushed_PreviousHorizontalButtonIsCurrentlyPressed_ReturnsFalse()
        {
            var inputChecker = new InputChecker();
            var inputConnectorMock = new InputConnectorMock();
            var gameSettings = new GameSettings();
            inputChecker.SetInputConnector(inputConnectorMock);
            gameSettings.SetKeyboardKeysForPreviousHorizontal(new Keys[] { Keys.A });
            inputConnectorMock.ManipulateKeyboardState = new KeyboardState(new Keys[] { Keys.D });
            Assert.IsFalse(inputChecker.PreviousHorizontalButtonIsCurrentlyPressed(gameSettings));
        }
        [TestMethod]
        public void WhenButtonForNextHorizontalIsPushed_NextHorizontalButtonIsCurrentlyPressed_ReturnsTrue()
        {
            var inputChecker = new InputChecker();
            var inputConnectorMock = new InputConnectorMock();
            var gameSettings = new GameSettings();
            inputChecker.SetInputConnector(inputConnectorMock);
            gameSettings.SetKeyboardKeysForNextHorizontal(new Keys[] { Keys.D });
            inputConnectorMock.ManipulateKeyboardState = new KeyboardState(new Keys[] { Keys.D });
            Assert.IsTrue(inputChecker.NextHorizontalButtonIsCurrentlyPressed(gameSettings));
        }
        [TestMethod]
        public void WhenNoButtonForNextHorizontalIsPushed_NextHorizontalButtonIsCurrentlyPressed_ReturnsFalse()
        {
            var inputChecker = new InputChecker();
            var inputConnectorMock = new InputConnectorMock();
            var gameSettings = new GameSettings();
            inputChecker.SetInputConnector(inputConnectorMock);
            gameSettings.SetKeyboardKeysForNextHorizontal(new Keys[] { Keys.D });
            inputConnectorMock.ManipulateKeyboardState = new KeyboardState(new Keys[] { Keys.S });
            Assert.IsFalse(inputChecker.NextHorizontalButtonIsCurrentlyPressed(gameSettings));
        }
        [TestMethod]
        public void WhenButtonForGoBackIsPushed_GoBackButtonIsCurrentlyPressed_ReturnsTrue()
        {
            var inputChecker = new InputChecker();
            var inputConnectorMock = new InputConnectorMock();
            var gameSettings = new GameSettings();
            inputChecker.SetInputConnector(inputConnectorMock);
            gameSettings.SetKeyboardKeysForGoBack(new Keys[] { Keys.Escape });
            inputConnectorMock.ManipulateKeyboardState = new KeyboardState(new Keys[] { Keys.Escape });
            Assert.IsTrue(inputChecker.GoBackButtonIsCurrentlyPressed(gameSettings));
        }
        [TestMethod]
        public void WhenNoButtonForGoBackIsPushed_GoBackButtonIsCurrentlyPressed_ReturnsFalse()
        {
            var inputChecker = new InputChecker();
            var inputConnectorMock = new InputConnectorMock();
            var gameSettings = new GameSettings();
            inputChecker.SetInputConnector(inputConnectorMock);
            gameSettings.SetKeyboardKeysForGoBack(new Keys[] { Keys.Escape });
            inputConnectorMock.ManipulateKeyboardState = new KeyboardState(new Keys[] { Keys.Back });
            Assert.IsFalse(inputChecker.GoBackButtonIsCurrentlyPressed(gameSettings));
        }
    }
}
