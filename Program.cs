using System;
using System.Text;

namespace SubtitleShifter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");

            try
            {
                if (args.Length > 1)
                {
                    var processor = new SubtitleProcessor(new SubtitleReaderWriter());
                    var fileName = args[0];
                    var toFileName = (args.Length > 2) ? args[2] : fileName;

                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    var encoding = Encoding.GetEncoding(1250);

                    if (Int32.TryParse(args[1], out int shift))
                    {
                        processor.ReadFile(fileName, encoding);
                        processor.ShiftSubtitles(shift);
                        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                        processor.WriteShift(toFileName, encoding);
                    }
                }
                else
                {
                    throw new InputDataException("Wrong number of parameters, missing input file or shift");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Console.WriteLine("Finished.");
            }
        }
    }
}
