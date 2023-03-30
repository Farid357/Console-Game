using System;
using ConsoleGame.SaveSystem;

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
            IPath healthPath = new Path(nameof(IPlayer) + nameof(IHealth));
            ISaveStorage<IHealth> healthStorage = new BinaryStorage<IHealth>(healthPath);
            IHealth defaultHealth = new Health(_viewFactory.Create(), 100);
            _saveStorages.Add(healthStorage);
            return healthStorage.HasSave() ? healthStorage.Load() : defaultHealth;
        }
    }
}