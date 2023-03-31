using System;
using System.Collections.Generic;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class RandomReward : IReward
    {
        private readonly List<(IReward Reward, float Chance)> _rewards;

        public RandomReward(List<(IReward Reward, float Chance)> rewards)
        {
            _rewards = rewards ?? throw new ArgumentNullException(nameof(rewards));
        }

        public bool WasReceived { get; private set; }

        public void Receive()
        {
            WasReceived = true;
            IReward reward = _rewards.GetRandom();
            reward.Receive();
        }
    }
}