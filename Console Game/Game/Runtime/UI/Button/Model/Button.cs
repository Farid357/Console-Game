using System;

namespace Console_Game.Shop
{
    public sealed class Button : IButton
    {
        private readonly IButtonView _buttonView;

        public Button(IButtonView buttonView)
        {
            _buttonView = buttonView ?? throw new ArgumentNullException(nameof(buttonView));
        }

        public bool IsEnabled { get; private set; }

        public void Press()
        {
            if (IsEnabled == false)
                throw new InvalidOperationException($"Buttons isn't enabled, you can't press it!");
            
            Console.WriteLine("Pressed");   
        }

        public void Enable()
        {
            IsEnabled = true;
            _buttonView.Enable();
        }

        public void Disable()
        {
            IsEnabled = false;
            _buttonView.Disable();
        }
    }
}