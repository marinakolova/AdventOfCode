using System.Numerics;

namespace AdventOfCode2023
{
    public static class Day04
    {
        public static void Task01(string input)
        {
            var points = 0;

            var inputLines = input.Split(Environment.NewLine).ToList();

            foreach (var line in inputLines)
            {
                var card = line.Trim().Split(": ", StringSplitOptions.RemoveEmptyEntries);
                var numbers = card[1].Trim().Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                var winningNumbers = numbers[0].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                var cardNumbers = numbers[1].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                var cardPoints = 0;

                foreach (var cardNumber in cardNumbers)
                {
                    if (winningNumbers.Any(x => x == cardNumber))
                    {
                        if (cardPoints == 0)
                        {
                            cardPoints += 1;
                        }
                        else
                        {
                            cardPoints *= 2;
                        }
                    }
                }

                points += cardPoints;
            }

            Console.WriteLine(points);
        }

        public static void Task02(string input)
        {
            var cards = new List<Card>();

            var inputLines = input.Split(Environment.NewLine).ToList();

            foreach (var line in inputLines)
            {
                var card = line.Trim().Split(": ", StringSplitOptions.RemoveEmptyEntries);
                var cardId = int.Parse(card[0].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]);
                var numbers = card[1].Trim().Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                var winningNumbers = numbers[0].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                var cardNumbers = numbers[1].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                var cardPoints = 0;

                foreach (var cardNumber in cardNumbers)
                {
                    if (winningNumbers.Any(x => x == cardNumber))
                    {
                        cardPoints += 1;
                    }
                }

                cards.Add(new Card
                {
                    Id = cardId,
                    Points = cardPoints,
                });
            }

            for (int i = 0; i < cards.Count; i++)
            {
                for (int j = 0; j < cards[i].Points; j++)
                {
                    var currentCardId = cards[i].Id;
                    var currentCardIndex = currentCardId - 1;

                    var cardToAdd = cards[currentCardIndex + 1 + j];
                    cards.Add(cardToAdd);
                }
            }

            Console.WriteLine(cards.Count);
        }
    }

    class Card
    {
        public int Id { get; set; }

        public int Points { get; set; }
    }
}
