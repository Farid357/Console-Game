namespace Console_Game.Tools.Extensions
{
    public static class HealthExtensions
    {
        public static bool IsDied(this IHealth health)
        {
            return !health.IsAlive;
        }
    }
}