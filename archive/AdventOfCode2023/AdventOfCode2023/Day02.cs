namespace AdventOfCode2023
{
    public static class Day02
    {
        public static void Task01()
        {
            var loadedCubes = new Dictionary<string, int>
            {
                { "red", 12 },
                { "green", 13 },
                { "blue", 14 },
            };
            var sumOfPossibleGamesIds = 0;

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "END")
                {
                    break;
                }

                var gameAndSubsets = line.Split(": ");
                var game = gameAndSubsets[0].Split();
                var gameId = int.Parse(game[1]);

                var subsets = gameAndSubsets[1].Split("; ");
                bool allPossible = true;
                foreach (var subset in subsets)
                {
                    var cubes = subset.Split(", ");
                    foreach (var cube in cubes)
                    {
                        var countAndColor = cube.Split();
                        var count = int.Parse(countAndColor[0]);
                        var color = countAndColor[1];
                        if (loadedCubes[color] < count)
                        {
                            allPossible = false;
                        }
                    }
                }
                if (allPossible)
                {
                    sumOfPossibleGamesIds += gameId;
                }
            }

            Console.WriteLine(sumOfPossibleGamesIds);
        }

        public static void Task02()
        {
            var powersSum = 0;

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "END")
                {
                    break;
                }

                var gameAndSubsets = line.Split(": ");
                var subsets = gameAndSubsets[1].Split("; ");

                var minPossible = new Dictionary<string, int>
                {
                    { "red", 0 },
                    { "green", 0 },
                    { "blue", 0 },
                };

                foreach (var subset in subsets)
                {
                    var cubes = subset.Split(", ");
                    foreach (var cube in cubes)
                    {
                        var countAndColor = cube.Split();
                        var count = int.Parse(countAndColor[0]);
                        var color = countAndColor[1];
                        if (minPossible[color] < count)
                        {
                            minPossible[color] = count;
                        }
                    }
                }

                var power = minPossible["red"] * minPossible["green"] * minPossible["blue"];
                powersSum += power;
            }

            Console.WriteLine(powersSum);
        }
    }
}
