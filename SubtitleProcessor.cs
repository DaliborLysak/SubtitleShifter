using System.Collections.Generic;
using System.Text;

namespace SubtitleShifter
{
    internal class SubtitleProcessor
    {
        private ISubtitleReaderWriter ReaderWriter;
        private List<ISubtitleItem> Subtitles;

        internal SubtitleProcessor(SubtitleReaderWriter readerWriter)
        {
            ReaderWriter = readerWriter;
        }

        public void ReadFile(string fileName, Encoding encoding)
        {
            Subtitles = ReaderWriter?.ReadFile(fileName, encoding);
        }

        public void ShiftSubtitles(int shift)
        {
            Subtitles?.ForEach(s => s.Shift(shift));
        }

        public void WriteShift(string fileName, Encoding encoding)
        {
            ReaderWriter?.WriteFile(fileName, Subtitles, encoding);
        }
    }
}