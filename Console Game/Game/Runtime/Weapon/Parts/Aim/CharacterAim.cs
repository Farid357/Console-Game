using System;
using System.Numerics;

namespace ConsoleGame
{
    public sealed class CharacterAim : IAim
    {
        private readonly IReadOnlyTransform _transform;

        public CharacterAim(IReadOnlyTransform transform)
        {
            _transform = transform ?? throw new ArgumentNullException(nameof(transform));
        }

        public Vector3 Position => _transform.Position;
        
        public Vector3 Target { get; } = new Vector3(0, 0, 1);
    }
}