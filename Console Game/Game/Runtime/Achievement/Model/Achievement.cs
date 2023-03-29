using System;
using ConsoleGame.SaveSystem;

namespace ConsoleGame
{
    public sealed class Achievement : IAchievement
    {
        private readonly ISaveStorage<bool> _wasReceivedStorage;
        private readonly IReward _reward;

        public Achievement(ISaveStorage<bool> wasReceivedStorage, IReward reward)
        {
            _wasReceivedStorage = wasReceivedStorage ?? throw new ArgumentNullException(nameof(wasReceivedStorage));
            _reward = reward ?? throw new ArgumentNullException(nameof(reward));
            CanReceive = _wasReceivedStorage.HasSave() ? false : true;
        }

        public bool CanReceive { get; private set; }
        
        public void Receive()
        {
            if (CanReceive == false)
                throw new Exception($"Achievement is already received!");
            
            CanReceive = false;
            _wasReceivedStorage.Save(CanReceive);
            _reward.Apply();
        }
    }
}