namespace AdventOfCode2015
{
    public static class Day19
    {
        public static void Task01(string input)
        {
            (string originalMolecule, List<(string, string)> replacements) = ReadInput(input);

            var distinctMolecules = new HashSet<string>();

            foreach (var replacement in replacements)
            {
                var lastReplacedIndex = 0;

                while (originalMolecule.IndexOf(replacement.Item1, lastReplacedIndex) != -1)
                {
                    var index = originalMolecule.IndexOf(replacement.Item1, lastReplacedIndex);

                    var molecule = string.Concat(
                        originalMolecule.Substring(0, index),
                        replacement.Item2,
                        originalMolecule.Substring(index + replacement.Item1.Length)
                        );

                    distinctMolecules.Add(molecule);
                    lastReplacedIndex = index + replacement.Item1.Length;
                }
            }

            Console.WriteLine(distinctMolecules.Count);
        }

        public static void Task02(string input)
        {
            throw new NotImplementedException();
        }

        private static (string, List<(string, string)>) ReadInput(string input)
        {
            var inputLines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();

            var originalMolecule = inputLines[inputLines.Count - 1];
            inputLines.RemoveAt(inputLines.Count - 1);

            var replacements = new List<(string, string)>();
            foreach (var line in inputLines)
            {
                var lineParts = line.Split(" => ").ToArray();
                replacements.Add((lineParts[0], lineParts[1]));
            }

            return (originalMolecule, replacements);
        }
    }
}
