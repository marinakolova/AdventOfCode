﻿namespace AdventOfCode2021
{
    public static class Day11
    {
        private static int[][] octopuses;
        private static int flashes;

        public static void Task01(string input)
        {
            octopuses = ReadInput(input.Split(Environment.NewLine).ToList());

            for (int step = 1; step <= 100; step++)
            {
                PerformStep();
            }

            Console.WriteLine("Flashes: " + flashes);
        }

        public static void Task02(string input)
        {
            octopuses = ReadInput(input.Split(Environment.NewLine).ToList());
            var step = 0;

            while (true)
            {
                step++;
                PerformStep();

                var allOctopusesFlashed = true;
                for (int row = 0; row < 10; row++)
                {
                    for (int col = 0; col < 10; col++)
                    {
                        if (octopuses[row][col] != 0)
                        {
                            allOctopusesFlashed = false;
                        }
                    }
                }
                if (allOctopusesFlashed)
                {
                    Console.WriteLine("Step: " + step);
                    break;
                }
            }
        }

        private static void PerformStep()
        {
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    //First, the energy level of each octopus increases by 1.
                    octopuses[row][col]++;

                    //Then, any octopus with an energy level greater than 9 flashes.
                    if (octopuses[row][col] == 10)
                    {
                        //This increases the energy level of all adjacent octopuses by 1.
                        IncreaseAdjacent(row, col);
                    }
                }
            }

            //Finally, any octopus that flashed during this step has its energy level set to 0.
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    if (octopuses[row][col] > 9)
                    {
                        flashes++;
                        octopuses[row][col] = 0;
                    }
                }
            }
        }

        private static void IncreaseAdjacent(int currentRow, int currentCol)
        {
            int row;
            int col;

            //up-left
            if (currentRow != 0 && currentCol != 0)
            {
                row = currentRow - 1;
                col = currentCol - 1;
                octopuses[row][col]++;
                if (octopuses[row][col] == 10)
                {
                    IncreaseAdjacent(row, col);
                }
            }

            //up
            if (currentRow != 0)
            {
                row = currentRow - 1;
                col = currentCol;
                octopuses[row][col]++;
                if (octopuses[row][col] == 10)
                {
                    IncreaseAdjacent(row, col);
                }
            }

            //up-right
            if (currentRow != 0 && currentCol != 9)
            {
                row = currentRow - 1;
                col = currentCol + 1;
                octopuses[row][col]++;
                if (octopuses[row][col] == 10)
                {
                    IncreaseAdjacent(row, col);
                }
            }

            //left
            if (currentCol != 0)
            {
                row = currentRow;
                col = currentCol - 1;
                octopuses[row][col]++;
                if (octopuses[row][col] == 10)
                {
                    IncreaseAdjacent(row, col);
                }
            }

            //right
            if (currentCol != 9)
            {
                row = currentRow;
                col = currentCol + 1;
                octopuses[row][col]++;
                if (octopuses[row][col] == 10)
                {
                    IncreaseAdjacent(row, col);
                }
            }

            //down-left
            if (currentRow != 9 && currentCol != 0)
            {
                row = currentRow + 1;
                col = currentCol - 1;
                octopuses[row][col]++;
                if (octopuses[row][col] == 10)
                {
                    IncreaseAdjacent(row, col);
                }
            }

            //down
            if (currentRow != 9)
            {
                row = currentRow + 1;
                col = currentCol;
                octopuses[row][col]++;
                if (octopuses[row][col] == 10)
                {
                    IncreaseAdjacent(row, col);
                }
            }

            //down-right
            if (currentRow != 9 && currentCol != 9)
            {
                row = currentRow + 1;
                col = currentCol + 1;
                octopuses[row][col]++;
                if (octopuses[row][col] == 10)
                {
                    IncreaseAdjacent(row, col);
                }
            }
        }

        private static int[][] ReadInput(List<string> inputLines)
        {
            var grid = new int[10][];

            for (int row = 0; row < 10; row++)
            {
                grid[row] = new int[10];
                var inputLine = inputLines[row];

                for (int col = 0; col < 10; col++)
                {
                    grid[row][col] = int.Parse(inputLine[col].ToString());
                }
            }

            return grid;
        }
    }
}
