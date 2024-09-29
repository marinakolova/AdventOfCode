namespace AdventOfCode2015
{
    public static class Day06
    {
        public static void Task01(string input)
        {
            // split input rows
            var instructions = input.Split(Environment.NewLine).ToArray();

            // make the grid
            var grid = new List<List<bool>>();
            for (int row = 0; row < 1000; row++)
            {
                grid.Add(new List<bool>());

                for (int col = 0; col < 1000; col++)
                {
                    grid[row].Add(false);
                }
            }

            // read instructions
            foreach (var instruction in instructions)
            {
                if (instruction.StartsWith("turn on"))
                {
                    var instructionParts = instruction.Split(" ").ToList();
                    var startCoordinates = instructionParts[2].Split(",");
                    var endCoordinates = instructionParts[4].Split(",");

                    var rowStart = int.Parse(startCoordinates[0]);
                    var rowEnd = int.Parse(endCoordinates[0]);
                    var colStart = int.Parse(startCoordinates[1]);
                    var colEnd = int.Parse(endCoordinates[1]);

                    for (int row = rowStart; row <= rowEnd; row++)
                    {
                        for (int col = colStart; col <= colEnd; col++)
                        {
                            grid[row][col] = true;
                        }
                    }
                }
                else if (instruction.StartsWith("turn off"))
                {
                    var instructionParts = instruction.Split(" ").ToList();
                    var startCoordinates = instructionParts[2].Split(",");
                    var endCoordinates = instructionParts[4].Split(",");

                    var rowStart = int.Parse(startCoordinates[0]);
                    var rowEnd = int.Parse(endCoordinates[0]);
                    var colStart = int.Parse(startCoordinates[1]);
                    var colEnd = int.Parse(endCoordinates[1]);

                    for (int row = rowStart; row <= rowEnd; row++)
                    {
                        for (int col = colStart; col <= colEnd; col++)
                        {
                            grid[row][col] = false;
                        }
                    }
                }
                else if (instruction.StartsWith("toggle"))
                {
                    var instructionParts = instruction.Split(" ").ToList();
                    var startCoordinates = instructionParts[1].Split(",");
                    var endCoordinates = instructionParts[3].Split(",");

                    var rowStart = int.Parse(startCoordinates[0]);
                    var rowEnd = int.Parse(endCoordinates[0]);
                    var colStart = int.Parse(startCoordinates[1]);
                    var colEnd = int.Parse(endCoordinates[1]);

                    for (int row = rowStart; row <= rowEnd; row++)
                    {
                        for (int col = colStart; col <= colEnd; col++)
                        {
                            grid[row][col] = !grid[row][col];
                        }
                    }
                }
            }

            // count turned on lights
            int turnedOn = 0;
            for (int row = 0; row < grid.Count; row++)
            {
                turnedOn += grid[row].Where(x => x == true).ToList().Count;
            }

            Console.WriteLine(turnedOn);
        }

        public static void Task02(string input)
        {
            // split input rows
            var instructions = input.Split(Environment.NewLine).ToArray();

            // make the grid
            var grid = new List<List<int>>();
            for (int row = 0; row < 1000; row++)
            {
                grid.Add(new List<int>());

                for (int col = 0; col < 1000; col++)
                {
                    grid[row].Add(0);
                }
            }

            // read instructions
            foreach (var instruction in instructions)
            {
                if (instruction.StartsWith("turn on"))
                {
                    var instructionParts = instruction.Split(" ").ToList();
                    var startCoordinates = instructionParts[2].Split(",");
                    var endCoordinates = instructionParts[4].Split(",");

                    var rowStart = int.Parse(startCoordinates[0]);
                    var rowEnd = int.Parse(endCoordinates[0]);
                    var colStart = int.Parse(startCoordinates[1]);
                    var colEnd = int.Parse(endCoordinates[1]);

                    for (int row = rowStart; row <= rowEnd; row++)
                    {
                        for (int col = colStart; col <= colEnd; col++)
                        {
                            grid[row][col] += 1;
                        }
                    }
                }
                else if (instruction.StartsWith("turn off"))
                {
                    var instructionParts = instruction.Split(" ").ToList();
                    var startCoordinates = instructionParts[2].Split(",");
                    var endCoordinates = instructionParts[4].Split(",");

                    var rowStart = int.Parse(startCoordinates[0]);
                    var rowEnd = int.Parse(endCoordinates[0]);
                    var colStart = int.Parse(startCoordinates[1]);
                    var colEnd = int.Parse(endCoordinates[1]);

                    for (int row = rowStart; row <= rowEnd; row++)
                    {
                        for (int col = colStart; col <= colEnd; col++)
                        {
                            grid[row][col] -= 1;
                            if (grid[row][col] < 0)
                            {
                                grid[row][col] = 0;
                            }
                        }
                    }
                }
                else if (instruction.StartsWith("toggle"))
                {
                    var instructionParts = instruction.Split(" ").ToList();
                    var startCoordinates = instructionParts[1].Split(",");
                    var endCoordinates = instructionParts[3].Split(",");

                    var rowStart = int.Parse(startCoordinates[0]);
                    var rowEnd = int.Parse(endCoordinates[0]);
                    var colStart = int.Parse(startCoordinates[1]);
                    var colEnd = int.Parse(endCoordinates[1]);

                    for (int row = rowStart; row <= rowEnd; row++)
                    {
                        for (int col = colStart; col <= colEnd; col++)
                        {
                            grid[row][col] += 2;
                        }
                    }
                }
            }

            // count total brightness
            int totalBrightness = 0;
            for (int row = 0; row < grid.Count; row++)
            {
                totalBrightness += grid[row].Sum();
            }

            Console.WriteLine(totalBrightness);
        }
    }
}
