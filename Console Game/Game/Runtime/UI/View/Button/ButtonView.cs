using System;
using System.Drawing;

namespace ConsoleGame.UI
{
    [Serializable]
    public sealed class ButtonView : IButtonView
    {
        private readonly IImage _image;
        private readonly IButtonViewData _viewData;

        public ButtonView(IImage image, IButtonViewData viewData)
        {
            _image = image ?? throw new ArgumentNullException(nameof(image));
            _viewData = viewData ?? throw new ArgumentNullException(nameof(viewData));
        }

        public Color Color => _image.Color;
        
        public void Press()
        {
            _image.SwitchColor(_viewData.PressedColor);
        }

        public void Enable()
        {
            _image.SwitchColor(_viewData.StartColor);
        }

        public void Disable()
        {
            _image.SwitchColor(_viewData.DisabledColor);
        }
    }
}