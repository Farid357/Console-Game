using System.Drawing;

namespace Console_Game
{
    public interface IInventoryItemViewData
    {
        string Name { get; }

        Graphics Icon { get; }
    }
}