using System;
using System.Globalization;
using System.Text;

namespace SubtitleShifter
{
    internal class SubtitleItem : ISubtitleItem
    {
        public ISubtitleItem Parse(string id, string time, string text)
        {
            try
            {
                ID = Int32.Parse(id);
                var timeRecords = time.Split(" --> ");
                Start = TimeSpan.Parse(timeRecords[0].Replace(',', '.'), CultureInfo.InvariantCulture);
                End = TimeSpan.Parse(timeRecords[1].Replace(',', '.'), CultureInfo.InvariantCulture);
                Text = text;
            }
            catch (Exception e)
            {
                throw new SubtitleParseException($"Exception occured while parsing subtitles: {id}, time:{time}, text{text}", e);
            }

            return this;
        }

        public void Shift(int shift)
        {
            var seconds = new TimeSpan(0, 0, shift);
            Start = Start.Add(seconds);
            End = End.Add(seconds);
        }

        public override string ToString()
        {
            var data = new StringBuilder();
            data.AppendLine(ID.ToString());
            data.AppendLine(GetTimeString());
            data.AppendLine(Text);
            return data.ToString();
        }

        private string GetTimeString()
        {
            return $"{GetTimeString(Start)} --> {GetTimeString(End)}";
        }

        private static string GetTimeString(TimeSpan time)
        {
            return time.ToString(@"hh\:mm\:ss\.fff").Replace(".", ",", true, CultureInfo.InvariantCulture);
        }

        public bool IsEmpty()
        {
            var emptyTimeSpan = new TimeSpan();
            return (ID == 0) && Start.Equals(emptyTimeSpan) && End.Equals(emptyTimeSpan) && String.IsNullOrEmpty(Text);
        }

        private int ID = 0;
        private TimeSpan Start;
        private TimeSpan End;
        private string Text;
    }
}