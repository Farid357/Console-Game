using System;

namespace Console_Game
{
    public struct PhysicsBody
    {
        public PhysicsBody(float mass, float gravity, float moveSpeed)
        {
            if (mass < 0)
                throw new ArgumentOutOfRangeException(nameof(mass));

            if (gravity < 0)
                throw new ArgumentOutOfRangeException(nameof(gravity));

            if (moveSpeed < 0)
                throw new ArgumentOutOfRangeException(nameof(moveSpeed));

            Mass = mass;
            Gravity = gravity;
            MoveSpeed = moveSpeed;
        }

        public float Mass { get; }

        public float Gravity { get; }

        public float MoveSpeed { get; }
    }
}