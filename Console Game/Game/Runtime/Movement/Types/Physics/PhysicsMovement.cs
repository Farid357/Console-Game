using System;
using System.Numerics;

namespace ConsoleGame
{
    public sealed class PhysicsMovement : IMovement, IGameLoopObject
    {
        private readonly ITransform _transform;
        private readonly IRigidbody _body;

        public PhysicsMovement(IRigidbody body, ITransform transform)
        {
            _transform = transform ?? throw new ArgumentNullException(nameof(transform));
            _body = body;
        }

        public IReadOnlyTransform Transform => _transform;
        
        public void Move(Vector3 direction)
        {
            Vector3 position = _transform.Position + direction * (_body.MoveSpeed - _body.Mass);
            _transform.Teleport(position);
        }

        public void Update(float deltaTime)
        {
            Vector3 position = _transform.Position - new Vector3(0, _body.Gravity, 0);
            _transform.Teleport(position);
        }
    }
}