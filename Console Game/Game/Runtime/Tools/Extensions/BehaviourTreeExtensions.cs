using BananaParty.BehaviorTree;

namespace ConsoleGame.Tools
{
    public static class BehaviourTreeExtensions
    {
        public static bool IsFinished(this IBehaviorNode behaviorTree)
        {
            return behaviorTree.Status > BehaviorNodeStatus.Running;
        }
    }
}