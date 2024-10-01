namespace AdventOfCode2015
{
    public class Path
    {
        public string From { get; set; }

        public string To { get; set; }

        public int Distance { get; set; }
    }

    public static class Day09
    {
        public static void Task01(string input)
        {
            var locations = new HashSet<string>();
            var paths = new List<Path>();
            ReadInput(input, ref locations, ref paths);

            paths = paths.OrderBy(p => p.Distance).ToList();

            var minPathLength = int.MaxValue;

            foreach (var path in paths)
            {
                var currentPath = path;
                var visited = new HashSet<string>();
                var distance = 0;

                while (distance < minPathLength && visited.Count < locations.Count && currentPath != null)
                {
                    visited.Add(currentPath.From);
                    distance += currentPath.Distance;
                    visited.Add(currentPath.To);

                    currentPath = paths.FirstOrDefault(p => p.From == currentPath.To && !visited.Contains(p.To));
                }

                if (distance < minPathLength && visited.Count == locations.Count)
                {
                    minPathLength = distance;
                }
            }

            Console.WriteLine(minPathLength);
        }

        public static void Task02(string input)
        {
            var locations = new HashSet<string>();
            var paths = new List<Path>();
            ReadInput(input, ref locations, ref paths);

            paths = paths.ToList();

            var maxPathLength = int.MinValue;

            foreach (var path in paths)
            {
                var currentPath = path;
                var visited = new HashSet<string>();
                var distance = 0;

                while (visited.Count < locations.Count && currentPath != null)
                {
                    visited.Add(currentPath.From);
                    distance += currentPath.Distance;
                    visited.Add(currentPath.To);

                    currentPath = paths.FirstOrDefault(p => p.From == currentPath.To && !visited.Contains(p.To));
                }

                if (distance > maxPathLength && visited.Count == locations.Count)
                {
                    maxPathLength = distance;
                }
            }

            Console.WriteLine(maxPathLength);
        }

        private static void ReadInput(string input, ref HashSet<string> locations, ref List<Path> paths)
        {
            foreach (var line in input.Split(Environment.NewLine).ToArray())
            {
                var lineParts = line.Split(" = ").ToArray();
                var locationsParts = lineParts[0].Split(" to ").ToArray();
                var locationOne = locationsParts[0];
                var locationTwo = locationsParts[1];
                var distance = int.Parse(lineParts[1]);

                locations.Add(locationOne);
                locations.Add(locationTwo);

                paths.Add(new Path
                {
                    From = locationOne,
                    To = locationTwo,
                    Distance = distance,
                });
                paths.Add(new Path
                {
                    From = locationTwo,
                    To = locationOne,
                    Distance = distance,
                });
            }
        }
    }
}
