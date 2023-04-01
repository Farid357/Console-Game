using System.Collections.Generic;

namespace ConsoleGame.Weapon
{
    public sealed class WeaponsData : IWeaponsData
    {
        private readonly Dictionary<IWeapon, IWeaponData> _data;

        public WeaponsData()
        {
            _data = new Dictionary<IWeapon, IWeaponData>();
        }

        public IWeaponData DataFor(IWeapon weapon)
        {
            return _data[weapon];
        }

        public void Add(IWeapon weapon, IWeaponData data)
        {
            _data.Add(weapon, data);
        }
    }
}