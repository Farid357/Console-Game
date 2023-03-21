using System.Drawing;
using Console_Game.UI;

namespace Console_Game.Tests
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