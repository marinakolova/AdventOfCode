namespace AdventOfCode2022
{
    public static class Day04
    {
        public static void Task01(string input)
        {
            var inputLines = input.Split(Environment.NewLine).ToList();

            var fullOverlapsCount = 0;

            foreach (var pair in inputLines)
            {
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

        public static void Task02(string input)
        {
            var inputLines = input.Split(Environment.NewLine).ToList();

            var overlapsCount = 0;

            foreach (var pair in inputLines)
            {
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
