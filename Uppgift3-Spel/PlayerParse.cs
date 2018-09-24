using System.Linq;
using System.Text.RegularExpressions;

namespace Uppgift3_Spel
{
    static class PlayerParse
    {
        private const string PlayerOptions = @"\bopen|drop|use|look|show|take|go|examine|read|pickups|inventory\b"; // Innehåller alla spelarens actions

        public static string ToPlayerAction(this string input)
        {
            Regex regex = new Regex(PlayerOptions);
            Match match = regex.Match(input);
            return match.Success ? match.Value : null;
        }

        public static bool CheckValue(string value, string compareTo)
        {
            var arrayValue = value.Split(' ').ToArray();
            return arrayValue.Any(t => compareTo.ToLower().Contains(t.ToLower()));
        }
    }
}
