using ConsoleGame.UI;

namespace ConsoleGame
{
    public interface IInventoryItemViewData
    {
        string Name { get; }

        IImage Icon { get; }
    }
}