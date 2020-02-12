using System;

namespace SubtitleShifter
{
    public class InputDataException : Exception
    {
        public InputDataException()
        {
        }

        public InputDataException(string message)
            : base(message)
        {
        }

        public InputDataException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}