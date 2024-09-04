using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;

namespace Day24
{
    public class Program
    {       

        public static void Main(string[] args)
        {
            var input = "inp w\nmul x 0\nadd x z\nmod x 26\ndiv z 1\nadd x 14\neql x w\neql x 0\nmul y 0\nadd y 25\nmul y x\nadd y 1\nmul z y\nmul y 0\nadd y w\nadd y 1" +
"\nmul y x\nadd z y\ninp w\nmul x 0\nadd x z\nmod x 26\ndiv z 1\nadd x 15\neql x w\neql x 0\nmul y 0\nadd y 25\nmul y x\nadd y 1\nmul z y" +
"\nmul y 0\nadd y w\nadd y 7\nmul y x\nadd z y\ninp w\nmul x 0\nadd x z\nmod x 26\ndiv z 1\nadd x 15\neql x w\neql x 0\nmul y 0\nadd y 25" +
"\nmul y x\nadd y 1\nmul z y\nmul y 0\nadd y w\nadd y 13\nmul y x\nadd z y\ninp w\nmul x 0\nadd x z\nmod x 26\ndiv z 26\nadd x -6\neql x w" +
"\neql x 0\nmul y 0\nadd y 25\nmul y x\nadd y 1\nmul z y\nmul y 0\nadd y w\nadd y 10\nmul y x\nadd z y\ninp w\nmul x 0\nadd x z\nmod x 26" +
"\ndiv z 1\nadd x 14\neql x w\neql x 0\nmul y 0\nadd y 25\nmul y x\nadd y 1\nmul z y\nmul y 0\nadd y w\nadd y 0\nmul y x\nadd z y" +
"\ninp w\nmul x 0\nadd x z\nmod x 26\ndiv z 26\nadd x -4\neql x w\neql x 0\nmul y 0\nadd y 25\nmul y x\nadd y 1\nmul z y\nmul y 0\nadd y w" +
"\nadd y 13\nmul y x\nadd z y\ninp w\nmul x 0\nadd x z\nmod x 26\ndiv z 1\nadd x 15\neql x w\neql x 0\nmul y 0\nadd y 25\nmul y x\nadd y 1" +
"\nmul z y\nmul y 0\nadd y w\nadd y 11\nmul y x\nadd z y\ninp w\nmul x 0\nadd x z\nmod x 26\ndiv z 1\nadd x 15\neql x w\neql x 0\nmul y 0" +
"\nadd y 25\nmul y x\nadd y 1\nmul z y\nmul y 0\nadd y w\nadd y 6\nmul y x\nadd z y\ninp w\nmul x 0\nadd x z\nmod x 26\ndiv z 1\nadd x 11" +
"\neql x w\neql x 0\nmul y 0\nadd y 25\nmul y x\nadd y 1\nmul z y\nmul y 0\nadd y w\nadd y 1\nmul y x\nadd z y\ninp w\nmul x 0\nadd x z" +
"\nmod x 26\ndiv z 26\nadd x 0\neql x w\neql x 0\nmul y 0\nadd y 25\nmul y x\nadd y 1\nmul z y\nmul y 0\nadd y w\nadd y 7\nmul y x\nadd z y" +
"\ninp w\nmul x 0\nadd x z\nmod x 26\ndiv z 26\nadd x 0\neql x w\neql x 0\nmul y 0\nadd y 25\nmul y x\nadd y 1\nmul z y\nmul y 0\nadd y w" +
"\nadd y 11\nmul y x\nadd z y\ninp w\nmul x 0\nadd x z\nmod x 26\ndiv z 26\nadd x -3\neql x w\neql x 0\nmul y 0\nadd y 25\nmul y x\nadd y 1" +
"\nmul z y\nmul y 0\nadd y w\nadd y 14\nmul y x\nadd z y\ninp w\nmul x 0\nadd x z\nmod x 26\ndiv z 26\nadd x -9\neql x w\neql x 0\nmul y 0" +
"\nadd y 25\nmul y x\nadd y 1\nmul z y\nmul y 0\nadd y w\nadd y 4\nmul y x\nadd z y\ninp w\nmul x 0\nadd x z\nmod x 26\ndiv z 26\nadd x -9" +
"\neql x w\neql x 0\nmul y 0\nadd y 25\nmul y x\nadd y 1\nmul z y\nmul y 0\nadd y w\nadd y 10\nmul y x\nadd z y";

            long CalculateNumber(string[] input, bool goBig = true)
            {
                Stack<(int sourceIndex, int offset)> inputStash = new();
                int[] finalDigits = new int[14];

                int targetIndex = 0;
                for (int block = 0; block < input.Length; block += 18)
                {
                    int check = int.Parse(input[block + 5].Split(' ')[2]);
                    int offset = int.Parse(input[block + 15].Split(' ')[2]);
                    if (check > 0)
                    {
                        inputStash.Push((targetIndex, offset));
                    }
                    else
                    {
                        (int sourceIndex, int offset) rule = inputStash.Pop();
                        int totalOffset = rule.offset + check;
                        if (totalOffset > 0)
                        {
                            if (goBig)
                            {
                                finalDigits[rule.sourceIndex] = 9 - totalOffset;
                                finalDigits[targetIndex] = 9;
                            }
                            else
                            {
                                finalDigits[rule.sourceIndex] = 1;
                                finalDigits[targetIndex] = 1 + totalOffset;
                            }
                        }
                        else
                        {
                            if (goBig)
                            {
                                finalDigits[rule.sourceIndex] = 9;
                                finalDigits[targetIndex] = 9 + totalOffset;
                            }
                            else
                            {
                                finalDigits[rule.sourceIndex] = 1 - totalOffset;
                                finalDigits[targetIndex] = 1;
                            }
                        }

                    }
                    targetIndex++;
                }
                return long.Parse(string.Join("", finalDigits));
            }

            Console.WriteLine(CalculateNumber(input.Split("\n"), true));
            Console.WriteLine(CalculateNumber(input.Split("\n"), false));
        }        
    }
}
