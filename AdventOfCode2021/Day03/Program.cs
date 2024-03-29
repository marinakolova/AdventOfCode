﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Day03
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Task01();
            Task02();
        }

        private static void Task02()
        {
            var inputLines = new List<string>();

            while (true)
            {
                var inputLine = Console.ReadLine();

                if (inputLine == "end")
                {
                    break;
                }

                inputLines.Add(inputLine);
            }

            var filteredByMostCommonBit = inputLines;
            var position = 0;

            while (filteredByMostCommonBit.Count > 1)
            {
                int[] bits = { 0, 0 };

                for (int i = 0; i < filteredByMostCommonBit.Count; i++)
                {
                    var element = filteredByMostCommonBit[i];

                    switch (element[position])
                    {
                        case '0':
                            bits[0] += 1;
                            break;

                        case '1':
                            bits[1] += 1;
                            break;
                    }
                }

                if (bits[0] > bits[1])
                {
                    filteredByMostCommonBit = filteredByMostCommonBit.Where(x => x[position] == '0').ToList();
                }
                else
                {
                    filteredByMostCommonBit = filteredByMostCommonBit.Where(x => x[position] == '1').ToList();
                }

                position++;
            }

            var oxygenGeneratorRating = filteredByMostCommonBit[0];

            var filteredByLeastCommonBit = inputLines;
            position = 0;

            while (filteredByLeastCommonBit.Count > 1)
            {
                int[] bits = { 0, 0 };

                for (int i = 0; i < filteredByLeastCommonBit.Count; i++)
                {
                    var element = filteredByLeastCommonBit[i];

                    switch (element[position])
                    {
                        case '0':
                            bits[0] += 1;
                            break;

                        case '1':
                            bits[1] += 1;
                            break;
                    }
                }

                if (bits[0] <= bits[1])
                {
                    filteredByLeastCommonBit = filteredByLeastCommonBit.Where(x => x[position] == '0').ToList();
                }
                else
                {
                    filteredByLeastCommonBit = filteredByLeastCommonBit.Where(x => x[position] == '1').ToList();
                }

                position++;
            }

            var carbonScrubberRating = filteredByLeastCommonBit[0];

            var lifeSupportRating = Convert.ToInt32(oxygenGeneratorRating, 2) * Convert.ToInt32(carbonScrubberRating, 2);

            Console.WriteLine("Life support rating: " + lifeSupportRating);
        }

        private static void Task01()
        {
            var bits = new List<List<int>>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                for (int i = 0; i < input.Length; i++)
                {
                    if (bits.Count <= i)
                    {
                        bits.Add(new List<int>());
                        bits[i].Add(0);
                        bits[i].Add(0);
                    }
                    
                    switch (input[i])
                    {
                        case '0': 
                            bits[i][0] += 1;
                            break;

                        case '1':
                            bits[i][1] += 1;
                            break;
                    }
                }
            }

            var gammaRate = "";
            var epsilonRate = "";

            for (int i = 0; i < bits.Count; i++)
            {
                if (bits[i][0] > bits[i][1])
                {
                    gammaRate += "0";
                    epsilonRate += "1";
                }
                else
                {
                    gammaRate += "1";
                    epsilonRate += "0";
                }
            }

            var powerConsumption = Convert.ToInt32(gammaRate, 2) * Convert.ToInt32(epsilonRate, 2);

            Console.WriteLine("Power Consumption: " + powerConsumption);
        }
    }
}
