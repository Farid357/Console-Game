using System;

namespace ConsoleGame
{
    public sealed class RewardWithView : IReward
    {
        private readonly IRewardView _rewardView;

        public RewardWithView(IRewardView rewardView)
        {
            _rewardView = rewardView ?? throw new ArgumentNullException(nameof(rewardView));
        }

        public bool IsApplied { get; private set; }

        public void Apply()
        {
            IsApplied = true;
            _rewardView.Apply();
        }
    }
}