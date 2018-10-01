using System.Linq;
using System.Text.RegularExpressions;

namespace Uppgift3_Spel
{
    internal static class InputParse
    {
        private const string PlayerOptions = @"open|drop|use|look|show|take|go|examine|read|pickup|inventory|turn|help|move|codelock";

        public static string ToPlayerAction(this string input)
        {
            input = input.ToLower();
            Regex regex = new Regex(PlayerOptions);
            Match match = regex.Match(input);
            return match.Success ? match.Value : "";
        }

        public static bool CompareStrings(string compare, string compareTo)
        {
            var arrayValue = compare.Split(' ').Skip(1).ToArray();
            return arrayValue.Any(str => compareTo.ToLower().Contains(str.ToLower()));
        }
    }
}
