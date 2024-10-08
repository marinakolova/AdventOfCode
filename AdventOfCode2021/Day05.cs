﻿namespace AdventOfCode2021
{
    public static class Day05
    {
        private static int[][] field;

        public static void Task01(string input)
        {
            ReadInput(input, true);
            CountOverlaps();
        }

        public static void Task02(string input)
        {
            ReadInput(input, false);
            CountOverlaps();
        }

        private static void CountOverlaps()
        {
            var overlapsCount = 0;

            for (int row = 0; row < field.Length; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] >= 2)
                    {
                        overlapsCount++;
                    }
                }
            }

            Console.WriteLine("Overlaps Count: " + overlapsCount);
        }

        private static void ReadInput(string input, bool skipDiagonals)
        {
            field = new int[1000][];
            for (int row = 0; row < 1000; row++)
            {
                field[row] = new int[1000];
                for (int col = 0; col < 1000; col++)
                {
                    field[row][col] = 0;
                }
            }

            foreach (var inputLine in input.Split(Environment.NewLine).ToList())
            {
                var coordinates = inputLine.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                var firstEnds = coordinates[0]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                var secondEnds = coordinates[1]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var x1 = firstEnds[0]; // col
                var y1 = firstEnds[1]; // row

                var x2 = secondEnds[0]; // col
                var y2 = secondEnds[1]; // row

                if (skipDiagonals && (x1 != x2 && y1 != y2))
                {
                    continue;
                }

                if (x1 == x2)
                {
                    var col = x1;
                    var rowStart = y1 < y2 ? y1 : y2;
                    var rowEnd = y1 > y2 ? y1 : y2;

                    for (int row = rowStart; row <= rowEnd; row++)
                    {
                        field[row][col] += 1;
                    }
                }
                else if (y1 == y2)
                {
                    var row = y1;
                    var colStart = x1 < x2 ? x1 : x2;
                    var colEnd = x1 > x2 ? x1 : x2;

                    for (int col = colStart; col <= colEnd; col++)
                    {
                        field[row][col] += 1;
                    }
                }
                else
                {
                    var rowStart = y1;
                    var colStart = x1;

                    if (y1 < y2)
                    {
                        for (int row = rowStart; row <= y2; row++)
                        {
                            field[row][colStart] += 1;
                            if (x1 < x2)
                            {
                                colStart++;
                            }
                            else
                            {
                                colStart--;
                            }
                        }
                    }
                    else
                    {
                        for (int row = rowStart; row >= y2; row--)
                        {
                            field[row][colStart] += 1;
                            if (x1 < x2)
                            {
                                colStart++;
                            }
                            else
                            {
                                colStart--;
                            }
                        }
                    }
                }
            }
        }
    }
}
