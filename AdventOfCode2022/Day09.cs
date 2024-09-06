namespace AdventOfCode2022
{
    public static class Day09
    {
        private class Position
        {
            public int Row { get; set; }

            public int Col { get; set; }
        }

        public static void Task01(string input)
        {
            var head = new Position { Row = 0, Col = 0 };
            var tail = new Position { Row = 0, Col = 0 };

            var tailPositions = new HashSet<(int x, int y)>
            {
                (0, 0)
            };

            var inputLines = input.Split(Environment.NewLine).ToList();

            foreach (var instruction in inputLines)
            {
                var motion = instruction.Split(' ');
                var direction = motion[0];
                var steps = int.Parse(motion[1]);

                for (int i = 0; i < steps; i++)
                {
                    if (direction == "U")
                    {
                        // move head up
                        head.Row -= 1;

                        // move tail up if needed
                        if (tail.Row > head.Row && Math.Abs(head.Row - tail.Row) > 1)
                        {
                            tail.Row -= 1;
                            tail.Col = head.Col; // handles diagonals
                        }
                    }
                    else if (direction == "D")
                    {
                        // move head down
                        head.Row += 1;

                        // move tail down if needed
                        if (tail.Row < head.Row && Math.Abs(head.Row - tail.Row) > 1)
                        {
                            tail.Row += 1;
                            tail.Col = head.Col; // handles diagonals
                        }
                    }
                    else if (direction == "L")
                    {
                        // move head left
                        head.Col -= 1;

                        // move tail left if needed
                        if (tail.Col > head.Col && Math.Abs(head.Col - tail.Col) > 1)
                        {
                            tail.Col -= 1;
                            tail.Row = head.Row; // handles diagonals
                        }

                    }
                    else if (direction == "R")
                    {
                        // move head right
                        head.Col += 1;

                        // move tail right if needed
                        if (tail.Col < head.Col && Math.Abs(head.Col - tail.Col) > 1)
                        {
                            tail.Col += 1;
                            tail.Row = head.Row; // handles diagonals
                        }
                    }

                    // save tail position
                    tailPositions.Add((tail.Row, tail.Col));
                }
            }

            Console.WriteLine(tailPositions.Count);
        }

        public static void Task02(string input)
        {
            var knots = new List<Position>
            {
                new Position { Row = 0, Col = 0 }, // 0 - head
                new Position { Row = 0, Col = 0 }, // 1
                new Position { Row = 0, Col = 0 }, // 2
                new Position { Row = 0, Col = 0 }, // 3
                new Position { Row = 0, Col = 0 }, // 4
                new Position { Row = 0, Col = 0 }, // 5
                new Position { Row = 0, Col = 0 }, // 6
                new Position { Row = 0, Col = 0 }, // 7
                new Position { Row = 0, Col = 0 }, // 8
                new Position { Row = 0, Col = 0 }, // 9 - tail
            };

            var tailPositions = new HashSet<(int x, int y)>
            {
                (0, 0)
            };

            var inputLines = input.Split(Environment.NewLine).ToList();

            foreach (var instruction in inputLines)
            {
                var motion = instruction.Split(' ');
                var direction = motion[0];
                var steps = int.Parse(motion[1]);

                for (int i = 0; i < steps; i++)
                {
                    // move knot 0 (head)
                    switch (direction)
                    {
                        case "U": // up
                            knots[0].Row -= 1;
                            break;

                        case "D": // down
                            knots[0].Row += 1;
                            break;

                        case "L": // left
                            knots[0].Col -= 1;
                            break;

                        case "R": // right
                            knots[0].Col += 1;
                            break;
                    }

                    // move knots 1 to 9
                    for (int j = 1; j < 10; j++)
                    {
                        // check if knot needs to go up
                        if (knots[j].Row > knots[j - 1].Row && Math.Abs(knots[j - 1].Row - knots[j].Row) > 1)
                        {
                            knots[j].Row -= 1;

                            // handle diagonals
                            if (knots[j].Col < knots[j - 1].Col)
                            {
                                knots[j].Col += 1;
                            }
                            else if (knots[j].Col > knots[j - 1].Col)
                            {
                                knots[j].Col -= 1;
                            }
                        }

                        // check if knot needs to go down
                        if (knots[j].Row < knots[j - 1].Row && Math.Abs(knots[j - 1].Row - knots[j].Row) > 1)
                        {
                            knots[j].Row += 1;

                            // handle diagonals
                            if (knots[j].Col < knots[j - 1].Col)
                            {
                                knots[j].Col += 1;
                            }
                            else if (knots[j].Col > knots[j - 1].Col)
                            {
                                knots[j].Col -= 1;
                            }
                        }

                        // check if knot needs to go left
                        if (knots[j].Col > knots[j - 1].Col && Math.Abs(knots[j - 1].Col - knots[j].Col) > 1)
                        {
                            knots[j].Col -= 1;

                            // handle diagonals
                            if (knots[j].Row < knots[j - 1].Row)
                            {
                                knots[j].Row += 1;
                            }
                            else if (knots[j].Row > knots[j - 1].Row)
                            {
                                knots[j].Row -= 1;
                            }
                        }

                        // check if knot needs to go right
                        if (knots[j].Col < knots[j - 1].Col && Math.Abs(knots[j - 1].Col - knots[j].Col) > 1)
                        {
                            knots[j].Col += 1;

                            // handle diagonals
                            if (knots[j].Row < knots[j - 1].Row)
                            {
                                knots[j].Row += 1;
                            }
                            else if (knots[j].Row > knots[j - 1].Row)
                            {
                                knots[j].Row -= 1;
                            }
                        }
                    }

                    // save knot 9 (tail) position
                    tailPositions.Add((knots[9].Row, knots[9].Col));
                }
            }

            Console.WriteLine(tailPositions.Count);
        }
    }
}
