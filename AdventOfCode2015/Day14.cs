namespace AdventOfCode2015
{
    public static class Day14
    {
        public static void Task01(string input)
        {
            var reindeers = ReadInput(input);
            var results = new List<int>();

            foreach (var reindeer in reindeers)
            {
                var totalTime = 2503;
                var distance = 0;

                var speed = reindeer[0];
                var timeFlying = reindeer[1];
                var timeResting = reindeer[2];

                while (totalTime > 0)
                {
                    if (totalTime >= timeFlying)
                    {
                        distance += timeFlying * speed;
                        totalTime -= timeFlying;
                    }
                    else
                    {
                        distance += totalTime * speed;
                        totalTime -= totalTime;
                    }

                    totalTime -= timeResting;
                }

                results.Add(distance);
            }

            Console.WriteLine(results.Max());
        }

        public static void Task02(string input)
        {
            var reindeers = ReadInput(input);
            var resultsBySecond = new List<List<int>>(2503);
            var points = new List<int>(reindeers.Count);

            for (int second = 0; second < 2503; second++)
            {
                resultsBySecond.Add(new List<int>(reindeers.Count));

                for (int reindeerIndex = 0; reindeerIndex < reindeers.Count; reindeerIndex++)
                {
                    var totalTime = second + 1;
                    var distance = 0;

                    var reindeer = reindeers[reindeerIndex];
                    var speed = reindeer[0];
                    var timeFlying = reindeer[1];
                    var timeResting = reindeer[2];

                    while (totalTime > 0)
                    {
                        if (totalTime >= timeFlying)
                        {
                            distance += timeFlying * speed;
                            totalTime -= timeFlying;
                        }
                        else
                        {
                            distance += totalTime * speed;
                            totalTime -= totalTime;
                        }

                        totalTime -= timeResting;
                    }

                    resultsBySecond[second].Add(distance);
                }
            }

            for (int i = 0; i < reindeers.Count; i++)
            {
                points.Add(0);
            }
            for (int second = 0; second < 2503; second ++)
            {
                var maxResult = resultsBySecond[second].Max();

                for (int i = 0; i < resultsBySecond[second].Count; i++)
                {
                    if (resultsBySecond[second][i] == maxResult)
                    {
                        points[i] += 1;
                    }
                }
            }

            Console.WriteLine(points.Max());
        }

        private static List<int[]> ReadInput(string input)
        {
            var reindeers = new List<int[]>();

            foreach (var line in input.Split(Environment.NewLine).ToArray())
            {
                var linePart = line.Split(' ').ToArray();

                var speed = int.Parse(linePart[3]);
                var timeFlying = int.Parse(linePart[6]);
                var timeResting = int.Parse(linePart[13]);

                reindeers.Add(new int[] { speed, timeFlying, timeResting });
            }

            return reindeers;
        }
    }
}
