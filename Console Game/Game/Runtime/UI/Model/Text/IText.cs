using System.Drawing;

namespace Console_Game.UI
{
    public interface IText : IUiElement
    {
        Color Color { get; }
        
        string Line { get; }
        
        void Visualize(string line);

        void SwitchColor(Color color);
    }
}