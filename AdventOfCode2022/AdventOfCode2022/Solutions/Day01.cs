namespace AdventOfCode2022.Solutions
{
    public static class Day01
    {
        public static void Task01()
        {
            var current = 0;
            var list = new List<int>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

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

            Console.WriteLine(list.Max());
        }
        public static void Task02()
        {
            var current = 0;
            var list = new List<int>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

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

            var first = list.Max();
            list.Remove(first);

            var second = list.Max();
            list.Remove(second);

            var third = list.Max();
            Console.WriteLine(first + second + third);
        }
    }
}
