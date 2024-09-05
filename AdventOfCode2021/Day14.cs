namespace AdventOfCode2021
{
    public static class Day14
    {
        private static List<char> template;
        private static Dictionary<char, Dictionary<char, char>> pairInsertions;
        private static Dictionary<char, int> charCounts;

        public static void Task01(string input)
        {
            var inputLines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();

            ReadTemplate(inputLines[0]);
            inputLines.RemoveAt(0);

            ReadPairInsertions(inputLines);
            PerformInsertions(10);
            CountChars();
            PrintResult();
        }

        public static void Task02(string input)
        {
            var inputLines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();

            var polymer = inputLines[0];
            var generatedElement = new Dictionary<string, string>();

            inputLines.RemoveAt(0);
            foreach (var inputLine in inputLines)
            {
                var inputParts = inputLine.Split(" -> ");
                var molecule = inputParts[0];
                var element = inputParts[1];

                generatedElement[molecule] = element;
            }

            var moleculeCount = new Dictionary<string, long>();
            foreach (var i in Enumerable.Range(0, polymer.Length - 1))
            {
                var ab = polymer.Substring(i, 2);
                moleculeCount[ab] = moleculeCount.GetValueOrDefault(ab) + 1;
            }

            for (var i = 0; i < 40; i++)
            {
                var updated = new Dictionary<string, long>();
                foreach (var (molecule, count) in moleculeCount)
                {
                    var (a, n, b) = (molecule[0], generatedElement[molecule], molecule[1]);
                    updated[$"{a}{n}"] = updated.GetValueOrDefault($"{a}{n}") + count;
                    updated[$"{n}{b}"] = updated.GetValueOrDefault($"{n}{b}") + count;
                }
                moleculeCount = updated;
            }

            var elementCounts = new Dictionary<char, long>();
            foreach (var (molecule, count) in moleculeCount)
            {
                var a = molecule[0];
                elementCounts[a] = elementCounts.GetValueOrDefault(a) + count;
            }
            elementCounts[polymer.Last()]++;

            Console.WriteLine("Result: " + (elementCounts.Values.Max() - elementCounts.Values.Min()));
        }

        private static void PrintResult()
        {
            var orderedCounts = charCounts.OrderBy(x => x.Value).Select(x => x.Value).ToList();
            var mostCommon = orderedCounts[^1];
            var leastCommon = orderedCounts[0];

            var result = mostCommon - leastCommon;
            Console.WriteLine("Result: " + result);
        }

        private static void CountChars()
        {
            charCounts = new Dictionary<char, int>();

            for (int i = 0; i < template.Count; i++)
            {
                var currChar = template[i];

                if (!charCounts.ContainsKey(currChar))
                {
                    charCounts[currChar] = 0;
                }
                charCounts[currChar]++;
            }
        }

        private static void PerformInsertions(int stepsCount)
        {
            for (int step = 0; step < stepsCount; step++)
            {
                var newList = new List<char>();
                for (int i = 0; i < template.Count - 1; i++)
                {
                    var firstChar = template[i];
                    var secondChar = template[i + 1];
                    var insertionChar = pairInsertions[firstChar][secondChar];

                    if (i == 0)
                    {
                        newList.Add(firstChar);
                    }
                    newList.Add(insertionChar);
                    newList.Add(secondChar);
                }
                template = newList;
            }
        }

        private static void ReadPairInsertions(List<string> inputLines)
        {
            pairInsertions = new Dictionary<char, Dictionary<char, char>>();

            foreach (var inputLine in inputLines)
            {
                var inputParts = inputLine.Split(" -> ");
                var firstChar = inputParts[0][0];
                var secondChar = inputParts[0][1];
                var insertionChar = inputParts[1][0];

                if (!pairInsertions.ContainsKey(firstChar))
                {
                    pairInsertions[firstChar] = new Dictionary<char, char>();
                }
                pairInsertions[firstChar][secondChar] = insertionChar;
            }
        }

        private static void ReadTemplate(string inputLine)
        {
            template = new List<char>();

            for (int i = 0; i < inputLine.Length; i++)
            {
                template.Add(inputLine[i]);
            }
        }
    }
}
