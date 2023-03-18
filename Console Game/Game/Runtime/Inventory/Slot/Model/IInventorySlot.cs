namespace Console_Game
{
    public interface IInventorySlot<out TItem> : IReadOnlyInventorySlot<TItem> where TItem : IInventoryItem
    {
        void Add(int itemsCount);

        void Take(int itemsCount);

    }
}