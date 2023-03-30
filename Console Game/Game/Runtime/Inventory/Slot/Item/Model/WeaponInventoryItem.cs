using System;

namespace ConsoleGame
{
    public sealed class WeaponInventoryItem<TShooter, TWeapon> : IWeaponInventoryItem<TWeapon> where TShooter : IShooter<TWeapon>
    {
        private readonly IShootersSimulation<TShooter, TWeapon> _shootersSimulation;
        private readonly IInventoryItem _item;
        private readonly TShooter _shooter;
        
        public WeaponInventoryItem(IShootersSimulation<TShooter, TWeapon> shootersSimulation, IInventoryItem item, TShooter shooter)
        {
            _shootersSimulation = shootersSimulation ?? throw new ArgumentNullException(nameof(shootersSimulation));
            _item = item ?? throw new ArgumentNullException(nameof(item));
            _shooter = shooter;
        }

        public IInventoryItemViewData ViewData => _item.ViewData;
        
        public TWeapon Weapon => _shooter.Weapon;
      
        public bool IsSelected => _item.IsSelected;

        public void Select()
        {
            _shootersSimulation.Add(_shooter);
            _item.Select();
        }

        public void Unselect()
        {
            _shootersSimulation.DeleteCurrentPlayer();
            _item.Unselect();
        }
    }
}