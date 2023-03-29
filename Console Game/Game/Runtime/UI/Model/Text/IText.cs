using System.Drawing;

namespace ConsoleGame.UI
{
    public interface IText : IOnlyVisualizeText, IUiElement
    {
        Color Color { get; }

        void SwitchColor(Color color);
    }
}