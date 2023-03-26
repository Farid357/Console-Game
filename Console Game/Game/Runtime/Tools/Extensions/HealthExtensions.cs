namespace ConsoleGame.Tools
{
    public static class HealthExtensions
    {
        public static bool IsDied(this IHealth health)
        {
            return !health.IsAlive;
        }


        public static void Kill(this IHealth health)
        {
            health.TakeDamage(health.Value);
        }
    }
}