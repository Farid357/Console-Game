using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ConsoleGame.Bonus;
using ConsoleGame.GameLoop;
using ConsoleGame.Physics;
using ConsoleGame.SaveSystem;
using ConsoleGame.Stats;
using ConsoleGame.Tests;
using ConsoleGame.Tests.UI;
using ConsoleGame.UI;
using ConsoleGame.Wave;
using ConsoleGame.Weapon;
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
            IGameLoopObjects physicsObjects = new GameLoopObjects();

            _gameLoop = new GameLoops(new List<IGameLoop>
            {
                new GameLoop.GameLoop(gamePause, loopObjects),
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
            IWeaponMagazineViewFactory magazineViewFactory = new WeaponMagazineViewFactory(textFactory);
            IWeaponMagazineFactory magazineFactory = new WeaponMagazineFactory(magazineViewFactory, 100);
            ICollidersWorld<IEnemy> enemyCollidersWorld = new CollidersWorld<IEnemy>();
            IMovementFactory enemyMovementFactory = new EnemyMovementFactory();
            IBulletFactory bulletFactory = new RaycastBulletFactory(new Raycast<IEnemy>(enemyCollidersWorld, 0.2f), enemyMovementFactory, gameObjects);
            IWeaponViewFactory weaponViewFactory = new WeaponViewFactory(new DummyText(), new EffectFactory());
            IAdjustableMovement characterMovement = characterMovementFactory.Create(new Transform());
            IWeaponFactory weaponFactory = new StartWeaponFactory(loopObjects, magazineFactory, bulletFactory, weaponViewFactory);
            IAim characterAim = new CharacterAim(characterMovement.Transform);
            IWeaponsData weaponsData = new WeaponsData();
            IWeapon weapon = weaponFactory.Create(characterAim, weaponsData);
            IHealth characterHealth = characterHealthFactory.Create();
            ICharacter character = new Character(characterHealth, characterMovement, weapon, weaponsData);
            IPlayerFactory playerFactory = new PlayerFactory(loopObjects, character, weapon);
            IPlayer player = playerFactory.Create();
            IEnemiesWorld enemiesWorld = new EnemiesWorld();
            IScoreViewFactory scoreViewFactory = new ScoreViewFactory(textFactory);
            IScoreFactory scoreFactory = new ScoreFactory(saveStorages, scoreViewFactory);
            IScoreWithFactor score = new ScoreWithFactor(scoreFactory.Create());
            IWalletViewFactory walletViewFactory = new WalletViewFactory(textFactory);
            IWalletFactory walletFactory = new WalletFactory(saveStorages, walletViewFactory);
            IWallet wallet = walletFactory.Create();
            IWeaponInventoryFactory weaponInventoryFactory = new WeaponInventoryFactory(new InventoryViewFactory<IWeaponInventoryItem>());
            IInventorySlotViewFactory slotViewFactory = new InventorySlotViewFactory(textFactory);
            IReadOnlyList<IEnemy> allEnemies = enemiesWorld.Enemies.Keys.ToList();
            IKillsStreakView killsStreakView = new KillsStreakViewFactory(textFactory).Create();
            var killsStreak = new KillsStreak(allEnemies, killsStreakView, characterHealth);
            var weaponSlotFactory = new WeaponSlotFactory(slotViewFactory, character);
            var weaponInventory = weaponInventoryFactory.Create();
            IInventoryItemViewData itemViewData = new InventoryItemViewData("Pistol", new DummyImage());
            var weaponSlot = weaponSlotFactory.Create(itemViewData, weapon);
            weaponInventory.Add(weaponSlot);
            IAchievementViewFactory achievementViewFactory = new AchievementViewFactory(imageFactory, windowFactory, textFactory);
            ICollidersWorld<IBonus> bonusesWorld = new CollidersWorld<IBonus>();

            IAchievementFactory achievementFactory = new AchievementsFactory(new List<IAchievementFactory>
            {
                new MoneyAchievementsFactory(loopObjects, achievementViewFactory, saveStorages, wallet),
                new ScoreAchievementsFactory(score, achievementViewFactory, loopObjects, wallet, saveStorages)
            });

            IBonusLoopFactory bonusLoopFactory = new BonusLoopFactory(new List<IBonusFactory>()
            {
                new HealBonusFactory(characterHealth, bonusesWorld),
                new EnemiesKillBonusFactory(allEnemies, bonusesWorld),
                new ScoreFactorBonusFactory(bonusesWorld, score)
            }, 
                new List<Vector3>
            {
                new Vector3(100, 0, 300)
            });

            var zombieBehaviourTreeFactory = new ZombieBehaviourTreeFactory(characterHealth, characterMovement.Transform);
            
            IEnemyFactory zombieFactory = new EnemyFactory(new HealthFactory(new EnemyHealthViewFactory(), 100), zombieBehaviourTreeFactory, enemyMovementFactory);
            IReadOnlyList<IWave> waves = new WavesFactory().Create();

            var waveFactory = new WaveFactory(enemiesWorld, new Dictionary<EnemyType, IEnemyFactory>
            {
                { EnemyType.Zombie, zombieFactory }
            }, waves);

            achievementFactory.Create();
            bonusLoopFactory.StartCreate(minCreateDelay: 30, maxCreateDelay: 120);
            loopObjects.Add(killsStreak);
            loopObjects.Add(waveFactory);
            loopObjects.Add(gameObjects);
        }

        public void Play()
        {
            _gameLoop.Start();
        }
    }
}