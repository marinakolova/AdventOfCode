namespace AdventOfCode2023
{
    public static class Day03
    {
        public static void Task01(string input)
        {
            var schema = new List<List<char>>();
            var partNumbersSum = 0;

            var inputLines = input.Split(Environment.NewLine).ToList();

            foreach (var line in inputLines)
            {
                var chars = new List<char>();
                for (int i = 0; i < line.Length; i++)
                {
                    chars.Add(line[i]);
                }
                schema.Add(chars);
            }

            for (int row = 0; row < schema.Count; row++)
            {
                for (int col = 0; col < schema[row].Count; col++)
                {
                    if (char.IsDigit(schema[row][col]))
                    {
                        var digits = new List<char>();
                        digits.Add(schema[row][col]);
                        while (schema[row].Count - 1 >= col + 1 && char.IsDigit(schema[row][col + 1]))
                        {
                            digits.Add(schema[row][col + 1]);
                            col += 1;
                        }

                        var number = int.Parse(string.Join("", digits));
                        var surroundingChars = new List<char>();

                        if (row > 0)
                        {
                            //check up & up left
                            for (int i = 0; i <= digits.Count; i++)
                            {
                                if (col - i >= 0)
                                {
                                    surroundingChars.Add(schema[row - 1][col - i]);
                                }
                            }
                            if (schema[row - 1].Count -1 >= col + 1)
                            {
                                // check up right
                                surroundingChars.Add(schema[row - 1][col + 1]);
                            }
                        }
                        if (col - digits.Count >= 0)
                        {
                            // check left
                            surroundingChars.Add(schema[row][col - digits.Count]);
                        }
                        if (schema[row].Count - 1 >= col +1)
                        {
                            // check right
                            surroundingChars.Add(schema[row][col + 1]);
                        }
                        if (schema.Count - 1 > row)
                        {
                            // check down & down left
                            for (int i = 0; i <= digits.Count; i++)
                            {
                                if (col - i >= 0)
                                {
                                    surroundingChars.Add(schema[row + 1][col - i]);
                                }
                            }
                            if (schema[row + 1].Count - 1 >= col + 1)
                            {
                                // check down right
                                surroundingChars.Add(schema[row + 1][col + 1]);
                            }
                        }

                        if (surroundingChars.Any(x => x != '.' && !char.IsDigit(x)))
                        {
                            partNumbersSum += number;
                        }
                    }
                }
            }

            Console.WriteLine(partNumbersSum);
        }

        public static void Task02(string input)
        {
            var schema = new List<List<char>>();
            var gears = new Dictionary<(int,int), List<int>>();

            var inputLines = input.Split(Environment.NewLine).ToList();

            foreach (var line in inputLines)
            {
                var chars = new List<char>();
                for (int i = 0; i < line.Length; i++)
                {
                    chars.Add(line[i]);
                }
                schema.Add(chars);
            }

            for (int row = 0; row < schema.Count; row++)
            {
                for (int col = 0; col < schema[row].Count; col++)
                {
                    if (char.IsDigit(schema[row][col]))
                    {
                        var digits = new List<char>();
                        digits.Add(schema[row][col]);
                        while (schema[row].Count - 1 >= col + 1 && char.IsDigit(schema[row][col + 1]))
                        {
                            digits.Add(schema[row][col + 1]);
                            col += 1;
                        }

                        var number = int.Parse(string.Join("", digits));

                        if (row > 0)
                        {
                            //check up & up left
                            for (int i = 0; i <= digits.Count; i++)
                            {
                                if (col - i >= 0)
                                {
                                    var checkedRow = row - 1;
                                    var checkedCol = col - i;
                                    var foundChar = schema[row - 1][col - i];

                                    if (foundChar == '*')
                                    {
                                        if (gears.ContainsKey((checkedRow, checkedCol)))
                                        {
                                            gears[(checkedRow, checkedCol)].Add(number);
                                        }
                                        else
                                        {
                                            gears.Add((checkedRow, checkedCol), new List<int> { number });
                                        }
                                    }
                                }
                            }
                            if (schema[row - 1].Count - 1 >= col + 1)
                            {
                                // check up right
                                var checkedRow = row - 1;
                                var checkedCol = col + 1;
                                var foundChar = schema[row - 1][col + 1];

                                if (foundChar == '*')
                                {
                                    if (gears.ContainsKey((checkedRow, checkedCol)))
                                    {
                                        gears[(checkedRow, checkedCol)].Add(number);
                                    }
                                    else
                                    {
                                        gears.Add((checkedRow, checkedCol), new List<int> { number });
                                    }
                                }
                            }
                        }
                        if (col - digits.Count >= 0)
                        {
                            // check left
                            var checkedRow = row;
                            var checkedCol = col - digits.Count;
                            var foundChar = schema[row][col - digits.Count];

                            if (foundChar == '*')
                            {
                                if (gears.ContainsKey((checkedRow, checkedCol)))
                                {
                                    gears[(checkedRow, checkedCol)].Add(number);
                                }
                                else
                                {
                                    gears.Add((checkedRow, checkedCol), new List<int> { number });
                                }
                            }
                        }
                        if (schema[row].Count - 1 >= col + 1)
                        {
                            // check right
                            var checkedRow = row;
                            var checkedCol = col + 1;
                            var foundChar = schema[row][col + 1];

                            if (foundChar == '*')
                            {
                                if (gears.ContainsKey((checkedRow, checkedCol)))
                                {
                                    gears[(checkedRow, checkedCol)].Add(number);
                                }
                                else
                                {
                                    gears.Add((checkedRow, checkedCol), new List<int> { number });
                                }
                            }
                        }
                        if (schema.Count - 1 > row)
                        {
                            // check down & down left
                            for (int i = 0; i <= digits.Count; i++)
                            {
                                if (col - i >= 0)
                                {
                                    var checkedRow = row + 1;
                                    var checkedCol = col - i;
                                    var foundChar = schema[row + 1][col - i];

                                    if (foundChar == '*')
                                    {
                                        if (gears.ContainsKey((checkedRow, checkedCol)))
                                        {
                                            gears[(checkedRow, checkedCol)].Add(number);
                                        }
                                        else
                                        {
                                            gears.Add((checkedRow, checkedCol), new List<int> { number });
                                        }
                                    }
                                }
                            }
                            if (schema[row + 1].Count - 1 >= col + 1)
                            {
                                // check down right
                                var checkedRow = row + 1;
                                var checkedCol = col + 1;
                                var foundChar = schema[row + 1][col + 1];

                                if (foundChar == '*')
                                {
                                    if (gears.ContainsKey((checkedRow, checkedCol)))
                                    {
                                        gears[(checkedRow, checkedCol)].Add(number);
                                    }
                                    else
                                    {
                                        gears.Add((checkedRow, checkedCol), new List<int> { number });
                                    }
                                }
                            }
                        }
                    }
                }
            }

            var gearRatiosSum = 0;
            foreach (var gear in gears)
            {
                if (gear.Value.Count == 2)
                {
                    var gearRatio = gear.Value[0] * gear.Value[1];
                    gearRatiosSum += gearRatio;
                }
            }

            Console.WriteLine(gearRatiosSum);
        }
    }
}
