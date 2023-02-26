namespace Console_Game
{
    public interface IInventorySlotView<in TItem> where TItem : IInventoryItem
    {
        void Visualize(TItem item, int count);
    }
}