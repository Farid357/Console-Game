using System.Drawing;

namespace ConsoleGame.UI
{
    public interface IImage : IUiElement
    {
        Color Color { get; }
        
        void Draw();
        
        void SwitchColor(Color color);
    }
}