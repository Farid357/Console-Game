using System.Linq;
using NUnit.Framework;

namespace Console_Game.Tests.Inventory
{
    [TestFixture]
    public sealed class InventoryTest
    {
        [Test]
        public void AddsCorrectly()
        {
            IInventory<IInventoryItem> inventory = new Inventory<IInventoryItem>(new InventoryView<IInventoryItem>());
            inventory.Add(new DummySlot<IInventoryItem>());
            Assert.That(inventory.Slots.Count() == 1);
        }
        
        [Test]
        public void RemovesCorrectly()
        {
            IInventory<IInventoryItem> inventory = new Inventory<IInventoryItem>(new InventoryView<IInventoryItem>());
            IInventorySlot<IInventoryItem> slot = new DummySlot<IInventoryItem>();
            inventory.Add(slot);
            Assert.That(inventory.CanDrop(slot));
            inventory.Drop(slot);
            Assert.That(!inventory.Slots.Any());
        }
    }
}