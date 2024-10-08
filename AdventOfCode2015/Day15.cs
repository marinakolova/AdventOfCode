namespace AdventOfCode2015
{
    public class Ingredient
    {
        public int Capacity { get; set; }

        public int Durability { get; set; }

        public int Flavor { get; set; }

        public int Texture { get; set; }

        public int Calories { get; set; }
    }

    public static class Day15
    {
        public static void Task01(string input)
        {
            var ingredients = ReadInput(input);

            var maxCookie = new List<Ingredient>(ingredients);

            for (int i = 0; i < 100 - ingredients.Count; i++)
            {
                var newCookies = new List<List<Ingredient>>();

                foreach (var ingredient in ingredients)
                {
                    var newCookie = new List<Ingredient>(maxCookie);
                    newCookie.Add(ingredient);

                    newCookies.Add(newCookie);
                }

                var newMaxCookie = newCookies.OrderByDescending(x => CalculateCookieTotalScore(x)).First();
                maxCookie = newMaxCookie;
            }

            Console.WriteLine(CalculateCookieTotalScore(maxCookie));
        }

        public static void Task02(string input)
        {
            var ingredients = ReadInput(input);
            var maxTotalScoreOf500calories = int.MinValue;

            for (int i = 1; i <= 100; i++)
            {
                for (int j = 1; j <= 100 - i; j++)
                {
                    for(int k = 1; k <= 100 - i - j; k++)
                    {
                        for (int l = 1; l <= 100 - i - j - k; l++)
                        {
                            if (i + j + k + l == 100)
                            {
                                var cookie = new List<Ingredient>();
                                cookie.AddRange(Enumerable.Range(0, i).Select(x => ingredients[0]));
                                cookie.AddRange(Enumerable.Range(0, j).Select(x => ingredients[1]));
                                cookie.AddRange(Enumerable.Range(0, k).Select(x => ingredients[2]));
                                cookie.AddRange(Enumerable.Range(0, l).Select(x => ingredients[3]));

                                if (GetCookieCalories(cookie) == 500)
                                {
                                    var cookieTotalScore = CalculateCookieTotalScore(cookie);
                                    if (cookieTotalScore > maxTotalScoreOf500calories)
                                    {
                                        maxTotalScoreOf500calories = cookieTotalScore;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine(maxTotalScoreOf500calories);
        }

        private static List<Ingredient> ReadInput(string input)
        {
            var ingredients = new List<Ingredient>();

            var inputLines = input.Split(Environment.NewLine).ToArray();
            foreach (var line in inputLines)
            {
                var properties = line.Split(": ").ToArray()[1].Split(", ").ToArray();
                ingredients.Add(new Ingredient
                {
                    Capacity = int.Parse(properties[0].Split(' ').ToArray()[1]),
                    Durability = int.Parse(properties[1].Split(' ').ToArray()[1]),
                    Flavor = int.Parse(properties[2].Split(' ').ToArray()[1]),
                    Texture = int.Parse(properties[3].Split(' ').ToArray()[1]),
                    Calories = int.Parse(properties[4].Split(' ').ToArray()[1]),
                });
            }

            return ingredients;
        }

        private static int CalculateCookieTotalScore(List<Ingredient> ingredients)
        {
            int capacitySum = ingredients.Select(x => x.Capacity).Sum();
            int durabilitySum = ingredients.Select(x => x.Durability).Sum();
            int flavorSum = ingredients.Select(x => x.Flavor).Sum();
            int textureSum = ingredients.Select(x => x.Texture).Sum();

            int totalScore = (capacitySum > 0 ? capacitySum : 0)
                * (durabilitySum > 0 ? durabilitySum : 0)
                * (flavorSum > 0 ? flavorSum : 0)
                * (textureSum > 0 ? textureSum : 0);

            return totalScore;
        }

        private static int GetCookieCalories(List<Ingredient> ingredients)
        {
            return ingredients.Select(x => x.Calories).Sum();
        }
    }
}
