namespace AdventOfCode2021
{
    public static class Day10
    {
        public static void Task01(string input)
        {
            var parenthesis = input.Split(Environment.NewLine).ToList();

            var points = new Dictionary<char, int>
            {
                { ')', 3 },
                { ']', 57 },
                { '}', 1197 },
                { '>', 25137 },
            };

            var score = 0;

            for (int line = 0; line < parenthesis.Count; line++)
            {
                var openingBrackets = new Stack<char>();

                for (int i = 0; i < parenthesis[line].Length; i++)
                {
                    var bracket = parenthesis[line][i];

                    if (bracket == '('
                        || bracket == '['
                        || bracket == '{'
                        || bracket == '<')
                    {
                        openingBrackets.Push(bracket);
                    }
                    else
                    {
                        var lastOpeningBracket = openingBrackets.Pop();

                        if ((bracket == ')' && lastOpeningBracket != '(')
                            || (bracket == ']' && lastOpeningBracket != '[')
                            || (bracket == '}' && lastOpeningBracket != '{')
                            || (bracket == '>' && lastOpeningBracket != '<'))
                        {
                            score += points[bracket];
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }

            Console.WriteLine("Score: " + score);
        }

        public static void Task02(string input)
        {
            var parenthesis = input.Split(Environment.NewLine).ToList();

            var points = new Dictionary<char, int>
            {
                { ')', 1 },
                { ']', 2 },
                { '}', 3 },
                { '>', 4 },
            };

            var scores = new List<long>();

            for (int line = 0; line < parenthesis.Count; line++)
            {
                var openingBrackets = new Stack<char>();
                var isValid = true;

                for (int i = 0; i < parenthesis[line].Length; i++)
                {
                    var bracket = parenthesis[line][i];

                    if (bracket == '('
                        || bracket == '['
                        || bracket == '{'
                        || bracket == '<')
                    {
                        openingBrackets.Push(bracket);
                    }
                    else
                    {
                        var lastOpeningBracket = openingBrackets.Pop();

                        if ((bracket == ')' && lastOpeningBracket != '(')
                            || (bracket == ']' && lastOpeningBracket != '[')
                            || (bracket == '}' && lastOpeningBracket != '{')
                            || (bracket == '>' && lastOpeningBracket != '<'))
                        {
                            isValid = false;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                if (isValid && openingBrackets.Count > 0)
                {
                    scores.Add(0);
                    var scoresIndex = scores.Count - 1;

                    while (openingBrackets.Count > 0)
                    {
                        var openingBracket = openingBrackets.Pop();

                        scores[scoresIndex] *= 5;

                        switch (openingBracket)
                        {
                            case '(':
                                scores[scoresIndex] += points[')'];
                                break;

                            case '[':
                                scores[scoresIndex] += points[']'];
                                break;

                            case '{':
                                scores[scoresIndex] += points['}'];
                                break;

                            case '<':
                                scores[scoresIndex] += points['>'];
                                break;

                        }
                    }
                }
            }

            var score = scores
                .OrderBy(x => x)
                .Skip((scores.Count - 1) / 2)
                .Take(1)
                .ToList()[0];

            Console.WriteLine("Score: " + score);
        }
    }
}
