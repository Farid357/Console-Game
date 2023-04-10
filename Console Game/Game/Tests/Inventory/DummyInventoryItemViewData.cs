using ConsoleGame.Tests.UI;
using ConsoleGame.UI;

namespace ConsoleGame.Tests
{
    public sealed class DummyInventoryItemViewData : IInventoryItemViewData
    {
        public string Name => "Item";

        public IImage Icon { get; } = new DummyImage();
    }
}