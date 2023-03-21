using System;
using System.Drawing;

namespace Console_Game.UI
{
    public sealed class ButtonFactory : IButtonFactory
    {
        private readonly IUiElementFactory _uiElementFactory;
        private readonly IImageFactory _imageFactory;
        private readonly ButtonViewData _viewData;

        public ButtonFactory(IUiElementFactory uiElementFactory, IImageFactory imageFactory) : this(uiElementFactory, new ButtonViewData(Color.White, Color.Gray, Color.Bisque), imageFactory)
        {
        }

        public ButtonFactory(IUiElementFactory uiElementFactory, ButtonViewData viewData, IImageFactory imageFactory)
        {
            _uiElementFactory = uiElementFactory ?? throw new ArgumentNullException(nameof(uiElementFactory));
            _viewData = viewData;
            _imageFactory = imageFactory ?? throw new ArgumentNullException(nameof(imageFactory));
        }

        public IButton Create(ITransform transform)
        {
            IImage image = _imageFactory.Create(transform);
            IButtonView view = new ButtonView(image, _viewData.StartColor, _viewData.DisableColor, _viewData.PressedColor);
            IButton button = new Button(view, _uiElementFactory.Create(transform));
            button.Enable();
            return button;
        }
    }
}