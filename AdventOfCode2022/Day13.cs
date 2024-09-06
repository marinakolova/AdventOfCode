using System.Text.Json.Nodes;

namespace AdventOfCode2022
{
    public static class Day13
    {
        public static void Task01(string input)
        {
            var result = GetPackets(input)
                .Chunk(2)
                .Select((pair, index) => Compare(pair[0], pair[1]) < 0 ? index + 1 : 0)
                .Sum();

            Console.WriteLine(result);
        }

        public static void Task02(string input)
        {
            var divider = GetPackets("[[2]]\r\n[[6]]").ToList();
            var packets = GetPackets(input).Concat(divider).ToList();
            packets.Sort(Compare);
            var result = (packets.IndexOf(divider[0]) + 1) * (packets.IndexOf(divider[1]) + 1);
            Console.WriteLine(result);
        }

        private static IEnumerable<JsonNode> GetPackets(string input)
        {
            return
                from line in input.Split("\r\n")
                where !string.IsNullOrEmpty(line)
                select JsonNode.Parse(line);
        }

        private static int Compare(JsonNode nodeA, JsonNode nodeB)
        {
            if (nodeA is JsonValue && nodeB is JsonValue)
            {
                return (int)nodeA - (int)nodeB;
            }
            else
            {
                // if all items are equal, compare the length of the arrays
                var arrayA = nodeA as JsonArray ?? new JsonArray((int)nodeA);
                var arrayB = nodeB as JsonArray ?? new JsonArray((int)nodeB);
                return Enumerable.Zip(arrayA, arrayB)
                    .Select(p => Compare(p.First, p.Second))
                    .FirstOrDefault(c => c != 0, arrayA.Count - arrayB.Count);
            }
        }
    }
}
