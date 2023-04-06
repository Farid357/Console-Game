using System;
using ConsoleGame.SaveSystem;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class CharacterHealthFactory : IHealthFactory
    {
        private readonly IHealthViewFactory _viewFactory;
        private readonly ISaveStorages _saveStorages;

        public CharacterHealthFactory(IHealthViewFactory viewFactory, ISaveStorages saveStorages)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
            _saveStorages = saveStorages ?? throw new ArgumentNullException(nameof(saveStorages));
        }

        public IHealth Create()
        {
            ISaveStorage<int> healthStorage = new BinaryStorage<int>(Paths.CharacterMaxHealthCount);
            int healthCount = healthStorage.LoadOrDefault(100);
            IHealthFactory healthFactory = new HealthFactory(_viewFactory, healthCount);
            _saveStorages.Add(healthStorage);
            return healthFactory.Create();
        }
    }
}