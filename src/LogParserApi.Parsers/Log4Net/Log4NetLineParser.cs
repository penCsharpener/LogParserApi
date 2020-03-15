using System;
using LogParserApi.Core.Contracts;

namespace LogParserApi.Parsers.Log4Net
{
    public class Log4NetLineParser : ILineParser
    {
        private string _line;

        public void ParseLine(string line)
        {
            _line = line;
            TimeStamp = default(DateTime);
            TimeStampMilliseconds = LogLevel = Message = Remainder = null;
            var dateTimeMsString = _line.Substring(0, 23).Replace("-", "/");
            HasTimeStamp = DateTime.TryParse(dateTimeMsString.Substring(0, 19), out var dt);
            if (HasTimeStamp)
            {
                TimeStamp = dt;
                TimeStampMilliseconds = dateTimeMsString.Substring(20, 3);
                if (_line.IndexOf("] ", 23) > 0)
                {
                    LogLevel = _line.Substring(_line.IndexOf("] ", 23) + 2, 5).Trim();
                }
                var posMessage = _line.IndexOf(LogLevel) + LogLevel.Length;
                if (posMessage > 0)
                {
                    Message = _line.Substring(posMessage, _line.Length - posMessage).Trim();
                }
            }
        }

        public bool HasTimeStamp { get; private set; }
        public DateTime TimeStamp { get; private set; }
        public string TimeStampMilliseconds { get; private set; }
        public string LogLevel { get; private set; }
        public string Message { get; private set; }
        public string Remainder { get; private set; }

    }
}
