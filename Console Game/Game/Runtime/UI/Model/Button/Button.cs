using System;

namespace Console_Game.UI
{
    public sealed class Button : IButton
    {
        private readonly IButtonView _view;

        public Button(IButtonView buttonView)
        {
            _view = buttonView ?? throw new ArgumentNullException(nameof(buttonView));
        }

        public bool IsEnabled { get; private set; }

        public void Press()
        {
            if (IsEnabled == false)
                throw new InvalidOperationException($"Buttons isn't enabled, you can't press it!");

            _view.Press();
        }

        public void Enable()
        {
            IsEnabled = true;
            _view.Enable();
        }

        public void Disable()
        {
            IsEnabled = false;
            _view.Disable();
        }
    }
}