using System;

namespace LogParserApi.Core.Contracts
{
    public interface ILineParser
    {
        void ParseLine(string line);
        public bool HasTimeStamp { get; }
        public DateTime TimeStamp { get; }
        public string TimeStampMilliseconds { get; }
        public string LogLevel { get; }
        public string Message { get; }
        public string Remainder { get; }
    }
}
