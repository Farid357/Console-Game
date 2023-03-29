using System.Collections.Generic;
using ConsoleGame.GameLoop;
using ConsoleGame.SaveSystem;

namespace ConsoleGame
{
    public sealed class AchievementsFactory : IAchievementFactory
    {
        private readonly List<IAchievementFactory> _factories;

        public AchievementsFactory(IAchievementViewFactory viewFactory, IGameLoopObjectsGroup gameLoop, ISaveStorages saveStorages, IWallet wallet, IReadOnlyScore score)
        {
            _factories = new List<IAchievementFactory>()
            {
                new MoneyAchievementsFactory(gameLoop, viewFactory, saveStorages, wallet),
                new ScoreAchievementsFactory(score, viewFactory, gameLoop, wallet, saveStorages)
            };
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