namespace Console_Game
{
    public sealed class NullBattery : IBattery
    {
        public float Amount { get; }
        
        public bool IsDischarged => true;
        
        public void Charge(float amount)
        {
            
        }

        public void Discharge(float amount)
        {
        }
    }
}