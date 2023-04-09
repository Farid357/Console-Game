using System;
using System.Numerics;
using ConsoleGame.Physics;

namespace ConsoleGame.Bonus
{
    public sealed class BonusFactory : IBonusFactory
    {
        private readonly ICollidersWorld<IBonus> _bonusesWorld;
        private readonly IBonusViewFactory _viewFactory;

        public BonusFactory(ICollidersWorld<IBonus> bonusesWorld, IBonusViewFactory viewFactory)
        {
            _bonusesWorld = bonusesWorld ?? throw new ArgumentNullException(nameof(bonusesWorld));
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        public IBonus Create(ITransform transform)
        {
            IBonusView view = _viewFactory.Create();
            IBonus bonus = new Bonus(transform, view);
            ICollider collider = new BoxCollider(Vector3.One, transform);
            _bonusesWorld.Add(bonus, collider, Layer.Bonus);
            return bonus;
        }
    }
}