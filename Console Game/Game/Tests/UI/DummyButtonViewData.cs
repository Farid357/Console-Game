using System.Drawing;
using ConsoleGame.UI;

namespace ConsoleGame.Tests.UI
{
    public sealed class DummyButtonViewData : IButtonViewData
    {
        public Color StartColor { get; } = Color.Aqua;
        public Color DisabledColor { get; } = Color.Aqua;
        
        public Color PressedColor { get; } = Color.Olive;
    }
}