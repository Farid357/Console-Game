using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using ConsoleGame.Loop;
using ConsoleGame.Physics;
using ConsoleGame.Save_Storages;
using ConsoleGame.Tests.UI;
using ConsoleGame.UI;
using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public sealed class Game : IGame
    {
        private readonly IGameLoop _gameLoop;

        public Game()
        {
            IGamePause gamePause = new GamePause(new GamePauseView());
            _gameLoop = new GameLoop(0.01f, gamePause);
            IGameLoopObjectsGroup gameLoopObjects = _gameLoop.Objects;
            IGameObjects gameObjects = new SelfCleaningGameObjects(new GameObjects());
            ISaveStorages saveStorages = new SaveStorages();
            ICanvas canvas = new Canvas(new Transform());
            IUiElementFactory uiElementFactory = new UiElementFactory(canvas);
            IImageFactory imageFactory = new ImageFactory(uiElementFactory);
            ITextFactory textFactory = new TextFactory(uiElementFactory);
            IWalletViewFactory walletViewFactory = new WalletViewFactory(textFactory);
            IWalletFactory walletFactory = new WalletFactory(saveStorages, walletViewFactory);
            IWeaponInput weaponInput = new WeaponInput(new Key(ConsoleKey.F));
            IReadOnlyCollidersWorld<IEnemy> enemiesWorld = new CollidersWorld<IEnemy>();
            IRaycastFactory<IEnemy> enemyRaycastFactory = new RaycastFactory<IEnemy>(gameLoopObjects, enemiesWorld);
            IMovementFactory enemyMovementFactory = new PhysicsMovementFactory(gameLoopObjects);
            IBulletFactory bulletFactory = new RaycastBulletFactory(enemyRaycastFactory, enemyMovementFactory, gameObjects);
            IText bulletsText = textFactory.Create(new Transform(new Vector2(1.5f, 1.3f)), new Font("Arial", 14), Color.Chocolate);
            IFactory<IWeaponWithMagazine> weaponFactory = new StartPlayerWeaponFactory(gameLoopObjects, bulletsText, bulletFactory);
            IWeaponWithMagazine weapon = weaponFactory.Create();
            IPlayerSimulationFactory playerSimulationFactory = new PlayerSimulationFactory(_gameLoop.Objects);
            IPlayersSimulation<IPlayer> playersSimulation = playerSimulationFactory.Create<IPlayer>();
            IWeaponInventoryFactory weaponInventoryFactory = new WeaponInventoryFactory();
            var playerFactory = new PlayerWithWeaponMagazineFactory(playersSimulation);
            IInventorySlotViewFactory slotViewFactory = new InventorySlotViewFactory(textFactory);
            IReadOnlyList<IEnemy> allEnemies = enemiesWorld.Models.Values.ToList();
          //  var killsStreak = new KillsStreak(allEnemies, new KillsStreakViewFactory(textFactory).Create());
            var weaponSlotFactory = new WeaponSlotFactory<IWeaponWithMagazine, IWeaponInput, IPlayerWithWeaponMagazine>(playerFactory, playersSimulation, slotViewFactory);
            var weaponInventory = weaponInventoryFactory.CreateStandard();
            weaponInventory.Add(weaponSlotFactory.Create(new InventoryItemViewData("Pistol", new DummyImage()), weapon, weaponInput));
            playerFactory.Create(weaponInput, weapon);
            walletFactory.Create();
        //    gameLoopObjects.Add(killsStreak);
            gameLoopObjects.Add(gameObjects);
        }

        public void Play()
        {
            _gameLoop.Start();
        }
    }
}