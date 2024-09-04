namespace AdventOfCode2022.Solutions
{
    public static class Day10
    {
        public static void Task01()
        {
            var instructions = ReadInput();

            var xRegister = 1;
            var signalStrengths = new List<int>();

            for (int cycle = 1; cycle <= 220; cycle++)
            {
                // 20th, 60th, 100th, 140th, 180th, and 220th cycles
                if (cycle == 20 || cycle == 60 || cycle == 100 || cycle == 140 || cycle == 180 || cycle == 220)
                {
                    var signalStrength = cycle * xRegister;
                    signalStrengths.Add(signalStrength);
                }

                int instruction = instructions.Dequeue();
                xRegister += instruction;
            }

            Console.WriteLine(signalStrengths.Sum());
        }

        public static void Task02()
        {
            var instructions = ReadInput();

            var crt = new List<List<char>>
            {
                new List<char>(), // row 0
                new List<char>(), // row 1
                new List<char>(), // row 2
                new List<char>(), // row 3
                new List<char>(), // row 4
                new List<char>(), // row 5
            };
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 40; col++)
                {
                    crt[row].Add('.'); // 40 cols in each row
                }
            }

            var currentRow = 0;
            var currentCol = 0;

            var xRegister = 1;

            for (int cycle = 1; cycle <= 240; cycle++)
            {
                // check on which row of the CRT is the strike
                if (cycle >= 1 && cycle <= 40)
                {
                    currentRow = 0;
                }
                else if (cycle >= 41 && cycle <= 80)
                {
                    currentRow = 1;
                }
                else if (cycle >= 81 && cycle <= 120)
                {
                    currentRow = 2;
                }
                else if (cycle >= 121 && cycle <= 160)
                {
                    currentRow = 3;
                }
                else if (cycle >= 161 && cycle <= 200)
                {
                    currentRow = 4;
                }
                else if (cycle >= 201 && cycle <= 240)
                {
                    currentRow = 5;
                }

                // drawing
                if (currentCol == xRegister - 1 || currentCol == xRegister || currentCol == xRegister + 1)
                {
                    crt[currentRow][currentCol] = '#';
                }

                // move to next col for the next cycle
                currentCol += 1;
                if (currentCol > 39) // if row ended
                {
                    currentCol -= 40; // start next row from col 0
                }

                // perform instruction for the current cycle
                if (instructions.Count > 0)
                {
                    int instruction = instructions.Dequeue();
                    xRegister += instruction;
                }
            }

            // print result
            foreach (var row in crt)
            {
                foreach (var col in row)
                {
                    Console.Write(col);
                }
                Console.WriteLine();
            }

            // ###..#..#..##..#..#.#..#.###..####.#..#.
            // #..#.#..#.#..#.#.#..#..#.#..#.#....#.#..
            // #..#.#..#.#..#.##...####.###..###..##...
            // ###..#..#.####.#.#..#..#.#..#.#....#.#..
            // #.#..#..#.#..#.#.#..#..#.#..#.#....#.#..
            // #..#..##..#..#.#..#.#..#.###..####.#..#.

            // RUAKHBEK
        }

        private static Queue<int> ReadInput()
        {
            var instructions = new Queue<int>();
            while (true)
            {
                var instruction = Console.ReadLine().ToString();

                if (instruction == "end") // added line "end" at the end of the original input
                {
                    break;
                }

                if (instruction.StartsWith("addx"))
                {
                    var instrArr = instruction.Split(" ").ToArray();
                    var num = int.Parse(instrArr[1]);

                    // "addx" takes 2 cycles
                    instructions.Enqueue(0); // 1st cycle -> adds 0 (does nothing)
                    instructions.Enqueue(num); // 2nd cycle -> adds the num
                }
                else
                {
                    // "noop" does nothing but takes 1 cycle
                    instructions.Enqueue(0); // 1 cycle -> adds 0 (does nothing)
                }
            }
            return instructions;
        }
    }
}
