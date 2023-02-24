using System;
using System.Numerics;
using Console_Game.Loop;
using Console_Game.Weapons;

namespace Console_Game
{
    public sealed class StartPlayerWeaponFactory : IFactory<IWeaponWithMagazine>
    {
        private readonly IGameUpdate _gameUpdate;
        private readonly IBulletsFactory _bulletsFactory;

        public StartPlayerWeaponFactory(IGameUpdate gameUpdate)
        {
            _gameUpdate = gameUpdate ?? throw new ArgumentNullException(nameof(gameUpdate));
            _bulletsFactory = new BulletsFactory(new Transform(Vector2.UnitX));
        }

        public IWeaponWithMagazine Create()
        {
            IWeaponMagazine magazine = new WeaponMagazine(30, new WeaponMagazineView());
            var cooldownTimer = new Timer(0.2f);
            _gameUpdate.Add(cooldownTimer);
            return new WeaponWithMagazine(magazine,
                new WeaponWithShootWaiting(cooldownTimer, new Weapon(_bulletsFactory)));
        }
    }
}