using System.Drawing;
using ConsoleGame.UI;

namespace ConsoleGame.Tests.UI
{
    public sealed class DummyImage : IImage
    {
        public bool IsEnabled { get; private set; }
       
        public ITransform Transform { get; }
       
        public Color Color { get; private set; }
        
        public void Enable()
        {
            IsEnabled = true;
        }

        public void Disable()
        {
            IsEnabled = false;
        }

        public void Draw()
        {
        }

        public void SwitchColor(Color color)
        {
            Color = color;
        }
    }
}