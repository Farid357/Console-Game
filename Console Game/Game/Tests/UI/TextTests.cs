using Console_Game;
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
            IText text = new Text(new UiElement(new UiElementView()));
            const string value = "dldld";
            text.Visualize(value);
            Assert.That(text.Value == value);
        }
        
        [Test]
        public void GroupUpdatesValue()
        {
            IText texts = new Texts(new Group<IText>());
            const string value = "dldld";
            texts.Visualize(value);
            Assert.That(texts.Value == value);
        }
    }
}