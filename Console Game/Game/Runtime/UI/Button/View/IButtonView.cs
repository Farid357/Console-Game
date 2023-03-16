using System.Drawing;

namespace Console_Game.Shop
{
    public interface IButtonView
    {
        Color Color { get; }
        
        void Enable();
        
        void Disable();
    }
}