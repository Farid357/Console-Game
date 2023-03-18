namespace Console_Game
{
    public interface IInventoryItem
    {
        IInventoryItemViewData ViewData { get; }

        bool IsSelected { get; }
        
        void Unselect();
        
        void Select();
    }
}
