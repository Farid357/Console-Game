using System;
using System.Drawing;

namespace Console_Game.UI
{
    [Serializable]
    public sealed class ButtonView : IButtonView
    {
        private readonly IImage _image;
        private readonly Color _startColor;
        private readonly Color _disabledColor;
        private readonly Color _pressedColor;

        public ButtonView(IImage image, Color color, Color disabledColor, Color pressedColor)
        {
            _image = image ?? throw new ArgumentNullException(nameof(image));
            _startColor = color;
            _disabledColor = disabledColor;
            _pressedColor = pressedColor;
        }

        public Color Color => _image.Color;
        
        public void Press()
        {
            _image.SwitchColor(_pressedColor);
        }

        public void Enable()
        {
            _image.SwitchColor(_startColor);
        }

        public void Disable()
        {
            _image.SwitchColor(_disabledColor);
        }
    }
}