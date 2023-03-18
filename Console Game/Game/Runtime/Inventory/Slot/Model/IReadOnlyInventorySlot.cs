namespace Console_Game
{
    public interface IReadOnlyInventorySlot<out TItem> where TItem : IInventoryItem
    {
        TItem Item { get; }
        
        int ItemsCount { get; }

        bool CanTake(int itemsCount);
        
        bool CanAdd(int itemsCount);
    }
}