using System;

namespace SubtitleShifter
{
    public class SubtitleParseException : Exception
    {
        public SubtitleParseException()
        {
        }

        public SubtitleParseException(string message)
            : base(message)
        {
        }

        public SubtitleParseException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}