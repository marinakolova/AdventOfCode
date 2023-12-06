using System;
using System.Numerics;

namespace AdventOfCode2023
{
    class Seed // for Task01
    {
        public BigInteger Id { get; set; }

        public BigInteger Soil { get; set; }

        public BigInteger Fertilizer { get; set; }

        public BigInteger Water { get; set; }

        public BigInteger Light { get; set; }

        public BigInteger Temperature { get; set; }

        public BigInteger Humidity { get; set; }

        public BigInteger Location { get; set; }
    }

    class Range // for Task02
    {
        public BigInteger StartValue { get; set; }

        public BigInteger EndValue { get; set; }

        public string MapSource { get; set; }
    }

    public static class Day05
    {
        public static void Task01()
        {
            var seeds = new List<Seed>();

            // read seeds
            var seedsString = Console.ReadLine();
            var seedsNumbers = seedsString.Split(": ")[1].Split().Select(BigInteger.Parse).ToList();
            foreach (var seedNumber in seedsNumbers)
            {
                seeds.Add(new Seed
                {
                    Id = seedNumber,
                    Soil = seedNumber,
                    Fertilizer = seedNumber,
                    Water = seedNumber,
                    Light = seedNumber,
                    Temperature = seedNumber,
                    Humidity = seedNumber,
                    Location = seedNumber,
                });
            }
            Console.ReadLine();

            // read seed-to-soil map
            Console.ReadLine();
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
                        s.Id >= sourceRangeStart &&
                        s.Id < sourceRangeStart + rangeLength)
                    .ToList();

                foreach (var seedToBeUpdated in seedsToBeUpdated)
                {
                    var i = seedToBeUpdated.Id - sourceRangeStart;
                    var destinationValue = destinationRangeStart + i;

                    var index = seeds.IndexOf(seedToBeUpdated);

                    //Seed, soil, fertilizer, water, light, temperature, humidity, location
                    seeds[index].Soil = destinationValue;
                    seeds[index].Fertilizer = destinationValue;
                    seeds[index].Water = destinationValue;
                    seeds[index].Light = destinationValue;
                    seeds[index].Temperature = destinationValue;
                    seeds[index].Humidity = destinationValue;
                    seeds[index].Location = destinationValue;
                }
            }

            // read soil-to-fertilizer map
            Console.ReadLine();
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
                        s.Soil >= sourceRangeStart &&
                        s.Soil < sourceRangeStart + rangeLength)
                    .ToList();

                foreach (var seedToBeUpdated in seedsToBeUpdated)
                {
                    var i = seedToBeUpdated.Soil - sourceRangeStart;
                    var destinationValue = destinationRangeStart + i;

                    var index = seeds.IndexOf(seedToBeUpdated);

                    //Seed, soil, fertilizer, water, light, temperature, humidity, location
                    seeds[index].Fertilizer = destinationValue;
                    seeds[index].Water = destinationValue;
                    seeds[index].Light = destinationValue;
                    seeds[index].Temperature = destinationValue;
                    seeds[index].Humidity = destinationValue;
                    seeds[index].Location = destinationValue;
                }
            }

            // read fertilizer-to-water map
            Console.ReadLine();
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
                        s.Fertilizer >= sourceRangeStart &&
                        s.Fertilizer < sourceRangeStart + rangeLength)
                    .ToList();

                foreach (var seedToBeUpdated in seedsToBeUpdated)
                {
                    var i = seedToBeUpdated.Fertilizer - sourceRangeStart;
                    var destinationValue = destinationRangeStart + i;

                    var index = seeds.IndexOf(seedToBeUpdated);

                    //Seed, soil, fertilizer, water, light, temperature, humidity, location
                    seeds[index].Water = destinationValue;
                    seeds[index].Light = destinationValue;
                    seeds[index].Temperature = destinationValue;
                    seeds[index].Humidity = destinationValue;
                    seeds[index].Location = destinationValue;
                }
            }

            // read water-to-light map
            Console.ReadLine();
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
                        s.Water >= sourceRangeStart &&
                        s.Water < sourceRangeStart + rangeLength)
                    .ToList();

                foreach (var seedToBeUpdated in seedsToBeUpdated)
                {
                    var i = seedToBeUpdated.Water - sourceRangeStart;
                    var destinationValue = destinationRangeStart + i;

                    var index = seeds.IndexOf(seedToBeUpdated);

                    //Seed, soil, fertilizer, water, light, temperature, humidity, location
                    seeds[index].Light = destinationValue;
                    seeds[index].Temperature = destinationValue;
                    seeds[index].Humidity = destinationValue;
                    seeds[index].Location = destinationValue;
                }
            }

            // read light-to-temperature map
            Console.ReadLine();
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
                        s.Light >= sourceRangeStart &&
                        s.Light < sourceRangeStart + rangeLength)
                    .ToList();

                foreach (var seedToBeUpdated in seedsToBeUpdated)
                {
                    var i = seedToBeUpdated.Light - sourceRangeStart;
                    var destinationValue = destinationRangeStart + i;

                    var index = seeds.IndexOf(seedToBeUpdated);

                    //Seed, soil, fertilizer, water, light, temperature, humidity, location
                    seeds[index].Temperature = destinationValue;
                    seeds[index].Humidity = destinationValue;
                    seeds[index].Location = destinationValue;
                }
            }

            // read temperature-to-humidity map
            Console.ReadLine();
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
                        s.Temperature >= sourceRangeStart &&
                        s.Temperature < sourceRangeStart + rangeLength)
                    .ToList();

                foreach (var seedToBeUpdated in seedsToBeUpdated)
                {
                    var i = seedToBeUpdated.Temperature - sourceRangeStart;
                    var destinationValue = destinationRangeStart + i;

                    var index = seeds.IndexOf(seedToBeUpdated);

                    //Seed, soil, fertilizer, water, light, temperature, humidity, location
                    seeds[index].Humidity = destinationValue;
                    seeds[index].Location = destinationValue;
                }
            }

            // read humidity-to-location map
            Console.ReadLine();
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
                        s.Humidity >= sourceRangeStart &&
                        s.Humidity < sourceRangeStart + rangeLength)
                    .ToList();

                foreach (var seedToBeUpdated in seedsToBeUpdated)
                {
                    var i = seedToBeUpdated.Humidity - sourceRangeStart;
                    var destinationValue = destinationRangeStart + i;

                    var index = seeds.IndexOf(seedToBeUpdated);

                    //Seed, soil, fertilizer, water, light, temperature, humidity, location
                    seeds[index].Location = destinationValue;
                }
            }

            var minLocation = seeds.Select(s => s.Location).ToList().Min();
            Console.WriteLine(minLocation);
        }

        public static void Task02()
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

        private static void ReadMapAndUpdateRanges(ref List<Range> ranges)
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
