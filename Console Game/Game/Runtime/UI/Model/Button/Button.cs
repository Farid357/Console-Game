using System;

namespace Console_Game.UI
{
    [Serializable]
    public sealed class Button : IButton
    {
        private readonly IButtonView _view;
        private readonly IUiElement _uiElement;

        public Button(IButtonView buttonView, IUiElement uiElement)
        {
            _view = buttonView ?? throw new ArgumentNullException(nameof(buttonView));
            _uiElement = uiElement ?? throw new ArgumentNullException(nameof(uiElement));
        }
        
        public ITransform Transform => _uiElement.Transform;

        public bool IsEnabled => _uiElement.IsEnabled;

        public void Press()
        {
            if (IsEnabled == false)
                throw new InvalidOperationException($"Buttons isn't enabled, you can't press it!");

            _view.Press();
        }

        public void Enable()
        {
            _view.Enable();
            _uiElement.Enable();
        }

        public void Disable()
        {
            _view.Disable();
            _uiElement.Disable();
        }
    }
}