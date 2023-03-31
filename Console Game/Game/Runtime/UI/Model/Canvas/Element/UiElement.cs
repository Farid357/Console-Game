using System;

namespace ConsoleGame.UI
{
    public sealed class UiElement : IUiElement
    {
        public UiElement(ITransform transform)
        {
            Transform = transform ?? throw new ArgumentNullException(nameof(transform));
        }

        public bool IsEnabled { get; private set; }

        public ITransform Transform { get; }

        public void Enable()
        {
            IsEnabled = true;
        }

        public void Disable()
        {
            IsEnabled = false;
        }
    }
}