using System.Collections.Generic;
using System.Text;

namespace SubtitleShifter
{
    public interface ISubtitleReaderWriter
    {
        List<ISubtitleItem> ReadFile(string fileName, Encoding encoding);
        void WriteFile(string fileName, List<ISubtitleItem> subtitles, Encoding encoding);
    }
}