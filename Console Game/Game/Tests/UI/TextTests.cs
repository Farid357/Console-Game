using System.Drawing;
using Console_Game.UI;
using NUnit.Framework;

namespace Console_Game.Tests.UI
{
    [TestFixture]
    public sealed class TextTests
    {
        [Test]
        public void UpdatesValue()
        {
            IText text = new Text(new UiElement(new Transform()), new Font("Arial", 15));
            const string value = "dldld";
            text.Visualize(value);
            Assert.That(text.Line == value);
        }
        
        [Test]
        public void GroupUpdatesValue()
        {
            IText texts = new Texts();
            const string value = "dldld";
            texts.Visualize(value);
            Assert.That(texts.Line == value);
        }
    }
}