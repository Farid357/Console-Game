namespace Console_Game
{
    public interface IInventorySlot<out TItem> where TItem : IInventoryItem
    {
        TItem Item{ get; }
        
        int ItemsCount { get; }

        bool CanAdd(int itemsCount);

        void Add(int itemsCount);

    }
}