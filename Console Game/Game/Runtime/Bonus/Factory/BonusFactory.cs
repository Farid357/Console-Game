using System;
using System.Numerics;
using ConsoleGame.GameLoop;
using ConsoleGame.Physics;

namespace ConsoleGame
{
    public sealed class BonusFactory : IBonusFactory
    {
        private readonly ICollidersWorld<IBonus> _bonusesWorld;
        private readonly IBonusViewFactory _viewFactory;
        private readonly IGameObjectsGroup _gameObjects;

        public BonusFactory(ICollidersWorld<IBonus> bonusesWorld, IBonusViewFactory viewFactory, IGameObjectsGroup gameObjects)
        {
            _bonusesWorld = bonusesWorld ?? throw new ArgumentNullException(nameof(bonusesWorld));
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
            _gameObjects = gameObjects ?? throw new ArgumentNullException(nameof(gameObjects));
        }

        public IBonus Create(ITransform transform)
        {
            IBonusView view = _viewFactory.Create();
            ICollider collider = new BoxCollider(Vector3.One, transform);
            var bonus = new Bonus(transform, view);
            _bonusesWorld.Add(bonus, collider, Layer.Bonus);
            _gameObjects.Add(bonus);
            return bonus;
        }
    }
}