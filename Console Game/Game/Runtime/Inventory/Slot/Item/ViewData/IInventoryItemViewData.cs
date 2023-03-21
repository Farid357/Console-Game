using Console_Game.UI;

namespace Console_Game
{
    public interface IInventoryItemViewData
    {
        string Name { get; }

        IImage Icon { get; }
    }
}