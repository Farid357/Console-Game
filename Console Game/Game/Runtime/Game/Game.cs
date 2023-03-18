using System;
using Console_Game.Loop;
using Console_Game.Save_Storages;
using Console_Game.UI;
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
            _gameLoop = new GameLoop(_gameTimer, 0.01f, new GamePause(new GamePauseView()));
            IGroup<IGameLoopObject> gameLoopObjects = _gameLoop.Objects;
            ISaveStorages saveStorages = new SaveStorages();
            IFactory<IWallet> walletFactory = new WalletFactory(saveStorages);
            IWeaponInput weaponInput = new WeaponInput(new Key(ConsoleKey.F));
            ICanvas canvas = new Canvas();
            ITextFactory textFactory = new TextFactory(canvas);
            IGameObjectsFactory gameObjectsFactory = new GameObjectsFactory();
            IBulletsFactory bulletsFactory = new BulletsFactory(new Transform(), gameLoopObjects, gameObjectsFactory);
            IText bulletsText = textFactory.Create();
            IFactory<IWeaponWithMagazine> weaponFactory = new StartPlayerWeaponFactory(gameLoopObjects, bulletsText, bulletsFactory);
            IWeaponWithMagazine weapon = weaponFactory.Create();
            IPlayerSimulationFactory playerSimulationFactory = new PlayerSimulationFactory(_gameLoop.Objects);
            IPlayersSimulation<IPlayer> playersSimulation = playerSimulationFactory.Create<IPlayer>();
            IWeaponInventoryFactory weaponInventoryFactory = new WeaponInventoryFactory();
            var playerFactory = new PlayerFactory(playersSimulation);
            IGameObject weaponGameObject = gameObjectsFactory.Create(new Transform());
            IWeaponSlotFactory weaponSlotFactory = new WeaponSlotFactory(playerFactory, new WeaponGameObject(weaponGameObject, bulletsText));
            var weaponInventory = weaponInventoryFactory.CreateStandard();
            weaponInventory.Add(weaponSlotFactory.Create("Pistol", weapon, weaponInput));
           // var enemyData = new JsonFilesStorage().LoadFile<EnemyData>(JsonFilesPaths.Zombie);
           // Console.WriteLine(enemyData.Name);
            playerFactory.Create(weaponInput, weapon);
            walletFactory.Create();
        }

        public void Play()
        {
            _gameTimer.Play();
            _gameLoop.Start();
        }
    }
}