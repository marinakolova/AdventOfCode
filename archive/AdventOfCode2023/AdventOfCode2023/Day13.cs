using System.Numerics;

namespace AdventOfCode2023
{
    public static class Day13
    {
        public static void Task01()
        {
            BigInteger sum = 0;
            
            while (true)
            {
                var line = Console.ReadLine();

                var patternRows = new List<string>();
                var patternCols = new List<char>[line.Length];
                for (int i = 0; i < line.Length; i++)
                {
                    patternCols[i] = new List<char>();
                }

                while (true)
                {
                    if (string.IsNullOrEmpty(line) || string.IsNullOrWhiteSpace(line) || line == "end")
                    {
                        break;
                    }

                    patternRows.Add(line);

                    for (int i = 0; i < line.Length; i++)
                    {
                        patternCols[i].Add(line[i]);
                    }

                    line = Console.ReadLine();
                }

                var reflectionRows = FindReflectionRows(patternRows);
                var reflectionCols = FindReflectionCols(patternCols);
                
                foreach (var item in reflectionCols)
                {
                    sum += item;
                }
                foreach (var item in reflectionRows)
                {
                    sum += item * 100;
                }

                if (line == "end")
                {
                    break;
                }
            }

            Console.WriteLine(sum);
        }

        public static void Task02()
        {
            BigInteger sum = 0;

            while (true)
            {
                var line = Console.ReadLine();

                var patternRows = new List<string>();
                var patternCols = new List<char>[line.Length];
                for (int i = 0; i < line.Length; i++)
                {
                    patternCols[i] = new List<char>();
                }

                while (true)
                {
                    if (string.IsNullOrEmpty(line) || string.IsNullOrWhiteSpace(line) || line == "end")
                    {
                        break;
                    }

                    patternRows.Add(line);

                    for (int i = 0; i < line.Length; i++)
                    {
                        patternCols[i].Add(line[i]);
                    }

                    line = Console.ReadLine();
                }

                var reflectionRows = FindReflectionRows(patternRows);
                var reflectionCols = FindReflectionCols(patternCols);

                var newNewReflectionRows = new List<int>();
                var newNewReflectionCols = new List<int>();

                var changed = false;
                
                for (int row = 0; row < patternRows.Count; row++)
                {
                    bool shouldBreak = false;
                    
                    for (int col = 0; col < patternRows[row].Length; col++)
                    {
                        var changeWith = patternRows[row][col] == '#' ? '.' : '#';

                        var newPatternRows = new List<string>(patternRows);
                        if (col < newPatternRows[row].Length - 1)
                        {
                            newPatternRows[row] = patternRows[row].Substring(0, col) + changeWith.ToString() + patternRows[row].Substring(col + 1);
                        }
                        else
                        {
                            newPatternRows[row] = patternRows[row].Substring(0, col) + changeWith.ToString();
                        }
                        var newPatternCols = new List<char>[patternCols.Length];
                        for (int i = 0; i < patternCols.Length; i++)
                        {
                            newPatternCols[i] = new List<char>(patternCols[i]);
                        }
                        var newCol = patternCols[col];
                        newCol[row] = changeWith;
                        newPatternCols[col] = newCol;

                        var newReflectionRows = FindReflectionRows(newPatternRows);
                        var newReflectionCols = FindReflectionCols(newPatternCols);

                        //if (newReflectionCols.Count > 0 && newReflectionCols.Any(x => !reflectionCols.Any(y => y == x)))
                        //{
                        //    var colToAdd = newReflectionCols.First(x => !reflectionCols.Any(y => y == x));
                        //
                        //    reflectionRows.Clear();
                        //    reflectionCols.Clear();
                        //    reflectionCols.Add(colToAdd);
                        //
                        //    shouldBreak = true;
                        //    changed = true;
                        //    break;
                        //}
                        //if (newReflectionRows.Count > 0 && newReflectionRows.Any(x => !reflectionRows.Any(y => y == x)))
                        //{
                        //    var rowToAdd = newReflectionRows.First(x => !reflectionRows.Any(y => y == x));
                        //
                        //    reflectionRows.Clear();
                        //    reflectionRows.Add(rowToAdd);
                        //    reflectionCols.Clear();
                        //    changed = true;
                        //
                        //    shouldBreak = true;
                        //    break;
                        //}

                        if ((newReflectionCols.Count > 0 && newReflectionCols.Any(x => !reflectionCols.Any(y => y == x)))
                            || (newReflectionRows.Count > 0 && newReflectionRows.Any(x => !reflectionRows.Any(y => y == x))))
                        {
                            newNewReflectionRows = newReflectionRows.Any(x => !reflectionRows.Any(y => y == x)) ? new List<int>(newReflectionRows.Where(x => !reflectionRows.Any(y => y == x))) : new List<int>();
                            newNewReflectionCols = newReflectionCols.Any(x => !reflectionCols.Any(y => y == x)) ? new List<int>(newReflectionCols.Where(x => !reflectionCols.Any(y => y == x))) : new List<int>();
                            changed = true;
                            Console.WriteLine("Changed row " + row + " and col " + col);
                            //shouldBreak= true;
                            //break;
                        }
                    }

                    if (shouldBreak)
                    {
                        break;
                    }
                }

                //if (changed)
                //{
                    reflectionCols = newNewReflectionCols;
                    reflectionRows = newNewReflectionRows;
                    
                    if (reflectionCols.Count > 0 && reflectionRows.Count > 0)
                    {
                        if (reflectionRows.Min() > reflectionCols.Min())
                        {
                            sum += reflectionRows.Min() * 100;
                        }
                        else
                        {
                            sum += reflectionCols.Min();
                        }
                    }
                    //else
                    //{
                    //foreach (var item in reflectionCols)
                    //{
                    //    sum += item;
                    //}
                    //foreach (var item in reflectionRows)
                    //{
                    //    sum += item * 100;
                    //}
                    //}
                    else if (reflectionRows.Count > 0)
                    {
                        sum += reflectionRows.Min() * 100;
                    }
                    else if (reflectionCols.Count > 0)
                    {
                        sum += reflectionCols.Min();
                    }
                //}
                //else
                //{

                    Console.WriteLine("not changed");
                    //foreach (var item in reflectionCols)
                    //{
                    //    sum += item;
                    //}
                    //foreach (var item in reflectionRows)
                    //{
                    //    sum += item * 100;
                    //}
                //}

                if (line == "end")
                {
                    break;
                }
            }

            Console.WriteLine(sum);
        }

