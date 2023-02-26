using System;
using Console_Game.Loop;
using Console_Game.Save_Storages;
using Console_Game.Weapons;

namespace Console_Game
{
    public sealed class Game : IGame
    {
        private readonly IGameLoop _gameLoop;
        private readonly IGameTime _gameTime;
        
        public Game()
        {
            _gameTime = new GameTime();
            _gameLoop = new GameLoop(_gameTime);
            IGameUpdate gameUpdate = _gameLoop.GameUpdate;
            ISaveStorages saveStorages = new SaveStorages();
            IFactory<IWallet> walletFactory = new WalletFactory(saveStorages);
            IWeaponInput weaponInput = new WeaponInput(new Key(ConsoleKey.F));
            IFactory<IWeaponWithMagazine> weaponFactory = new StartPlayerWeaponFactory(gameUpdate);
            IWeaponWithMagazine weapon = weaponFactory.Create();
            IPlayerSimulation playerSimulation = new PlayerSimulation(gameUpdate);
            playerSimulation.CreatePlayer(weaponInput, weapon);
            walletFactory.Create();
            _gameLoop.Start();
        }

        public void Play()
        {
            _gameTime.Play();
            _gameLoop.Start();
        }
    }
}