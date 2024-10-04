using System.Text;

namespace AdventOfCode2015
{
    public static class Day10
    {
        public static void Task01(string input)
        {
            LookAndSay(input, 40);
        }

        public static void Task02(string input)
        {
            LookAndSay(input, 50);
        }

        private static void LookAndSay(string sequence, int repeats)
        {
            for (int i = 0; i < repeats; i++)
            {
                var prevDigit = sequence[0];
                var prevDigitCount = 1;

                var newSequence = new StringBuilder();

                for (int j = 1; j < sequence.Length; j++)
                {
                    var currentDigit = sequence[j];

                    if (currentDigit == prevDigit)
                    {
                        prevDigitCount++;
                    }
                    else
                    {
                        newSequence.Append(prevDigitCount.ToString());
                        newSequence.Append(prevDigit.ToString());

                        prevDigit = currentDigit;
                        prevDigitCount = 1;
                    }

                    if (j == sequence.Length - 1)
                    {
                        newSequence.Append(prevDigitCount.ToString());
                        newSequence.Append(prevDigit.ToString());
                    }
                }

                sequence = newSequence.ToString();
            }

            Console.WriteLine(sequence.Length);
        }
    }
}
