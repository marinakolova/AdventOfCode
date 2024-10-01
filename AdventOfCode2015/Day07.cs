namespace AdventOfCode2015
{
    public static class Day07
    {
        public static void Task01(string input)
        {
            var results = new Dictionary<string, ushort>();
            ReadInstructions(input, ref results);

            foreach (var item in results.OrderBy(x => x.Key))
            {
                Console.WriteLine(item.Key + " : " + item.Value);
            }
        }

        public static void Task02(string input)
        {
            var results = new Dictionary<string, ushort>();
            ReadInstructions(input, ref results);

            var newResults = new Dictionary<string, ushort>();
            newResults.Add("b", results["a"]);

            ReadInstructions(input, ref newResults, "b");

            foreach (var item in newResults.OrderBy(x => x.Key))
            {
                Console.WriteLine(item.Key + " : " + item.Value);
            }
        }

        private static void ReadInstructions(string input, ref Dictionary<string, ushort> results, string? skip = null)
        {
            var lines = new Queue<string>(input.Split(Environment.NewLine).ToList());

            while (lines.Count > 0)
            {
                var line = lines.Dequeue();
                var lineParts = line.Split(" -> ").ToArray();

                if (lineParts[0].Contains(" AND "))
                {
                    var keysToWorkWith = lineParts[0].Replace(" AND ", " ");
                    (int valueOne, int valueTwo) = GetValues(results, keysToWorkWith, 2);

                    if (valueOne != -1 && valueTwo != -1)
                    {
                        var newValue = valueOne & valueTwo;
                        AddToDictionary(ref results, lineParts[1], newValue, skip);
                    }
                    else
                    {
                        lines.Enqueue(line);
                    }
                }
                else if (lineParts[0].Contains(" OR "))
                {
                    var keysToWorkWith = lineParts[0].Replace(" OR ", " ");
                    (int valueOne, int valueTwo) = GetValues(results, keysToWorkWith, 2);

                    if (valueOne != -1 && valueTwo != -1)
                    {
                        var newValue = valueOne | valueTwo;
                        AddToDictionary(ref results, lineParts[1], newValue, skip);
                    }
                    else
                    {
                        lines.Enqueue(line);
                    }
                }
                else if (lineParts[0].Contains(" LSHIFT "))
                {
                    var keysToWorkWith = lineParts[0].Replace(" LSHIFT ", " ");
                    (int valueOne, int valueTwo) = GetValues(results, keysToWorkWith, 2);

                    if (valueOne != -1 && valueTwo != -1)
                    {
                        var newValue = valueOne << valueTwo;
                        AddToDictionary(ref results, lineParts[1], newValue, skip);
                    }
                    else
                    {
                        lines.Enqueue(line);
                    }
                }
                else if (lineParts[0].Contains(" RSHIFT "))
                {
                    var keysToWorkWith = lineParts[0].Replace(" RSHIFT ", " ");
                    (int valueOne, int valueTwo) = GetValues(results, keysToWorkWith, 2);

                    if (valueOne != -1 && valueTwo != -1)
                    {
                        var newValue = valueOne >> valueTwo;
                        AddToDictionary(ref results, lineParts[1], newValue, skip);
                    }
                    else
                    {
                        lines.Enqueue(line);
                    }
                }
                else if (lineParts[0].Contains("NOT "))
                {
                    var keyToWorkWith = lineParts[0].Replace("NOT ", "");
                    (int valueToWorkWith, int valueTwo) = GetValues(results, keyToWorkWith, 1);

                    if (valueToWorkWith != -1)
                    {
                        var newValue = ~(valueToWorkWith);
                        AddToDictionary(ref results, lineParts[1], newValue, skip);
                    }
                    else
                    {
                        lines.Enqueue(line);
                    }
                }
                else
                {
                    (int valueToWorkWith, int valueTwo) = GetValues(results, lineParts[0], 1);

                    if (valueToWorkWith != -1)
                    {
                        AddToDictionary(ref results, lineParts[1], valueToWorkWith, skip);
                    }
                    else
                    {
                        lines.Enqueue(line);
                    }
                }
            }
        }

        private static void AddToDictionary(ref Dictionary<string, ushort> results, string keyToAddOrUpdate, int valueToAdd, string? skip)
        {
            if (keyToAddOrUpdate != skip)
            {
                if (results.ContainsKey(keyToAddOrUpdate))
                {
                    results[keyToAddOrUpdate] = (ushort)valueToAdd;
                }
                else
                {
                    results.Add(keyToAddOrUpdate, (ushort)valueToAdd);
                }
            }
        }

        private static (int, int) GetValues(Dictionary<string, ushort> results, string keysToWorkWith, int numOfValues)
        {
            if (numOfValues == 2)
            {
                var keyOne = keysToWorkWith.Split(" ").ToArray()[0];
                var keyTwo = keysToWorkWith.Split(" ").ToArray()[1];

                var valueOne = keyOne.All(char.IsDigit) ? ushort.Parse(keyOne)
                    : results.ContainsKey(keyOne) ? results[keyOne]
                    : -1;

                var valueTwo = keyTwo.All(char.IsDigit) ? ushort.Parse(keyTwo)
                    : results.ContainsKey(keyTwo) ? results[keyTwo]
                    : -1;

                return (valueOne, valueTwo);
            }
            else
            {
                var valueToWorkWith = keysToWorkWith.All(char.IsDigit) ? ushort.Parse(keysToWorkWith)
                    : results.ContainsKey(keysToWorkWith) ? results[keysToWorkWith]
                    : -1;

                return (valueToWorkWith, 0);
            }
        }
    }
}
