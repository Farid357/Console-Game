namespace Console_Game
{
    public interface IInventory<TItem> : IReadOnlyInventory<TItem> where TItem : IInventoryItem
    {
        void Add(IInventorySlot<TItem> slot);

        void Drop(IInventorySlot<TItem> slot);
    }
}