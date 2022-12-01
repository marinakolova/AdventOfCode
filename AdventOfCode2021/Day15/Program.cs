using System;
using System.Collections.Generic;
using System.Linq;

namespace Day15
{
    public class Program
    {
        private static int[,] matrix;
        private static Dictionary<(int, int), Dictionary<(int, int), int>> graph;

        public static void Main(string[] args)
        {
            //Task01();
            Task02();
        }

        private static void Task02()
        {
            ReadInputEnlarged();
            CreateGraph();
            Dijkstra();
        }

        private static void Task01()
        {
            ReadInput();
            CreateGraph();
            Dijkstra();
        }

        private static void Dijkstra()
        {
            var start = (0, 0);
            var end = (matrix.GetLength(0) - 1, matrix.GetLength(1) - 1);

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

                    var newDistance = child.Value + distances[minNode];
                    if (newDistance < distances[childNode])
                    {
                        distances[childNode] = newDistance;
                    }
                }
            }

            if (distances[end] == int.MaxValue)
            {
                Console.WriteLine("There is no such path.");
            }
            else
            {
                Console.WriteLine(distances[end]);
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
                }
            }
        }

        private static void ReadInput()
        {
            var input = Console.ReadLine();

            matrix = new int[input.Length, input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                matrix[0, i] = int.Parse(input[i].ToString());
            }
            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = int.Parse(input[col].ToString());
                }
            }
        }

        private static void ReadInputEnlarged()
        {
            var input = Console.ReadLine();
            var initialLength = input.Length;

            matrix = new int[initialLength * 5, initialLength * 5];
            for (int row = 0; row < initialLength; row++)
            {
                if (row != 0)
                {
                    input = Console.ReadLine();
                }
                for (int col = 0; col < initialLength; col++)
                {
                    var element = int.Parse(input[col].ToString());
                    matrix[row, col] = element;

                    for (int i = 1; i < 5; i++)
                    {
                        element = element < 9 ? element + 1 : 1;
                        matrix[row + (initialLength * i), col] = element;
                        matrix[row, col + (initialLength * i)] = element;                        
                    }
                }                
            }
            for (int expand = 1; expand < 5; expand++)
            {
                for (int row = 0 + (initialLength * expand); row < initialLength + (initialLength * expand); row++)
                {                    
                    for (int col = 0 + (initialLength * expand); col < initialLength + (initialLength * expand); col++)
                    {
                        var element = matrix[row, col - initialLength];
                        element = element < 9 ? element + 1 : 1;
                        matrix[row, col] = element;

                        for (int i = 1; i < 5 - expand; i++)
                        {
                            element = element < 9 ? element + 1 : 1;
                            matrix[row + (initialLength * i), col] = element;
                            matrix[row, col + (initialLength * i)] = element;
                        }
                    }
                }
            }

            //for (int row = 0; row < matrix.GetLength(0); row++)
            //{
            //    for (int col = 0; col < matrix.GetLength(1); col++)
            //    {
            //        Console.Write(matrix[row,col]);
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}
