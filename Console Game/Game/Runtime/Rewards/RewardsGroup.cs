using System;

namespace Console_Game
{
    public sealed class RewardsGroup : IReward
    {
        private readonly IReward[] _rewards;

        public RewardsGroup(params IReward[] rewards)
        {
            _rewards = rewards ?? throw new ArgumentNullException(nameof(rewards));
        }

        public bool IsApplied { get; private set; }

        public void Apply()
        {
            IsApplied = true;

            foreach (var reward in _rewards)
            {
                reward.Apply();
            }
        }
    }
}