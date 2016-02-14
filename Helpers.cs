using System;
using System.Collections.Generic;
using System.Linq;
using TeleBotDotNet.Requests.Types;

namespace TeleBotDotNet
{
    internal static class Helpers
    {
        internal static DateTime? ToDateTime(this int? timestamp)
        {
            if (timestamp.HasValue)
            {
                return new DateTime(1970, 1, 1).AddSeconds(timestamp.Value);
            }
            return null;
        }

        internal static string GetValue(this ParseMode parseMode)
        {
            switch (parseMode)
            {
                case ParseMode.Markdown:
                    return "Markdown";

                case ParseMode.Html:
                    return "HTML";

                default:
                    return null;
            }
        }

        internal static void RemoveEmptyEntries(this Dictionary<string, object> dictionary)
        {
            var emptyEntryKeys = dictionary.Where(e => e.Value == null).Select(e => e.Key).ToList();
            foreach (var emptyEntryKey in emptyEntryKeys)
            {
                dictionary.Remove(emptyEntryKey);
            }
        }
    }
}