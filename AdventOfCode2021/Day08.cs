namespace AdventOfCode2021
{
    public static class Day08
    {
        public static void Task01(string input)
        {
            var inputLines = input.Split(Environment.NewLine).ToList();
            
            var result = 0;

            foreach (var line in inputLines)
            {
                var inputParts = line.Split(" | ");
                var output = inputParts[1].Split(" ");

                for (int i = 0; i < output.Length; i++)
                {
                    if (output[i].Length == 2
                        || output[i].Length == 3
                        || output[i].Length == 4
                        || output[i].Length == 7)
                    {
                        result++;
                    }
                }
            }

            Console.WriteLine("Result: " + result);
        }

        public static void Task02(string input)
        {
            var inputLines = input.Split(Environment.NewLine).ToList();

            var result = 0;

            foreach (var line in inputLines)
            {
                var inputParts = line.Split(" | ");
                var uniqueSignalPatterns = inputParts[0].Split(" ").Select(x => x.ToHashSet()).ToArray();
                var output = inputParts[1].Split(" ");

                var digits = new HashSet<char>[10];
                digits[1] = uniqueSignalPatterns.Single(pattern => pattern.Count() == "cf".Length);
                digits[4] = uniqueSignalPatterns.Single(pattern => pattern.Count() == "bcdf".Length);

                digits[0] =
                    uniqueSignalPatterns.Single(pattern =>
                        pattern.Count() == 6 &&
                        pattern.Intersect(digits[1]).Count() == 2 &&
                        pattern.Intersect(digits[4]).Count() == 3
                    );
                digits[2] =
                    uniqueSignalPatterns.Single(pattern =>
                        pattern.Count() == 5 &&
                        pattern.Intersect(digits[1]).Count() == 1 &&
                        pattern.Intersect(digits[4]).Count() == 2
                    );
                digits[3] =
                    uniqueSignalPatterns.Single(pattern =>
                        pattern.Count() == 5 &&
                        pattern.Intersect(digits[1]).Count() == 2 &&
                        pattern.Intersect(digits[4]).Count() == 3
                    );
                digits[5] =
                    uniqueSignalPatterns.Single(pattern =>
                        pattern.Count() == 5 &&
                        pattern.Intersect(digits[1]).Count() == 1 &&
                        pattern.Intersect(digits[4]).Count() == 3
                    );
                digits[6] =
                    uniqueSignalPatterns.Single(pattern =>
                        pattern.Count() == 6 &&
                        pattern.Intersect(digits[1]).Count() == 1 &&
                        pattern.Intersect(digits[4]).Count() == 3
                    );
                digits[7] =
                    uniqueSignalPatterns.Single(pattern =>
                        pattern.Count() == 3 &&
                        pattern.Intersect(digits[1]).Count() == 2 &&
                        pattern.Intersect(digits[4]).Count() == 2
                    );
                digits[8] =
                    uniqueSignalPatterns.Single(pattern =>
                        pattern.Count() == 7 &&
                        pattern.Intersect(digits[1]).Count() == 2 &&
                        pattern.Intersect(digits[4]).Count() == 4
                    );
                digits[9] =
                    uniqueSignalPatterns.Single(pattern =>
                        pattern.Count() == 6 &&
                        pattern.Intersect(digits[1]).Count() == 2 &&
                        pattern.Intersect(digits[4]).Count() == 4
                    );

                result += output.Aggregate(0, (n, digit) => n * 10 + (Enumerable.Range(0, 10).Single(i => digits[i].SetEquals(digit))));
            }

            Console.WriteLine("Result: " + result);
        }
    }
}
