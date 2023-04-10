using BananaParty.BehaviorTree;

namespace ConsoleGame
{
    public interface IEnemyBehaviourTreeFactory
    {
        IBehaviorNode Create(IMovement enemyMovement);
    }
}