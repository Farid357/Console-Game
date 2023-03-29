using System;
using BananaParty.BehaviorTree;

namespace ConsoleGame
{
    public sealed class WeaponAttackNode : BehaviorNode
    {
        private readonly IWeapon _weapon;

        public WeaponAttackNode(IWeapon weapon)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }

        public override BehaviorNodeStatus OnExecute(float deltaTime)
        {
            bool hasShot = false;

            if (_weapon.CanShoot)
            {
                _weapon.Shoot();
                hasShot = true;
            }

            return hasShot ? BehaviorNodeStatus.Success : BehaviorNodeStatus.Failure;
        }
    }
}