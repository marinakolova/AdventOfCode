namespace AdventOfCode2015
{
    public static class Day02
    {
        public static void Task01(string input)
        {
            var boxes = input.Split(Environment.NewLine).ToArray();

            var paper = 0;

            foreach (var box in boxes)
            {
                var dimensions = box.Split("x").Select(int.Parse).ToArray();
                var l = dimensions[0];
                var w = dimensions[1];
                var h = dimensions[2];

                var side1 = l * w;
                var side2 = w * h;
                var side3 = h * l;
                var sides = new[] { side1, side2, side3 };

                paper += side1 * 2 + side2 * 2 + side3 * 2;
                paper += sides.Min();
            }

            Console.WriteLine(paper);
        }

        public static void Task02(string input)
        {
            var boxes = input.Split(Environment.NewLine).ToArray();

            var ribbon = 0;

            foreach (var box in boxes)
            {
                var dimensions = box.Split("x").Select(int.Parse).ToArray();
                var l = dimensions[0];
                var w = dimensions[1];
                var h = dimensions[2];

                ribbon += l * w * h;
                ribbon += (l + w + h) * 2 - dimensions.Max() * 2;
            }

            Console.WriteLine(ribbon);
        }
    }
}
