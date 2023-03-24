namespace Console_Game
{
    public interface IInventorySlot<out TItem> : IReadOnlyInventorySlot<TItem>
    {
        void Add(int itemsCount);

        void Take(int itemsCount);

    }
}