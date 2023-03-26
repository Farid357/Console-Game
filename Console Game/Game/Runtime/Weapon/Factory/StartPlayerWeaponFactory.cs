using System;
using ConsoleGame.Loop;
using ConsoleGame.UI;
using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public sealed class StartPlayerWeaponFactory : IFactory<IWeaponWithMagazine>
    {
        private readonly IGameLoopObjectsGroup _gameLoop;
        private readonly IText _text;
        private readonly IBulletFactory _bulletFactory;

        public StartPlayerWeaponFactory(IGameLoopObjectsGroup gameLoop, IText text, IBulletFactory bulletFactory)
        {
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
            _text = text ?? throw new ArgumentNullException(nameof(text));
            _bulletFactory = bulletFactory ?? throw new ArgumentNullException(nameof(bulletFactory));
        }

        public IWeaponWithMagazine Create()
        {
            IWeaponMagazineView magazineView = new WeaponMagazineView(_text);
            IWeaponMagazine magazine = new WeaponMagazine(30, magazineView);
            var shootCooldownTimer = new Timer(0.2f);
            IWeapon weapon = new Weapon(_bulletFactory, 10);
            IWeapon weaponWithShootWaiting = new WeaponWithShootWaiting(shootCooldownTimer, weapon);
            _gameLoop.Add(shootCooldownTimer);
            IWeaponWithMagazineView view = new WeaponWithMagazineView();
            return new WeaponWithMagazine(magazine, weaponWithShootWaiting, view);
        }
    }
}