using System;
using System.Collections.Generic;
using System.Linq;

namespace Day18
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = "[[1,8],[[8,7],[3,[1,9]]]]\n" +
"[[[[8, 1],7],[[9,9],[4,8]]],[[7,[7,2]],[2,[1,6]]]]\n" +
"[[[[0,8],0],[0,[7,2]]],[[[3,2],8],[[5,6],3]]]\n" +
"[[[7,[7,9]],8],[[[7,0],[7,7]],[[8,2],2]]]\n" +
"[[5,7],[[0,[1,0]],[2,[4,6]]]]\n" +
"[[[[7,7],[2,6]],9],[[1,3],[[1,7],7]]]\n" +
"[[[[5,7],[8,6]],[1,[6,4]]],[7,[[2,8],[9,2]]]]\n" +
"[[[3,6],[[7,7],[1,0]]],[[1,[9,3]],[[0,9],[9,5]]]]\n" +
"[[[6,[6,2]],[[3,4],[5,1]]],[[3,[5,6]],[8,[4,8]]]]\n" +
"[[[[4,9],6],4],[3,[[1,6],[4,3]]]]\n" +
"[[[[4,9],[6,0]],2],[[0,9],[[8,4],[3,5]]]]\n" +
"[[5,[8,[1,1]]],[7,[[3,2],2]]]\n" +
"[1,2]\n" +
"[[[1,9],[[7,4],4]],[[7,[0,7]],9]]\n" +
"[[[[5,9],0],[3,8]],[[[4,9],[5,8]],[2,7]]]\n" +
"[[[[1,1],[4,5]],[7,7]],1]\n" +
"[[[[4,3],3],[1,6]],[[0,2],8]]\n" +
"[[[[1,5],9],[[5,5],1]],[[6,1],[[9,9],[3,0]]]]\n" +
"[[6,9],[[[9,7],[3,8]],[[2,2],[8,7]]]]\n" +
"[[[6,2],[6,[8,1]]],[[[5,1],1],9]]\n" +
"[[[8,5],[7,9]],[[5,2],[[1,6],[8,0]]]]\n" +
"[[[[5,6],[9,1]],3],[[1,7],[6,5]]]\n" +
"[[[5,7],8],[9,[8,7]]]\n" +
"[[[[0,7],4],[3,[3,2]]],[[[0,8],5],[[8,8],1]]]\n" +
"[[[[8,2],[6,5]],[8,6]],[1,[[1,4],[3,7]]]]\n" +
"[[7,[9,[0,8]]],[[[7,1],[5,5]],[5,[1,5]]]]\n" +
"[[3,5],[[[7,4],[1,6]],[[6,9],4]]]\n" +
"[4,[9,4]]\n" +
"[[3,[5,5]],9]\n" +
"[[0,2],[[[9,8],9],1]]\n" +
"[[[0,3],[[9,8],0]],[[5,[5,1]],[7,[6,5]]]]\n" +
"[[[9,[0,4]],[[0,2],[4,5]]],[3,[2,[9,8]]]]\n" +
"[[[2,6],[[3,5],5]],[0,[9,7]]]\n" +
"[[[6,[0,8]],9],[8,7]]\n" +
"[[[[8,2],3],[6,6]],[6,[5,[7,8]]]]\n" +
"[[[9,[3,6]],[0,6]],[9,[[4,4],5]]]\n" +
"[[[3,2],5],2]\n" +
"[[[2,1],[[6,7],1]],[[7,[7,0]],5]]\n" +
"[[[[1,3],1],[1,5]],[[1,3],[[5,6],1]]]\n" +
"[[[3,[9,9]],[2,6]],[[[3,4],[5,8]],[1,[1,9]]]]\n" +
"[[[0,2],[4,[5,0]]],9]\n" +
"[[9,0],[7,[7,[9,9]]]]\n" +
"[[[8,[4,9]],[6,[4,8]]],[[3,6],[7,[9,1]]]]\n" +
"[[7,[6,[5,7]]],[[[0,9],[9,2]],1]]\n" +
"[8,[6,[[9,7],[5,7]]]]\n" +
"[[[7,[6,1]],[9,[4,9]]],[[[2,0],7],[8,7]]]\n" +
"[[5,[[4,1],[2,7]]],[0,[2,[5,3]]]]\n" +
"[[[0,8],[0,5]],2]\n" +
"[[[3,[9,8]],9],[1,2]]\n" +
"[[[[7,1],9],2],[[[4,6],[0,5]],[6,8]]]\n" +
"[4,[[[5,3],3],[[1,8],3]]]\n" +
"[[[3,0],[[5,0],[3,9]]],[6,[9,2]]]\n" +
"[[[6,6],[[8,2],6]],[[[0,6],8],[[3,3],[1,2]]]]\n" +
"[[6,[[5,2],[2,8]]],[1,7]]\n" +
"[[4,3],[[[1,5],0],[[1,4],6]]]\n" +
"[[7,[[2,7],7]],[[[4,2],[4,5]],[[5,3],3]]]\n" +
"[[0,1],[[9,[1,0]],9]]\n" +
"[[[[4,5],[1,8]],[5,1]],[[[4,6],[6,0]],[3,[1,4]]]]\n" +
"[[[[7,5],[0,9]],[[1,0],[2,7]]],[[9,4],[6,[7,7]]]]\n" +
"[[[3,1],9],[[[7,9],[4,7]],[[4,0],2]]]\n" +
"[[[9,[2,3]],[4,[3,1]]],[[9,[1,7]],[8,[9,6]]]]\n" +
"[[[2,2],0],[[9,[0,1]],[2,[2,4]]]]\n" +
"[9,[[6,9],[[2,5],[1,1]]]]\n" +
"[[2,9],[[[8,8],9],[[4,0],[8,2]]]]\n" +
"[1,[[8,[7,4]],8]]\n" +
"[[[[0,3],2],[[0,6],[3,8]]],6]\n" +
"[[[[3,7],[1,3]],[4,[0,3]]],[[[7,7],1],[[2,9],1]]]\n" +
"[[[4,[5,0]],[[1,1],6]],[[3,4],[8,5]]]\n" +
"[8,[2,[[0,4],9]]]\n" +
"[[[7,1],8],[[0,2],[[8,7],6]]]\n" +
"[[[4,0],4],[[4,[2,4]],[2,[1,8]]]]\n" +
"[[[1,5],[2,[5,4]]],[2,5]]\n" +
"[[[9,[6,7]],[1,6]],[[[0,3],[8,2]],[9,7]]]\n" +
"[[[[4,9],[4,0]],[[6,7],[5,9]]],[[[7,0],1],[[0,1],[4,6]]]]\n" +
"[[[8,[2,3]],[[1,6],[2,9]]],[[6,9],[4,[2,3]]]]\n" +
"[[[3,1],7],[[[6,9],[9,2]],[[3,9],2]]]\n" +
"[[9,[[8,3],[0,9]]],[[0,8],8]]\n" +
"[[[[4,8],4],[5,[3,3]]],[8,[6,4]]]\n" +
"[[[[0,8],[1,6]],[[9,4],3]],2]\n" +
"[[[7,[8,2]],[[9,0],1]],[[2,7],[[3,0],[8,6]]]]\n" +
"[[4,[1,[4,7]]],[[[2,6],4],[[5,3],9]]]\n" +
"[[0,5],[8,[[1,8],0]]]\n" +
"[[[1,[3,3]],9],[2,1]]\n" +
"[[[[5,0],[2,4]],[[1,7],0]],[[[5,3],4],5]]\n" +
"[[[9,[1,1]],7],[9,[7,1]]]\n" +
"[[[[5,5],9],4],[2,9]]\n" +
"[[5,[5,[6,8]]],9]\n" +
"[[[9,[1,6]],[[1,7],7]],[[7,3],[5,4]]]\n" +
"[[3,[[7,5],4]],[[[9,6],[7,1]],1]]\n" +
"[[[[8,7],1],3],[[2,[3,1]],[4,8]]]\n" +
"[[[4,[5,5]],0],[[7,8],[1,[5,6]]]]\n" +
"[[[[1,1],[9,2]],[1,[3,5]]],[[7,[2,1]],[2,[7,3]]]]\n" +
"[[[[3,7],[0,9]],0],[[0,8],[9,[2,8]]]]\n" +
"[[[7,[3,9]],[5,[1,6]]],[[[8,4],7],[[5,6],3]]]\n" +
"[[[[0,7],[4,3]],[1,[0,8]]],[[6,9],2]]\n" +
"[[[8,9],[8,3]],[[6,[0,1]],[7,8]]]\n" +
"[[[[6,6],9],[8,0]],[[9,[7,2]],[0,3]]]\n" +
"[[[[8,9],[0,0]],[9,3]],[3,[9,[8,9]]]]\n" +
"[[[8,[8,5]],[6,[9,1]]],8]\n" +
"[[6,[[1,0],8]],[4,6]]";

            Console.WriteLine(input.Split("\n").Select(ParseNumber).Aggregate(
            new Number(),
            (acc, number) => !acc.Any() ? number : Sum(acc, number),
            Magnitude
        ));

            // get the highest magnitude resulted from adding any two 'numbers' in the input:
            var numbers = input.Split("\n").Select(ParseNumber).ToArray();
            Console.WriteLine((
            from i in Enumerable.Range(0, numbers.Length)
            from j in Enumerable.Range(0, numbers.Length)
            where i != j
            select Magnitude(Sum(numbers[i], numbers[j]))
        ).Max());


            long Magnitude(Number number)
            {
                var itoken = 0; // we will process the number tokenwise

                long computeRecursive()
                {
                    var token = number[itoken++];
                    if (token.kind == TokenKind.Digit)
                    {
                        // just the number
                        return token.value;
                    }
                    else
                    {
                        // take left and right side of the pair
                        var left = computeRecursive();
                        var right = computeRecursive();
                        itoken++; // don't forget to eat the closing parenthesis
                        return 3 * left + 2 * right;
                    }
                }

                return computeRecursive();
            }


            // just wrap A and B in a new 'number' and reduce:
            Number Sum(Number numberA, Number numberB) => Reduce(Number.Pair(numberA, numberB));

            Number Reduce(Number number)
            {
                while (Explode(number) || Split(number))
                {
                    ; // repeat until we cannot explod or split anymore
                }
                return number;
            }

            bool Explode(Number number)
            {
                // exploding means we need to find the first pair in the number 
                // that is embedded in 4 other pairs and get rid of it:
                var depth = 0;
                for (var i = 0; i < number.Count; i++)
                {
                    if (number[i].kind == TokenKind.Open)
                    {
                        depth++;
                        if (depth == 5)
                        {
                            // we are deep enough, let's to the reduce part

                            // find the digit to the left (if any) and increase:
                            for (var j = i - 1; j >= 0; j--)
                            {
                                if (number[j].kind == TokenKind.Digit)
                                {
                                    number[j] = number[j] with { value = number[j].value + number[i + 1].value };
                                    break;
                                }
                            }

                            // find the digit to the right (if any) and increase:
                            for (var j = i + 3; j < number.Count; j++)
                            {
                                if (number[j].kind == TokenKind.Digit)
                                {
                                    number[j] = number[j] with { value = number[j].value + number[i + 2].value };
                                    break;
                                }
                            }

                            // replace [a b] with 0:
                            number.RemoveRange(i, 4);
                            number.Insert(i, new Token(TokenKind.Digit, 0));

                            // successful reduce:
                            return true;
                        }
                    }
                    else if (number[i].kind == TokenKind.Close)
                    {
                        depth--;
                    }
                }

                // couldn't reduce:
                return false;
            }

            bool Split(Number number)
            {

                // spliting means we neeed to find a token with a high value and make a pair out of it:
                for (var i = 0; i < number.Count; i++)
                {
                    if (number[i].value >= 10)
                    {

                        var v = number[i].value;
                        number.RemoveRange(i, 1);
                        number.InsertRange(i, Number.Pair(Number.Digit(v / 2), Number.Digit((v + 1) / 2)));

                        // successful split:
                        return true;
                    }
                }
                // couldn't split:
                return false;
            }

            // tokenize the input to a list of '[' ']' and digit tokens
            Number ParseNumber(string st)
            {
                var res = new Number();
                var n = "";
                foreach (var ch in st)
                {
                    if (ch >= '0' && ch <= '9')
                    {
                        n += ch;
                    }
                    else
                    {
                        if (n != "")
                        {
                            res.Add(new Token(TokenKind.Digit, int.Parse(n)));
                            n = "";
                        }
                        if (ch == '[')
                        {
                            res.Add(new Token(TokenKind.Open));
                        }
                        else if (ch == ']')
                        {
                            res.Add(new Token(TokenKind.Close));
                        }
                    }
                }
                if (n != "")
                {
                    res.Add(new Token(TokenKind.Digit, int.Parse(n)));
                    n = "";
                }
                return res;
            }
        }

        // we will work with a list of tokens directly
        enum TokenKind
        {
            Open,
            Close,
            Digit
        }
        record Token(TokenKind kind, int value = 0);

        class Number : List<Token>
        {
            public static Number Digit(int value) =>
                new Number(){
            new Token(TokenKind.Digit, value)
                };

            public static Number Pair(Number a, Number b)
            {
                var number = new Number();
                number.Add(new Token(TokenKind.Open));
                number.AddRange(a);
                number.AddRange(b);
                number.Add(new Token(TokenKind.Close));
                return number;
            }
        }
    }
}
