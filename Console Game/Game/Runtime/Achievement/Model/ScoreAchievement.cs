using System;

namespace ConsoleGame
{
    public sealed class ScoreAchievement : IAchievement
    {
        private readonly IAchievement _achievement;
        private readonly IScoreAchievementView _view;
        private readonly IReadOnlyScore _score;
        private readonly int _needScore;

        public ScoreAchievement(IAchievement achievement, IScoreAchievementView view, IReadOnlyScore score, int needScore)
        {
            _achievement = achievement ?? throw new ArgumentNullException(nameof(achievement));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _score = score ?? throw new ArgumentNullException(nameof(score));
            _needScore = needScore;
        }

        public bool CanReceive => _score.Count >= _needScore;
        
        public void Receive()
        {
            if (CanReceive == false)
                throw new Exception($"You can't receive achievement! Your score is {_score.Count}, but you need {_needScore}");
            
            _achievement.Receive();
            _view.ReceiveWithCongratulations(_needScore, _score.Count);
        }
    }
}