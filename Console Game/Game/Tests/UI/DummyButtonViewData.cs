using System.Drawing;
using Console_Game.UI;

namespace Console_Game.Tests.UI
{
    public sealed class DummyButtonViewData : IButtonViewData
    {
        public Color StartColor { get; } = Color.Aqua;
        public Color DisabledColor { get; } = Color.Aqua;
        
        public Color PressedColor { get; } = Color.Olive;
    }
}