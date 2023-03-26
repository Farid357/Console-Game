using System.Drawing;

namespace ConsoleGame.UI
{
    public interface IImage : IRenderer, IUiElement
    {
        Color Color { get; }
        
        void SwitchColor(Color color);
    }
}