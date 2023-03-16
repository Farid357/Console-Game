using System.Drawing;

namespace Console_Game.UI
{
    public sealed class ButtonView : IButtonView
    {
        private readonly Color _startColor;
        private readonly Color _disableColor;
        private readonly Color _pressedColor;

        public ButtonView(Color color, Color disableColor, Color pressedColor)
        {
            _startColor = color;
            _disableColor = disableColor;
            _pressedColor = pressedColor;
            Color = color;
        }
        
        public Color Color { get; private set; }
        
        public void Press()
        {
            Color = _pressedColor;
        }

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