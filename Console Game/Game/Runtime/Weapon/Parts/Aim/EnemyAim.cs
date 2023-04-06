using System;
using System.Numerics;

namespace ConsoleGame
{
    public sealed class EnemyAim : IAim
    {
        private readonly IReadOnlyTransform _transform;
        private readonly IReadOnlyTransform _character;

        public EnemyAim(IReadOnlyTransform transform, IReadOnlyTransform character)
        {
            _transform = transform ?? throw new ArgumentNullException(nameof(transform));
            _character = character ?? throw new ArgumentNullException(nameof(character));
        }

        public Vector3 Position => _transform.Position;
        
        public Vector3 Target => _character.Position - _transform.Position;
    }
}