using System.Numerics;

namespace AdventOfCode2023
{
    public static class Day09
    {
        public static void Task01(string input)
        {
            ReadInputAndPrintResult(input);
        }

        public static void Task02(string input)
        {
            var extrapolateBackwards = true;
            ReadInputAndPrintResult(input, extrapolateBackwards);
        }

        private static void ReadInputAndPrintResult(string input, bool extrapolateBackwards = false)
        {
            BigInteger result = 0;

            var inputLines = input.Split(Environment.NewLine).ToList();

            foreach (var line in inputLines)
            {
                var sequences = new List<List<BigInteger>>();

                var history = line.Split().Select(BigInteger.Parse).ToList();
                if (extrapolateBackwards) // Task02
                {
                    history.Reverse();
                }
                sequences.Add(history);

                while (!sequences[sequences.Count - 1].All(x => x == 0))
                {
                    var newSequence = new List<BigInteger>();

                    if (extrapolateBackwards) // Task02
                    {
                        for (int i = 1; i < sequences[sequences.Count - 1].Count; i++)
                        {
                            newSequence.Add(sequences[sequences.Count - 1][i] - sequences[sequences.Count - 1][i - 1]);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < sequences[sequences.Count - 1].Count - 1; i++)
                        {
                            newSequence.Add(sequences[sequences.Count - 1][i + 1] - sequences[sequences.Count - 1][i]);
                        }
                    }

                    sequences.Add(newSequence);
                }

                for (int i = sequences.Count - 2; i >= 0; i--)
                {
                    sequences[i].Add(sequences[i].Last() + sequences[i + 1].Last());
                }

                result += sequences[0].Last();
            }

            Console.WriteLine(result);
        }
    }
}
