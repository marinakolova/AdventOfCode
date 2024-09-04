namespace AdventOfCode2021
{
    public static class Day07
    {
        public static void Task02()
        {
            var input = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var minPosition = input.Min();
            var maxPosition = input.Max();
            var minFuel = int.MaxValue;

            for (int position = minPosition; position <= maxPosition; position++)
            {
                var fuel = 0;

                for (int i = 0; i < input.Length; i++)
                {
                    var distance = Math.Abs(input[i] - position);
                    fuel += (1 + distance) * distance / 2;
                }

                if (fuel < minFuel)
                {
                    minFuel = fuel;
                }
            }

            Console.WriteLine("Min Fuel: " + minFuel);
        }

        public static void Task01()
        {
            var input = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var minPosition = input.Min();
            var maxPosition = input.Max();
            var minFuel = int.MaxValue;

            for (int position = minPosition; position <= maxPosition; position++)
            {
                var fuel = 0;

                for (int i = 0; i < input.Length; i++)
                {
                    fuel += Math.Abs(input[i] - position);
                }

                if (fuel < minFuel)
                {
                    minFuel = fuel;
                }
            }

            Console.WriteLine("Min Fuel: " + minFuel);
        }
    }
}
