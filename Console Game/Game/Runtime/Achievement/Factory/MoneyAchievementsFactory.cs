using System;
using System.Collections.Generic;
using ConsoleGame.GameLoop;
using ConsoleGame.SaveSystem;

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
            ISaveStorage<bool> wasReceivedStorage = new BinaryStorage<bool>(new Path($"MoneyAchievement {moneyForReward} {needMoney}"));
            _saveStorages.Add(wasReceivedStorage);
            IMoneyAchievementView view = new MoneyAchievementView(_viewFactory.Create());
            IAchievement achievement = new Achievement(wasReceivedStorage, moneyReward);
            
            if(wasReceivedStorage.HasSave() && wasReceivedStorage.Load())
                view.Receive();
            
            return new MoneyAchievement(achievement, view, _wallet, needMoney);
        }
    }
}