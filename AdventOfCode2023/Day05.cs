using System;
using System.Numerics;

namespace AdventOfCode2023
{
    class Seed // for Task01
    {
        public BigInteger Number { get; set; }

        public string MapSource { get; set; }
    }

    class Range // for Task02
    {
        public BigInteger StartValue { get; set; }

        public BigInteger EndValue { get; set; }

        public string MapSource { get; set; }
    }

    public static class Day05
    {
        public static void Task01() // reads input from the console with added line "end" at the end
        {
            var seeds = new List<Seed>();

            // read seeds
            var seedsString = Console.ReadLine();
            var seedsNumbers = seedsString.Split(": ")[1].Split().Select(BigInteger.Parse).ToList();
            foreach (var seedNumber in seedsNumbers)
            {
                seeds.Add(new Seed
                {
                    Number = seedNumber,
                    MapSource = "seed",
                });
            }
            Console.ReadLine();

            // read seed-to-soil map
            ReadMapAndUpdateSeedNumbers(ref seeds);

            // read soil-to-fertilizer map
            ReadMapAndUpdateSeedNumbers(ref seeds);

            // read fertilizer-to-water map
            ReadMapAndUpdateSeedNumbers(ref seeds);

            // read water-to-light map
            ReadMapAndUpdateSeedNumbers(ref seeds);

            // read light-to-temperature map
            ReadMapAndUpdateSeedNumbers(ref seeds);

            // read temperature-to-humidity map
            ReadMapAndUpdateSeedNumbers(ref seeds);

            // read humidity-to-location map
            ReadMapAndUpdateSeedNumbers(ref seeds);

            var minLocation = seeds.Select(s => s.Number).ToList().Min();
            Console.WriteLine(minLocation);
        }

        private static void ReadMapAndUpdateSeedNumbers(ref List<Seed> seeds) // for Task01
        {
            var map = Console.ReadLine();
            var mapName = map.Split()[0].Split("-");
            var mapSource = mapName[0];
            var mapDestination = mapName[2];

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "end" || string.IsNullOrEmpty(line) || string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                var mapLine = line.Split().Select(BigInteger.Parse).ToList();
                var destinationRangeStart = mapLine[0];
                var sourceRangeStart = mapLine[1];
                var rangeLength = mapLine[2];

                var seedsToBeUpdated = seeds.Where(s =>
                        s.MapSource != mapDestination &&
                        s.Number >= sourceRangeStart &&
                        s.Number < sourceRangeStart + rangeLength)
                    .ToList();

                foreach (var seedToBeUpdated in seedsToBeUpdated)
                {
                    var i = seedToBeUpdated.Number - sourceRangeStart;
                    var destinationValue = destinationRangeStart + i;

                    var index = seeds.IndexOf(seedToBeUpdated);

                    seeds[index].Number = destinationValue;
                    seeds[index].MapSource = mapDestination;
                }
            }
        }

        public static void Task02() // reads input from the console with added line "end" at the end
        {
            var ranges = new List<Range>();

            // read seeds
            var seedsString = Console.ReadLine();
            var seedsNumbers = seedsString.Split(": ")[1].Split().Select(BigInteger.Parse).ToList();
            for (int i = 0; i < seedsNumbers.Count; i += 2)
            {
                var rangeStart = seedsNumbers[i];
                var rangeLength = seedsNumbers[i + 1];
                var rangeEnd = rangeStart + rangeLength - 1;

                ranges.Add(new Range
                {
                    StartValue = rangeStart,
                    EndValue = rangeEnd,
                    MapSource = "seed",
                });
            }
            Console.ReadLine();

            // read seed-to-soil map
            ReadMapAndUpdateRanges(ref ranges);

            // read soil-to-fertilizer map
            ReadMapAndUpdateRanges(ref ranges);

            // read fertilizer-to-water map
            ReadMapAndUpdateRanges(ref ranges);

            // read water-to-light map
            ReadMapAndUpdateRanges(ref ranges);

            // read light-to-temperature map
            ReadMapAndUpdateRanges(ref ranges);

            // read temperature-to-humidity map
            ReadMapAndUpdateRanges(ref ranges);

            // read humidity-to-location map
            ReadMapAndUpdateRanges(ref ranges);

            var minLocation = ranges.Select(r => r.StartValue).ToList().Min();
            Console.WriteLine(minLocation);
        }

