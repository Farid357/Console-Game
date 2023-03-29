using BananaParty.BehaviorTree;

namespace ConsoleGame
{
    public sealed class WaitNode : BehaviorNode
    {
        private readonly float _waitTime;
        private float _time;

        public WaitNode(float waitTime)
        {
            _waitTime = waitTime;
        }

        public override BehaviorNodeStatus OnExecute(float deltaTime)
        {
            _time += deltaTime;

            if (_waitTime <= _time)
            {
                _time = 0;
                return BehaviorNodeStatus.Success;
            }

            else
            {
                return BehaviorNodeStatus.Failure;
            }
        }
    }
}