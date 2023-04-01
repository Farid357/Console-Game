using System;
using BananaParty.BehaviorTree;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class AttackHealthNode : BehaviorNode
    {
        private readonly IHealth _health;
        private readonly int _damage;

        public AttackHealthNode(IHealth health, int damage)
        {
            _health = health ?? throw new ArgumentNullException(nameof(health));
            _damage = damage.ThrowIfLessThanOrEqualsToZeroException();
        }

        public override BehaviorNodeStatus OnExecute(float deltaTime)
        {
            _health.TakeDamage(_damage);
            return BehaviorNodeStatus.Success;
        }
    }
}