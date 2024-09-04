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
            throw new NotImplementedException();
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
