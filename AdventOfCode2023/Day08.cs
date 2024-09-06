using System.Numerics;

namespace AdventOfCode2023
{
    class Node
    {
        public string Left { get; set; }

        public string Right { get; set; }
    }

    public static class Day08
    {
        public static void Task01(string input)
        {
            var inputLines = input.Split(Environment.NewLine).ToList();
            var instructions = inputLines[0];

            var map = new Dictionary<string, Node>();

            foreach (var line in inputLines.Skip(2))
            {
                var split = line.Split(" = (");
                var nodeKey = split[0];
                var directions = split[1].Split(", ");
                var left = directions[0];
                var right = directions[1].Substring(0, 3);

                map.Add(
                    nodeKey,
                    new Node
                    {
                        Left = left,
                        Right = right,
                    });
            }

            var position = "AAA";
            var steps = 0;

            while (position != "ZZZ")
            {
                for (int i = 0; i < instructions.Length; i++)
                {
                    if (instructions[i] == 'L')
                    {
                        position = map[position].Left;
                    }
                    else // instructions[i] == 'R'
                    {
                        position = map[position].Right;
                    }

                    steps++;

                    if (position == "ZZZ")
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(steps);
        }

        public static void Task02(string input)
        {
            var inputLines = input.Split(Environment.NewLine).ToList();
            var instructions = inputLines[0];

            var map = new Dictionary<string, Node>();

            foreach (var line in inputLines.Skip(2))
            {
                var split = line.Split(" = (");
                var nodeKey = split[0];
                var directions = split[1].Split(", ");
                var left = directions[0];
                var right = directions[1].Substring(0, 3);

                map.Add(
                    nodeKey,
                    new Node
                    {
                        Left = left,
                        Right = right,
                    });
            }

            var positions = map.Keys.Where(x => x[2] == 'A').ToArray();
            BigInteger[] steps = new BigInteger[positions.Length];

            for (int i = 0; i < positions.Length; i++)
            {
                while (positions[i][2] != 'Z')
                {
                    for (int j = 0; j < instructions.Length; j++)
                    {
                        if (instructions[j] == 'L')
                        {
                            positions[i] = map[positions[i]].Left;
                        }
                        else // instructions[j] == 'R'
                        {
                            positions[i] = map[positions[i]].Right;
                        }

                        steps[i]++;

                        if (positions[i][2] == 'Z')
                        {
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(LowestCommonMultiple(steps, steps.Length));
        }

        private static BigInteger GreatestCommonDivisor(BigInteger a, BigInteger b)
        {
            if (b == 0)
                return a;
            return GreatestCommonDivisor(b, a % b);
        }
        private static BigInteger LowestCommonMultiple(BigInteger[] arr, int n)
        {
            // Initialize result
            var ans = arr[0];

            // ans contains LCM of arr[0], ..arr[i]
            // after i'th iteration,
            for (int i = 1; i < n; i++)
                ans = (((arr[i] * ans)) /
                        (GreatestCommonDivisor(arr[i], ans)));

            return ans;
        }
    }
}
