using System;
using System.Collections.Generic;
using System.Linq;
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
            ICharacterFactory characterFactory = new CharacterFactory(characterMovementFactory, characterHealthFactory);
            ICharacter character = characterFactory.Create();
            IPlayerFactory playerFactory = new PlayerFactory(loopObjects, character);
            IPlayer player = playerFactory.Create();
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
            IWeaponMagazineViewFactory weaponMagazineViewFactory = new WeaponMagazineViewFactory(textFactory);
            IWeaponMagazineFactory weaponMagazineFactory = new WeaponMagazineFactory(weaponMagazineViewFactory, 100);
            var weaponFactory = new StartPlayerWeaponFactory(loopObjects, weaponMagazineFactory, bulletFactory);
            IWeaponWithMagazine weapon = weaponFactory.Create();
            IShootersSimulationFactory shootersSimulationFactory = new ShootersSimulationFactory(loopObjects);
            var shootersSimulation = shootersSimulationFactory.Create<IShooterWithWeaponMagazine, IWeaponWithMagazine>();
            IWeaponInventoryFactory weaponInventoryFactory = new WeaponInventoryFactory();
            var shooterFactory = new ShooterWithWeaponMagazineFactory();
            IInventorySlotViewFactory slotViewFactory = new InventorySlotViewFactory(textFactory);
            IReadOnlyList<IEnemy> allEnemies = enemiesWorld.Enemies.Keys.ToList();
           var killsStreak = new KillsStreak(allEnemies, new KillsStreakViewFactory(textFactory).Create(), character.Health);
            var weaponSlotFactory = new WeaponSlotFactory<IWeaponWithMagazine, IShooterWithWeaponMagazine>(shootersSimulation, slotViewFactory);
            var weaponInventory = weaponInventoryFactory.CreateStandard();
            IInventoryItemViewData itemViewData = new InventoryItemViewData("Pistol", new DummyImage());
            var startPlayer = shooterFactory.Create(new WeaponInput(), weapon);
            weaponInventory.Add(weaponSlotFactory.Create(itemViewData, startPlayer));
            shooterFactory.Create(weaponInput, weapon);
            IAchievementViewFactory achievementViewFactory = new AchievementViewFactory(imageFactory, windowFactory, textFactory);
            IAchievementFactory achievementFactory = new AchievementsFactory(new List<IAchievementFactory>
            {
                new MoneyAchievementsFactory(loopObjects, achievementViewFactory, saveStorages, wallet),
                new ScoreAchievementsFactory(score, achievementViewFactory, loopObjects, wallet, saveStorages)
            });
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