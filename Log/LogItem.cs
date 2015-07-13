using System;

namespace TeleBotDotNet.Log
{
    public enum LogType
    {
        Info
    }

    public class LogItem
    {
        public DateTime Date { get; set; }
        public string Method { get; set; }
        public string Message { get; set; }
        public LogType Type { get; set; }

        public new string ToString()
        {
            return string.Format("{0} @ {1}: {2} ({3})", Type, Date, Message, Method);
        }
    }
}