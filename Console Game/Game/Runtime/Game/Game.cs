using System;
using System.Drawing;
using System.Numerics;
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
            ICanvas canvas = new Canvas(new Transform());
            IUiElementFactory uiElementFactory = new UiElementFactory(canvas);
            ITextFactory textFactory = new TextFactory(uiElementFactory);
            IFactory<IWallet> walletFactory = new WalletFactory(saveStorages, textFactory);
            IWeaponInput weaponInput = new WeaponInput(new Key(ConsoleKey.F));
            IBulletsFactory bulletsFactory = new BulletsFactory(new Transform(), gameLoopObjects);
            IText bulletsText = textFactory.Create(new Transform(new Vector2(1.5f, 1.3f)));
            IFactory<IWeaponWithMagazine> weaponFactory = new StartPlayerWeaponFactory(gameLoopObjects, bulletsText, bulletsFactory);
            IWeaponWithMagazine weapon = weaponFactory.Create();
            IPlayerSimulationFactory playerSimulationFactory = new PlayerSimulationFactory(_gameLoop.Objects);
            IPlayersSimulation<IPlayer> playersSimulation = playerSimulationFactory.Create<IPlayer>();
            IWeaponInventoryFactory weaponInventoryFactory = new WeaponInventoryFactory();
            var playerFactory = new PlayerFactory(playersSimulation);
            IImageFactory imageFactory = new ImageFactory(ImagePaths.Logo, uiElementFactory, Color.Beige);
            IWeaponSlotFactory<IWeapon, IWeaponInput> weaponSlotFactory = new WeaponSlotFactory<IWeapon, IWeaponInput>(playerFactory, playersSimulation, textFactory, imageFactory);
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