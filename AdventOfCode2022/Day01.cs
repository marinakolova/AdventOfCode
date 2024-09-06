namespace AdventOfCode2022
{
    public static class Day01
    {
        public static void Task01(string input)
        {
            var inputLines = input.Split(Environment.NewLine).ToList();

            var current = 0;
            var list = new List<int>();

            foreach (var line in inputLines)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    current += int.Parse(line);
                }
                else
                {
                    list.Add(current);
                    current = 0;
                }
            }
            list.Add(current);

            Console.WriteLine(list.Max());
        }

        public static void Task02(string input)
        {
            var inputLines = input.Split(Environment.NewLine).ToList();

            var current = 0;
            var list = new List<int>();

            foreach (var line in inputLines)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    current += int.Parse(line);
                }
                else
                {
                    list.Add(current);
                    current = 0;
                }
            }
            list.Add(current);

            var first = list.Max();
            list.Remove(first);

            var second = list.Max();
            list.Remove(second);

            var third = list.Max();
            Console.WriteLine(first + second + third);
        }
    }
}
