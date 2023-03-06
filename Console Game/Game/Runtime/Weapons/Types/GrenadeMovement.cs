using System.Numerics;

namespace Console_Game
{
    public sealed class GrenadeMovement : IGrenadeMovement
    {
        private readonly IMovement _movement;

        public void Throw()
        {
            var throwDirection = new Vector2(0, 0.5f);

        }
    }
}