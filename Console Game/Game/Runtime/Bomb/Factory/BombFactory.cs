using System;
using ConsoleGame.Physics;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class BombFactory : IBombFactory
    {
        private readonly IBombViewFactory _viewFactory;
        private readonly IAreaRaycast<IEnemy> _raycast;
        private readonly int _damage;

        public BombFactory(IAreaRaycast<IEnemy> raycast, IBombViewFactory viewFactory, int damage)
        {
            _raycast = raycast ?? throw new ArgumentNullException(nameof(raycast));
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
            _damage = damage.ThrowIfLessThanOrEqualsToZeroException();
        }

        public IBomb Create(ITransform transform)
        {
            IBombView view = _viewFactory.Create(transform);
            return new Bomb(view, _raycast, transform, _damage);
        }
    }
}