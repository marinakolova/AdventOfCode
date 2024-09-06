using static System.Formats.Asn1.AsnWriter;

namespace AdventOfCode2022
{
    public static class Day08
    {
        public static void Task01(string input)
        {
            var forest = ReadInput(input.Split(Environment.NewLine).ToList());
            var length = forest[0].Count;

            var visible = new HashSet<(int x, int y)>();

            for (int row = 0; row < length; row++)
            {
                for (int col = 0; col < length; col++)
                {
                    if (row == 0 || col == 0 || row == length - 1 || col == length - 1)
                    {
                        visible.Add((row, col));
                    }
                    else
                    {
                        var current = forest[row][col];

                        var leftTrees = forest[row].Take(col).ToList();
                        var rightTrees = forest[row].TakeLast(length - col - 1).ToList();
                        var upTrees = forest.Take(row).Select(x => x[col]).ToList();
                        var downTrees = forest.TakeLast(length - row - 1).Select(x => x[col]).ToList();

                        if (!leftTrees.Any(x => x >= current)
                            || !rightTrees.Any(x => x >= current)
                            || !upTrees.Any(x => x >= current)
                            || !downTrees.Any(x => x >= current))
                        {
                            visible.Add((row, col));
                        }
                    }
                }
            }

            Console.WriteLine(visible.Count);
        }

        public static void Task02(string input)
        {
            var forest = ReadInput(input.Split(Environment.NewLine).ToList());
            var length = forest[0].Count;

            var highestScenicScore = 0;

            for (int row = 0; row < length; row++)
            {
                for (int col = 0; col < length; col++)
                {
                    if (row == 0 || col == 0 || row == length - 1 || col == length - 1)
                    {
                        continue;
                    }

                    var current = forest[row][col];

                    var leftTrees = forest[row].Take(col).ToList();
                    var rightTrees = forest[row].TakeLast(length - col - 1).ToList();
                    var upTrees = forest.Take(row).Select(x => x[col]).ToList();
                    var downTrees = forest.TakeLast(length - row - 1).Select(x => x[col]).ToList();

                    var leftScore = 0;
                    var rightScore = 0;
                    var upScore = 0;
                    var downScore = 0;

                    for (int i = leftTrees.Count - 1; i >= 0; i--)
                    {
                        leftScore++;
                        if (leftTrees[i] >= current)
                        {
                            break;
                        }
                    }

                    for (int i = 0; i < rightTrees.Count; i++)
                    {
                        rightScore++;
                        if (rightTrees[i] >= current)
                        {
                            break;
                        }
                    }

                    for (int i = upTrees.Count - 1; i >= 0; i--)
                    {
                        upScore++;
                        if (upTrees[i] >= current)
                        {
                            break;
                        }
                    }

                    for (int i = 0; i < downTrees.Count; i++)
                    {
                        downScore++;
                        if (downTrees[i] >= current)
                        {
                            break;
                        }
                    }

                    var scenicScore = leftScore * rightScore * upScore * downScore;
                    if (scenicScore > highestScenicScore)
                    {
                        highestScenicScore = scenicScore;
                    }
                }
            }

            Console.WriteLine(highestScenicScore);
        }

        private static List<List<int>> ReadInput(List<string> inputLines)
        {
            var forest = new List<List<int>> { new List<int>() };

            var firstRow = inputLines[0].ToCharArray().Select(x => int.Parse(x.ToString())).ToList();
            forest[0].AddRange(firstRow);

            for (int i = 1; i < firstRow.Count; i++)
            {
                var row = inputLines[i].ToCharArray().Select(x => int.Parse(x.ToString())).ToList();
                forest.Add(new List<int>());
                forest[i].AddRange(row);
            }

            return forest;
        }
    }
}
