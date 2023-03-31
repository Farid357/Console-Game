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

        public bool WasReceived { get; private set; }

        public void Receive()
        {
            WasReceived = true;

            foreach (var reward in _rewards)
            {
                reward.Receive();
            }
        }
    }
}