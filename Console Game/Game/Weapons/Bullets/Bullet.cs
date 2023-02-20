using System;
using System.Numerics;
using System.Threading.Tasks;

namespace Console_Game.Weapons
{
    public sealed class Bullet : IBullet
    {
        private readonly IBulletView _bulletView;
        private readonly Vector2 _direction;
        private const float Force = 250;
        private Vector2 _position;
        
        public Bullet(Vector2 direction)
        {
            _bulletView = new BulletView();
            _direction = direction;
        }

        public async void Throw()
        {
            for (var i = 0; i < Force; i++)
            {
                _position += _direction;
                _bulletView.VisualizePosition(_position);
                await Task.Delay(TimeSpan.FromSeconds(0.1f));
            }
        }
    }
}