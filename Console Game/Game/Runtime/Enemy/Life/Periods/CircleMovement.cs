using System;
using System.Numerics;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class CircleMovement : IGameLoopObject, ICircleMovement
    {
        private readonly ITransform _transform;
        private readonly float _radius;
        private readonly float _speed;
        private float _angle;

        public CircleMovement(float radius, ITransform transform, float speed)
        {
            _radius = radius.ThrowIfLessThanZeroException();
            _speed = speed.ThrowIfLessOrEqualsToZeroException();
            _transform = transform ?? throw new ArgumentNullException(nameof(transform));
        }

        public bool IsActive { get; private set; }

        public IReadOnlyTransform Transform => _transform;

        public void Stop() => IsActive = false;

        public void Continue() => IsActive = true;

        public void Update(float deltaTime)
        {
            if (!IsActive)
                return;

            _angle += deltaTime;

            if (_angle > 360)
                _angle = 0;

            Move();
        }

        private void Move()
        {
            float x = (float)(Math.Cos(_angle * _speed) * _radius);
            float y = (float)(Math.Sin(_angle * _speed) * _radius);
            Vector2 position = new Vector2(x, y);
            _transform.Teleport(position);
        }
    }
}