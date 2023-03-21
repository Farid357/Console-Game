namespace Console_Game
{
    public interface IInventorySlot<TItem> : IReadOnlyInventorySlot<TItem>
    {
        void Add(int itemsCount);

        void Take(int itemsCount);

    }
}