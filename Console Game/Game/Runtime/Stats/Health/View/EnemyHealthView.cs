using System;

namespace ConsoleGame
{
    public sealed class EnemyHealthView : IHealthView
    {
        private readonly IGameObjectView _gameObjectView;

        public EnemyHealthView(IGameObjectView gameObjectView)
        {
            _gameObjectView = gameObjectView ?? throw new ArgumentNullException(nameof(gameObjectView));
        }

        public void Visualize(int maxValue, int value)
        {
            Console.WriteLine($"Enemy Health {value}");
        }

        public void Die()
        {
            Console.WriteLine($"Enemy died!");
            _gameObjectView.Destroy();
        }
    }
}