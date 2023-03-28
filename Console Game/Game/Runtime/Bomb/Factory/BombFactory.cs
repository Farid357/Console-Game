using System;
using ConsoleGame.Physics;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class BombFactory<TTarget> : IBombFactory where TTarget : IHealth
    {
        private readonly IBombViewFactory _viewFactory;
        private readonly IAreaRaycast<TTarget> _raycast;
        private readonly int _damage;

        public BombFactory(IAreaRaycast<TTarget> raycast, IBombViewFactory viewFactory, int damage)
        {
            _raycast = raycast ?? throw new ArgumentNullException(nameof(raycast));
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
            _damage = damage.ThrowIfLessThanOrEqualsToZeroException();
        }

        public IBomb Create(IReadOnlyTransform transform)
        {
            IBombView view = _viewFactory.Create();
            return new Bomb<TTarget>(view, _raycast, transform, _damage);
        }
    }
}