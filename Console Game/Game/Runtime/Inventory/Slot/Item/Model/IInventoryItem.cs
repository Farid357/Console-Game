namespace ConsoleGame
{
    public interface IInventoryItem
    {
        IInventoryItemViewData ViewData { get; }

        bool IsSelected { get; }
        
        void Select();

        void Unselect();
    }
}