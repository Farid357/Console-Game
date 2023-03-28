using System;

namespace ConsoleGame
{
    public sealed class KillsStreakAchievement : IAchievement
    {
        private readonly IAchievement _achievement;
        private readonly IKillsStreak _killsStreak;
        private readonly int _needFactor;

        public KillsStreakAchievement(IAchievement achievement, IKillsStreak killsStreak, int needFactor)
        {
            _achievement = achievement ?? throw new ArgumentNullException(nameof(achievement));
            _killsStreak = killsStreak ?? throw new ArgumentNullException(nameof(killsStreak));
            _needFactor = needFactor;
        }

        public bool CanReceive => _killsStreak.Factor >= _needFactor;

        public void Receive()
        {
            _achievement.Receive();
        }
    }
}