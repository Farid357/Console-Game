using System;

namespace Console_Game
{
    public sealed class InventoryItem : IInventoryItem
    {
        private readonly IGameObject _gameObject;

        public InventoryItem(IInventoryItemViewData viewData, IGameObject gameObject)
        {
            _gameObject = gameObject ?? throw new ArgumentNullException(nameof(gameObject));
            ViewData = viewData ?? throw new ArgumentNullException(nameof(viewData));
        }

        public IInventoryItemViewData ViewData { get; }
        
        public bool IsSelected { get; private set; }
        
        public void Unselect()
        {
            if (IsSelected == false)
                throw new InvalidOperationException($"Already unselected!");

            IsSelected = false;
            _gameObject.Disable();
        }

        public void Select()
        {
            if (IsSelected)
                throw new InvalidOperationException($"Already selected!");

            IsSelected = true;
            _gameObject.Enable();
        }
    }
}