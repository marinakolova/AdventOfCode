namespace AdventOfCode2022
{
    public static class Day11
    {
        public static void Task01() // input hardcoded into the solution
        {
            var monkeyItems = GetMonkeysItems();
            var inspectedItems = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 };

            // rounds 1 to 20
            for (int i = 1; i <= 20; i++)
            {
                //Monkey 0:
                //  Operation: new = old * 13
                //  Test: divisible by 19
                //    If true: throw to monkey 5
                //    If false: throw to monkey 6
                while (monkeyItems[0].Count > 0)
                {
                    var item = monkeyItems[0].Dequeue();
                    inspectedItems[0]++;

                    var operationResult = item * 13;
                    operationResult = (int)(operationResult / 3);

                    if (operationResult % 19 == 0)
                    {
                        monkeyItems[5].Enqueue(operationResult);
                    }
                    else
                    {
                        monkeyItems[6].Enqueue(operationResult);
                    }
                }

                //Monkey 1:
                //  Operation: new = old * old
                //  Test: divisible by 7
                //    If true: throw to monkey 5
                //    If false: throw to monkey 0
                while (monkeyItems[1].Count > 0)
                {
                    var item = monkeyItems[1].Dequeue();
                    inspectedItems[1]++;

                    var operationResult = item * item;
                    operationResult = (int)(operationResult / 3);

                    if (operationResult % 7 == 0)
                    {
                        monkeyItems[5].Enqueue(operationResult);
                    }
                    else
                    {
                        monkeyItems[0].Enqueue(operationResult);
                    }
                }

                //Monkey 2:
                //  Operation: new = old + 6
                //  Test: divisible by 17
                //    If true: throw to monkey 1
                //    If false: throw to monkey 0
                while (monkeyItems[2].Count > 0)
                {
                    var item = monkeyItems[2].Dequeue();
                    inspectedItems[2]++;

                    var operationResult = item + 6;
                    operationResult = (int)(operationResult / 3);

                    if (operationResult % 17 == 0)
                    {
                        monkeyItems[1].Enqueue(operationResult);
                    }
                    else
                    {
                        monkeyItems[0].Enqueue(operationResult);
                    }
                }

                //Monkey 3:
                //  Operation: new = old + 2
                //  Test: divisible by 13
                //    If true: throw to monkey 1
                //    If false: throw to monkey 2
                while (monkeyItems[3].Count > 0)
                {
                    var item = monkeyItems[3].Dequeue();
                    inspectedItems[3]++;

                    var operationResult = item + 2;
                    operationResult = (int)(operationResult / 3);

                    if (operationResult % 13 == 0)
                    {
                        monkeyItems[1].Enqueue(operationResult);
                    }
                    else
                    {
                        monkeyItems[2].Enqueue(operationResult);
                    }
                }

                //Monkey 4:
                //  Operation: new = old + 3
                //  Test: divisible by 11
                //    If true: throw to monkey 3
                //    If false: throw to monkey 7
                while (monkeyItems[4].Count > 0)
                {
                    var item = monkeyItems[4].Dequeue();
                    inspectedItems[4]++;

                    var operationResult = item + 3;
                    operationResult = (int)(operationResult / 3);

                    if (operationResult % 11 == 0)
                    {
                        monkeyItems[3].Enqueue(operationResult);
                    }
                    else
                    {
                        monkeyItems[7].Enqueue(operationResult);
                    }
                }

                //Monkey 5:
                //  Operation: new = old + 4
                //  Test: divisible by 2
                //    If true: throw to monkey 4
                //    If false: throw to monkey 6
                while (monkeyItems[5].Count > 0)
                {
                    var item = monkeyItems[5].Dequeue();
                    inspectedItems[5]++;

                    var operationResult = item + 4;
                    operationResult = (int)(operationResult / 3);

                    if (operationResult % 2 == 0)
                    {
                        monkeyItems[4].Enqueue(operationResult);
                    }
                    else
                    {
                        monkeyItems[6].Enqueue(operationResult);
                    }
                }

                //Monkey 6:
                //  Operation: new = old + 8
                //  Test: divisible by 5
                //    If true: throw to monkey 4
                //    If false: throw to monkey 7
                while (monkeyItems[6].Count > 0)
                {
                    var item = monkeyItems[6].Dequeue();
                    inspectedItems[6]++;

                    var operationResult = item + 8;
                    operationResult = (int)(operationResult / 3);

                    if (operationResult % 5 == 0)
                    {
                        monkeyItems[4].Enqueue(operationResult);
                    }
                    else
                    {
                        monkeyItems[7].Enqueue(operationResult);
                    }
                }

                //Monkey 7:
                //  Operation: new = old * 7
                //  Test: divisible by 3
                //    If true: throw to monkey 2
                //    If false: throw to monkey 3
                while (monkeyItems[7].Count > 0)
                {
                    var item = monkeyItems[7].Dequeue();
                    inspectedItems[7]++;

                    var operationResult = item * 7;
                    operationResult = (int)(operationResult / 3);

                    if (operationResult % 3 == 0)
                    {
                        monkeyItems[2].Enqueue(operationResult);
                    }
                    else
                    {
                        monkeyItems[3].Enqueue(operationResult);
                    }
                }
            }

            // get monkey business
            var sorted = inspectedItems.OrderByDescending(x => x).ToList();
            var result = sorted[0] * sorted[1];
            Console.WriteLine(result);
        }

        public static void Task02() // input hardcoded into the solution
        {
            var monkeysItems = GetMonkeysItems();
            var inspectedItems = new List<long>() { 0, 0, 0, 0, 0, 0, 0, 0 };

            var mod = 1;
            mod *= 19; // Monkey 0:  Test: divisible by 19
            mod *= 7;  // Monkey 1:  Test: divisible by 7
            mod *= 17; // Monkey 2:  Test: divisible by 17
            mod *= 13; // Monkey 3:  Test: divisible by 13
            mod *= 11; // Monkey 4:  Test: divisible by 11
            mod *= 2;  // Monkey 5:  Test: divisible by 2
            mod *= 5;  // Monkey 6:  Test: divisible by 5
            mod *= 3;  // Monkey 7:  Test: divisible by 3

            // rounds 1 to 10000
            for (int i = 1; i <= 10000; i++)
            {
                //Monkey 0:
                //  Operation: new = old * 13
                //  Test: divisible by 19
                //    If true: throw to monkey 5
                //    If false: throw to monkey 6
                while (monkeysItems[0].Count > 0)
                {
                    var item = monkeysItems[0].Dequeue();
                    inspectedItems[0]++;

                    var operationResult = item * 13;
                    operationResult = operationResult % mod;

                    if (operationResult % 19 == 0)
                    {
                        monkeysItems[5].Enqueue(operationResult);
                    }
                    else
                    {
                        monkeysItems[6].Enqueue(operationResult);
                    }
                }

                //Monkey 1:
                //  Operation: new = old * old
                //  Test: divisible by 7
                //    If true: throw to monkey 5
                //    If false: throw to monkey 0
                while (monkeysItems[1].Count > 0)
                {
                    var item = monkeysItems[1].Dequeue();
                    inspectedItems[1]++;

                    var operationResult = item * item;
                    operationResult = operationResult % mod;

                    if (operationResult % 7 == 0)
                    {
                        monkeysItems[5].Enqueue(operationResult);
                    }
                    else
                    {
                        monkeysItems[0].Enqueue(operationResult);
                    }
                }

                //Monkey 2:
                //  Operation: new = old + 6
                //  Test: divisible by 17
                //    If true: throw to monkey 1
                //    If false: throw to monkey 0
                while (monkeysItems[2].Count > 0)
                {
                    var item = monkeysItems[2].Dequeue();
                    inspectedItems[2]++;

                    var operationResult = item + 6;
                    operationResult = operationResult % mod;

                    if (operationResult % 17 == 0)
                    {
                        monkeysItems[1].Enqueue(operationResult);
                    }
                    else
                    {
                        monkeysItems[0].Enqueue(operationResult);
                    }
                }

                //Monkey 3:
                //  Operation: new = old + 2
                //  Test: divisible by 13
                //    If true: throw to monkey 1
                //    If false: throw to monkey 2
                while (monkeysItems[3].Count > 0)
                {
                    var item = monkeysItems[3].Dequeue();
                    inspectedItems[3]++;

                    var operationResult = item + 2;
                    operationResult = operationResult % mod;

                    if (operationResult % 13 == 0)
                    {
                        monkeysItems[1].Enqueue(operationResult);
                    }
                    else
                    {
                        monkeysItems[2].Enqueue(operationResult);
                    }
                }

                //Monkey 4:
                //  Operation: new = old + 3
                //  Test: divisible by 11
                //    If true: throw to monkey 3
                //    If false: throw to monkey 7
                while (monkeysItems[4].Count > 0)
                {
                    var item = monkeysItems[4].Dequeue();
                    inspectedItems[4]++;

                    var operationResult = item + 3;
                    operationResult = operationResult % mod;

                    if (operationResult % 11 == 0)
                    {
                        monkeysItems[3].Enqueue(operationResult);
                    }
                    else
                    {
                        monkeysItems[7].Enqueue(operationResult);
                    }
                }

                //Monkey 5:
                //  Operation: new = old + 4
                //  Test: divisible by 2
                //    If true: throw to monkey 4
                //    If false: throw to monkey 6
                while (monkeysItems[5].Count > 0)
                {
                    var item = monkeysItems[5].Dequeue();
                    inspectedItems[5]++;

                    var operationResult = item + 4;
                    operationResult = operationResult % mod;

                    if (operationResult % 2 == 0)
                    {
                        monkeysItems[4].Enqueue(operationResult);
                    }
                    else
                    {
                        monkeysItems[6].Enqueue(operationResult);
                    }
                }

                //Monkey 6:
                //  Operation: new = old + 8
                //  Test: divisible by 5
                //    If true: throw to monkey 4
                //    If false: throw to monkey 7
                while (monkeysItems[6].Count > 0)
                {
                    var item = monkeysItems[6].Dequeue();
                    inspectedItems[6]++;

                    var operationResult = item + 8;
                    operationResult = operationResult % mod;

                    if (operationResult % 5 == 0)
                    {
                        monkeysItems[4].Enqueue(operationResult);
                    }
                    else
                    {
                        monkeysItems[7].Enqueue(operationResult);
                    }
                }

                //Monkey 7:
                //  Operation: new = old * 7
                //  Test: divisible by 3
                //    If true: throw to monkey 2
                //    If false: throw to monkey 3
                while (monkeysItems[7].Count > 0)
                {
                    var item = monkeysItems[7].Dequeue();
                    inspectedItems[7]++;

                    var operationResult = item * 7;
                    operationResult = operationResult % mod;

                    if (operationResult % 3 == 0)
                    {
                        monkeysItems[2].Enqueue(operationResult);
                    }
                    else
                    {
                        monkeysItems[3].Enqueue(operationResult);
                    }
                }
            }

            // get monkey business
            var sorted = inspectedItems.OrderByDescending(x => x).ToList();
            long result = sorted[0] * sorted[1];
            Console.WriteLine(result);
        }

        private static Dictionary<int, Queue<long>> GetMonkeysItems()
        {
            var monkeyItems = new Dictionary<int, Queue<long>>()
            {
                { 0, new Queue<long>() },
                { 1, new Queue<long>() },
                { 2, new Queue<long>() },
                { 3, new Queue<long>() },
                { 4, new Queue<long>() },
                { 5, new Queue<long>() },
                { 6, new Queue<long>() },
                { 7, new Queue<long>() },
            };

            //Monkey 0:
            //  Starting items: 72, 97
            monkeyItems[0].Enqueue((long)72);
            monkeyItems[0].Enqueue((long)97);

            //Monkey 1:
            //  Starting items: 55, 70, 90, 74, 95
            monkeyItems[1].Enqueue((long)55);
            monkeyItems[1].Enqueue((long)70);
            monkeyItems[1].Enqueue((long)90);
            monkeyItems[1].Enqueue((long)74);
            monkeyItems[1].Enqueue((long)95);

            //Monkey 2:
            //  Starting items: 74, 97, 66, 57
            monkeyItems[2].Enqueue((long)74);
            monkeyItems[2].Enqueue((long)97);
            monkeyItems[2].Enqueue((long)66);
            monkeyItems[2].Enqueue((long)57);

            //Monkey 3:
            //  Starting items: 86, 54, 53
            monkeyItems[3].Enqueue((long)86);
            monkeyItems[3].Enqueue((long)54);
            monkeyItems[3].Enqueue((long)53);

            //Monkey 4:
            //  Starting items: 50, 65, 78, 50, 62, 99
            monkeyItems[4].Enqueue((long)50);
            monkeyItems[4].Enqueue((long)65);
            monkeyItems[4].Enqueue((long)78);
            monkeyItems[4].Enqueue((long)50);
            monkeyItems[4].Enqueue((long)62);
            monkeyItems[4].Enqueue((long)99);

            //Monkey 5:
            //  Starting items: 90
            monkeyItems[5].Enqueue(90);

            //Monkey 6:
            //  Starting items: 88, 92, 63, 94, 96, 82, 53, 53
            monkeyItems[6].Enqueue((long)88);
            monkeyItems[6].Enqueue((long)92);
            monkeyItems[6].Enqueue((long)63);
            monkeyItems[6].Enqueue((long)94);
            monkeyItems[6].Enqueue((long)96);
            monkeyItems[6].Enqueue((long)82);
            monkeyItems[6].Enqueue((long)53);
            monkeyItems[6].Enqueue((long)53);

            //Monkey 7:
            //  Starting items: 70, 60, 71, 69, 77, 70, 98
            monkeyItems[7].Enqueue((long)70);
            monkeyItems[7].Enqueue((long)60);
            monkeyItems[7].Enqueue((long)71);
            monkeyItems[7].Enqueue((long)69);
            monkeyItems[7].Enqueue((long)77);
            monkeyItems[7].Enqueue((long)70);
            monkeyItems[7].Enqueue((long)98);

            return monkeyItems;
        }
    }
}
