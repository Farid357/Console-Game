using System;
using System.Drawing;

namespace Console_Game.UI
{
    public sealed class ButtonFactory : IButtonFactory
    {
        private readonly IUiElementFactory _uiElementFactory;
        private readonly ButtonViewData _viewData;

        public ButtonFactory(IUiElementFactory uiElementFactory) : this(uiElementFactory, new ButtonViewData(Color.White, Color.Gray, Color.Bisque))
        {
        }

        public ButtonFactory(IUiElementFactory uiElementFactory, ButtonViewData viewData)
        {
            _uiElementFactory = uiElementFactory ?? throw new ArgumentNullException(nameof(uiElementFactory));
            _viewData = viewData;
        }

        public IButton Create(ITransform transform)
        {
            IButtonView view = new ButtonView(_viewData.StartColor, _viewData.DisableColor, _viewData.PressedColor);
            IButton button = new Button(view, _uiElementFactory.Create(transform));
            return button;
        }
    }
}