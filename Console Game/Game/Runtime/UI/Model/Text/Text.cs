using System;

namespace Console_Game.UI
{
    public sealed class Text : IText
    {
        private readonly IUiElement _uiElement;

        public Text(IUiElement uiElement)
        {
            _uiElement = uiElement ?? throw new ArgumentNullException(nameof(uiElement));
        }
        
        public bool IsEnabled => _uiElement.IsEnabled;

        public string Value { get; private set; }

        public void Visualize(string value)
        {
            Value = value;
            Console.WriteLine(value);
        }


        public void Enable() => _uiElement.Enable();

        public void Disable() => _uiElement.Disable();
        
    }
}