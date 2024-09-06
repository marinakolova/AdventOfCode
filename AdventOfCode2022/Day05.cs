using System.Diagnostics;

namespace AdventOfCode2022
{
    public static class Day05
    {
        // this was originally part of the input:
        // 
        //         [F] [Q]         [Q]        
        // [B]     [Q] [V] [D]     [S]        
        // [S] [P] [T] [R] [M]     [D]        
        // [J] [V] [W] [M] [F]     [J]     [J]
        // [Z] [G] [S] [W] [N] [D] [R]     [T]
        // [V] [M] [B] [G] [S] [C] [T] [V] [S]
        // [D] [S] [L] [J] [L] [G] [G] [F] [R]
        // [G] [Z] [C] [H] [C] [R] [H] [P] [D]
        //  1   2   3   4   5   6   7   8   9 
        // 

        private static Dictionary<int, Stack<char>> stacks = new Dictionary<int, Stack<char>>
        {
            { 1, new Stack<char>(new List<char> { 'G', 'D', 'V', 'Z', 'J', 'S', 'B' }) },
            { 2, new Stack<char>(new List<char> { 'Z', 'S', 'M', 'G', 'V', 'P' }) },
            { 3, new Stack<char>(new List<char> { 'C', 'L', 'B', 'S', 'W', 'T', 'Q', 'F' }) },
            { 4, new Stack<char>(new List<char> { 'H', 'J', 'G', 'W', 'M', 'R', 'V', 'Q' }) },
            { 5, new Stack<char>(new List<char> { 'C', 'L', 'S', 'N', 'F', 'M', 'D' }) },
            { 6, new Stack<char>(new List<char> { 'R', 'G', 'C', 'D' }) },
            { 7, new Stack<char>(new List<char> { 'H', 'G', 'T', 'R', 'J', 'D', 'S', 'Q' }) },
            { 8, new Stack<char>(new List<char> { 'P', 'F', 'V' }) },
            { 9, new Stack<char>(new List<char> { 'D', 'R', 'S', 'T', 'J' }) },
        };

        public static void Task01(string input)
        {
            var inputLines = input.Split(Environment.NewLine).Skip(10).ToList();

            foreach (var step in inputLines)
            {
                var instruction = step.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var count = int.Parse(instruction[1]);
                var from = int.Parse(instruction[3]);
                var to = int.Parse(instruction[5]);

                for (int i = 0; i < count; i++)
                {
                    var crate = stacks[from].Pop();
                    stacks[to].Push(crate);
                }
            }

            PrintResult();
        }

        public static void Task02(string input)
        {
            var inputLines = input.Split(Environment.NewLine).Skip(10).ToList();

            foreach (var step in inputLines)
            {
                var instruction = step.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var count = int.Parse(instruction[1]);
                var from = int.Parse(instruction[3]);
                var to = int.Parse(instruction[5]);

                var crates = new Stack<char>();
                for (int i = 0; i < count; i++)
                {
                    crates.Push(stacks[from].Pop());
                }
                for (int i = 0; i < count; i++)
                {
                    stacks[to].Push(crates.Pop());
                }
            }

            PrintResult();
        }

        private static void PrintResult()
        {
            var result = new List<char>();
            foreach (var stack in stacks)
            {
                result.Add(stack.Value.Peek());
            }
            Console.WriteLine(string.Join("", result));
        }
    }
}
