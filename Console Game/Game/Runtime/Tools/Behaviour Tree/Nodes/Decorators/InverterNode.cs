namespace BananaParty.BehaviorTree
{
    public class InverterNode : DecoratorNode
    {
        public InverterNode(IBehaviorNode childNode) : base(childNode)
        {
        }

        public override BehaviorNodeStatus OnExecute(float deltaTime)
        {
            BehaviorNodeStatus childStatus = ChildNode.Execute(deltaTime);

            switch (childStatus)
            {
                case BehaviorNodeStatus.Failure:
                    return BehaviorNodeStatus.Success;
                case BehaviorNodeStatus.Success:
                    return BehaviorNodeStatus.Failure;
                default:
                    return childStatus;
            }

        }
    }
}