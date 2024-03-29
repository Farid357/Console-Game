using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class BonusLoopFactory : IBonusLoopFactory
    {
        private readonly IReadOnlyList<IBonusFactory> _factories;
        private readonly IReadOnlyList<Vector3> _createPositions;
        private readonly Random _random;

        public BonusLoopFactory(IReadOnlyList<IBonusFactory> factories, IReadOnlyList<Vector3> createPositions)
        {
            _factories = factories ?? throw new ArgumentNullException(nameof(factories));
            _createPositions = createPositions ?? throw new ArgumentNullException(nameof(createPositions));
            _random = new Random();
        }

        public async void StartCreate(int minCreateDelay, int maxCreateDelay)
        {
            while (true)
            {
                int spawnDelay = _random.Next(minCreateDelay, maxCreateDelay);
                IBonusFactory bonusFactory = _factories.GetRandom();
                await Task.Delay(TimeSpan.FromSeconds(spawnDelay));
                Vector3 position = _createPositions.GetRandom();
                ITransform transform = new Transform(position);
                bonusFactory.Create(transform);
            }
        }
    }
}