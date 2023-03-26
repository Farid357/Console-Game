using System.Linq;
using NUnit.Framework;

namespace ConsoleGame.Tests.Inventory
{
    [TestFixture]
    public sealed class InventoryTest
    {
        private readonly IInventoryView<InventoryItem> _inventoryView = new DummyInventoryView<InventoryItem>();

        [Test]
        public void AddsCorrectly()
        {
            IInventory<InventoryItem> inventory = new Inventory<InventoryItem>(_inventoryView);
            inventory.Add(new DummySlot<InventoryItem>());
            Assert.That(inventory.Slots.Count() == 1);
        }
        
        [Test]
        public void RemovesCorrectly()
        {
            IInventory<InventoryItem> inventory = new Inventory<InventoryItem>(_inventoryView);
            IInventorySlot<InventoryItem> slot = new DummySlot<InventoryItem>();
            inventory.Add(slot);
            Assert.That(inventory.CanDrop(slot));
            inventory.Drop(slot);
            Assert.That(!inventory.Slots.Any());
        }
    }
}