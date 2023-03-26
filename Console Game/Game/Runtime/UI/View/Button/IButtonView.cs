using System.Drawing;

namespace ConsoleGame.UI
{
    public interface IButtonView
    {
        Color Color { get; }

        void Press();

        void Enable();

        void Disable();
    }
}