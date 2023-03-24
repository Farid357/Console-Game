using System.Drawing;

namespace Console_Game.UI
{
    public interface IImage : IRenderer, IUiElement
    {
        Color Color { get; }
        
        void SwitchColor(Color color);
    }
}