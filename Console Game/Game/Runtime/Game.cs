using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using ConsoleGame.Physics;
using ConsoleGame.SaveSystem;
using ConsoleGame.Stats;
using ConsoleGame.Tests;
using ConsoleGame.Tests.UI;
using ConsoleGame.UI;
using ConsoleGame.Weapons;

namespace ConsoleGame.GameLoop
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
                new GameLoop(gamePause, loopObjects),
                new PhysicsGameLoop(gamePause, physicsObjects)
            });

            IGameObjects gameObjects = new SelfCleaningGameObjects(new GameObjects());
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
            IText bulletsText = textFactory.Create(new Transform(new Vector2(70, 70)), new Font("Arial", 14), Color.Azure);
            IWeaponMagazineFactory magazineFactory = new WeaponMagazineFactory(new WeaponMagazineView(bulletsText), 100);
            IGameObjectsCollidersWorld<IHealth> healthsCollidersWorld = new GameObjectsCollidersWorld<IHealth>();
            IMovementFactory enemyMovementFactory = new EnemyMovementFactory();
            IBulletFactory bulletFactory = new BulletFactory(healthsCollidersWorld, enemyMovementFactory, gameObjects, Layer.Enemy);
            IEffectFactory effectFactory = new EffectFactory();
            IWeaponViewFactory weaponViewFactory = new WeaponViewFactory(new DummyText(), effectFactory);
            IAdjustableMovement characterMovement = characterMovementFactory.Create(new Transform());
            IWeaponFactory weaponFactory = new WeaponWithMagazineFactory(loopObjects, magazineFactory, bulletFactory, weaponViewFactory);
            Vector3 weaponPosition = characterMovement.Transform.Position + new Vector3(0, 9.5f, 2f);
            IAim characterAim = new CharacterAim(new Transform(weaponPosition + new Vector3(0, 0.5f, 2.5f)));
            var weaponModel = weaponFactory.Create(characterAim);
            IWeaponInventoryFactory weaponInventoryFactory = new WeaponInventoryFactory(new InventoryViewFactory<IWeaponInventoryItem>());
            IInventorySlotViewFactory slotViewFactory = new InventorySlotViewFactory(textFactory);
            IHealth characterHealth = characterHealthFactory.Create();
            IInventory<IWeaponInventoryItem> weaponInventory = weaponInventoryFactory.Create();
            ICharacter character = new Character(characterHealth, weaponInventory, characterMovement);
            IEnemiesWorld enemiesWorld = new EnemiesWorld();
            IScoreViewFactory scoreViewFactory = new ScoreViewFactory(textFactory);
            IScoreFactory scoreFactory = new ScoreFactory(saveStorages, scoreViewFactory);
            IScoreWithFactor score = new ScoreWithFactor(scoreFactory.Create());
            IScoreBestRecordFactory bestRecordFactory = new ScoreBestRecordFactory(saveStorages, loopObjects, new ScoreBestRecordViewFactory(textFactory));
            bestRecordFactory.Create(score);
            IWalletViewFactory walletViewFactory = new WalletViewFactory(textFactory);
            IWalletFactory walletFactory = new WalletFactory(saveStorages, walletViewFactory);
            IWallet wallet = walletFactory.Create();
            IReadOnlyList<IEnemy> allEnemies = enemiesWorld.Enemies.Keys.ToList();
            IKillsStreakView killsStreakView = new KillsStreakViewFactory(textFactory).Create();
            IGameLoopObject killsStreak = new KillsStreak(allEnemies, killsStreakView, characterHealth);
            IWeaponSlotFactory weaponSlotFactory = new WeaponSlotFactory(slotViewFactory);
            IInventoryItemViewData itemViewData = new InventoryItemViewData("Pistol", new DummyImage());
            IInventorySlot<IWeaponInventoryItem> weaponSlot = weaponSlotFactory.Create(itemViewData, weaponModel.Weapon, weaponModel.PartsData);
            weaponInventory.Add(weaponSlot);
            IAreaRaycast<IHealth> sphereRaycast = new SphereRaycast<IHealth>(new CollidersWorld<IHealth>());
            IBombFactory bombFactory = new BombFactory<IHealth>(sphereRaycast, new BombViewFactory(effectFactory), 10);
            IWeaponFactory grenadeFactory = new GrenadeFactory(bombFactory, new Transform(weaponPosition));
            (IWeapon Weapon, IWeaponPartsData PartsData) grenadeModel = grenadeFactory.Create(new DummyAim());
            IInventoryItemViewData grenadeItemViewData = new InventoryItemViewData("Grenade", new DummyImage());
            IInventorySlot<IWeaponInventoryItem> grenadeSlot = weaponSlotFactory.Create(grenadeItemViewData, grenadeModel.Weapon, grenadeModel.PartsData);
            weaponInventory.Add(grenadeSlot);
            IAchievementViewFactory achievementViewFactory = new AchievementViewFactory(imageFactory, windowFactory, textFactory);
            IGameObjectsCollidersWorld<IBonus> bonusesWorld = new GameObjectsCollidersWorld<IBonus>();
            ILevelFactory levelFactory = new CharacterLevelFactory(saveStorages, new LevelViewFactory(textFactory));
            IBonusFactory bonusFactory = new BonusFactory(bonusesWorld, new BonusViewFactory(), gameObjects);
            ILevel level = levelFactory.Create();
            
            IAchievementFactory achievementFactory = new AchievementsFactory(new List<IAchievementFactory>
            {
                new MoneyAchievementsFactory(loopObjects, achievementViewFactory, saveStorages, wallet),
                new ScoreAchievementsFactory(score, achievementViewFactory, loopObjects, wallet, saveStorages)
            });

            IBonusLoopFactory bonusLoopFactory = new BonusLoopFactory(new List<IBonusFactory>()
            {
                new HealBonusFactory(bonusFactory, characterHealth),
                new EnemiesKillBonusFactory(bonusFactory, allEnemies),
                new IncreaseFactorBonusFactory(bonusFactory, score),
                new BulletsBonusFactory(bonusFactory, weaponInventory)
            }, 
                new List<Vector3>
            {
                new Vector3(100, 0, 300)
            });

            IEnemyFactory zombieFactory = new ZombieFactory(character, new HealthFactory(new EnemyHealthViewFactory(), 100), enemyMovementFactory, gameObjects);
            IWeaponMagazineFactory enemyWeaponMagazineFactory = new WeaponMagazineFactory(new DummyMagazineView(), 100000);
            IWeaponFactory enemyWeaponFactory = new WeaponWithMagazineFactory(loopObjects, enemyWeaponMagazineFactory, bulletFactory, weaponViewFactory);
            IEnemyFactory shooterFactory = new ShooterEnemyFactory(enemyWeaponFactory, character, new HealthFactory(new EnemyHealthViewFactory(), 80), enemyMovementFactory, gameObjects);
          
            IReadOnlyDictionary<EnemyType, IEnemyFactory> enemyFactories = new Dictionary<EnemyType, IEnemyFactory>
            {
                { EnemyType.Zombie, zombieFactory },
                { EnemyType.Skeleton, zombieFactory },
                { EnemyType.Shooter, shooterFactory}
            };

            IEnemyWavesFactory waves = new EnemyWavesFactory(enemyFactories, enemiesWorld);
            IGameLoopObject enemyWavesLoop = new EnemyWavesLoop(waves.Create());
            achievementFactory.Create();
            bonusLoopFactory.StartCreate(minCreateDelay: 30, maxCreateDelay: 120);
            IPlayerFactory playerFactory = new PlayerFactory(loopObjects, character);
            playerFactory.Create();
            
            loopObjects.Add(new GameLoopObjects(new List<IGameLoopObject>
            {
                healthsCollidersWorld,
                bonusesWorld,
                killsStreak,
                enemyWavesLoop,
                gameObjects
            }));
        }

        public void Play()
        {
            _gameLoop.Start();
        }
    }
}