using System;

namespace ConsoleGame
{
    public sealed class MoneyAchievement : IAchievement
    {
        private readonly IAchievement _achievement;
        private readonly IMoneyAchievementView _view;
        private readonly IWallet _wallet;
        private readonly int _needMoney;

        public MoneyAchievement(IAchievement achievement, IMoneyAchievementView view, IWallet wallet, int needMoney)
        {
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
            _achievement = achievement ?? throw new ArgumentNullException(nameof(achievement));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _needMoney = needMoney;
        }

        public bool CanReceive => _wallet.Money >= _needMoney;

        public void Receive()
        {
            if (CanReceive == false)
                throw new Exception($"You can't receive achievement! Your money is {_wallet.Money}, but you need {_needMoney}");
            
            _achievement.Receive();
            _view.ReceiveWithCongratulations(_needMoney);
        }
    }
}