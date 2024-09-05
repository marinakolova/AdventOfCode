namespace AdventOfCode2021
{
    public static class Day07
    {
        public static void Task01(string input)
        {
            var inputArr = input
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var minPosition = inputArr.Min();
            var maxPosition = inputArr.Max();
            var minFuel = int.MaxValue;

            for (int position = minPosition; position <= maxPosition; position++)
            {
                var fuel = 0;

                for (int i = 0; i < inputArr.Length; i++)
                {
                    fuel += Math.Abs(inputArr[i] - position);
                }

                if (fuel < minFuel)
                {
                    minFuel = fuel;
                }
            }

            Console.WriteLine("Min Fuel: " + minFuel);
        }

        public static void Task02(string input)
        {
            var inputArr = input
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var minPosition = inputArr.Min();
            var maxPosition = inputArr.Max();
            var minFuel = int.MaxValue;

            for (int position = minPosition; position <= maxPosition; position++)
            {
                var fuel = 0;

                for (int i = 0; i < inputArr.Length; i++)
                {
                    var distance = Math.Abs(inputArr[i] - position);
                    fuel += (1 + distance) * distance / 2;
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
