using System;
using System.Numerics;

namespace Console_Game
{
    public sealed class PhysicsMovement : IPhysicsMovement, IGameLoopObject
    {
        private readonly ITransform _transform;

        public PhysicsMovement(Rigidbody body, ITransform transform)
        {
            _transform = transform ?? throw new ArgumentNullException(nameof(transform));
            Body = body;
        }

        public Rigidbody Body { get; }

        public IReadOnlyTransform Transform => _transform;

        public void Move(Vector2 direction)
        {
            Vector2 position = _transform.Position + direction * (Body.MoveSpeed - Body.Mass);
            _transform.Teleport(position);
        }

        public void Rotate(Quaternion rotation)
        {
            _transform.Rotate(rotation);
        }

        public void Update(float deltaTime)
        {
            Vector2 position = _transform.Position - new Vector2(0, Body.Gravity);
            _transform.Teleport(position);
        }
    }
}