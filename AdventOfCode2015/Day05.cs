namespace AdventOfCode2015
{
    public static class Day05
    {
        public static void Task01(string input)
        {
            var strings = input.Split(Environment.NewLine).ToArray();
            int niceStrings = 0;

            foreach (string s in strings)
            {
                int vowelsCount = 0;
                int repeatingChars = -1;
                bool notNice = false;

                char prevChar = s[0];

                for (int i = 0; i < s.Length; i++)
                {
                    char currChar = s[i];

                    if (currChar == 'a' || currChar == 'e' || currChar == 'i' || currChar == 'o' || currChar == 'u')
                    {
                        vowelsCount++;
                    }

                    if (currChar == prevChar)
                    {
                        repeatingChars++;
                    }

                    if ((prevChar == 'a' && currChar == 'b') ||
                        (prevChar == 'c' && currChar == 'd') ||
                        (prevChar == 'p' && currChar == 'q') ||
                        (prevChar == 'x' && currChar == 'y'))
                    {
                        notNice = true;
                    }

                    prevChar = currChar;
                }

                if (vowelsCount >= 3 && repeatingChars >= 1 && notNice == false)
                {
                    niceStrings++;
                }
            }

            Console.WriteLine(niceStrings);
        }

        public static void Task02(string input)
        {
            var strings = input.Split(Environment.NewLine).ToArray();
            int niceStrings = 0;

            foreach (string s in strings)
            {
                var pairs = new Dictionary<string, int[]>();
                bool repeatsWithOneLetterInBetween = false;

                for (int i = 0; i < s.Length; i++)
                {
                    char currChar = s[i];

                    if (i < s.Length - 1)
                    {
                        char nextChar = s[i + 1];
                        string pair = currChar.ToString() + nextChar.ToString();

                        if (pairs.ContainsKey(pair) && pairs[pair][1] != i)
                        {
                            pairs[pair][2] += 1;
                        }
                        else if (!pairs.ContainsKey(pair))
                        {
                            pairs.Add(pair, new int[3] { i, i + 1, 1 });
                        }
                    }

                    if (i < s.Length - 2)
                    {
                        char nextBetweenOne = s[i + 2];
                        if (currChar == nextBetweenOne)
                        {
                            repeatsWithOneLetterInBetween = true;
                        }
                    }
                }

                if (pairs.Any(x => x.Value[2] > 1) && repeatsWithOneLetterInBetween)
                {
                    niceStrings++;
                }
            }

            Console.WriteLine(niceStrings);
        }
    }
}