        private static List<int> FindReflectionRows(List<string> patternRows)
        {
            var reflectionRows = new List<int>();

            for (int i = 1; i < patternRows.Count; i++)
            {
                if (patternRows[i] == patternRows[i - 1])
                {
                    bool isPerfectReflection = true;

                    for (int j = 0; j < i; j++)
                    {
                        if (i + j < patternRows.Count && i - 1 - j >= 0 &&
                            patternRows[i + j] != patternRows[i - 1 - j])
                        {
                            isPerfectReflection = false;
                        }
                    }

                    if (isPerfectReflection)
                    {
                        reflectionRows.Add(i);
                    }
                }
            }

            return reflectionRows;
        }

        private static List<int> FindReflectionCols(List<char>[] patternCols)
        {
            var reflectionCols = new List<int>();

            for (int i = 1; i < patternCols.Length; i++)
            {
                if (string.Join("", patternCols[i]) == string.Join("", patternCols[i - 1]))
                {
                    bool isPerfectReflection = true;

                    for (int j = 0; j < i; j++)
                    {
                        if (i + j < patternCols.Length && i - 1 - j >= 0 &&
                            string.Join("", patternCols[i + j]) != string.Join("", patternCols[i - 1 - j]))
                        {
                            isPerfectReflection = false;
                        }
                    }

                    if (isPerfectReflection)
                    {
                        reflectionCols.Add(i);
                    }
                }
            }

            return reflectionCols;
        }
    }
}
