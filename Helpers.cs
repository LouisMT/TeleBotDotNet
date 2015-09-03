using System;
using System.Web.Script.Serialization;

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

        internal static string ToJson(this object input)
        {
            var javaScriptSerializer = new JavaScriptSerializer();
            return javaScriptSerializer.Serialize(input);
        }

        internal static dynamic FromJson(this string input)
        {
            var javaScriptSerializer = new JavaScriptSerializer();
            return javaScriptSerializer.DeserializeObject(input);
        }
    }
}