        private static void ReadMapAndUpdateRanges(ref List<Range> ranges) // for Task02
        {
            var map = Console.ReadLine();
            var mapName = map.Split()[0].Split("-");
            var mapSource = mapName[0];
            var mapDestination = mapName[2];

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "end" || string.IsNullOrEmpty(line) || string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                var mapLine = line.Split().Select(BigInteger.Parse).ToList();
                var destinationRangeStartValue = mapLine[0];
                var sourceRangeStartValue = mapLine[1];

                var mapRangeLength = mapLine[2];

                var destinationRangeEndValue = destinationRangeStartValue + mapRangeLength - 1;
                var sourceRangeEndValue = sourceRangeStartValue + mapRangeLength - 1;

                for (int i = 0; i < ranges.Count; i++)
                {
                    var current = ranges[i];

                    if (current.MapSource != mapDestination)
                    {
                        // start in map range and end in map range
                        if (current.StartValue >= sourceRangeStartValue && current.EndValue <= sourceRangeEndValue)
                        {
                            var startIndexInMapRange = current.StartValue - sourceRangeStartValue;
                            var updatedStartValue = destinationRangeStartValue + startIndexInMapRange;

                            var endIndexInMapRange = current.EndValue - sourceRangeStartValue;
                            var updatedEndValue = destinationRangeStartValue + endIndexInMapRange;

                            // update current
                            ranges[i].StartValue = updatedStartValue;
                            ranges[i].EndValue = updatedEndValue;
                            ranges[i].MapSource = mapDestination;
                        }
                        // start in map range and end outside of map range
                        else if (current.StartValue >= sourceRangeStartValue && current.StartValue <= sourceRangeEndValue
                            && current.EndValue > sourceRangeEndValue)
                        {
                            var startIndexInMapRange = current.StartValue - sourceRangeStartValue;
                            var updatedStartValue = destinationRangeStartValue + startIndexInMapRange;

                            var currentEndInMap = current.StartValue + (sourceRangeEndValue - current.StartValue);
                            var endIndexInMapRange = currentEndInMap - sourceRangeStartValue;
                            var updatedEndValue = destinationRangeStartValue + endIndexInMapRange;

                            // split the part remaining after the map range
                            ranges.Add(new Range
                            {
                                StartValue = currentEndInMap + 1,
                                EndValue = current.EndValue,
                                MapSource = current.MapSource,
                            });

                            // update current
                            ranges[i].StartValue = updatedStartValue;
                            ranges[i].EndValue = updatedEndValue;
                            ranges[i].MapSource = mapDestination;
                        }
                        // start outside of map range and end in map range
                        else if (current.StartValue < sourceRangeStartValue
                            && current.EndValue >= sourceRangeStartValue && current.EndValue <= sourceRangeEndValue)
                        {
                            var currentStartInMap = sourceRangeStartValue;
                            var startIndexInMapRange = currentStartInMap - sourceRangeStartValue;
                            var updatedStartValue = destinationRangeStartValue + startIndexInMapRange;

                            var endIndexInMapRange = current.EndValue - sourceRangeStartValue;
                            var updatedEndValue = destinationRangeStartValue + endIndexInMapRange;

                            // split the part remaining before the map range
                            ranges.Add(new Range
                            {
                                StartValue = current.StartValue,
                                EndValue = currentStartInMap - 1,
                                MapSource = current.MapSource,
                            });

                            // update current
                            ranges[i].StartValue = updatedStartValue;
                            ranges[i].EndValue = updatedEndValue;
                            ranges[i].MapSource = mapDestination;
                        }
                    }
                }
            }
        }
    }
}
