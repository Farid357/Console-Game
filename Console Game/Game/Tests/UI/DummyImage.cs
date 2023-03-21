using System.Drawing;
using Console_Game.UI;

namespace Console_Game.Tests.UI
{
    public sealed class DummyImage : IImage
    {
        public bool IsEnabled { get; }
       
        public ITransform Transform { get; }
       
        public Color Color { get; }
        
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
        }
    }
}