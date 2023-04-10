using System;

namespace ConsoleGame
{
    public sealed class BulletsBonusFactory : IBonusFactory
    {
        private readonly IBonusFactory _bonusFactory;
        private readonly IInventory<IWeaponInventoryItem> _inventory;

        public BulletsBonusFactory(IBonusFactory bonusFactory, IInventory<IWeaponInventoryItem> inventory)
        {
            _bonusFactory = bonusFactory ?? throw new ArgumentNullException(nameof(bonusFactory));
            _inventory = inventory ?? throw new ArgumentNullException(nameof(inventory));
        }

        public IBonus Create(ITransform transform)
        {
            IBonus bonus = _bonusFactory.Create(transform);
            return new BulletsBonus(bonus, _inventory);
        }
    }
}