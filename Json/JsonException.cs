using System;

namespace TeleBotDotNet.Json
{
    internal class JsonException : Exception
    {
        public Exception UnderlyingException { get; }

        internal JsonException(string input, Exception underlyingException)
            : base(GetExceptionMessage(input))
        {
            UnderlyingException = underlyingException;
        }

        private static string GetExceptionMessage(string input)
        {
            return $"The received JSON is invalid:{Environment.NewLine}{Environment.NewLine}{input}";
        }
    }
}
