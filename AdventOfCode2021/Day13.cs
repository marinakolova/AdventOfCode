namespace AdventOfCode2021
{
    public static class Day13
    {
        private static List<List<int>> paper = new List<List<int>>();

        public static void Task01(string input)
        {
            var inputLines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();
            ReadPaperInput(inputLines);

            FoldPaper(inputLines.First(x => x.StartsWith("fold")));

            CountDots();
        }

        public static void Task02(string input)
        {
            var inputLines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();
            ReadPaperInput(inputLines);

            var foldingInstructions = inputLines.Where(x => x.StartsWith("fold")).ToList();
            foreach (var foldingInstruction in foldingInstructions)
            {
                FoldPaper(foldingInstruction);
            }

            // what is printed on the console looks like 8 capital letters -> the answear
            for (int row = 0; row < paper.Count; row++)
            {
                for (int col = 0; col < paper[0].Count; col++)
                {
                    if (paper[row][col] > 0)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        private static void CountDots()
        {
            var dots = 0;

            for (int row = 0; row < paper.Count; row++)
            {
                for (int col = 0; col < paper[0].Count; col++)
                {
                    if (paper[row][col] > 0)
                    {
                        dots++;
                    }
                }
            }

            Console.WriteLine("Dots: " + dots);
        }

        private static void FoldPaper(string input)
        {
            var inputParts = input.Split(" ")[2].Split("=");
            var direction = inputParts[0] == "y" ? "row" : "col";
            var index = int.Parse(inputParts[1]);

            if (direction == "row")
            {
                for (int row = index - 1; row >= 0; row--)
                {
                    if (index + 1 < paper.Count)
                    {
                        for (int col = 0; col < paper[0].Count; col++)
                        {
                            paper[row][col] += paper[index + 1][col];
                        }
                        paper.RemoveAt(index + 1);
                    }
                }

                var remainingDown = paper.Count - (index + 1);
                if (remainingDown > 0)
                {
                    for (int i = 0; i < remainingDown; i++)
                    {
                        paper.Insert(0 + i, paper[^1]);
                        paper.RemoveAt(paper.Count - 1);
                    }
                }
                paper.RemoveAt(paper.Count - 1);
            }

            if (direction == "col")
            {
                for (int col = index - 1; col >= 0; col--)
                {
                    for (int row = 0; row < paper.Count; row++)
                    {
                        if (index + 1 < paper[row].Count)
                        {
                            paper[row][col] += paper[row][index + 1];
                            paper[row].RemoveAt(index + 1);
                        }
                    }
                }

                var remainingRight = paper[0].Count - (index + 1);
                if (remainingRight > 0)
                {
                    for (int i = 0; i < remainingRight; i++)
                    {
                        for (int row = 0; row < paper.Count; row++)
                        {
                            paper[row].Insert(0 + i, paper[row][^1]);
                            paper[row].RemoveAt(paper[row].Count - 1);
                        }
                    }
                }
                for (int row = 0; row < paper.Count; row++)
                {
                    paper[row].RemoveAt(paper[row].Count - 1);
                }
            }
        }

        private static void ReadPaperInput(List<string> inputLines)
        {
            foreach (var inputLine in inputLines)
            {
                if (inputLine.StartsWith("fold"))
                {
                    break;
                }
                
                var coordinates = inputLine.Split(",");
                var x = int.Parse(coordinates[0]); // col
                var y = int.Parse(coordinates[1]); // row

                for (int row = paper.Count; row <= y; row++)
                {
                    paper.Add(new List<int>());
                }
                for (int row = 0; row < paper.Count; row++)
                {
                    for (int col = paper[row].Count; col <= x; col++)
                    {
                        paper[row].Add(0);
                    }
                }

                paper[y][x]++;
            }
        }
    }
}
