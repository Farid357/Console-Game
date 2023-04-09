using System;
using BananaParty.BehaviorTree;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class Enemy : IEnemy, IGameObject
    {
        private readonly IBehaviorNode _behaviorTree;

        public Enemy(IHealth health, IBehaviorNode behaviorTree)
        {
            _behaviorTree = behaviorTree ?? throw new ArgumentNullException(nameof(behaviorTree));
            Health = health ?? throw new ArgumentNullException(nameof(health));
        }

        public IHealth Health { get; }
        
        public bool IsAlive => Health.IsAlive;

        public void Update(float deltaTime)
        {
            if (!IsAlive)
                throw new Exception($"Enemy is not alive! You can't update it!");

            _behaviorTree.Execute(deltaTime);
            
            if(_behaviorTree.IsFinished())
                _behaviorTree.Reset();
        }
    }
}