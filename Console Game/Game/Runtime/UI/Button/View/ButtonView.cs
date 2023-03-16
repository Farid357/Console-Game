using System.Drawing;

namespace Console_Game.Shop
{
    public sealed class ButtonView : IButtonView
    {
        private readonly Color _startColor;
        private readonly Color _disableColor;

        public ButtonView(Color color, Color disableColor)
        {
            _startColor = color;
            _disableColor = disableColor;
            Color = color;
        }
        
        public Color Color { get; private set; }

        public void Enable()
        {
            Color = _startColor;
        }

        public void Disable()
        {
            Color = _disableColor;
        }
    }
}