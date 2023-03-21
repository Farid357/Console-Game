namespace Console_Game
{
    public interface IInventorySlotView
    {
        void Visualize(IInventoryItemViewData viewData, int count);
    }
}