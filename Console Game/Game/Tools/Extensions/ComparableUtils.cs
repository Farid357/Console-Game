namespace Console_Game.Tools
{
    public static class ComparableUtils
    {
        public static int ThrowIfLessThanOrEqualsToZeroException(this int number)
        {
            ThrowIfLessOrEqualsToZeroException((float)number);
            return number;
        }

        public static float ThrowIfLessOrEqualsToZeroException(this float number)
        {
            if (number <= 0)
                throw new LessThanOrEqualsToZeroException(nameof(number));
            
            return number;
        }
    }
}
