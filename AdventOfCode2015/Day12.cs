using System.Text.Json;

namespace AdventOfCode2015
{
    public static class Day12
    {
        public static void Task01(string input)
        {
            var jsonElement = JsonDocument.Parse(input).RootElement;
            var result = GetJsonElementIntValue(jsonElement, false);
            Console.WriteLine(result);
        }

        public static void Task02(string input)
        {
            var jsonElement = JsonDocument.Parse(input).RootElement;
            var result = GetJsonElementIntValue(jsonElement, true);
            Console.WriteLine(result);
        }

        private static int GetJsonElementIntValue(JsonElement jsonElement, bool skipRed)
        {
            if (jsonElement.ValueKind == JsonValueKind.Object)
            {
                if (skipRed
                    && jsonElement
                    .EnumerateObject()
                    .Any(p => p.Value.ValueKind == JsonValueKind.String && p.Value.GetString() == "red")
                    )
                {
                    return 0;
                }
                else
                {
                    return jsonElement.EnumerateObject().Select(p => GetJsonElementIntValue(p.Value, skipRed)).Sum();
                }
            }
            else if (jsonElement.ValueKind == JsonValueKind.Array)
            {
                return jsonElement.EnumerateArray().Select(x => GetJsonElementIntValue(x, skipRed)).Sum();
            }
            else if (jsonElement.ValueKind == JsonValueKind.Number)
            {
                return jsonElement.GetInt32();
            }
            else
            {
                return 0;
            }
        }
    }
}
