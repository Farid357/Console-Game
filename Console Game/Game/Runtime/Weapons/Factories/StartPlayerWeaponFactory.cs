using System;
using System.Numerics;
using Console_Game.Loop;
using Console_Game.Tools;
using Console_Game.Weapons;

namespace Console_Game
{
    public sealed class StartPlayerWeaponFactory : IFactory<IWeaponWithMagazine>
    {
        private readonly IGameUpdate _gameUpdate;
        private readonly float _reloadTime;
        private readonly IBulletsFactory _bulletsFactory;

        public StartPlayerWeaponFactory(IGameUpdate gameUpdate, float reloadTime)
        {
            _gameUpdate = gameUpdate ?? throw new ArgumentNullException(nameof(gameUpdate));
            _reloadTime = reloadTime.ThrowIfLessOrEqualsToZeroException();
            _bulletsFactory = new BulletsFactory(new Transform(new ReadOnlyTransform(Vector2.UnitX)));
        }

        public IWeaponWithMagazine Create()
        {
            IWeaponMagazine magazine = new WeaponMagazine(30, new WeaponMagazineView());
            var shootCooldownTimer = new Timer(0.2f);
            var reloadTimer = new Timer(_reloadTime);
            IWeapon weapon = new Weapon(_bulletsFactory);
            IWeapon weaponWithShootWaiting = new WeaponWithShootWaiting(shootCooldownTimer, weapon);
            _gameUpdate.Add(shootCooldownTimer, reloadTimer);
            IWeaponWithMagazineView view = new WeaponWithMagazineView(reloadTimer);
            return new WeaponWithMagazine(magazine, weaponWithShootWaiting, view);
        }
    }
}