using System;

namespace ConsoleGame
{
    public sealed class WeaponInventoryItem<TPlayer> : IWeaponInventoryItem where TPlayer : IPlayer
    {
        private readonly IPlayersSimulation<TPlayer> _playersSimulation;
        private readonly IInventoryItem _item;
        private readonly TPlayer _player;
        
        public WeaponInventoryItem(IPlayersSimulation<TPlayer> playersSimulation, IInventoryItem item, TPlayer player)
        {
            _playersSimulation = playersSimulation ?? throw new ArgumentNullException(nameof(playersSimulation));
            _item = item ?? throw new ArgumentNullException(nameof(item));
            _player = player;
        }

        public IInventoryItemViewData ViewData => _item.ViewData;
        
        public IWeapon Weapon => _player.Weapon;
      
        public bool IsSelected => _item.IsSelected;

        public void Select()
        {
            _playersSimulation.Add(_player);
            _item.Select();
        }

        public void Unselect()
        {
            _playersSimulation.DeleteCurrentPlayer();
            _item.Unselect();
        }
    }
}