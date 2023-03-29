using System;
using System.Collections.Generic;

namespace ConsoleGame.UI
{
    [Serializable]
    public sealed class Canvas : ICanvas
    {
        private readonly List<IUiElement> _elements;

        public Canvas(List<IUiElement> elements, ITransform transform)
        {
            _elements = elements ?? throw new ArgumentNullException(nameof(elements));
            Transform = transform ?? throw new ArgumentNullException(nameof(transform));
        }

        public Canvas(ITransform transform) : this(new List<IUiElement>(), transform)
        {
        }

        public bool IsEnabled { get; private set; }

        public ITransform Transform { get; }

        public void Add(IUiElement element) => _elements.Add(element);

        public void Remove(IUiElement element) => _elements.Remove(element);

        public void Enable()
        {
            IsEnabled = true;
            _elements.ForEach(element => element.Enable());
        }

        public void Disable()
        {
            IsEnabled = false;
            _elements.ForEach(element => element.Disable());
        }
    }
}