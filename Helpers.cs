using System;
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

                case ParseMode.HTML:
                    return "HTML";

                default:
                    return null;
            }
        }
    }
}