namespace AdventOfCode2015
{
    public static class Day11
    {
        public static void Task01(string input)
        {
            var password = input.ToString().ToCharArray();
            password = RenewPassword(password);

            Console.WriteLine(string.Join("", password));
        }

        public static void Task02(string input)
        {
            var password = input.ToString().ToCharArray();
            password = RenewPassword(password);
            password = RenewPassword(password);

            Console.WriteLine(string.Join("", password));
        }

        private static char[] RenewPassword(char[] password)
        {
            var meetsRequirements = false;

            while (!meetsRequirements)
            {
                for (int i = password.Length - 1; i >= 0; i--)
                {
                    password[i] = (char)((int)password[i] + 1);
                    if (!char.IsLetter(password[i]))
                    {
                        password[i] = 'a';
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                bool hasIncreasingStraightOfThree = false;
                var charsOnPairs = new HashSet<char>();

                for (int i = 0; i < password.Length; i++)
                {
                    if (i < password.Length - 2)
                    {
                        if ((int)password[i] == (int)password[i + 1] - 1
                            && (int)password[i + 1] == (int)password[i + 2] - 1)
                        {
                            hasIncreasingStraightOfThree = true;
                        }
                    }
                    if (i < password.Length - 1)
                    {
                        if (password[i] == password[i + 1])
                        {
                            charsOnPairs.Add(password[i]);
                        }
                    }
                }

                if (hasIncreasingStraightOfThree && charsOnPairs.Count >= 2
                    && !password.Contains('i') && !password.Contains('o') && !password.Contains('l'))
                {
                    meetsRequirements = true;
                }
            }

            return password;
        }
    }
}
