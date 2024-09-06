namespace AdventOfCode2022
{
    public static class Day03
    {
        public static void Task01(string input)
        {
            var inputLines = input.Split(Environment.NewLine).ToList();

            var prioritiesSum = 0;

            foreach (var rucksack in inputLines)
            {
                var compartment1 = new HashSet<char>();
                var compartment2 = new List<char>();

                for (int i = 0; i < rucksack.Length / 2; i++)
                {
                    compartment1.Add(rucksack[i]);
                    compartment2.Add(rucksack[rucksack.Length - 1 - i]);
                }

                foreach (var itemType in compartment1)
                {
                    if (compartment2.Contains(itemType))
                    {
                        var priority = (int)itemType;

                        if (priority >= 97) // a-z -  1-26
                        {
                            priority -= 96;
                        }
                        else // A-Z - 27-52
                        {
                            priority -= 38;
                        }

                        prioritiesSum += priority;
                    }
                }
            }

            Console.WriteLine(prioritiesSum);
        }

        public static void Task02(string input)
        {
            var rucksacks = input.Split(Environment.NewLine).ToList();

            var prioritiesSum = 0;

            for (int i = 0; i < rucksacks.Count; i += 3)
            {
                var rucksack1 = rucksacks[i];
                var itemTypesInRucksack1 = new HashSet<char>();
                for (int j = 0; j < rucksack1.Length; j++)
                {
                    itemTypesInRucksack1.Add(rucksack1[j]);
                }

                var rucksack2 = rucksacks[i + 1];
                var itemTypesInRucksack2 = new HashSet<char>();
                for (int j = 0; j < rucksack2.Length; j++)
                {
                    itemTypesInRucksack2.Add(rucksack2[j]);
                }

                var rucksack3 = rucksacks[i + 2];
                var itemTypesInRucksack3 = new HashSet<char>();
                for (int j = 0; j < rucksack3.Length; j++)
                {
                    itemTypesInRucksack3.Add(rucksack3[j]);
                }

                foreach (var itemType in itemTypesInRucksack1)
                {
                    if (itemTypesInRucksack2.Contains(itemType) && itemTypesInRucksack3.Contains(itemType))
                    {
                        var priority = (int)itemType;

                        if (priority >= 97) // a-z -  1-26
                        {
                            priority -= 96;
                        }
                        else // A-Z - 27-52
                        {
                            priority -= 38;
                        }

                        prioritiesSum += priority;
                        break;
                    }
                }
            }

            Console.WriteLine(prioritiesSum);
        }
    }
}
