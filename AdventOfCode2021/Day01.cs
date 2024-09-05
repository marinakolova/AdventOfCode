namespace AdventOfCode2021
{
    public static class Day01
    {
        public static void Task01(string input)
        {
            var numbers = input.Split(Environment.NewLine).Select(int.Parse).ToArray();

            var largerCount = 0;
            var previous = numbers[0];

            for (var i = 1; i < numbers.Length; i++)
            {
                var current = numbers[i];

                if (current > previous)
                {
                    largerCount++;
                }

                previous = current;
            }

            Console.WriteLine("Larger Count: " + largerCount);
        }

        public static void Task02(string input)
        {
            var numbers = input.Split(Environment.NewLine).Select(int.Parse).ToList();
            var largerCount = 0;

            var firstWindow = 0;
            var secondWindow = 0;
            var thirdWindow = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i == 0)
                {
                    firstWindow += numbers[i];
                }
                else if (i == 1)
                {
                    firstWindow += numbers[i];
                    secondWindow += numbers[i];
                }
                else if (i == 2)
                {
                    firstWindow += numbers[i];
                    secondWindow += numbers[i];
                    thirdWindow += numbers[i];
                }
                else
                {
                    secondWindow += numbers[i];

                    if (secondWindow > firstWindow)
                    {
                        largerCount++;
                    }

                    firstWindow = secondWindow;
                    secondWindow = thirdWindow + numbers[i];
                    thirdWindow = numbers[i];
                }
            }

            Console.WriteLine("Larger Count: " + largerCount);
        }
    }
}
