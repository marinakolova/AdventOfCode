namespace AdventOfCode2021
{
    public static class Day04
    {
        public static void Task02()
        {
            var numbers = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var boards = ReadBoardsInput();

            var winningBoards = new List<int[][]>();
            var lastWinningNumber = -1;

            for (int i = 0; i < numbers.Length; i++)
            {
                var currentNum = numbers[i];

                for (int board = 0; board < boards.Count; board++)
                {
                    for (int row = 0; row < 5; row++)
                    {
                        for (int col = 0; col < 5; col++)
                        {
                            if (boards[board][row][col] == currentNum)
                            {
                                boards[board][row][col] = -1;
                            }
                        }
                    }
                }

                for (int boardIndex = 0; boardIndex < boards.Count; boardIndex++)
                {
                    var wins = CheckIfBoardWins(boards[boardIndex]);
                    if (wins)
                    {
                        lastWinningNumber = currentNum;
                        winningBoards.Add(boards[boardIndex]);
                        boards.RemoveAt(boardIndex);
                        boardIndex -= 1;
                    }
                }
            }

            var lastWinningBoard = winningBoards[winningBoards.Count - 1];
            var lastWinningBoardSum = 0;
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if (lastWinningBoard[row][col] != -1)
                    {
                        lastWinningBoardSum += lastWinningBoard[row][col];
                    }
                }
            }

            var result = lastWinningBoardSum * lastWinningNumber;
            Console.WriteLine("Last Winning board sum: " + lastWinningBoardSum);
            Console.WriteLine("Last Winning number: " + lastWinningNumber);
            Console.WriteLine("Result: " + result);
        }

        public static void Task01()
        {
            var numbers = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var boards = ReadBoardsInput();

            var winningBoard = new int[5][];
            var winningNumber = -1;

            for (int i = 0; i < numbers.Length; i++)
            {
                var currentNum = numbers[i];

                for (int board = 0; board < boards.Count; board++)
                {
                    for (int row = 0; row < 5; row++)
                    {
                        for (int col = 0; col < 5; col++)
                        {
                            if (boards[board][row][col] == currentNum)
                            {
                                boards[board][row][col] = -1;

                                for (int boardIndex = 0; boardIndex < boards.Count; boardIndex++)
                                {
                                    var wins = CheckIfBoardWins(boards[boardIndex]);
                                    if (wins)
                                    {
                                        winningBoard = boards[boardIndex];
                                        winningNumber = currentNum;
                                        break;
                                    }
                                }
                                if (winningNumber != -1)
                                {
                                    break;
                                }
                            }
                            if (winningNumber != -1)
                            {
                                break;
                            }
                        }
                        if (winningNumber != -1)
                        {
                            break;
                        }
                    }
                    if (winningNumber != -1)
                    {
                        break;
                    }
                }
                if (winningNumber != -1)
                {
                    break;
                }
            }

            var winningBoardSum = 0;
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if (winningBoard[row][col] != -1)
                    {
                        winningBoardSum += winningBoard[row][col];
                    }
                }
            }

            var result = winningBoardSum * winningNumber;
            Console.WriteLine("Winning board sum: " + winningBoardSum);
            Console.WriteLine("Winning number: " + winningNumber);
            Console.WriteLine("Result: " + result);
        }

        private static bool CheckIfBoardWins(int[][] board)
        {
            var hasWinningRow = false;
            var hasWinningCol = false;

            for (int row = 0; row < 5; row++)
            {
                var isWinningRow = true;
                for (int col = 0; col < 5; col++)
                {
                    if (board[row][col] != -1)
                    {
                        isWinningRow = false;
                    }
                }
                if (isWinningRow)
                {
                    hasWinningRow = true;
                    break;
                }
            }
            if (hasWinningRow)
            {
                return true;
            }

            for (int col = 0; col < 5; col++)
            {
                var isWinningCol = true;
                for (int row = 0; row < 5; row++)
                {
                    if (board[row][col] != -1)
                    {
                        isWinningCol = false;
                    }

                }
                if (isWinningCol)
                {
                    hasWinningCol = true;
                    break;
                }
            }
            if (hasWinningCol)
            {
                return true;
            }

            return false;
        }

        private static List<int[][]> ReadBoardsInput()
        {
            var boards = new List<int[][]>();

            while (true)
            {
                var inputRow = Console.ReadLine();
                if (string.IsNullOrEmpty(inputRow))
                {
                    continue;
                }
                if (inputRow == "end")
                {
                    break;
                }

                boards.Add(new int[5][]);
                var currentBoardIndex = boards.Count - 1;

                var rowNums = inputRow
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var currentRowIndex = 0;
                boards[currentBoardIndex][currentRowIndex] = new int[5];
                for (int col = 0; col < 5; col++)
                {
                    boards[currentBoardIndex][currentRowIndex][col] = rowNums[col];
                }
                for (int i = 1; i < 5; i++)
                {
                    currentRowIndex++;
                    boards[currentBoardIndex][currentRowIndex] = new int[5];
                    inputRow = Console.ReadLine();
                    rowNums = inputRow
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                    for (int col = 0; col < 5; col++)
                    {
                        boards[currentBoardIndex][currentRowIndex][col] = rowNums[col];
                    }
                }
            }

            return boards;
        }
    }
}
