using System;

namespace ConsoleGame
{
    public sealed class ScoreAchievementView : IScoreAchievementView
    {
        private readonly IAchievementView _view;

        public ScoreAchievementView(IAchievementView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public void Receive()
        {
            _view.Receive();
        }

        public void ReceiveWithCongratulations(int needScore, int currentScore)
        {
            Receive();
            string congratulation = $"You received score: {needScore}, now your score: {currentScore}, it's great!!";
            _view.ReceiveWithCongratulation(congratulation);
        }
    }
}