using System;

namespace ConsoleGame
{
    public sealed class ScoreAchievement : IAchievement
    {
        private readonly IAchievement _achievement;
        private readonly IScore _score;
        private readonly int _needScore;

        public ScoreAchievement(IAchievement achievement, IScore score, int needScore)
        {
            _achievement = achievement ?? throw new ArgumentNullException(nameof(achievement));
            _score = score ?? throw new ArgumentNullException(nameof(score));
            _needScore = needScore;
        }

        public bool CanReceive => _score.Count >= _needScore;
        
        public void Receive()
        {
            _achievement.Receive();
        }
    }
}