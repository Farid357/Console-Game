using ConsoleGame.Tests.Inventory;
using NUnit.Framework;

namespace ConsoleGame.Tests
{
    [TestFixture]
    public sealed class CharacterTest
    {
        [Test]
        public void SelectsCorrectWeapon()
        {
            IInventory<IWeaponInventoryItem> inventory = new Inventory<IWeaponInventoryItem>(new DummyInventoryView<IWeaponInventoryItem>());
            IAdjustableMovement movement = new AdjustableMovement(new DummyMovement(), 1.5f);
            ICharacter character = new Character(new Health(50), inventory, movement);
            IWeapon weapon = new DummyWeapon();
            IWeaponInventoryItem item = new WeaponInventoryItem(new InventoryItem(new DummyInventoryItemViewData()), weapon, new WeaponParts(true));
            var slotView = new InventorySlotView(new DummyText());
            var slot = new InventorySlot<IWeaponInventoryItem>(item, slotView);
            item.Select();
            inventory.Add(slot);
            Assert.That(character.SelectedWeaponItem == item && character.SelectedWeaponItem.Weapon == weapon);
        }
    }
}