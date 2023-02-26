using System;

namespace Console_Game.Inventory
{
    public sealed class WeaponInventoryItemSelector : IInventoryItemSelector<IWeaponInventoryItem>
    {
        private readonly IPlayerSimulation _playerSimulation;

        public WeaponInventoryItemSelector(IPlayerSimulation playerSimulation)
        {
            _playerSimulation = playerSimulation ?? throw new ArgumentNullException(nameof(playerSimulation));
        }

        public void Select(IWeaponInventoryItem item)
        {
            if (_playerSimulation.HasPlayer())
                _playerSimulation.DeleteCurrentPlayer();

            _playerSimulation.CreatePlayer(item.WeaponInput, item.Weapon);
        }
    }
}