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
            IGameLoopObjects loopObjects = new GameLoopObjects();
            
            _gameLoop = new GameLoops(new List<IGameLoop>
            {
                new GameLoop(gamePause, loopObjects)
            });
            
            IGameObjects gameObjects = new SelfCleaningGameObjects(new GameObjects());
            ISaveStorages saveStorages = new SaveStorages();
            ICanvas canvas = new Canvas(new Transform());
            IUiElementFactory uiElementFactory = new UiElementFactory(canvas);
            IImageFactory imageFactory = new ImageFactory(uiElementFactory);
            ITextFactory textFactory = new TextFactory(uiElementFactory);
            IWalletViewFactory walletViewFactory = new WalletViewFactory(textFactory);
            IWalletFactory walletFactory = new WalletFactory(saveStorages, walletViewFactory);
            IWeaponInput weaponInput = new WeaponInput(new Key(ConsoleKey.F));
            var enemiesWorld = new CollidersWorld<IEnemy>();
            IRaycastFactory<IEnemy> enemyRaycastFactory = new RaycastFactory<IEnemy>(loopObjects, enemiesWorld);
            IMovementFactory enemyMovementFactory = new PhysicsMovementFactory(loopObjects);
            IBulletFactory bulletFactory = new RaycastBulletFactory(enemyRaycastFactory, enemyMovementFactory, gameObjects);
            IText bulletsText = textFactory.Create(new Transform(new Vector3(1.5f, 1.3f, 0)), new Font("Arial", 14), Color.Chocolate);
            IFactory<IWeaponWithMagazine> weaponFactory = new StartPlayerWeaponFactory(loopObjects, bulletsText, bulletFactory);
            IWeaponWithMagazine weapon = weaponFactory.Create();
            IPlayerSimulationFactory playerSimulationFactory = new PlayerSimulationFactory(loopObjects);
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
            loopObjects.Add(gameObjects);
        }

        public void Play()
        {
            _gameLoop.Start();
        }
    }
}