using System.Collections.Generic;
using System.Drawing;
using ConsoleGame.UI;
using NUnit.Framework;

namespace ConsoleGame.Tests.UI
{
    [TestFixture]
    public sealed class ButtonTest
    {
        [Test]
        public void GroupPressesCorrectly()
        {
            IButtonViewData buttonViewData = new DummyButtonViewData();
            IButtonView buttonView = new ButtonView(new DummyImage(), buttonViewData);
            IButton button = new Button(buttonView, new UiElement(new Transform()));
            button.Enable();
            IPressOnlyButton buttons = new Buttons(new List<IButton> { button });
            buttons.Press();
            Assert.That(buttonView.Color == buttonViewData.PressedColor);
        }
    }
}