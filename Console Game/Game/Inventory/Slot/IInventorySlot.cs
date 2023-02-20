namespace Console_Game
{
    public interface IInventorySlot<TItem> where TItem : IInventoryItem
    {
        int ItemsCount { get; }

        bool IsCrowded { get; }

        bool CanAddItem(IInventoryItem item);
    }
}