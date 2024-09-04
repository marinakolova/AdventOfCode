namespace AdventOfCode2023
{
    public static class Day01
    {
        public static void Task01()
        {
            var sum = 0;

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "END")
                {
                    break;
                }

                char firstDigit = 'a';
                char lastDigit = 'a';

                for (int i = 0; i < line.Length; i++)
                {
                    var currChar = line[i];
                    if (char.IsDigit(currChar))
                    {
                        if (!char.IsDigit(firstDigit))
                        {
                            firstDigit = currChar;
                        }
                        lastDigit = currChar;
                    }
                }

                var number = int.Parse(new string(new char[2] { firstDigit, lastDigit }));
                sum += number;
            }

            Console.WriteLine(sum);
        }

        public static void Task02()
        {
            var sum = 0;

            var numbersFrom3letters = new Dictionary<string, char>
            {
                { "one", '1'},
                { "two", '2'},
                { "six", '6'},
            };
            var numbersFrom4letters = new Dictionary<string, char>
            {
                { "four", '4'},
                { "five", '5'},
                { "nine", '9'},
            };
            var numbersFrom5letters = new Dictionary<string, char>
            {
                { "three", '3'},
                { "seven", '7'},
                { "eight", '8'},
            };

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "END")
                {
                    break;
                }

                char firstDigit = 'a';
                char lastDigit = 'a';

                for (int i = 0; i < line.Length; i++)
                {
                    var currChar = line[i];
                    if (char.IsDigit(currChar))
                    {
                        if (!char.IsDigit(firstDigit))
                        {
                            firstDigit = currChar;
                        }
                        lastDigit = currChar;
                    }
                    else
                    {
                        if (line.Length > i + 2)
                        {
                            string numberOf3letters = new string(new char[3] { currChar, line[i + 1], line[i + 2] });
                            if (numbersFrom3letters.ContainsKey(numberOf3letters))
                            {
                                char digit = numbersFrom3letters[numberOf3letters];
                                if (!char.IsDigit(firstDigit))
                                {
                                    firstDigit = digit;
                                }
                                lastDigit = digit;
                            }
                        }

                        if (line.Length > i + 3)
                        {
                            string numberOf4letters = new string(new char[4] { currChar, line[i + 1], line[i + 2], line[i + 3] });
                            if (numbersFrom4letters.ContainsKey(numberOf4letters))
                            {
                                char digit = numbersFrom4letters[numberOf4letters];
                                if (!char.IsDigit(firstDigit))
                                {
                                    firstDigit = digit;
                                }
                                lastDigit = digit;
                            }
                        }

                        if (line.Length > i + 4)
                        {
                            string numberOf5letters = new string(new char[5] { currChar, line[i + 1], line[i + 2], line[i + 3], line[i + 4] });
                            if (numbersFrom5letters.ContainsKey(numberOf5letters))
                            {
                                char digit = numbersFrom5letters[numberOf5letters];
                                if (!char.IsDigit(firstDigit))
                                {
                                    firstDigit = digit;
                                }
                                lastDigit = digit;
                            }
                        }
                    }
                }

                var number = int.Parse(new string(new char[2] { firstDigit, lastDigit }));
                sum += number;
            }

            Console.WriteLine(sum);
        }
    }
}
