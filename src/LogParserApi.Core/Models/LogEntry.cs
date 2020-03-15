using System;

namespace LogParserApi.Core.Models
{
    public class LogEntry
    {
        public DateTime TimeStamp { get; set; }
        public string LogLevel { get; set; }
        public string Message { get; set; }
        public string CallStack { get; set; }
    }
}
