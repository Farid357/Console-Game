using System;
using System.Numerics;
using ConsoleGame.Physics;
using ConsoleGame.Stats;

namespace ConsoleGame.Bonus
{
    public sealed class ScoreFactorBonusFactory : IBonusFactory
    {
        private readonly ICollidersWorld<IBonus> _bonusesWorld;
        private readonly IScoreWithFactor _score;

        public ScoreFactorBonusFactory(ICollidersWorld<IBonus> bonusesWorld, IScoreWithFactor score)
        {
            _bonusesWorld = bonusesWorld ?? throw new ArgumentNullException(nameof(bonusesWorld));
            _score = score ?? throw new ArgumentNullException(nameof(score));
        }

        public IBonus Create(IReadOnlyTransform transform)
        {
            IBonus bonus = new ScoreFactorBonus(_score, 30);
            ICollider collider = new BoxCollider(Vector3.One, transform.Position);
            _bonusesWorld.Add(bonus, collider);
            return bonus;
        }
    }
}