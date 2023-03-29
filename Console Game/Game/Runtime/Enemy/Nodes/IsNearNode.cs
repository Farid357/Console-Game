using System;
using System.Numerics;
using BananaParty.BehaviorTree;

namespace ConsoleGame
{
    public sealed class IsNearNode : BehaviorNode
    {
        private readonly IReadOnlyTransform _first;
        private readonly IReadOnlyTransform _enemy;
        private readonly float _distance;

        public IsNearNode(IReadOnlyTransform first, IReadOnlyTransform second, float distance = 15f)
        {
            _first = first ?? throw new ArgumentNullException(nameof(first));
            _enemy = second ?? throw new ArgumentNullException(nameof(second));
            _distance = distance;
        }

        public override BehaviorNodeStatus OnExecute(float deltaTime)
        {
            bool isNear = Vector3.DistanceSquared(_first.Position, _enemy.Position) <= _distance;
            return isNear ? BehaviorNodeStatus.Success : BehaviorNodeStatus.Failure;
        }
    }
}