namespace AdventOfCode2015
{
    public static class Day01
    {
        public static void Task01(string input)
        {
            var floor = 0;

            foreach (char i in input)
            {
                floor += i == '(' ? 1 : -1;
            }

            Console.WriteLine(floor);
        }

        public static void Task02(string input)
        {
            var floor = 0;

            for (int i = 0; i < input.Length; i++)
            {
                floor += input[i] == '(' ? 1 : -1;

                if (floor == -1)
                {
                    Console.WriteLine(i + 1);
                    break;
                }
            }
        }
    }
}
