using System;
using System.Collections.Generic;

namespace Console_Game.UI
{
    public sealed class Canvas : ICanvas
    {
        private readonly List<IUiElement> _uiElements;

        public Canvas(List<IUiElement> uiElements)
        {
            _uiElements = uiElements ?? throw new ArgumentNullException(nameof(uiElements));
        }

        public Canvas() : this(new List<IUiElement>())
        {
            
        }
        
        public bool IsEnabled { get; private set; }

        public IReadOnlyList<IUiElement> All => _uiElements;

        public void Add(IUiElement instance) => _uiElements.Add(instance);

        public void Remove(IUiElement instance) => _uiElements.Remove(instance);

        public void Enable()
        {
            IsEnabled = true;
            _uiElements.ForEach(element => element.Enable());
        }

        public void Disable()
        {
            IsEnabled = false;
            _uiElements.ForEach(element => element.Disable());
        }
    }
}