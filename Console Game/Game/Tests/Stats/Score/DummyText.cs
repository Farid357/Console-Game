using System.Drawing;
using ConsoleGame.UI;

namespace ConsoleGame.Tests
{
    public sealed class DummyText : IText
    {
        public bool IsEnabled { get; }
        public ITransform Transform { get; }
        public Color Color { get; }
        public string Line { get; }

        public void Enable()
        {
        }

        public void Disable()
        {
        }

        public void Visualize(string line)
        {
        }

        public void SwitchColor(Color color)
        {
        }
    }
}