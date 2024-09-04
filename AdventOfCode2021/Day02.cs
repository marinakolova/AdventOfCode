namespace AdventOfCode2021
{
    public static class Day02
    {
        public static void Task02()
        {
            var horizontalPosition = 0;
            var depth = 0;
            var aim = 0;

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                var inputProps = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var keyWord = inputProps[0];
                var number = int.Parse(inputProps[1]);

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

        public static void Task01()
        {
            var horizontalPosition = 0;
            var depth = 0;

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                var inputProps = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var keyWord = inputProps[0];
                var number = int.Parse(inputProps[1]);

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
    }
}
