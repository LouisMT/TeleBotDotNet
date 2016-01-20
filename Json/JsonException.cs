using System;

namespace TeleBotDotNet.Json
{
    internal class JsonException : Exception
    {
        internal JsonException(string input, Exception innerException)
            : base(GetExceptionMessage(input), innerException)
        {
        }

        private static string GetExceptionMessage(string input)
        {
            return $"The received JSON is invalid:{Environment.NewLine}{Environment.NewLine}{input}";
        }
    }
}
