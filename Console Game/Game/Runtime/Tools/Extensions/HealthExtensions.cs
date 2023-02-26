namespace Console_Game.Tools
{
    public static class HealthExtensions
    {
        public static bool IsDied(this IHealth health)
        {
            return !health.IsAlive;
        }


        public static void VisualizeCurrentValue(this IHealth health) => health.TakeDamage(0);
        
    }
}