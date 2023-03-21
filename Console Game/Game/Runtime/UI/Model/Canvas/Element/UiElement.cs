using System;

namespace Console_Game.UI
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
            if (IsEnabled)
                throw new InvalidOperationException($"Window is already open!");

            IsEnabled = true;
        }

        public void Disable()
        {
            if (IsEnabled == false)
                throw new InvalidOperationException($"Window is already closed!");

            IsEnabled = false;
        }
    }
}