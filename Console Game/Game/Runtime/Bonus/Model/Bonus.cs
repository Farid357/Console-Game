using System;
using System.Numerics;
using ConsoleGame.Tools;

namespace ConsoleGame.Bonus
{
    public sealed class Bonus : IBonus, IGameObject
    {
        private readonly ITransform _transform;
        private readonly IBonusView _view;
        private readonly float _rotateSpeed;
        
        public Bonus(ITransform transform, IBonusView view, float rotateSpeed = 1.5f)
        {
            _transform = transform ?? throw new ArgumentNullException(nameof(transform));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _rotateSpeed = rotateSpeed.ThrowIfLessThanZeroException();
        }
        
        public bool IsAlive { get; private set; }

        public void Pick()
        {
            if (!IsAlive)
                throw new Exception($"Bonus isn't alive!");

            IsAlive = false;
            _view.Destroy();
        }

        public void Update(float deltaTime)
        {
            if(!IsAlive)
                throw new Exception($"Bonus isn't alive! You can't update it!");

            Quaternion rotation = new Quaternion(30f  * _rotateSpeed * deltaTime, 0f, 0f, 0f);
            _transform.Rotate(_transform.Rotation * rotation);
        }
    }
}