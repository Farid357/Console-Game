using System;
using System.Numerics;
using ConsoleGame.Tools;

namespace ConsoleGame.Physics
{
    public sealed class Rigidbody : IRigidbody
    {
        private readonly IReadOnlyTransform _transform;

        public Rigidbody(float mass, float gravity, float moveSpeed, IReadOnlyTransform transform)
        {
            _transform = transform ?? throw new ArgumentNullException(nameof(transform));
            Mass = mass.ThrowIfLessOrEqualsToZeroException();
            MoveSpeed = moveSpeed.ThrowIfLessThanZeroException();
            Gravity = gravity;
        }

        public float Mass { get; }

        public float Gravity { get; }

        public float MoveSpeed { get; }
        
        public Vector3 Position => _transform.Position;
        
        public Quaternion Rotation => _transform.Rotation;
       
        public void AddForce(Vector3 direction, float force)
        {
            throw new NotImplementedException();
        }
    }
}