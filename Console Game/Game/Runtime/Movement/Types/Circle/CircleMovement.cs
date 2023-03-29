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
        }

        public void Move()
        {
            //TODO FIx
            float x = (float)(Math.Cos(_angle * _speed) * _radius);
            float y = (float)(Math.Sin(_angle * _speed) * _radius);
            Vector3 position = new Vector3(x, y, 0);
            _transform.Teleport(position);
        }
    }
}