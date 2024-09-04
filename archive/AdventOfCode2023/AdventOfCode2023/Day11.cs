using System.Numerics;

namespace AdventOfCode2023
{
    public static class Day11
    {
        private static char[,] matrix;
        private static bool[] rowsContainGalaxies;
        private static bool[] colsContainGalaxies;
        private static List<(int, int)> galaxies = new List<(int, int)>();
        private static Dictionary<(int, int), Dictionary<(int, int), int>> graph;
        private static BigInteger shortestPathsSum;

        public static void Task01()
        {
            ReadInput();
            CreateGraph();

            // any rows or columns that contain no galaxies should all actually be twice as big
            // => for each empty row/column add 1 more empty row/column
            var expansion = 1;

            for (int i = 0; i < galaxies.Count - 1; i++)
            {
                for (int j = i + 1; j < galaxies.Count; j++)
                {
                    shortestPathsSum += Dijkstra(galaxies[i], galaxies[j], expansion);
                }
            }

            Console.WriteLine($"shortestPathsSum: {shortestPathsSum}");
        }

        public static void Task02()
        {
            ReadInput();
            CreateGraph();

            // make each empty row or column one million times larger
            // => replace each empty row/column witn 1000000 empty rows/columns
            var expansion = 1000000 - 1;

            for (int i = 0; i < galaxies.Count - 1; i++)
            {
                for (int j = i + 1; j < galaxies.Count; j++)
                {
                    shortestPathsSum += Dijkstra(galaxies[i], galaxies[j], expansion);
                }
            }

            Console.WriteLine($"shortestPathsSum: {shortestPathsSum}");
        }

        private static void ReadInput()
        {
            var input = Console.ReadLine();

            matrix = new char[input.Length, input.Length];
            rowsContainGalaxies = new bool[input.Length];
            colsContainGalaxies = new bool[input.Length];

            // first row
            for (int i = 0; i < input.Length; i++)
            {
                matrix[0, i] = input[i];
                if (input[i] == '#')
                {
                    rowsContainGalaxies[0] = true;
                    colsContainGalaxies[i] = true;
                    galaxies.Add((0, i));
                }
            }
            // next rows
            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == '#')
                    {
                        rowsContainGalaxies[row] = true;
                        colsContainGalaxies[col] = true;
                        galaxies.Add((row, col));
                    }
                }
            }
        }

        private static void CreateGraph()
        {
            graph = new Dictionary<(int, int), Dictionary<(int, int), int>>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var node = (row, col);

                    if (!graph.ContainsKey(node))
                    {
                        graph.Add(node, new Dictionary<(int, int), int>());
                    }

                    // down
                    if (row < matrix.GetLength(0) - 1)
                    {
                        graph[node].Add((row + 1, col), matrix[row + 1, col]);
                    }

                    // right
                    if (col < matrix.GetLength(1) - 1)
                    {
                        graph[node].Add((row, col + 1), matrix[row, col + 1]);
                    }

                    // up
                    if (row > 0)
                    {
                        graph[node].Add((row - 1, col), matrix[row - 1, col]);
                    }

                    // left
                    if (col > 0)
                    {
                        graph[node].Add((row, col - 1), matrix[row, col - 1]);
                    }
                }
            }
        }

        private static int Dijkstra((int, int) start, (int, int) end, int expansion)
        {
            var distances = new Dictionary<(int, int), int>();
            foreach (var node in graph.Keys)
            {
                distances[node] = int.MaxValue;
            }
            distances[start] = 0;

            var queue = new Queue<(int, int)>();

            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var minNode = queue.Dequeue();
                var children = graph[minNode];

                if (minNode == end)
                {
                    break;
                }

                foreach (var child in children)
                {
                    var childNode = child.Key;

                    if (distances[childNode] == int.MaxValue)
                    {
                        queue.Enqueue(childNode);
                    }

                    var expansionDistance = 0;
                    if (rowsContainGalaxies[child.Key.Item1] == false)
                    {
                        expansionDistance += expansion;
                    }
                    if (colsContainGalaxies[child.Key.Item2] == false)
                    {
                        expansionDistance += expansion;
                    }

                    var newDistance = 1 + expansionDistance + distances[minNode];
                    if (newDistance < distances[childNode])
                    {
                        distances[childNode] = newDistance;
                    }
                }
            }

            return distances[end];
        }
    }
}
