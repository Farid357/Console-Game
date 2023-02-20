using System;
using System.Collections.Generic;
using System.Drawing;
using Console_Game.Loop;
using Console_Game.Weapons;

namespace Console_Game
{
    public sealed class Program
    {
        public static void Main()
        {
        }
    }

    public sealed class Game
    {
        public Game()
        {
            IGameTime gameTime = new GameTime();
            IGameLoop gameLoop = new GameLoop(gameTime);
            IPlayerSimulation playerSimulation = new PlayerSimulation();
            IWeaponInput weaponInput = new WeaponInput(new Key(ConsoleKey.F));
            IFactory<IWeaponWithMagazine> weaponFactory = new StartPlayerWeaponFactory(gameLoop.GameUpdate);
            IWeaponWithMagazine weapon = weaponFactory.Create();
            playerSimulation.CreatePlayer(weaponInput, weapon);
            gameLoop.StartUpdating();
        }
    }

    public sealed class StartPlayerWeaponFactory : IFactory<IWeaponWithMagazine>
    {
        private readonly IGameUpdate _gameUpdate;
        private readonly IBulletsFactory _bulletsFactory;

        public StartPlayerWeaponFactory(IGameUpdate gameUpdate)
        {
            _gameUpdate = gameUpdate ?? throw new ArgumentNullException(nameof(gameUpdate));
            _bulletsFactory = new BulletsFactory();
        }

        public IWeaponWithMagazine Create()
        {
            IWeaponMagazine magazine = new WeaponMagazine(30, new WeaponMagazineView());
            var cooldownTimer = new Timer(0.2f);
            _gameUpdate.Add(cooldownTimer);
            return new WeaponWithMagazine(magazine,
                new WeaponWithShootWaiting(cooldownTimer, new Weapon(_bulletsFactory)));
        }
    }

    public interface IInventory<TItem> where TItem : IInventoryItem
    {
        IEnumerable<IInventorySlot<TItem>> Slots { get; }

        void Add(IInventoryItem item);
    }

    public sealed class Inventory<TItem> : IInventory<TItem> where TItem : IInventoryItem
    {
        private readonly List<IInventorySlot<TItem>> _slots = new();

        public IEnumerable<IInventorySlot<TItem>> Slots => _slots;

        public void Add(IInventoryItem item)
        {
            IInventorySlot<TItem> slot = _slots.Find(slot => slot.IsCrowded == false && slot.CanAddItem(item));

            if (slot is null)
            {
                IInventorySlot<TItem> newSlot = new InventorySlot<TItem>(1);
            }
        }
    }

    public interface IInventorySlot<TItem> where TItem : IInventoryItem
    {
        int ItemsCount { get; }

        bool IsCrowded { get; }

        bool CanAddItem(IInventoryItem item);
    }

    public sealed class InventorySlot<TItem> : IInventorySlot<TItem> where TItem : IInventoryItem
    {
        private readonly int _maxItemsCount;

        public InventorySlot(int itemsCount)
        {
            if (itemsCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(itemsCount));

            ItemsCount = itemsCount;
            _maxItemsCount = ItemsCount;
        }

        public int ItemsCount { get; }

        public bool IsCrowded => ItemsCount == _maxItemsCount;

        public bool CanAddItem(IInventoryItem item)
        {
            throw new NotImplementedException();
        }
    }

    public interface IInventoryItem
    {
        IInventoryItemData Data { get; }
    }

    public interface IInventoryItemData
    {
        string Name { get; }

        Graphics Icon { get; }
    }
}