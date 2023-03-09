using System;

namespace Console_Game
{
    public sealed class RewardView : IReward
    {
        private readonly string _name;

        public RewardView(string name)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public bool IsApplied { get; private set; }
        
        public void Apply()
        {
            IsApplied = true;
            Console.WriteLine($"Reward applied {_name}");
        }
    }
}