using System;

namespace Console_Game.UI
{
    public sealed class UiElementFactory : IUiElementFactory
    {
        private readonly ICanvas _canvas;

        public UiElementFactory(ICanvas canvas)
        {
            _canvas = canvas ?? throw new ArgumentNullException(nameof(canvas));
        }

        public IUiElement Create(ITransform transform)
        {
            IUiElement uiElement = new UiElement(transform);
            _canvas.Add(uiElement);
            return uiElement;
        }
    }
}