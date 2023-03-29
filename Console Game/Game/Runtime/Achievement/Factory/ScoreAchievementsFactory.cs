using System;
using System.Collections.Generic;
using ConsoleGame.GameLoop;
using ConsoleGame.SaveSystem;

namespace ConsoleGame
{
    public sealed class ScoreAchievementsFactory : IAchievementFactory
    {
        private readonly IReadOnlyScore _score;
        private readonly IAchievementViewFactory _viewFactory;
        private readonly IGameLoopObjectsGroup _gameLoop;
        private readonly IWallet _wallet;
        private readonly ISaveStorages _saveStorages;
        private readonly List<int> _needScoreList;

        public ScoreAchievementsFactory(IReadOnlyScore score, IAchievementViewFactory viewFactory, IGameLoopObjectsGroup gameLoop, IWallet wallet, ISaveStorages saveStorages)
        {
            _score = score ?? throw new ArgumentNullException(nameof(score));
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
            _saveStorages = saveStorages;

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
                int needScore = _needScoreList[i];
                int moneyForReward = needScore / 5;
                IReward moneyReward = new MoneyReward(_wallet, moneyForReward);
                ISaveStorage<bool> wasReceivedStorage = new BinaryStorage<bool>(new Path($"Score Achievement {moneyForReward} {needScore}"));
                _saveStorages.Add(wasReceivedStorage);
                IScoreAchievementView view = new ScoreAchievementView(_viewFactory.Create());
                IAchievement scoreAchievement = new ScoreAchievement(new Achievement(wasReceivedStorage, moneyReward), view,_score, needScore);
                achievements.Add(scoreAchievement);
            }

            var chainOfAchievement = new ChainOfAchievement(achievements);
            _gameLoop.Add(chainOfAchievement);
        }
    }
}