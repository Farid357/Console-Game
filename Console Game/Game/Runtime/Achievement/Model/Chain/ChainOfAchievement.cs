using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleGame
{
    public sealed class ChainOfAchievement : IGameLoopObject, IChainOfAchievement
    {
        private readonly List<IAchievement> _achievements;

        public ChainOfAchievement(List<IAchievement> achievements)
        {
            _achievements = achievements ?? throw new ArgumentNullException(nameof(achievements));
            CurrentAchievement = _achievements.First(achievement => achievement.CanReceive);
        }

        public IAchievement CurrentAchievement { get; private set; }

        public void Update(float deltaTime)
        {
            if (CurrentAchievement.CanReceive)
            {
                int nextAchievementIndex = _achievements.IndexOf(CurrentAchievement) + 1;
                CurrentAchievement.Receive();
                
                if (_achievements.Count > nextAchievementIndex)
                    CurrentAchievement = _achievements[nextAchievementIndex];
            }
        }
    }
}