using System.Numerics;

namespace AdventOfCode2023
{
    public static class Day06
    {
        public static void Task01(string input)
        {
            var inputLines = input.Split(Environment.NewLine).ToList();
            var times = inputLines[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var distances = inputLines[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var result = 1;

            for (int i = 1; i < times.Length; i++)
            {
                var raceTime = int.Parse(times[i]);
                var raceDistanceRecord = int.Parse(distances[i]);

                var winningWays = 0;

                for (int holdTime = 1; holdTime < raceTime; holdTime++)
                {
                    var speed = holdTime;
                    var time = raceTime - holdTime;
                    var distance = speed * time;

                    if (distance > raceDistanceRecord)
                    {
                        winningWays++;
                    }
                }

                result *= winningWays;
            }

            Console.WriteLine(result);
        }

        public static void Task02(string input)
        {
            var inputLines = input.Split(Environment.NewLine).ToList();
            var times = inputLines[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var distances = inputLines[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var raceTime = BigInteger.Parse(string.Join("", times.Skip(1)));
            var raceDistanceRecord = BigInteger.Parse(string.Join("", distances.Skip(1)));

            BigInteger minHoldTimeToWin = 1;
            BigInteger maxHoldTimeToWin = raceTime - 1;

            for (BigInteger holdTime = 1; holdTime < raceTime; holdTime++)
            {
                var speed = holdTime;
                var time = raceTime - holdTime;
                var distance = speed * time;

                if (distance > raceDistanceRecord)
                {
                    minHoldTimeToWin = holdTime;
                    break;
                }
            }

            for (BigInteger holdTime = raceTime - 1; holdTime > 0; holdTime--)
            {
                var speed = holdTime;
                var time = raceTime - holdTime;
                var distance = speed * time;

                if (distance > raceDistanceRecord)
                {
                    maxHoldTimeToWin = holdTime;
                    break;
                }
            }

            var winningWays = maxHoldTimeToWin - minHoldTimeToWin + 1;

            Console.WriteLine(winningWays);
        }
    }
}
