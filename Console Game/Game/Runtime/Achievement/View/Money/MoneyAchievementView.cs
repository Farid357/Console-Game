using System;

namespace ConsoleGame
{
    public sealed class MoneyAchievementView : IMoneyAchievementView
    {
        private readonly IAchievementView _view;

        public MoneyAchievementView(IAchievementView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public void Receive()
        {
            _view.Receive();
        }

        public void ReceiveWithCongratulations(int needMoney)
        {
            Receive();
            string congratulation = $"You received money: {needMoney} and got an achievement!";
            _view.ReceiveWithCongratulation(congratulation);
        }
    }
}