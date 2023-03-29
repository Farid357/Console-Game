using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    public sealed class ChainOfAchievement : IGameLoopObject, IChainOfAchievement
    {
        private readonly List<IAchievement> _achievements;
        private readonly List<IAchievement> _notReceivedAchievements;

        public ChainOfAchievement(List<IAchievement> achievements)
        {
            _achievements = achievements ?? throw new ArgumentNullException(nameof(achievements));
            _notReceivedAchievements = _achievements;
        }

        public IReadOnlyList<IAchievement> Achievements => _achievements;

        public void Update(float deltaTime)
        {
            foreach (IAchievement achievement in _notReceivedAchievements)
            {
                if (achievement.CanReceive)
                {
                    achievement.Receive();
                    _notReceivedAchievements.Remove(achievement);
                }
            }
        }
    }
}