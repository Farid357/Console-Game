using System.Drawing;

namespace ConsoleGame.UI
{
    public interface IButtonViewData
    {
        Color StartColor { get; }
        
        Color DisabledColor { get; }
        
        Color PressedColor { get; }
    }
}