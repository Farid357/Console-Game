using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    public sealed class EnemyRewardFactory : IRewardFactory
    {
        private readonly IWallet _wallet;
        private readonly IScore _score;

        public EnemyRewardFactory(IScore score, IWallet wallet)
        {
            _score = score ?? throw new ArgumentNullException(nameof(score));
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
        }

        public IReward Create()
        {
            IReward scoreReward = new ScoreReward(_score, 20);
            IReward moneyReward = new MoneyReward(_wallet, 10);
            
            IReward bestReward = new Rewards(new[]
            {
                moneyReward,
                scoreReward,
            });

            return new RandomReward(new List<(IReward Reward, float Chance)>
            {
                (moneyReward, 0.3f),
                (scoreReward, 0.3f),
                (bestReward, 0.1f)
            });
        }
    }
}