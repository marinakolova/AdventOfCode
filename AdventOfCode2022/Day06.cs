namespace AdventOfCode2022
{
    public static class Day06
    {
        public static void Task01()
        {
            FindMarker(4);
        }

        public static void Task02()
        {
            FindMarker(14);
        }

        private static void FindMarker(int charsCount)
        {
            var signal = Console.ReadLine().ToString();

            for (int i = charsCount; i < signal.Length; i++)
            {
                var uniqueChars = new HashSet<char>();

                for (int j = 0; j < charsCount; j++)
                {
                    uniqueChars.Add(signal[i - j]);
                }

                if (uniqueChars.Count == charsCount)
                {
                    Console.WriteLine(i + 1);
                    break;
                }
            }
        }
    }
}
