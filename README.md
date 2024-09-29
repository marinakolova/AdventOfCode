# :christmas_tree: Advent of Code

This repo contains solutions for [Advent of Code](https://adventofcode.com/) in C#.

- [Advent of Code 2015 puzzles](https://adventofcode.com/2015) :point_right: [2015 solutions](https://github.com/marinakolova/AdventOfCode/tree/main/AdventOfCode2015) - In progress
- [Advent of Code 2016 puzzles](https://adventofcode.com/2016) - TODO
- [Advent of Code 2017 puzzles](https://adventofcode.com/2017) - TODO
- [Advent of Code 2018 puzzles](https://adventofcode.com/2018) - TODO
- [Advent of Code 2019 puzzles](https://adventofcode.com/2019) - TODO
- [Advent of Code 2020 puzzles](https://adventofcode.com/2020) - TODO
- [Advent of Code 2021 puzzles](https://adventofcode.com/2021) :point_right: [2021 solutions](https://github.com/marinakolova/AdventOfCode/tree/main/AdventOfCode2021) - Days 1-15
- [Advent of Code 2022 puzzles](https://adventofcode.com/2022) :point_right: [2022 solutions](https://github.com/marinakolova/AdventOfCode/tree/main/AdventOfCode2022) - Days 1-13
- [Advent of Code 2023 puzzles](https://adventofcode.com/2023) :point_right: [2023 solutions](https://github.com/marinakolova/AdventOfCode/tree/main/AdventOfCode2023) - Days 1-13

## Structure
1. `AdventOfCode.sln` -> project for each year.
2. Project `AdventOfCode20XX` -> class for each day.
3. Class `DayXX.cs` -> methods `Task01` (for part one of the daily problem) and `Task02` (for part two of the daily problem).
4. The starting point is the main method in `Program.cs` and each task for each day can be called from there.
5. The input is being read from `input.txt` file (each project contains one such file).

## How to use
1. Put your input for the task you want to solve in the `input.txt` file in the project for the corresponding year.
2. Uncomment the task you want to solve in the main method in `Program.cs` for the corresponding year.
3. Run the project for the corresponding year.
4. Get the result from the console.
