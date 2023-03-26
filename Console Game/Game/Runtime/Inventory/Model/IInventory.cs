namespace ConsoleGame
{
    public interface IInventory<TItem> : IReadOnlyInventory<TItem>
    {
        void Add(IInventorySlot<TItem> slot);

        void Drop(IInventorySlot<TItem> slot);
    }
}