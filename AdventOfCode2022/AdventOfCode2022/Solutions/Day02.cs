namespace AdventOfCode2022.Solutions
{
    public static class Day02
    {
        public static void Task01()
        {
            var shapesScores = new Dictionary<char, int>
            {
                { 'X', 1 }, // rock
                { 'Y', 2 }, // paper
                { 'Z', 3 }, // scissors
            };
            var gameScores = new Dictionary<string, int>
            {
                { "A X", 3 }, // rock - rock -> draw
                { "A Y", 6 }, // rock - paper -> win
                { "A Z", 0 }, // rock - scissors -> lost

                { "B X", 0 }, // paper - rock -> lost
                { "B Y", 3 }, // paper - paper -> draw
                { "B Z", 6 }, // paper - scissors -> win

                { "C X", 6 }, // scissors - rock -> win
                { "C Y", 0 }, // scissors - paper -> lost
                { "C Z", 3 }, // scissors - scissors -> draw
            };

            var totalScore = 0;

            while (true)
            {
                var game = Console.ReadLine();

                if (game == "end")
                {
                    break;
                }

                totalScore += gameScores[game];
                totalScore += shapesScores[game[^1]];
            }

            Console.WriteLine(totalScore);
        }

        public static void Task02()
        {
            // A - rock - 1
            // B - paper - 2
            // C - scissors - 3

            // X - lost - 0
            // Y - draw - 3
            // Z - win - 6

            var gameScores = new Dictionary<string, int>
            {
                { "A X", 3 }, // rock - scissors -> lost -> 3+0 = 3
                { "A Y", 4 }, // rock - rock -> draw -> 1+3 = 4
                { "A Z", 8 }, // rock - paper -> win -> 2+6 = 8

                { "B X", 1 }, // paper - rock -> lost -> 1+0 = 1
                { "B Y", 5 }, // paper - paper -> draw -> 2+3 = 5
                { "B Z", 9 }, // paper - scissors -> win -> 3+6 = 9

                { "C X", 2 }, // scissors - paper -> lost -> 2+0 = 2
                { "C Y", 6 }, // scissors - scissors -> draw -> 3+3 = 6
                { "C Z", 7 }, // scissors - rock -> win -> 1+6 = 7
            };

            var totalScore = 0;

            while (true)
            {
                var game = Console.ReadLine();

                if (game == "end")
                {
                    break;
                }

                totalScore += gameScores[game];
            }

            Console.WriteLine(totalScore);
        }
    }
}
