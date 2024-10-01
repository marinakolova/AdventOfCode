using System.Text.RegularExpressions;

namespace AdventOfCode2015
{
    public static class Day08
    {
        public static void Task01(string input)
        {
            int numOfCharsOfCode = 0;
            int numOfCharsInMemory = 0;

            foreach (var line in input.Split(Environment.NewLine).ToArray())
            {
                numOfCharsOfCode += line.Length;
                numOfCharsInMemory += Regex.Unescape(line.Substring(1, line.Length - 2)).Length;
            }

            Console.WriteLine(numOfCharsOfCode - numOfCharsInMemory);
        }

        public static void Task02(string input)
        {
            int numOfCharsOfCode = 0;
            int numOfCharsInNewlyEncodedStrings = 0;

            foreach (var line in input.Split(Environment.NewLine).ToArray())
            {
                numOfCharsOfCode += line.Length;
                numOfCharsInNewlyEncodedStrings += ("\"" + line.Replace("\\", "\\\\").Replace("\"", "\\\"") + "\"").Length;
            }

            Console.WriteLine(numOfCharsInNewlyEncodedStrings - numOfCharsOfCode);
        }
    }
}
