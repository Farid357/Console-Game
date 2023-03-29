using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using ConsoleGame.GameLoop;
using ConsoleGame.Physics;
using ConsoleGame.SaveSystem;
using ConsoleGame.Tests.UI;
using ConsoleGame.UI;
using ConsoleGame.Weapons;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class Game : IGame
    {
        private readonly IGameLoop _gameLoop;

        public Game()
        {
            IGamePause gamePause = new GamePause(new GamePauseView());
            IGameLoopObjects loopObjects = new GameLoopObjects();
            IGameLoopObjects physicsObjects = new GameLoopObjects();

            _gameLoop = new GameLoops(new List<IGameLoop>
            {
                new GameLoop.GameLoop(gamePause, loopObjects),
                new PhysicsGameLoop(gamePause, physicsObjects)
            });

            ISaveStorages saveStorages = new SaveStorages();
            ICanvas canvas = new Canvas(new Transform());
            IUiElementFactory uiElementFactory = new UiElementFactory(canvas);
            IImageFactory imageFactory = new ImageFactory(uiElementFactory);
            ITextFactory textFactory = new TextFactory(uiElementFactory);
            IWindowFactory windowFactory = new WindowFactory(imageFactory);
            IMovementFactory characterMovementFactory = new CharacterMovementFactory(loopObjects, saveStorages);
            IBarFactory barFactory = new BarFactory(imageFactory);
            IHealthViewFactory characterHealthViewFactory = new CharacterHealthViewFactory(textFactory, barFactory);
            IHealthFactory characterHealthFactory = new CharacterHealthFactory(characterHealthViewFactory, saveStorages);
            ICharacterFactory characterFactory = new CharacterFactory(characterMovementFactory, loopObjects, characterHealthFactory);
            ICharacter character = characterFactory.Create();
            ICollidersWorld<IEnemy> enemyCollidersWorld = new CollidersWorld<IEnemy>();
            IEnemiesWorld enemiesWorld = new EnemiesWorld(enemyCollidersWorld);
            IGameObjects gameObjects = new SelfCleaningGameObjects(new GameObjects());
            IScoreViewFactory scoreViewFactory = new ScoreViewFactory(textFactory);
            IScoreFactory scoreFactory = new ScoreFactory(saveStorages, scoreViewFactory);
            IScore score = scoreFactory.Create();
            IWalletViewFactory walletViewFactory = new WalletViewFactory(textFactory);
            IWalletFactory walletFactory = new WalletFactory(saveStorages, walletViewFactory);
            IWallet wallet = walletFactory.Create();
            IWeaponInput weaponInput = new WeaponInput(new Key(ConsoleKey.F));
            IRaycastFactory<IEnemy> enemyRaycastFactory = new RaycastFactory<IEnemy>(loopObjects, enemyCollidersWorld);
            IMovementFactory enemyMovementFactory = new EnemyMovementFactory(loopObjects);
            IBulletFactory bulletFactory = new RaycastBulletFactory(enemyRaycastFactory, enemyMovementFactory, gameObjects);
            IText bulletsText = textFactory.Create(new Transform(new Vector3(1.5f, 1.3f, 0)), new Font("Arial", 14), Color.Chocolate);
            IFactory<IWeaponWithMagazine> weaponFactory = new StartPlayerWeaponFactory(loopObjects, bulletsText, bulletFactory);
            IWeaponWithMagazine weapon = weaponFactory.Create();
            IPlayerSimulationFactory playerSimulationFactory = new PlayerSimulationFactory(loopObjects);
            IPlayersSimulation<IPlayer> playersSimulation = playerSimulationFactory.Create<IPlayer>();
            IWeaponInventoryFactory weaponInventoryFactory = new WeaponInventoryFactory();
            var playerFactory = new PlayerWithWeaponMagazineFactory(playersSimulation);
            IInventorySlotViewFactory slotViewFactory = new InventorySlotViewFactory(textFactory);
            IReadOnlyList<IEnemy> allEnemies = enemiesWorld.Enemies.Keys.ToList();
           var killsStreak = new KillsStreak(allEnemies, new KillsStreakViewFactory(textFactory).Create(), character.Health);
            var weaponSlotFactory = new WeaponSlotFactory<IWeaponWithMagazine, IWeaponInput, IPlayerWithWeaponMagazine>(playerFactory, playersSimulation, slotViewFactory);
            var weaponInventory = weaponInventoryFactory.CreateStandard();
            weaponInventory.Add(weaponSlotFactory.Create(new InventoryItemViewData("Pistol", new DummyImage()), weapon, weaponInput));
            playerFactory.Create(weaponInput, weapon);
            IAchievementViewFactory achievementViewFactory = new AchievementViewFactory(imageFactory, windowFactory, textFactory);
            IAchievementFactory achievementFactory = new AchievementsFactory(achievementViewFactory, loopObjects, saveStorages, wallet, score);
            loopObjects.Add(killsStreak);
            loopObjects.Add(gameObjects);
            achievementFactory.Create();
        }

        public void Play()
        {
            _gameLoop.Start();
        }
    }
}