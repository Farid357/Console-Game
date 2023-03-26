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
            Color startColor = Color.Azure;
            Color disableColor = Color.Brown;
            IButtonView buttonView = new ButtonView(new DummyImage(), new DummyButtonViewData());
            IButton button = new Buttons(new List<IButton> { new Button(buttonView, new UiElement(new Transform())) });
            button.Enable();
            Assert.That(button.IsEnabled);
            Assert.That(buttonView.Color == startColor);
            button.Disable();
            Assert.That(button.IsEnabled == false);
            Assert.That(buttonView.Color == disableColor);
        }
    }
}