namespace Console_Game
{
    public interface IReadOnlyInventorySlot<out TItem> where TItem : IInventoryItem
    {
        TItem Item { get; }
        
        int ItemsCount { get; }

        bool CanTake(int itemsCount);
        
        bool CanAdd(int itemsCount);
    }

    public interface IInventorySlot<out TItem> : IReadOnlyInventorySlot<TItem> where TItem : IInventoryItem
    {
        void Add(int itemsCount);

        void Take(int itemsCount);

    }
}