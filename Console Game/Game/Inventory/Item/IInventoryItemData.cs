using System.Drawing;

namespace Console_Game
{
    public interface IInventoryItemData
    {
        string Name { get; }

        Graphics Icon { get; }
    }
}