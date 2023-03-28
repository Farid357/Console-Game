using System;
using System.Collections.Generic;
using ConsoleGame.Loop;
using ConsoleGame.Save_Storages;
using ConsoleGame.Save_Storages.Paths;

namespace ConsoleGame
{
    public sealed class MoneyAchievementsFactory : IAchievementFactory
    {
        private readonly IGameLoopObjectsGroup _gameLoop;
        private readonly IAchievementViewFactory _viewFactory;
        private readonly ISaveStorages _saveStorages;
        private readonly IWallet _wallet;

        public MoneyAchievementsFactory(IGameLoopObjectsGroup gameLoop, IAchievementViewFactory viewFactory, ISaveStorages saveStorages, IWallet wallet)
        {
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
            _saveStorages = saveStorages ?? throw new ArgumentNullException(nameof(saveStorages));
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
        }

        public void Create()
        {
            var achievements = new List<IAchievement>();
            var moneyForReward = 0;
            
            for (int i = 1; i < 101; i++)
            {
                int needMoney = i * 100;
                moneyForReward += 25;
                IAchievement achievement = Create(moneyForReward, needMoney);
                achievements.Add(achievement);

                if (i % 50 == 0)
                    moneyForReward *= 2;
            }

            var chainOfAchievement = new ChainOfAchievement(achievements);
            _gameLoop.Add(chainOfAchievement);
        }

        private IAchievement Create(int moneyForReward, int needMoney)
        {
            IReward moneyReward = new MoneyReward(_wallet, moneyForReward);
            string congratulationText = $"Great! You earned money: {moneyReward} and received money: {moneyReward}";
            ISaveStorage<bool> wasReceivedStorage = new BinaryStorage<bool>(new Path(congratulationText));
            _saveStorages.Add(wasReceivedStorage);
            IAchievementView view = _viewFactory.Create(congratulationText);
            return new MoneyAchievement(new Achievement(view, wasReceivedStorage), _wallet, needMoney);
        }
    }
}