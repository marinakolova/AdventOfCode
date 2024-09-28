using System.Runtime.CompilerServices;

namespace AdventOfCode2015
{
    public static class Day04
    {
        public static void Task01(string input)
        {
            int number = 1;

            while (true)
            {
                string inputAndNumber = input + number.ToString();

                if (CreateMD5(inputAndNumber).StartsWith("00000"))
                {
                    Console.WriteLine(number);
                    break;
                }

                number++;
            }
        }

        public static void Task02(string input)
        {
            int number = 1;

            while (true)
            {
                string inputAndNumber = input + number.ToString();

                if (CreateMD5(inputAndNumber).StartsWith("000000"))
                {
                    Console.WriteLine(number);
                    break;
                }

                number++;
            }
        }

        private static string CreateMD5(string text)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] textBytes = System.Text.Encoding.ASCII.GetBytes(text);
                byte[] hashBytes = md5.ComputeHash(textBytes);

                return Convert.ToHexString(hashBytes);
            }
        }
    }
}
