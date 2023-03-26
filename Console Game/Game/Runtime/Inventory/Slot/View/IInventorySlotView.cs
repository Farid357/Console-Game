namespace ConsoleGame
{
    public interface IInventorySlotView
    {
        void Visualize(IInventoryItemViewData viewData, int count);
    }
}