using System;
using System.Numerics;
using ConsoleGame.Physics;

namespace ConsoleGame
{
    public sealed class PhysicsMovement : IMovement
    {
        private readonly IRigidbody _rigidbody;

        public PhysicsMovement(IRigidbody rigidbody)
        {
            _rigidbody = rigidbody ?? throw new ArgumentNullException(nameof(rigidbody));
        }

        public IReadOnlyTransform Transform => _rigidbody;
        
        public void Move(Vector3 direction)
        {
            _rigidbody.AddForce(direction, 5);
        }
    }
}