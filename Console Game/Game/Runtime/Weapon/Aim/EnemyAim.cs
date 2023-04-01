using System;
using System.Numerics;

namespace ConsoleGame
{
    public sealed class EnemyAim : IAim
    {
        private readonly IReadOnlyTransform _transform;
        private readonly IReadOnlyCharacter _character;

        public EnemyAim(IReadOnlyTransform transform, IReadOnlyCharacter character)
        {
            _transform = transform ?? throw new ArgumentNullException(nameof(transform));
            _character = character ?? throw new ArgumentNullException(nameof(character));
        }

        public Vector3 Position => _transform.Position;
        
        public Vector3 Target => _character.Movement.Transform.Position - _transform.Position;
    }
}