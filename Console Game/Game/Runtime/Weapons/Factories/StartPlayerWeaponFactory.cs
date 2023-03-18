using System;
using Console_Game.UI;
using Console_Game.Weapons;

namespace Console_Game
{
    public sealed class StartPlayerWeaponFactory : IFactory<IWeaponWithMagazine>
    {
        private readonly IGroup<IGameLoopObject> _gameLoopObjects;
        private readonly IText _text;
        private readonly IBulletsFactory _bulletsFactory;

        public StartPlayerWeaponFactory(IGroup<IGameLoopObject> gameLoopObjects, IText text, IBulletsFactory bulletsFactory)
        {
            _gameLoopObjects = gameLoopObjects ?? throw new ArgumentNullException(nameof(gameLoopObjects));
            _text = text ?? throw new ArgumentNullException(nameof(text));
            _bulletsFactory = bulletsFactory ?? throw new ArgumentNullException(nameof(bulletsFactory));
        }

        public IWeaponWithMagazine Create()
        {
            IWeaponMagazineView magazineView = new WeaponMagazineView(_text);
            IWeaponMagazine magazine = new WeaponMagazine(30, magazineView);
            var shootCooldownTimer = new Timer(0.2f);
            IWeapon weapon = new Weapon(_bulletsFactory);
            IWeapon weaponWithShootWaiting = new WeaponWithShootWaiting(shootCooldownTimer, weapon);
            _gameLoopObjects.Add(shootCooldownTimer);
            IWeaponWithMagazineView view = new WeaponWithMagazineView();
            return new WeaponWithMagazine(magazine, weaponWithShootWaiting, view);
        }
    }
}