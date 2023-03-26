using System;

namespace ConsoleGame
{
    public sealed class Rewards : IReward
    {
        private readonly IReward[] _rewards;

        public Rewards(IReward[] rewards)
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