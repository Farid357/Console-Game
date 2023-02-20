using Console_Game.Tools.Exceptions;

namespace Console_Game.Tools.Extensions
{
    public static class ComparableUtils
    {
        public static int ThrowIfLessThanOrEqualsToZeroException(this int number)
        {
            if (number <= 0)
                throw new LessThanOrEqualsToZeroException(nameof(number));

            return number;
        }

        public static float ThrowIfLessOrEqualsToZeroException(this float number)
        {
            ThrowIfLessOrEqualsToZeroException((int)number);
            return number;
        }
    }
}
