using System;
using System.Collections.Generic;
using ConsoleGame.Loop;

namespace ConsoleGame
{
    public sealed class ScoreAchievementsFactory : IAchievementFactory
    {
        private readonly IScore _score;
        private readonly IGameLoopObjectsGroup _gameLoop;
        private readonly IWallet _wallet;
        private readonly List<int> _needScoreList;
        
        public ScoreAchievementsFactory(IScore score, IGameLoopObjectsGroup gameLoop, IWallet wallet)
        {
            _score = score ?? throw new ArgumentNullException(nameof(score));
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
            
            _needScoreList = new List<int>
            {
                100,
                250,
                500,
                1000,
                5000,
                10000,
                25000,
                50000,
                100000
            };
        }

        public void Create()
        {
            var achievements = new List<IAchievement>();
            
            for (int i = 1; i < _needScoreList.Count; i++)
            {
           //      int needScore = _needScoreList[i];
           //      IAchievement scoreAchievement = new ScoreAchievement(_score, needScore);
           //      IReward moneyReward = new MoneyReward(_wallet, needScore / 5);
           // //     IAchievement achievement = new AchievementWithReward(scoreAchievement, moneyReward);
           //      achievements.Add(achievement);
            }

            var chainOfAchievement = new ChainOfAchievement(achievements);
            _gameLoop.Add(chainOfAchievement);
        }
    }
}