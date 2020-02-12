using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading;

namespace SubtitleShifter
{
    internal class SubtitleReaderWriter : ISubtitleReaderWriter
    {
        public List<ISubtitleItem> ReadFile(string fileName, Encoding encoding)
        {
            var subtitles = new List<ISubtitleItem>();
            var data = File.ReadLines(fileName, encoding).ToArray();

            string id = String.Empty;
            string time = String.Empty;
            string text = String.Empty;
            var lineCounter = 0;

            while (lineCounter < data.Count())
            {
                var line = data[lineCounter].TrimEnd();
                if (!String.IsNullOrEmpty(line))
                {
                    if (String.IsNullOrEmpty(id))
                    {
                        id = line;
                    }
                    else if (String.IsNullOrEmpty(time))
                    {
                        time = line;
                    }
                    else
                    {
                        text = String.IsNullOrEmpty(text) ? line : String.Join(System.Environment.NewLine, new string[] { text, line });
                    }
                }
                else
                {
                    subtitles.Add(new SubtitleItem().Parse(id, time, text));
                    id = String.Empty;
                    time = String.Empty;
                    text = String.Empty;
                }

                lineCounter++;
            }

            if (!String.IsNullOrEmpty(id) && !String.IsNullOrEmpty(time) && !String.IsNullOrEmpty(text))
            {
                subtitles.Add(new SubtitleItem().Parse(id, time, text));
            }

            return subtitles.Where(s => !s.IsEmpty()).ToList();
        }

        public void WriteFile(string fileName, List<ISubtitleItem> subtitles, Encoding encoding)
        {
            var data = new StringBuilder();
            subtitles.ForEach(s => data.AppendLine(s.ToString()));
            File.WriteAllText(fileName, data.ToString(), encoding);
        }
    }
}