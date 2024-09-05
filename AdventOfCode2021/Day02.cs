namespace AdventOfCode2021
{
    public static class Day02
    {
        public static void Task01(string input)
        {
            var inputLines = input.Split(Environment.NewLine).ToArray();

            var horizontalPosition = 0;
            var depth = 0;

            foreach (var line in inputLines)
            {
                var lineProps = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var keyWord = lineProps[0];
                var number = int.Parse(lineProps[1]);

                switch (keyWord)
                {
                    case "forward":
                        horizontalPosition += number;
                        break;

                    case "down":
                        depth += number;
                        break;

                    case "up":
                        depth -= number;
                        break;
                }
            }

            Console.WriteLine($"Result: {horizontalPosition * depth}");
        }

        public static void Task02(string input)
        {
            var inputLines = input.Split(Environment.NewLine).ToArray();

            var horizontalPosition = 0;
            var depth = 0;
            var aim = 0;

            foreach (var line in inputLines)
            {
                var lineProps = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var keyWord = lineProps[0];
                var number = int.Parse(lineProps[1]);

                switch (keyWord)
                {
                    case "forward":
                        horizontalPosition += number;
                        depth += (aim * number);
                        break;

                    case "down":
                        aim += number;
                        break;

                    case "up":
                        aim -= number;
                        break;
                }
            }

            Console.WriteLine($"Result: {horizontalPosition * depth}");
        }
    }
}
