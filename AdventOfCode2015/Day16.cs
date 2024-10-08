using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode2015
{
    public class Sue
    {
        public int Id { get; set; }

        public int Children { get; set; }

        public int Cats { get; set; }

        public int Samoyeds { get; set; }

        public int Pomeranians { get; set; }

        public int Akitas { get; set; }

        public int Vizslas { get; set; }

        public int Goldfish { get; set; }

        public int Trees { get; set; }

        public int Cars { get; set; }

        public int Perfumes { get; set; }
    }

    public static class Day16
    {
        public static void Task01(string input)
        {
            var aunts = ReadInput(input);

            var filteredAunts = aunts
                .Where(x =>
                    //children: 3
                    (x.Children == 3 || x.Children == -1) &&
                    //cats: 7
                    (x.Cats == 7 || x.Cats == -1) &&
                    //samoyeds: 2
                    (x.Samoyeds == 2 || x.Samoyeds == -1) &&
                    //pomeranians: 3
                    (x.Pomeranians == 3 || x.Pomeranians == -1) &&
                    //akitas: 0
                    (x.Akitas == 0 || x.Akitas == -1) &&
                    //vizslas: 0
                    (x.Vizslas == 0 || x.Vizslas == -1) &&
                    //goldfish: 5
                    (x.Goldfish == 5 || x.Goldfish == -1) &&
                    //trees: 3
                    (x.Trees == 3 || x.Trees == -1) &&
                    //cars: 2
                    (x.Cars == 2 || x.Cars == -1) &&
                    //perfumes: 1
                    (x.Perfumes == 1 || x.Perfumes == -1)
                )
                .ToList();

            if (filteredAunts.Count == 1)
            {
                Console.WriteLine(filteredAunts[0].Id);
            }
            else
            {
                Console.WriteLine("More than one result...");
                foreach (var item in filteredAunts)
                {
                    Console.WriteLine(item.Id);
                }
            }
        }

        public static void Task02(string input)
        {
            var aunts = ReadInput(input);

            var filteredAunts = aunts
                .Where(x =>
                    //children: 3
                    (x.Children == 3 || x.Children == -1) &&
                    //cats: 7
                    (x.Cats > 7 || x.Cats == -1) &&
                    //samoyeds: 2
                    (x.Samoyeds == 2 || x.Samoyeds == -1) &&
                    //pomeranians: 3
                    (x.Pomeranians < 3 || x.Pomeranians == -1) &&
                    //akitas: 0
                    (x.Akitas == 0 || x.Akitas == -1) &&
                    //vizslas: 0
                    (x.Vizslas == 0 || x.Vizslas == -1) &&
                    //goldfish: 5
                    (x.Goldfish < 5 || x.Goldfish == -1) &&
                    //trees: 3
                    (x.Trees > 3 || x.Trees == -1) &&
                    //cars: 2
                    (x.Cars == 2 || x.Cars == -1) &&
                    //perfumes: 1
                    (x.Perfumes == 1 || x.Perfumes == -1)
                )
                .ToList();

            if (filteredAunts.Count == 1)
            {
                Console.WriteLine(filteredAunts[0].Id);
            }
            else
            {
                Console.WriteLine("More than one result...");
                foreach (var item in filteredAunts)
                {
                    Console.WriteLine(item.Id);
                }
            }
        }

        private static List<Sue> ReadInput(string input)
        {
            var aunts = new List<Sue>();

            var inputLines = input.Split(Environment.NewLine).ToArray();
            for (int i = 0; i < inputLines.Length; i++)
            {
                var line = inputLines[i];
                var lineParts = line.Split(' ').ToArray();

                var belongings = new Dictionary<string, int>();
                for (int j = 2; j < lineParts.Length - 1; j += 2)
                {
                    var belongingKey = lineParts[j].Substring(0, lineParts[j].Length - 1);
                    var belongingValue = int.Parse(lineParts[j + 1].EndsWith(',') ? lineParts[j + 1].Substring(0, lineParts[j + 1].Length - 1) : lineParts[j + 1]);
                    belongings.Add(belongingKey, belongingValue);
                }

                aunts.Add(new Sue
                {
                    Id = i + 1,
                    Children = belongings.ContainsKey("children") ? belongings["children"] : -1,
                    Cats = belongings.ContainsKey("cats") ? belongings["cats"] : -1,
                    Samoyeds = belongings.ContainsKey("samoyeds") ? belongings["samoyeds"] : -1,
                    Pomeranians = belongings.ContainsKey("pomeranians") ? belongings["pomeranians"] : -1,
                    Akitas = belongings.ContainsKey("akitas") ? belongings["akitas"] : -1,
                    Vizslas = belongings.ContainsKey("vizslas") ? belongings["vizslas"] : -1,
                    Goldfish = belongings.ContainsKey("goldfish") ? belongings["goldfish"] : -1,
                    Trees = belongings.ContainsKey("trees") ? belongings["trees"] : -1,
                    Cars = belongings.ContainsKey("cars") ? belongings["cars"] : -1,
                    Perfumes = belongings.ContainsKey("perfumes") ? belongings["perfumes"] : -1,
                });
            }

            return aunts;
        }
    }
}
