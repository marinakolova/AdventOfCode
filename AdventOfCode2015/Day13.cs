namespace AdventOfCode2015
{
    public static class Day13
    {
        public static void Task01(string input)
        {
            var guests = ReadInput(input);
            var people = guests.Keys.Select(k => k.Item1).Distinct().ToList();
            IEnumerable<int> results = Permutations(people.ToArray()).Select(order =>
                order.Zip(order.Skip(1).Append(order[0]), (a, b) => guests.TryGetValue((a, b), out var v) ? v : 0).Sum()
            );
            Console.WriteLine(results.Max());
        }

        public static void Task02(string input)
        {
            var guests = ReadInput(input);
            var people = guests.Keys.Select(k => k.Item1).Distinct().ToList();
            people.Add("me");
            IEnumerable<int> results = Permutations(people.ToArray()).Select(order =>
                order.Zip(order.Skip(1).Append(order[0]), (a, b) => guests.TryGetValue((a, b), out var v) ? v : 0).Sum()
            );
            Console.WriteLine(results.Max());
        }

        private static Dictionary<(string, string), int> ReadInput(string input)
        {
            var guests = new Dictionary<(string, string), int>();

            foreach (var line in input.Split(Environment.NewLine).ToArray())
            {
                var lineParts = line.Split(' ').ToArray();
                var guest = lineParts[0];
                var gainOrLose = lineParts[2];
                var points = int.Parse(lineParts[3]) * (lineParts[2] == "gain" ? 1 : -1);
                var seatsTo = lineParts[10].Replace(".", "");

                if (!guests.ContainsKey((guest, seatsTo)))
                {
                    guests.Add((guest, seatsTo), 0);
                    guests.Add((seatsTo, guest), 0);
                }
                guests[(guest, seatsTo)] += points;
                guests[(seatsTo, guest)] += points;
            }

            return guests;
        }

        private static IEnumerable<T[]> Permutations<T>(T[] rgt)
        {
            IEnumerable<T[]> PermutationsRec(int i)
            {
                if (i == rgt.Length)
                {
                    yield return rgt.ToArray();
                }

                for (var j = i; j < rgt.Length; j++)
                {
                    (rgt[i], rgt[j]) = (rgt[j], rgt[i]);
                    foreach (var perm in PermutationsRec(i + 1))
                    {
                        yield return perm;
                    }
                    (rgt[i], rgt[j]) = (rgt[j], rgt[i]);
                }
            }

            return PermutationsRec(0);
        }
    }
}
