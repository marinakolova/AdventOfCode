namespace AdventOfCode2015
{
    public static class Day18
    {
        public static void Task01(string input)
        {
            var matrix = ReadInput(input);
            Apply100Steps(ref matrix, false);
            var result = GetNumOfLightsOn(matrix);
            Console.WriteLine(result);
        }

        public static void Task02(string input)
        {
            var matrix = ReadInput(input);
            Apply100Steps(ref matrix, true);
            var result = GetNumOfLightsOn(matrix);
            Console.WriteLine(result);
        }

        private static char[][] ReadInput(string input)
        {
            var inputLines = input.Split(Environment.NewLine).ToArray();

            var matrix = new char[inputLines.Length][];

            for ( int i = 0; i < inputLines.Length; i++)
            {
                matrix[i] = new char[inputLines[i].Length];

                for (int j = 0; j < inputLines[i].Length; j++)
                {
                    matrix[i][j] = inputLines[i][j];
                }
            }

            return matrix;
        }

        private static void Apply100Steps(ref char[][] matrix, bool cornersAlwaysOn)
        {
            if (cornersAlwaysOn)
            {
                matrix[0][0] = '#';
                matrix[0][matrix[0].Length - 1] = '#';
                matrix[matrix.Length - 1][0] = '#';
                matrix[matrix.Length - 1][matrix[matrix.Length - 1].Length - 1] = '#';
            }

            for (int i = 0; i < 100; i++)
            {
                var newMatrix = new char[matrix.Length][];

                for (int row = 0; row < matrix.Length; row++)
                {
                    newMatrix[row] = new char[matrix[row].Length];

                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        var current = matrix[row][col];
                        var numOfNeighboursOn = GetNumOfNeighboursOn(row, col, matrix);

                        //A light which is on stays on when 2 or 3 neighbors are on, and turns off otherwise.
                        if (current == '#')
                        {
                            if (numOfNeighboursOn == 2 || numOfNeighboursOn == 3)
                            {
                                newMatrix[row][col] = '#';
                            }
                            else
                            {
                                newMatrix[row][col] = '.';
                            }
                        }

                        //A light which is off turns on if exactly 3 neighbors are on, and stays off otherwise.
                        if (current == '.')
                        {
                            if (numOfNeighboursOn == 3)
                            {
                                newMatrix[row][col] = '#';
                            }
                            else
                            {
                                newMatrix[row][col] = '.';
                            }
                        }
                    }
                }

                matrix = newMatrix;

                if (cornersAlwaysOn)
                {
                    matrix[0][0] = '#';
                    matrix[0][matrix[0].Length - 1] = '#';
                    matrix[matrix.Length - 1][0] = '#';
                    matrix[matrix.Length - 1][matrix[matrix.Length - 1].Length - 1] = '#';
                }
            }
        }

        private static int GetNumOfNeighboursOn(int row, int col, char[][] matrix)
        {
            var numOfNeighboursOn = 0;

            if (row > 0)
            {
                // up left
                if (col > 0 && matrix[row - 1][col - 1] == '#')
                {
                    numOfNeighboursOn++;
                }

                // up
                if (matrix[row - 1][col] == '#')
                {
                    numOfNeighboursOn++;
                }

                // up right
                if (col < matrix[row].Length - 1 && matrix[row - 1][col + 1] == '#')
                {
                    numOfNeighboursOn++;
                }
            }

            // right
            if (true)
            {
                if (col < matrix[row].Length - 1 && matrix[row][col + 1] == '#')
                {
                    numOfNeighboursOn++;
                }
            }

            if (row < matrix.Length - 1)
            {
                // down left
                if (col > 0 && matrix[row + 1][col - 1] == '#')
                {
                    numOfNeighboursOn++;
                }

                // down
                if (matrix[row + 1][col] == '#')
                {
                    numOfNeighboursOn++;
                }

                // down right
                if (col < matrix[row].Length - 1 && matrix[row + 1][col + 1] == '#')
                {
                    numOfNeighboursOn++;
                }
            }

            // left
            if (col > 0 && matrix[row][col - 1] == '#')
            {
                numOfNeighboursOn++;
            }

            return numOfNeighboursOn;
        }

        private static int GetNumOfLightsOn(char[][] matrix)
        {
            int numOfLightsOn = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == '#')
                    {
                        numOfLightsOn++;
                    }
                }
            }

            return numOfLightsOn;
        }
    }
}
