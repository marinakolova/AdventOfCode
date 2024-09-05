namespace AdventOfCode2021
{
    public static class Day09
    {
        private static List<HashSet<ValueTuple<int, int>>> basins = new List<HashSet<ValueTuple<int, int>>>();

        public static void Task01(string input)
        {
            var inputLines = input.Split(Environment.NewLine).ToList();

            var matrix = new List<int[]>();

            foreach (var inputLine in inputLines)
            {
                matrix.Add(new int[inputLine.Length]);
                for (int i = 0; i < inputLine.Length; i++)
                {
                    matrix[matrix.Count - 1][i] = int.Parse(inputLine[i].ToString());
                }
            }

            var riskLevel = 0;

            for (int row = 0; row < matrix.Count; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    var element = matrix[row][col];

                    var up = row != 0 ? matrix[row - 1][col] : int.MaxValue;
                    var down = row != matrix.Count - 1 ? matrix[row + 1][col] : int.MaxValue;
                    var left = col != 0 ? matrix[row][col - 1] : int.MaxValue;
                    var right = col != matrix[0].Length - 1 ? matrix[row][col + 1] : int.MaxValue;

                    if (element < up && element < down && element < left && element < right)
                    {
                        riskLevel += (element + 1);
                    }
                }
            }

            Console.WriteLine("Risk Level: " + riskLevel);
        }

        public static void Task02(string input)
        {
            var inputLines = input.Split(Environment.NewLine).ToList();

            var matrix = new List<int[]>();

            foreach (var inputLine in inputLines)
            {
                matrix.Add(new int[inputLine.Length]);
                for (int i = 0; i < inputLine.Length; i++)
                {
                    matrix[matrix.Count - 1][i] = int.Parse(inputLine[i].ToString());
                }
            }

            for (int row = 0; row < matrix.Count; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    var element = matrix[row][col];

                    var up = row != 0 ? matrix[row - 1][col] : int.MaxValue;
                    var down = row != matrix.Count - 1 ? matrix[row + 1][col] : int.MaxValue;
                    var left = col != 0 ? matrix[row][col - 1] : int.MaxValue;
                    var right = col != matrix[0].Length - 1 ? matrix[row][col + 1] : int.MaxValue;

                    if (element < up && element < down && element < left && element < right)
                    {
                        basins.Add(new HashSet<(int, int)>());
                        var currentBasin = basins.Count - 1;

                        var currentRow = row;
                        var currentCol = col;

                        //check up
                        while (currentRow >= 0)
                        {
                            if (matrix[currentRow][currentCol] == 9)
                            {
                                break;
                            }
                            else
                            {
                                basins[currentBasin].Add((currentRow, currentCol));
                                CheckBasin(matrix, currentBasin, currentRow, currentCol);
                            }
                            currentRow -= 1;
                        }
                        currentRow = row;

                        //check down
                        while (currentRow < matrix.Count)
                        {
                            if (matrix[currentRow][currentCol] == 9)
                            {
                                break;
                            }
                            else
                            {
                                basins[currentBasin].Add((currentRow, currentCol));
                                CheckBasin(matrix, currentBasin, currentRow, currentCol);
                            }
                            currentRow += 1;
                        }
                        currentRow = row;

                        //check left
                        while (currentCol >= 0)
                        {
                            if (matrix[currentRow][currentCol] == 9)
                            {
                                break;
                            }
                            else
                            {
                                basins[currentBasin].Add((currentRow, currentCol));
                                CheckBasin(matrix, currentBasin, currentRow, currentCol);
                            }
                            currentCol -= 1;
                        }
                        currentCol = col;

                        //check right
                        while (currentCol < matrix[0].Length)
                        {
                            if (matrix[currentRow][currentCol] == 9)
                            {
                                break;
                            }
                            else
                            {
                                basins[currentBasin].Add((currentRow, currentCol));
                                CheckBasin(matrix, currentBasin, currentRow, currentCol);
                            }
                            currentCol += 1;
                        }
                    }
                }
            }

            var sortedBasins = basins.OrderByDescending(x => x.Count).ToList();
            var result = sortedBasins[0].Count * sortedBasins[1].Count * sortedBasins[2].Count;
            Console.WriteLine("Result: " + result);
        }

        private static void CheckBasin(List<int[]> matrix, int currentBasin, int row, int col)
        {
            var currentRow = row;
            var currentCol = col;

            //check up
            while (currentRow >= 0)
            {
                if (matrix[currentRow][currentCol] == 9)
                {
                    break;
                }
                else
                {
                    basins[currentBasin].Add((currentRow, currentCol));
                    CheckBasinAgain(matrix, currentBasin, currentRow, currentCol);
                }
                currentRow -= 1;
            }
            currentRow = row;

            //check down
            while (currentRow < matrix.Count)
            {
                if (matrix[currentRow][currentCol] == 9)
                {
                    break;
                }
                else
                {
                    basins[currentBasin].Add((currentRow, currentCol));
                    CheckBasinAgain(matrix, currentBasin, currentRow, currentCol);
                }
                currentRow += 1;
            }
            currentRow = row;

            //check left
            while (currentCol >= 0)
            {
                if (matrix[currentRow][currentCol] == 9)
                {
                    break;
                }
                else
                {
                    basins[currentBasin].Add((currentRow, currentCol));
                    CheckBasinAgain(matrix, currentBasin, currentRow, currentCol);
                }
                currentCol -= 1;
            }
            currentCol = col;

            //check right
            while (currentCol < matrix[0].Length)
            {
                if (matrix[currentRow][currentCol] == 9)
                {
                    break;
                }
                else
                {
                    basins[currentBasin].Add((currentRow, currentCol));
                    CheckBasinAgain(matrix, currentBasin, currentRow, currentCol);
                }
                currentCol += 1;
            }

            return;
        }

        private static void CheckBasinAgain(List<int[]> matrix, int currentBasin, int row, int col)
        {
            var currentRow = row;
            var currentCol = col;

            //check up
            while (currentRow >= 0)
            {
                if (matrix[currentRow][currentCol] == 9)
                {
                    break;
                }
                else
                {
                    basins[currentBasin].Add((currentRow, currentCol));
                }
                currentRow -= 1;
            }
            currentRow = row;

            //check down
            while (currentRow < matrix.Count)
            {
                if (matrix[currentRow][currentCol] == 9)
                {
                    break;
                }
                else
                {
                    basins[currentBasin].Add((currentRow, currentCol));
                }
                currentRow += 1;
            }
            currentRow = row;

            //check left
            while (currentCol >= 0)
            {
                if (matrix[currentRow][currentCol] == 9)
                {
                    break;
                }
                else
                {
                    basins[currentBasin].Add((currentRow, currentCol));
                }
                currentCol -= 1;
            }
            currentCol = col;

            //check right
            while (currentCol < matrix[0].Length)
            {
                if (matrix[currentRow][currentCol] == 9)
                {
                    break;
                }
                else
                {
                    basins[currentBasin].Add((currentRow, currentCol));
                }
                currentCol += 1;
            }

            return;
        }
    }
}
