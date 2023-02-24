namespace Console_Game
{
    public interface IHealableHealth : IHealth
    {
        bool CanHeal(int value);
        
        void Heal(int value);
    }
}