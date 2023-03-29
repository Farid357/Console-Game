using System;
using BananaParty.BehaviorTree;

namespace ConsoleGame
{
    public sealed class MoveNode : BehaviorNode
    {
        private readonly IIndependentMovement _movement;
        private readonly IBehaviorNode _nodeForComplete;

        public MoveNode(IIndependentMovement movement, IBehaviorNode nodeForComplete)
        {
            _movement = movement ?? throw new ArgumentNullException(nameof(movement));
            _nodeForComplete = nodeForComplete ?? throw new ArgumentNullException(nameof(nodeForComplete));
        }

        public override BehaviorNodeStatus OnExecute(float deltaTime)
        {
            _movement.Move();
            return _nodeForComplete.Execute(deltaTime);
        }
    }
}