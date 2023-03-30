using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ConsoleGame
{
    public sealed class PlayerInput : IPlayerInput, IGameLoopObject
    {
        private readonly Dictionary<IKey, Vector3> _keys;
        private readonly IKey _shootKey;
        private readonly IKey _reloadingKey;
        private Vector3 _moveDirection;

        public PlayerInput()
        {
            _keys = new Dictionary<IKey, Vector3>
            {
                { new Key(ConsoleKey.A), new Vector3(-1, 0, 0) },
                { new Key(ConsoleKey.W), new Vector3(0, 0, 1) },
                { new Key(ConsoleKey.D), new Vector3(1, 0, 0) },
                { new Key(ConsoleKey.S), new Vector3(0, 0, -1) }
            };

            _moveDirection = Vector3.Zero;
            _shootKey = new Key(ConsoleKey.P);
            _reloadingKey = new Key(ConsoleKey.R);
        }

        public bool IsMoving => _moveDirection != Vector3.Zero;

        public bool IsReloading => _reloadingKey.IsPressed();
        
        public bool IsShooting => _shootKey.IsPressed();

        public Vector3 Direction()
        {
            if (!IsMoving)
                throw new Exception($"Input isn't using! You can't get move direction!");

            return _moveDirection;
        }

        public void Update(float deltaTime)
        {
            var usingValuePair = _keys.ToList().Find(pair => pair.Key.IsPressed());

            if (usingValuePair.Key != null)
            {
                Vector3 moveDirection = usingValuePair.Value;
                _moveDirection = moveDirection;
            }

            else
            {
                _moveDirection = Vector3.Zero;
            }
        }
    }
}