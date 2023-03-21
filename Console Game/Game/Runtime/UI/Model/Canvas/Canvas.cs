using System;
using System.Collections.Generic;

namespace Console_Game.UI
{
    [Serializable]
    public sealed class Canvas : ICanvas
    {
        private readonly List<IUiElement> _uiElements;

        public Canvas(List<IUiElement> uiElements, ITransform transform)
        {
            _uiElements = uiElements ?? throw new ArgumentNullException(nameof(uiElements));
            Transform = transform ?? throw new ArgumentNullException(nameof(transform));
        }

        public Canvas(ITransform transform) : this(new List<IUiElement>(), transform)
        {
        }

        public bool IsEnabled { get; private set; }

        public ITransform Transform { get; }

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