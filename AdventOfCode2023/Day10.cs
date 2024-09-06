namespace AdventOfCode2023
{
    class Tile
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public char Pipe { get; set; }
    }

    public static class Day10
    {
        private static List<string> field = new List<string>();

        private static int startingRow = 0;
        private static int startingCol = 0;

        private static int rows = 0;
        private static int cols = 0;

        private static Dictionary<char, string> validUpPipes = new Dictionary<char, string>();
        private static Dictionary<char, string> validDownPipes = new Dictionary<char, string>();
        private static Dictionary<char, string> validLeftPipes = new Dictionary<char, string>();
        private static Dictionary<char, string> validRightPipes = new Dictionary<char, string>();

        private static int nextRow = 0;
        private static int nextCol = 0;
        private static string wentInDirection;

        private static int loopDistance = 0; // for Task01
        private static List<Tile> loopTiles = new List<Tile>(); // for Task02

        public static void Task01(string input)
        {
            ReadInput(input);
            PrepareDirectionsRules();
            FindLoop();

            Console.WriteLine(loopDistance / 2);
        }

        public static void Task02(string input)
        {
            ReadInput(input);
            PrepareDirectionsRules();
            FindLoop();

            var tilesEnclosedByTheLoop = 0;

            for (int row = 0; row < rows; row++)
            {
                var isInside = false;

                for (int col = 0; col < cols; col++)
                {
                    if (loopTiles.Any(t => t.Row == row && t.Col == col && (t.Pipe == '7' || t.Pipe == 'F' || t.Pipe == '|')))
                    {
                        // crossing a border
                        isInside = !isInside;
                    }

                    if (isInside && !loopTiles.Any(t => t.Row == row && t.Col == col))
                    {
                        tilesEnclosedByTheLoop++;
                    }
                }
            }

            Console.WriteLine(tilesEnclosedByTheLoop);
        }

        private static void ReadInput(string input)
        {
            var inputLines = input.Split(Environment.NewLine).ToList();

            foreach (var line in inputLines)
            {
                field.Add(line);

                if (line.Contains('S'))
                {
                    startingRow = field.Count - 1;
                    startingCol = line.IndexOf('S');
                }
            }

            rows = field.Count;
            cols = field[0].Length;
        }

        private static void PrepareDirectionsRules()
        {
            // | is a vertical pipe connecting north and south.
            // - is a horizontal pipe connecting east and west.
            // L is a 90 - degree bend connecting north and east.
            // J is a 90 - degree bend connecting north and west.
            // 7 is a 90 - degree bend connecting south and west.
            // F is a 90 - degree bend connecting south and east.
            // . is ground; there is no pipe in this tile.
            // S is the starting position of the animal; there is a pipe on this tile, but your sketch doesn't show what shape the pipe has.

            validUpPipes.Add('|', "up");
            validUpPipes.Add('7', "left");
            validUpPipes.Add('F', "right");

            validDownPipes.Add('|', "down");
            validDownPipes.Add('L', "right");
            validDownPipes.Add('J', "left");

            validLeftPipes.Add('-', "left");
            validLeftPipes.Add('L', "up");
            validLeftPipes.Add('F', "down");

            validRightPipes.Add('-', "right");
            validRightPipes.Add('J', "up");
            validRightPipes.Add('7', "down");
        }

        private static void FindLoop()
        {
            // start up
            if (startingRow > 0 && validUpPipes.ContainsKey(field[startingRow - 1][startingCol]))
            {
                nextRow = startingRow - 1;
                nextCol = startingCol;

                wentInDirection = "up";
                loopDistance += 1;
            }
            // start down
            else if (startingRow < rows - 1 && validDownPipes.ContainsKey(field[startingRow + 1][startingCol]))
            {
                nextRow = startingRow + 1;
                nextCol = startingCol;

                wentInDirection = "down";
                loopDistance += 1;
            }
            // start left
            else if (startingCol > 0 && validLeftPipes.ContainsKey(field[startingRow][startingCol - 1]))
            {
                nextRow = startingRow;
                nextCol = startingCol - 1;

                wentInDirection = "left";
                loopDistance += 1;
            }
            // start right
            else if (startingCol < cols - 1 && validRightPipes.ContainsKey(field[startingRow][startingCol + 1]))
            {
                nextRow = startingRow;
                nextCol = startingCol + 1;

                wentInDirection = "right";
                loopDistance += 1;
            }

            // for Task02
            loopTiles.Add(new Tile
            {
                Row = nextRow,
                Col = nextCol,
                Pipe = field[nextRow][nextCol],
            });

            Loop();
        }

        private static void Loop()
        {
            while (nextRow != startingRow || nextCol != startingCol)
            {
                if (wentInDirection == "up")
                {
                    switch (validUpPipes[field[nextRow][nextCol]])
                    {
                        case "up": nextRow = nextRow - 1; wentInDirection = "up"; break;
                        case "down": nextRow = nextRow + 1; wentInDirection = "down"; break;
                        case "left": nextCol = nextCol - 1; wentInDirection = "left"; break;
                        default: nextCol = nextCol + 1; wentInDirection = "right"; break;
                    }
                }
                else if (wentInDirection == "down")
                {
                    switch (validDownPipes[field[nextRow][nextCol]])
                    {
                        case "up": nextRow = nextRow - 1; wentInDirection = "up"; break;
                        case "down": nextRow = nextRow + 1; wentInDirection = "down"; break;
                        case "left": nextCol = nextCol - 1; wentInDirection = "left"; break;
                        default: nextCol = nextCol + 1; wentInDirection = "right"; break; break;
                    }
                }
                else if (wentInDirection == "left")
                {
                    switch (validLeftPipes[field[nextRow][nextCol]])
                    {
                        case "up": nextRow = nextRow - 1; wentInDirection = "up"; break;
                        case "down": nextRow = nextRow + 1; wentInDirection = "down"; break;
                        case "left": nextCol = nextCol - 1; wentInDirection = "left"; break;
                        default: nextCol = nextCol + 1; wentInDirection = "right"; break; break;
                    }
                }
                else if (wentInDirection == "right")
                {
                    switch (validRightPipes[field[nextRow][nextCol]])
                    {
                        case "up": nextRow = nextRow - 1; wentInDirection = "up"; break;
                        case "down": nextRow = nextRow + 1; wentInDirection = "down"; break;
                        case "left": nextCol = nextCol - 1; wentInDirection = "left"; break;
                        default: nextCol = nextCol + 1; wentInDirection = "right"; break;
                    }
                }

                // for Task 01
                loopDistance += 1;

                // for Task02
                loopTiles.Add(new Tile
                {
                    Row = nextRow,
                    Col = nextCol,
                    Pipe = field[nextRow][nextCol],
                });
            }
        }
    }
}
