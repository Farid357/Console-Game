using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleGame.GameLoop;
using ConsoleGame.Physics;
using ConsoleGame.SaveSystem;
using ConsoleGame.Tests;
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
            IRaycastFactory<IEnemy> enemyRaycastFactory = new RaycastFactory<IEnemy>(loopObjects, enemyCollidersWorld);
            IMovementFactory enemyMovementFactory = new EnemyMovementFactory(loopObjects);
            IBulletFactory bulletFactory = new RaycastBulletFactory(enemyRaycastFactory, enemyMovementFactory, gameObjects);
            IWeaponViewFactory weaponViewFactory = new WeaponViewFactory(new DummyText(), new EffectFactory());
            IAdjustableMovement characterMovement = characterMovementFactory.Create(new Transform());
            var weaponFactory = new StartWeaponFactory(loopObjects, magazineFactory, bulletFactory, characterMovement, weaponViewFactory);
            IWeapon weapon = weaponFactory.Create();
            ICharacterFactory characterFactory = new CharacterFactory(characterMovement, characterHealthFactory, weapon);
            ICharacter character = characterFactory.Create();
            IPlayerFactory playerFactory = new PlayerFactory(loopObjects, character, weapon);
            IPlayer player = playerFactory.Create();
            IEnemiesWorld enemiesWorld = new EnemiesWorld(enemyCollidersWorld);
            IScoreViewFactory scoreViewFactory = new ScoreViewFactory(textFactory);
            IScoreFactory scoreFactory = new ScoreFactory(saveStorages, scoreViewFactory);
            IScore score = scoreFactory.Create();
            IWalletViewFactory walletViewFactory = new WalletViewFactory(textFactory);
            IWalletFactory walletFactory = new WalletFactory(saveStorages, walletViewFactory);
            IWallet wallet = walletFactory.Create();
            IWeaponInventoryFactory weaponInventoryFactory = new WeaponInventoryFactory(new InventoryViewFactory<IWeaponInventoryItem>());
            IInventorySlotViewFactory slotViewFactory = new InventorySlotViewFactory(textFactory);
            IReadOnlyList<IEnemy> allEnemies = enemiesWorld.Enemies.Keys.ToList();
            IKillsStreakView killsStreakView = new KillsStreakViewFactory(textFactory).Create();
            var killsStreak = new KillsStreak(allEnemies, killsStreakView, character.Health);
            var weaponSlotFactory = new WeaponSlotFactory(slotViewFactory, character);
            var weaponInventory = weaponInventoryFactory.Create();
            IInventoryItemViewData itemViewData = new InventoryItemViewData("Pistol", new DummyImage());
            var weaponSlot = weaponSlotFactory.Create(itemViewData, weapon);
            weaponInventory.Add(weaponSlot);
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