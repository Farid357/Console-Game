using System.Collections.Generic;
using System.Drawing;
using Console_Game.UI;
using NUnit.Framework;

namespace Console_Game.Tests.UI
{
    [TestFixture]
    public sealed class ButtonTest
    {
        [Test]
        public void GroupPressesCorrectly()
        {
            Color startColor = Color.Azure;
            Color disableColor = Color.Brown;
            IButtonView buttonView = new ButtonView(startColor, disableColor, Color.Aqua);
            IButton button = new Buttons(new List<IButton> { new Button(buttonView) });
            button.Enable();
            Assert.That(button.IsEnabled);
            Assert.That(buttonView.Color == startColor);
            button.Disable();
            Assert.That(button.IsEnabled == false);
            Assert.That(buttonView.Color == disableColor);
        }
    }
}