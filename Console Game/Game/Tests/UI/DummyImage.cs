using System.Drawing;
using ConsoleGame.UI;

namespace ConsoleGame.Tests.UI
{
    public sealed class DummyImage : IImage
    {
        public bool IsEnabled { get; }
       
        public ITransform Transform { get; }
       
        public Color Color { get; private set; }
        
        public void Enable()
        {
            
        }

        public void Disable()
        {
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