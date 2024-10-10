namespace AdventOfCode2015
{
    public static class Day17
    {
        public static void Task01(string input)
        {
            var combinations = GetCombinations(input);
            Console.WriteLine(combinations.Count());
        }

        public static void Task02(string input)
        {
            var combinations = GetCombinations(input);
            var minCount = combinations.Min(comb => comb.Count());
            var minCombinations = combinations.Where(comb => comb.Count() == minCount);
            Console.WriteLine(minCombinations.Count());
        }

        private static IEnumerable<List<int>> GetCombinations(string input)
        {
            var containers = input.Split(Environment.NewLine).Select(int.Parse).ToArray();

            var combinations = Enumerable
                .Range(1, (1 << containers.Length) - 1)
                .Select(index => containers.Where((item, idx) => ((1 << idx) & index) != 0).ToList());

            return combinations.Where(comb => comb.Sum() == 150);
        }
    }
}
