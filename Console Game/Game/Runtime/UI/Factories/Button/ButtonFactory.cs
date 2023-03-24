using System;
using System.Drawing;

namespace Console_Game.UI
{
    public sealed class ButtonFactory : IButtonFactory
    {
        private readonly IUiElementFactory _uiElementFactory;
        private readonly IImageFactory _imageFactory;

        public ButtonFactory(IUiElementFactory uiElementFactory, IImageFactory imageFactory)
        {
            _uiElementFactory = uiElementFactory ?? throw new ArgumentNullException(nameof(uiElementFactory));
            _imageFactory = imageFactory ?? throw new ArgumentNullException(nameof(imageFactory));
        }

        public IButton Create(IImage image, IButtonViewData viewData)
        {
            IButtonView view = new ButtonView(image, viewData);
            IButton button = new Button(view, _uiElementFactory.Create(image.Transform));
            button.Enable();
            return button;
        }
    }
}