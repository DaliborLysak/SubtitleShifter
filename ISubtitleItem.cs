namespace SubtitleShifter
{
    public interface ISubtitleItem
    {
        ISubtitleItem Parse(string id, string time, string text);
        void Shift(int shift);
        string ToString();
        bool IsEmpty();
    }
}