using System;

namespace ConsoleGame
{
    public sealed class RewardView : IRewardView
    {
        private readonly string _name;

        public RewardView(string name)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public void Apply()
        {
            Console.WriteLine($"Reward applied {_name}");
        }
    }
}