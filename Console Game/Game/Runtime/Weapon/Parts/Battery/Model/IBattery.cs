namespace Console_Game
{
    public interface IBattery : IReadOnlyBattery
    {
        void Charge(float amount);

        void Discharge(float amount);
    }
}