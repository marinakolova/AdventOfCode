using System.Collections.Immutable;

namespace AdventOfCode2021
{
    public static class Day12
    {
        private static Dictionary<string, List<string>> graph;

        public static void Task01(string input)
        {
            graph = ReadInput(input.Split(Environment.NewLine).ToList());

            var result = FindPathsCount("start", ImmutableHashSet.Create<string>("start"), false, false);
            Console.WriteLine("Paths: " + result);
        }

        public static void Task02(string input)
        {
            graph = ReadInput(input.Split(Environment.NewLine).ToList());

            var result = FindPathsCount("start", ImmutableHashSet.Create<string>("start"), false, true);
            Console.WriteLine("Paths: " + result);
        }

        private static int FindPathsCount(string current, ImmutableHashSet<string> visited, bool isSmallVisitedTwice, bool canVisitSmallTwice)
        {
            if (current == "end")
            {
                return 1;
            }

            var pathsCount = 0;

            foreach (var edge in graph[current])
            {
                var isBig = edge.ToUpper() == edge;
                var seen = visited.Contains(edge);

                if (!seen || isBig)
                {
                    pathsCount += FindPathsCount(edge, visited.Add(edge), isSmallVisitedTwice, canVisitSmallTwice);
                }
                else if (canVisitSmallTwice && !isBig && edge != "start" && !isSmallVisitedTwice)
                {
                    pathsCount += FindPathsCount(edge, visited, true, canVisitSmallTwice);
                }
            }

            return pathsCount;
        }

        private static Dictionary<string, List<string>> ReadInput(List<string> inputLines)
        {
            var graph = new Dictionary<string, List<string>>();

            foreach (var inputLine in inputLines)
            {
                var inputParts = inputLine.Split("-");
                var firstEdge = inputParts[0];
                var secondEdge = inputParts[1];

                if (!graph.ContainsKey(firstEdge))
                {
                    graph[firstEdge] = new List<string>();
                }
                if (!graph.ContainsKey(secondEdge))
                {
                    graph[secondEdge] = new List<string>();
                }

                graph[firstEdge].Add(secondEdge);
                graph[secondEdge].Add(firstEdge);
            }

            return graph;
        }
    }
}
