using System.Drawing;

namespace Console_Game.UI
{
    public interface IImage : IUiElement
    {
        Color Color { get; }

        void Draw();
        
        void SwitchColor(Color color);
    }
}