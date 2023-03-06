using System;
using System.Numerics;
using Console_Game.Loop;
using Console_Game.Tools;
using Console_Game.Weapons;

namespace Console_Game
{
    public sealed class StartPlayerWeaponFactory : IFactory<IWeaponWithMagazine>
    {
        private readonly IGroup<IGameLoopObject> _gameLoopObjects;
        private readonly IBulletsFactory _bulletsFactory;
        private readonly float _reloadTime;

        public StartPlayerWeaponFactory(IGroup<IGameLoopObject> gameLoopObjects, float reloadTime)
        {
            _gameLoopObjects = gameLoopObjects ?? throw new ArgumentNullException(nameof(gameLoopObjects));
            _reloadTime = reloadTime.ThrowIfLessOrEqualsToZeroException();
            _bulletsFactory = new BulletsFactory(new Transform(new ReadOnlyTransform(Vector2.UnitX)), _gameLoopObjects);
        }

        public IWeaponWithMagazine Create()
        {
            IWeaponMagazine magazine = new WeaponMagazine(30, new WeaponMagazineView());
            var shootCooldownTimer = new Timer(0.2f);
            var reloadTimer = new Timer(_reloadTime);
            IWeapon weapon = new Weapon(_bulletsFactory);
            IWeapon weaponWithShootWaiting = new WeaponWithShootWaiting(shootCooldownTimer, weapon);
            _gameLoopObjects.Add(shootCooldownTimer, reloadTimer);
            IWeaponWithMagazineView view = new WeaponWithMagazineView(reloadTimer);
            return new WeaponWithMagazine(magazine, weaponWithShootWaiting, view);
        }
    }
}