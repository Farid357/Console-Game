using System;
using System.Numerics;

namespace ConsoleGame
{
    public interface ICharacter : IReadOnlyGameObject
    {
        IHealth Health { get; }
        
        IAdjustableMovement Movement { get; }

        void Move(Vector3 direction);
    }

    class Character : ICharacter
    {
        public Character(IHealth health, IAdjustableMovement movement)
        {
            Health = health ?? throw new ArgumentNullException(nameof(health));
            Movement = movement ?? throw new ArgumentNullException(nameof(movement));
        }
        
        public bool IsAlive => Health.IsAlive;

        public IHealth Health { get; }
        
        public IAdjustableMovement Movement { get; }

        public void Move(Vector3 direction)
        {
            Movement.Move(direction);
        }

    }
}