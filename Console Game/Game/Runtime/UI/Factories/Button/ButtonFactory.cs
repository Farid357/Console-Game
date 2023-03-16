using System;
using System.Drawing;

namespace Console_Game.UI
{
    public sealed class ButtonFactory : IButtonFactory
    {
        private readonly ICanvas _canvas;
        private readonly ButtonViewData _viewData;

        public ButtonFactory(ICanvas canvas) : this(canvas, new ButtonViewData(Color.White, Color.Gray, Color.Bisque))
        {
        }

        public ButtonFactory(ICanvas canvas, ButtonViewData viewData)
        {
            _canvas = canvas ?? throw new ArgumentNullException(nameof(canvas));
            _viewData = viewData;
        }

        public IButton Create()
        {
            IButtonView view = new ButtonView(_viewData.StartColor, _viewData.DisableColor, _viewData.PressedColor);
            IButton button = new Button(view);
            _canvas.Add(button);
            return button;
        }
    }
}