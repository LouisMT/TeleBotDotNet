using System;

namespace TeleBotDotNet.Log
{
    public class LogItem
    {
        public DateTime Date { get; set; }
        public string Method { get; set; }
        public string Message { get; set; }
        public LogType Type { get; set; }

        public new string ToString()
        {
            return $"{Type} @ {Date}: {Message} ({Method})";
        }
    }
}