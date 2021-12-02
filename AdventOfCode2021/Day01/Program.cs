using System;
using System.Collections.Generic;

namespace Day01
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Task01();
            Task02();
        }

        static void Task02()
        {
            var numbers = new List<int>();
            var largerCount = 0;
            
            while (true)
            {
                var input = Console.ReadLine();
            
                if (input == "end")
                {
                    break;
                }
            
                numbers.Add(int.Parse(input));
            }
            
            var firstWindow = 0;
            var secondWindow = 0;
            var thirdWindow = 0;
            
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i == 0)
                {
                    firstWindow += numbers[i];
                } 
                else if (i == 1)
                {
                    firstWindow += numbers[i];
                    secondWindow += numbers[i];                    
                }
                else if (i == 2)
                {
                    firstWindow += numbers[i];
                    secondWindow += numbers[i];
                    thirdWindow += numbers[i];
                }
                else
                {                    
                    secondWindow += numbers[i];
            
                    if (secondWindow > firstWindow)
                    {
                        largerCount++;
                    }
            
                    firstWindow = secondWindow;
                    secondWindow = thirdWindow + numbers[i];
                    thirdWindow = numbers[i];
                }
            }
            
            Console.WriteLine("Larger Count: " + largerCount);
        }

        static void Task01()
        {
            var largerCount = 0;
            var previous = int.Parse(Console.ReadLine());
            
            while (true)
            {
                var input = Console.ReadLine();
            
                if (input == "end")
                {
                    break;
                }
            
                var current = int.Parse(input);
            
                if (current > previous)
                {
                    largerCount++;
                }
            
                previous = current;
            }
            
            Console.WriteLine("Larger Count: " + largerCount);
        }
    }
}
