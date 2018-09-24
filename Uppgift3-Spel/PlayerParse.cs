using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;

namespace Uppgift3_Spel
{
    static class PlayerParse
    {
        private const string PlayerOptions = @"\bopen|drop|use|look|show|take|go|examine|read|\b"; // Innehåller alla spelarens actions
        private const string UseableObjects = @"\bkey|bottle|rags|note|broom|door|left|right\b"; // innehåller alla föremål som kan användas
        // ragsbroom | bottlerags| keydoor

        public static string ToPlayerAction(this string input)
        {
            Regex regex = new Regex(PlayerOptions);
            Match match = regex.Match(input);
            return match.Success ? match.Value : null;
        }

        public static string ToUseableObject(this string input)
        {
            Regex regex = new Regex(UseableObjects);
            Match match = regex.Match(input);
            return match.Success ? match.Value : null;
        }

        public static bool CheckValue(IEnumerable<string> compare, string compareTo)
        {
            return compare.Any(str => compareTo.ToLower().Contains(str.ToLower()));
        }

        public static bool CheckValue(string value, string compareTo)
        {
            var arrayValue = value.Split(' ').ToArray();
            return arrayValue.Any(t => compareTo.ToLower().Contains(t.ToLower()));
        }
    }
}
