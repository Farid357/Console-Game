namespace Console_Game
{
    public interface IBatteryView
    {
        void Visualize(float charge);

        void Discharge();
    }
}