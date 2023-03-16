using System;

namespace Console_Game.UI
{
    public sealed class UiElement : IUiElement
    {
        private readonly IUiElementView _view;

        public UiElement(IUiElementView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public bool IsEnabled { get; private set; }
        
        public void Enable()
        {
            if (IsEnabled)
                throw new InvalidOperationException($"Window is already open!");

            IsEnabled = true;
            _view.Enable();
        }

        public void Disable()
        {
            if (IsEnabled == false)
                throw new InvalidOperationException($"Window is already closed!");
            
            IsEnabled = false;
            _view.Disable();
        }
    }
}