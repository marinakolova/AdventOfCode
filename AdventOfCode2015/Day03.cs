namespace AdventOfCode2015
{
    public static class Day03
    {
        public static void Task01(string input)
        {
            var startingPoint = (0, 0);
            var visited = new HashSet<(int, int)> { startingPoint };

            foreach (var direction in input)
            {
                switch (direction)
                {
                    case '>':
                        startingPoint.Item1 += 1;
                        break;
                    case '<':
                        startingPoint.Item1 -= 1;
                        break;
                    case 'v':
                        startingPoint.Item2 += 1;
                        break;
                    case '^':
                        startingPoint.Item2 -= 1;
                        break;
                }
                visited.Add(startingPoint);
            }

            Console.WriteLine(visited.Count);
        }

        public static void Task02(string input)
        {
            var startingPointSanta = (0, 0);
            var startingPointRobot = (0, 0);
            var visited = new HashSet<(int, int)> { startingPointSanta };

            for (int i = 0; i < input.Length; i++)
            {
                if (i % 2 == 0)
                {
                    switch (input[i])
                    {
                        case '>':
                            startingPointSanta.Item1 += 1;
                            break;
                        case '<':
                            startingPointSanta.Item1 -= 1;
                            break;
                        case 'v':
                            startingPointSanta.Item2 += 1;
                            break;
                        case '^':
                            startingPointSanta.Item2 -= 1;
                            break;
                    }
                    visited.Add(startingPointSanta);
                }
                else
                {
                    switch (input[i])
                    {
                        case '>':
                            startingPointRobot.Item1 += 1;
                            break;
                        case '<':
                            startingPointRobot.Item1 -= 1;
                            break;
                        case 'v':
                            startingPointRobot.Item2 += 1;
                            break;
                        case '^':
                            startingPointRobot.Item2 -= 1;
                            break;
                    }
                    visited.Add(startingPointRobot);
                }
            }

            Console.WriteLine(visited.Count);
        }
    }
}
