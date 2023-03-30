using System;
using ConsoleGame.GameLoop;
using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public sealed class StartCharacterWeaponFactory : IWeaponWithMagazineFactory
    {
        private readonly IGameLoopObjectsGroup _gameLoop;
        private readonly IWeaponMagazineFactory _magazineFactory;
        private readonly IBulletFactory _bulletFactory;
        private readonly IReadOnlyCharacter _character;

        public StartCharacterWeaponFactory(IGameLoopObjectsGroup gameLoop, IWeaponMagazineFactory magazineFactory, IBulletFactory bulletFactory, IReadOnlyCharacter character)
        {
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
            _magazineFactory = magazineFactory ?? throw new ArgumentNullException(nameof(magazineFactory));
            _bulletFactory = bulletFactory ?? throw new ArgumentNullException(nameof(bulletFactory));
            _character = character ?? throw new ArgumentNullException(nameof(character));
        }

        public IWeaponWithMagazine Create()
        {
            IWeaponMagazine magazine = _magazineFactory.Create();
            var shootCooldownTimer = new Timer(0.2f);
            IWeapon weapon = new CharacterWeapon(_bulletFactory, _character.Movement, 10);
            IWeapon weaponWithShootWaiting = new WeaponWithShootWaiting(shootCooldownTimer, weapon);
            _gameLoop.Add(shootCooldownTimer);
            IWeaponWithReloadingView view = new WeaponWithReloadingView();
            return new WeaponWithMagazine(magazine, weaponWithShootWaiting, view);
        }
    }
}