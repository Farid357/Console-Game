using System;
using Console_Game.Json;
using Console_Game.Loop;
using Console_Game.Save_Storages;
using Console_Game.Weapons;

namespace Console_Game
{
    public sealed class Game : IGame
    {
        private readonly IGameLoop _gameLoop;
        private readonly IGameTimer _gameTimer;

        public Game()
        {
            _gameTimer = new GameTimer();
            IFps fps = new Fps();
            _gameLoop = new GameLoop(_gameTimer, fps, 0.01f, new GamePause(new GameGamePauseView()));
            IGroup<IGameLoopObject> gameLoopObjects = _gameLoop.GameLoopObjects;
            ISaveStorages saveStorages = new SaveStorages();
            IFactory<IWallet> walletFactory = new WalletFactory(saveStorages);
            IWeaponInput weaponInput = new WeaponInput(new Key(ConsoleKey.F));
            IFactory<IWeaponWithMagazine> weaponFactory = new StartPlayerWeaponFactory(gameLoopObjects, 0.2f);
            IWeaponWithMagazine weapon = weaponFactory.Create();
            IPlayersSimulationView<IPlayer> playersSimulationView = new PlayersSimulationView<IPlayer>();
            IPlayersSimulation<IPlayer> playersSimulation = new PlayersSimulation<IPlayer>(gameLoopObjects, playersSimulationView);
            playersSimulation = new SelfCleaningPlayerSimulation<IPlayer>(playersSimulation);
            var playerFactory = new PlayerFactory(playersSimulation);
            var enemyData = new JsonFilesStorage().LoadFile<EnemyData>(JsonFilesPaths.Zombie);
            Console.WriteLine(enemyData.Name);
            playerFactory.Create(weaponInput, weapon);
            walletFactory.Create();
            _gameLoop.Start();
        }

        public void Play()
        {
            _gameTimer.Play();
            _gameLoop.Start();
        }
    }
}