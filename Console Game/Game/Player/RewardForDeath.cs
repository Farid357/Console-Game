using System;

namespace Console_Game
{
    public sealed class RewardForDeath : IUpdateable
    {
        private readonly IHealth _health;
        private readonly IReward _reward;

        public RewardForDeath(IHealth health, IReward reward)
        {
            _health = health ?? throw new ArgumentNullException(nameof(health));
            _reward = reward ?? throw new ArgumentNullException(nameof(reward));
        }

        public void Update(float deltaTime)
        {
            if (_health.IsDied && _reward.IsApplied == false)
                _reward.Apply();
        }
    }
}