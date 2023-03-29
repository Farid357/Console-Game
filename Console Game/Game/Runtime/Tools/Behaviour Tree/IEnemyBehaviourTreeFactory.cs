using ConsoleGame;

namespace BananaParty.BehaviorTree
{
    public interface IEnemyBehaviourTreeFactory
    {
        IBehaviorNode Create(IMovement enemyMovement);
    }
}