using System.Drawing;

namespace Console_Game.UI
{
    public interface IButtonView
    {
        Color Color { get; }

        void Press();

        void Enable();

        void Disable();
    }
}