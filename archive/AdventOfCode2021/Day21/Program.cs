using System;
using System.Collections.Generic;
using System.Linq;

namespace Day21
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = "Player 1 starting position: 6\nPlayer 2 starting position: 8";

            //Part 1
            // ⭐ we can convert 3 consecutive throws to a 3-throw with the new .Net 6 Chunk function:
            var threeRoll = DeterministicThrows().Chunk(3)
                .Select(x => x.Sum());

            // take turns until the active player wins:
            var round = 0;
            var (active, other) = Parse(input);
            foreach (var steps in threeRoll)
            {
                round++;
                active = active.Move(steps);
                if (active.score >= 1000)
                {
                    break;
                }
                (active, other) = (other, active);
            }

            Console.WriteLine("Part 1 Result: " + other.score * 3 * round);

            //Part 2
            // win counts tells us how many times the active and the other player wins
            // if they are starting from the given positions and scores.

            // this function needs to be cached, because we don't have time till eternity.
            var cache = new Dictionary<(Player, Player), (long, long)>();

            (long activeWins, long otherWins) winCounts((Player active, Player other) players)
            {
                if (players.other.score >= 21)
                {
                    return (0, 1);
                }

                if (!cache.ContainsKey(players))
                {
                    var (activeWins, otherWins) = (0L, 0L);
                    foreach (var steps in DiracThrows())
                    {
                        var wins = winCounts((players.other, players.active.Move(steps)));
                        // they are switching roles here ^
                        // hence the return value needs to be swapped as well
                        activeWins += wins.otherWins;
                        otherWins += wins.activeWins;
                    }
                    cache[players] = (activeWins, otherWins);
                }
                return cache[players];
            }

            var wins = winCounts(Parse(input));

            // which player wins more:
            Console.WriteLine("Part 2 Result: " + Math.Max(wins.activeWins, wins.otherWins));

            IEnumerable<int> DeterministicThrows() =>
                from i in Enumerable.Range(1, int.MaxValue) 
                    select(i - 1) % 100 + 1; 

            IEnumerable<int> DiracThrows() =>
                from i in new[] { 1, 2, 3 }
                from j in new[] { 1, 2, 3 }
                from k in new[] { 1, 2, 3 }
                select i + j + k;

            (Player active, Player other) Parse(string input)
            {
                var players = (
                    from line in input.Split("\n")
                    let parts = line.Split(": ")
                    select new Player(0, int.Parse(parts[1]))
                ).ToArray();
                return (players[0], players[1]);
            }
        }

        record Player(int score, int pos)
        {
            public Player Move(int steps)
            {
                var newPos = (this.pos - 1 + steps) % 10 + 1;
                return new Player(this.score + newPos, newPos);
            }
        }
    }
}
