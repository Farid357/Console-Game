using System;
using System.Numerics;
using ConsoleGame.GameLoop;
using ConsoleGame.Physics;

namespace ConsoleGame
{
    public sealed class BonusFactory : IBonusFactory
    {
        private readonly ICollidersWorld<IBonus> _physicsWorld;
        private readonly IBonusViewFactory _viewFactory;
        private readonly IGameObjectsGroup _gameObjects;

        public BonusFactory(ICollidersWorld<IBonus> bonusesWorld, IBonusViewFactory viewFactory, IGameObjectsGroup gameObjects)
        {
            _physicsWorld = bonusesWorld ?? throw new ArgumentNullException(nameof(bonusesWorld));
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
            _gameObjects = gameObjects ?? throw new ArgumentNullException(nameof(gameObjects));
        }

        public IBonus Create(ITransform transform)
        {
            IBonusView view = _viewFactory.Create();
            ICollider collider = new BoxCollider(Vector3.One, transform);
            var bonus = new Bonus(transform, view);
            _physicsWorld.Add(bonus, collider);
            _gameObjects.Add(bonus);
            return bonus;
        }
    }
}