using System.Drawing;

namespace Console_Game.UI
{
    public interface IButtonViewData
    {
        Color StartColor { get; }
        
        Color DisabledColor { get; }
        
        Color PressedColor { get; }
    }
}