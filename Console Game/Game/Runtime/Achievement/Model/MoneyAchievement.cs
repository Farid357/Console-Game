using System;

namespace ConsoleGame
{
    public sealed class MoneyAchievement : IAchievement
    {
        private readonly IAchievement _achievement;
        private readonly IWallet _wallet;
        private readonly int _needMoney;

        public MoneyAchievement(IAchievement achievement, IWallet wallet, int needMoney)
        {
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
            _achievement = achievement ?? throw new ArgumentNullException(nameof(achievement));
            _needMoney = needMoney;
        }

        public bool CanReceive => _wallet.Money >= _needMoney;

        public void Receive()
        {
            _achievement.Receive();
        }
    }
}