using System.Numerics;

namespace AdventOfCode2023
{
    class HandOfCards
    {
        public int Type { get; set; }

        public int FirstCard { get; set; }

        public int SecondCard { get; set; }

        public int ThirdCard { get; set; }

        public int FourthCard { get; set; }

        public int FifthCard { get; set; }

        public int Bid { get; set; }
    }

    public static class Day07
    {
        public static void Task01()
        {
            ReadInputAndPrintResult();
        }

        public static void Task02()
        {
            bool playWithJokers = true;
            ReadInputAndPrintResult(playWithJokers);
        }

        private static void ReadInputAndPrintResult(bool playWithJokers = false)
        {
            var hands = new List<HandOfCards>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                var hand = line.Split();
                var cards = hand[0].ToCharArray().Select(x => DetermineCard(x, playWithJokers)).ToArray();
                var bid = int.Parse(hand[1]);
                var type = DermineHandType(cards, playWithJokers);

                hands.Add(new HandOfCards
                {
                    Type = type,
                    FirstCard = cards[0],
                    SecondCard = cards[1],
                    ThirdCard = cards[2],
                    FourthCard = cards[3],
                    FifthCard = cards[4],
                    Bid = bid,
                });
            }

            var orderedHands = hands
                .OrderBy(h => h.Type)
                .ThenBy(h => h.FirstCard)
                .ThenBy(h => h.SecondCard)
                .ThenBy(h => h.ThirdCard)
                .ThenBy(h => h.FourthCard)
                .ThenBy(h => h.FifthCard)
                .ToList();

            BigInteger winnings = 0;

            for (int i = 0; i < orderedHands.Count; i++)
            {
                winnings += (orderedHands[i].Bid * (i + 1));
            }

            Console.WriteLine(winnings);
        }

        private static int DetermineCard(char label, bool playWithJokers = false)
        {
            // A = 14, K = 13, Q = 12, J = 11, T = 10, 9, 8, 7, 6, 5, 4, 3, 2 (Task01)
            // with jokers/wildcards: J = 1 (Task02)
            switch (label)
            {
                case 'A': return 14;
                case 'K': return 13;
                case 'Q': return 12;
                case 'J': return playWithJokers ? 1 : 11;
                case 'T': return 10;
                default:
                    return int.Parse(label.ToString());
            }
        }

        private static int DermineHandType(int[] cards, bool playWithJokers = false)
        {
            // 7 = Five of a kind, where all five cards have the same label: AAAAA
            // 6 = Four of a kind, where four cards have the same label and one card has a different label: AA8AA
            // 5 = Full house, where three cards have the same label, and the remaining two cards share a different label: 23332
            // 4 = Three of a kind, where three cards have the same label, and the remaining two cards are each different from any other card in the hand: TTT98
            // 3 = Two pair, where two cards share one label, two other cards share a second label, and the remaining card has a third label: 23432
            // 2 = One pair, where two cards share one label, and the other three cards have a different label from the pair and each other: A23A4
            // 1 = High card, where all cards' labels are distinct: 23456

            var distinct = cards.Distinct().ToArray();
            var handHasJokers = cards.Any(c => c == 1); // for Task02

            if (distinct.Length == 1) // five of a kind = 7
            {
                // five of a kind = 7
                return 7;
            }
            else if (distinct.Length == 2) // four of a kind = 6, or full house = 5
            {
                if (cards.Where(c => c == distinct[0]).Count() == 4
                    || cards.Where(c => c == distinct[1]).Count() == 4)
                {
                    if (playWithJokers // Task02
                        && handHasJokers)
                    {
                        // J => played as one of the other cards => five of a kind = 7
                        return 7;
                    }

                    // four of a kind = 6
                    return 6;
                }
                else
                {
                    if (playWithJokers // Task02
                        && handHasJokers)
                    {
                        // J => played as one of the other cards => five of a kind = 7
                        return 7;
                    }

                    // full house = 5
                    return 5;
                }
            }
            else if (distinct.Length == 3) // three of a kind = 4, or two pair = 3
            {
                if (cards.Where(c => c == distinct[0]).Count() == 3
                    || cards.Where(c => c == distinct[1]).Count() == 3
                    || cards.Where(c => c == distinct[2]).Count() == 3)
                {
                    if (playWithJokers // Task02
                        && handHasJokers)
                    {
                        // J => played as one of the other cards => four of a kind = 6
                        return 6;
                    }

                    // three of a kind = 4
                    return 4;
                }
                else
                {
                    if (playWithJokers // Task02
                        && handHasJokers)
                    {
                        if (cards.Where(c => c == 1).Count() == 2)
                        {
                            // J => played as one of the other cards => four of a kind = 6
                            return 6;
                        }
                        else
                        {
                            // J => played as one of the other cards => full house = 5
                            return 5;
                        }
                    }

                    // two pair = 3
                    return 3;
                }
            }
            else if (distinct.Length == 4) // one pair = 2
            {
                if (playWithJokers // Task02
                    && handHasJokers)
                {
                    // J => played as one of the other cards => three of a kind = 4
                    return 4;
                }

                // one pair = 2
                return 2;
            }
            else // high card = 1
            {
                if (playWithJokers // Task02
                    && handHasJokers)
                {
                    // J => played as one of the other cards => one pair = 2
                    return 2;
                }

                // high card = 1
                return 1;
            }
        }
    }
}
