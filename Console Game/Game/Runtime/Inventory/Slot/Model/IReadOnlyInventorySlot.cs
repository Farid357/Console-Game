namespace ConsoleGame
{
    public interface IReadOnlyInventorySlot<out TItem>
    {
        TItem Item { get; }

        int ItemsCount { get; }

        bool CanTake(int itemsCount);

        bool CanAdd(int itemsCount);
    }
}