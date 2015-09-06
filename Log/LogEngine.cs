using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TeleBotDotNet.Log
{
    public class LogEngine
    {
        private readonly List<LogItem> _logItems = new List<LogItem>();
        public bool Enabled { get; set; }

        public ReadOnlyCollection<LogItem> LogItems => _logItems.AsReadOnly();

        internal void Info(string method, string message)
        {
            Add(method, message, LogType.Info);
        }

        private void Add(string method, string message, LogType logType)
        {
            if (!Enabled)
            {
                return;
            }

            _logItems.Add(new LogItem
            {
                Date = DateTime.Now,
                Method = method,
                Message = message,
                Type = logType
            });
        }
    }
}