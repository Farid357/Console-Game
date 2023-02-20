using System;

namespace Console_Game.Tools.Exceptions
{
    [Serializable]
    public sealed class LessThanOrEqualsToZeroException : Exception
    {
        public LessThanOrEqualsToZeroException(string message) : base($"Value is less or equal zero! Value : {message}")
        {

        }
    }
}
