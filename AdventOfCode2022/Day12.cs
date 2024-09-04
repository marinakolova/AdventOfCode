namespace AdventOfCode2022
{
    public static class Day12
    {
        // used when reading the input from the Console in ReadInput()
        // example input is 5 lines, should change the value here for testing with the example
        private static int inputLinesCount = 41;

        private static char[,] matrix;
        private static Dictionary<(int, int), Dictionary<(int, int), char>> graph;
        private static (int x, int y) start;
        private static (int x, int y) end;

        // for the second task
        private static List<(int x, int y)> possibleStartingPoints = new List<(int x, int y)>();        

        public static void Task01()
        {
            ReadInput();
            CreateGraph();
            
            var result = Dijkstra();
            
            Console.WriteLine(result);
        }

        public static void Task02()
        {
            ReadInput();
            CreateGraph();

            var result = int.MaxValue;
            foreach (var possibleStart in possibleStartingPoints)
            {
                start = possibleStart;
                
                var newResult = Dijkstra();
                
                if (newResult < result)
                {
                    result = newResult;
                }
            }
            Console.WriteLine(result);
        }

        private static int Dijkstra()
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

                    var newDistance = 1 + distances[minNode];
                    if (newDistance < distances[childNode])
                    {
                        distances[childNode] = newDistance;
                    }
                }
            }

            return distances[end];
        }

        private static void CreateGraph()
        {
            graph = new Dictionary<(int, int), Dictionary<(int, int), char>>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var node = (row, col);
                    var nodeValue = (int)matrix[row, col];

                    // get start and end points
                    if (matrix[row, col] == 'S')
                    {
                        start = (row, col);
                        nodeValue = (int)'a';
                        possibleStartingPoints.Add((row, col)); // for the second task
                    }
                    else if (matrix[row, col] == 'E')
                    {
                        end = (row, col);
                        nodeValue = (int)'z';
                    }
                    else if (matrix[row, col] == 'a')
                    {
                        possibleStartingPoints.Add((row, col)); // for the second task
                    }

                    if (!graph.ContainsKey(node))
                    {
                        graph.Add(node, new Dictionary<(int, int), char>());
                    }

                    // up
                    if (row > 0)
                    {
                        var value = (int)matrix[row - 1, col];
                        if (matrix[row - 1, col] == 'S')
                        {
                            value = (int)'a';
                        }
                        else if (matrix[row - 1, col] == 'E')
                        {
                            value = (int)'z';
                        }

                        if (value - 1 <= nodeValue)
                        {
                            graph[node].Add((row - 1, col), matrix[row - 1, col]);
                        }
                    }

                    // down
                    if (row < matrix.GetLength(0) - 1)
                    {
                        var value = (int)matrix[row + 1, col];
                        if (matrix[row + 1, col] == 'S')
                        {
                            value = (int)'a';
                        }
                        else if (matrix[row + 1, col] == 'E')
                        {
                            value = (int)'z';
                        }

                        if (value - 1 <= nodeValue)
                        {
                            graph[node].Add((row + 1, col), matrix[row + 1, col]);
                        }
                    }

                    // left
                    if (col > 0)
                    {
                        var value = (int)matrix[row, col - 1];
                        if (matrix[row, col - 1] == 'S')
                        {
                            value = (int)'a';
                        }
                        else if (matrix[row, col - 1] == 'E')
                        {
                            value = (int)'z';
                        }

                        if (value - 1 <= nodeValue)
                        {
                            graph[node].Add((row, col - 1), matrix[row, col - 1]);
                        }
                    }

                    // right
                    if (col < matrix.GetLength(1) - 1)
                    {
                        var value = (int)matrix[row, col + 1];
                        if (matrix[row, col + 1] == 'S')
                        {
                            value = (int)'a';
                        }
                        else if (matrix[row, col + 1] == 'E')
                        {
                            value = (int)'z';
                        }

                        if (value - 1 <= nodeValue)
                        {
                            graph[node].Add((row, col + 1), matrix[row, col + 1]);
                        }
                    }
                }
            }
        }

        private static void ReadInput()
        {
            var input = Console.ReadLine().ToString();

            matrix = new char[inputLinesCount, input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                matrix[0, i] = input[i];
            }
            for (int row = 1; row < inputLinesCount; row++)
            {
                input = Console.ReadLine().ToString();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}
