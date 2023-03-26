using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ConsoleGame.UI
{
    public sealed class LayoutGroup : ILayoutGroup
    {
        private readonly List<Vector2> _elementsPositions;
        private readonly Vector2 _size;
        private readonly Vector2 _offset;

        public LayoutGroup(Vector2 size, Vector2 offset)
        {
            _size = size;
            _offset = offset;
            _elementsPositions = new List<Vector2>();
        }

        private Vector2 LastElementPosition => _elementsPositions.Last();

        public void Add(IReadOnlyUiElement uiElement)
        {
            Vector2 elementPosition = new Vector2(LastElementPosition.X + _offset.X, LastElementPosition.Y);

            if (elementPosition.X > _size.X)
            {
                elementPosition = new Vector2(_elementsPositions.First().X, LastElementPosition.Y - _offset.Y);
            }

            uiElement.Transform.Teleport(elementPosition);
            _elementsPositions.Add(uiElement.Transform.Position);
        }

        public void Remove(IReadOnlyUiElement element)
        {
            _elementsPositions.Remove(element.Transform.Position);
        }
    }
}