using System.Collections.Generic;
using Console_Game;
using Console_Game.UI;
using NUnit.Framework;

namespace Console_Game.Tests.UI
{
    [TestFixture]
    public sealed class WindowTest
    {
        [Test]
        public void OpensAndClosesCorrectly()
        {
            IWindow window = new Window(new UiElement(new Transform()));
            window.Open();
            Assert.That(window.IsOpen);
            window.Close();
            Assert.That(window.IsOpen == false);
        }

        [Test]
        public void GroupOpensAndClosesCorrectly()
        {
            IWindow window = new Window(new UiElement(new Transform()));
            IWindow windows = new Windows(new List<IWindow> { new Window(new UiElement(new Transform())), window });
            windows.Open();
            Assert.That(windows.IsOpen);
            Assert.That(window.IsOpen);
            windows.Close();
            Assert.That(windows.IsOpen == false);
            Assert.That(window.IsOpen == false);
        }
    }
}