using System;

namespace Console_Game
{
    public sealed class EnemyRewardFactory : IFactory<IReward>
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
            
            return new Rewards(new IReward[]
            {
                moneyReward,
                scoreReward,
                
                new Rewards(new IReward[]
                {
                    moneyReward,
                    scoreReward,
                })
            });
        }
    }
}