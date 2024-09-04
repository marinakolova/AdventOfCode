namespace AdventOfCode2022.Solutions
{
    public static class Day04
    {
        public static void Task01()
        {
            var fullOverlapsCount = 0;

            while (true)
            {
                var pair = Console.ReadLine().ToString();

                if (pair == "end")
                {
                    break;
                }

                var assignments = pair.Split(",");
                var firstAssign = assignments[0].Split("-").Select(int.Parse).ToArray();
                var secondAssign = assignments[1].Split("-").Select(int.Parse).ToArray();

                if ((firstAssign[0] >= secondAssign[0] && firstAssign[1] <= secondAssign[1])
                    || (secondAssign[0] >= firstAssign[0] && secondAssign[1] <= firstAssign[1]))
                {
                    fullOverlapsCount++;
                }
            }

            Console.WriteLine(fullOverlapsCount);
        }

        public static void Task02()
        {
            var overlapsCount = 0;

            while (true)
            {
                var pair = Console.ReadLine().ToString();

                if (pair == "end")
                {
                    break;
                }

                var assignments = pair.Split(",");
                var firstAssign = assignments[0].Split("-").Select(int.Parse).ToArray();
                var secondAssign = assignments[1].Split("-").Select(int.Parse).ToArray();

                if ((firstAssign[0] >= secondAssign[0] && firstAssign[1] <= secondAssign[1])
                    || (secondAssign[0] >= firstAssign[0] && secondAssign[1] <= firstAssign[1])
                    || (firstAssign[0] <= secondAssign[0] && firstAssign[1] >= secondAssign[0])
                    || (secondAssign[0] <= firstAssign[0] && secondAssign[1] >= firstAssign[0]))
                {
                    overlapsCount++;
                }
            }

            Console.WriteLine(overlapsCount);
        }
    }
}
