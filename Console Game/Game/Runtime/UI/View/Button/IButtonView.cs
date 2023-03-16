using System.Drawing;

namespace Console_Game.UI
{
    public interface IButtonView : IUiElementView
    {
        Color Color { get; }

        void Press();
    }
}