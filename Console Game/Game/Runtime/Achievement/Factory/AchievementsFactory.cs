using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    public sealed class AchievementsFactory : IAchievementFactory
    {
        private readonly List<IAchievementFactory> _factories;

        public AchievementsFactory(List<IAchievementFactory> factories)
        {
            if (factories.Count == 0)
                throw new ArgumentException("Value cannot be an empty collection.", nameof(factories));
            
            _factories = factories ?? throw new ArgumentNullException(nameof(factories));
        }

        public void Create()
        {
            foreach (var factory in _factories)
            {
                factory.Create();
            }
        }
    }
}