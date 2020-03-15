using System;
using System.Collections.Generic;
using System.Text;
using LogParserApi.Core.Contracts;
using LogParserApi.Core.Models;

namespace LogParserApi.Parsers
{
    public class Log4NetParser : ILogReader
    {
        private readonly IFileReader _fileReader;
        private readonly ILineParser _lineParser;

        public Log4NetParser(IFileReader fileReader, ILineParser lineParser)
        {
            _fileReader = fileReader;
            _lineParser = lineParser;
        }

        public async IAsyncEnumerable<LogEntry> ReadAsync(string fullFilePath)
        {
            StringBuilder sb = new StringBuilder();
            LogEntry logEntry = new LogEntry();

            await foreach (var line in _fileReader.ReadLinesAsync(fullFilePath))
            {
                _lineParser.ParseLine(line);

                if (_lineParser.HasTimeStamp)
                {
                    if (logEntry.TimeStamp > DateTime.MinValue)
                    {
                        logEntry.CallStack = sb.ToString();
                        sb = new StringBuilder();
                        yield return logEntry;
                    }

                    logEntry = new LogEntry();

                    logEntry.TimeStamp = _lineParser.TimeStamp.AddMilliseconds(int.Parse(_lineParser.TimeStampMilliseconds));
                    logEntry.LogLevel = _lineParser.LogLevel;
                    logEntry.Message = _lineParser.Message;
                }
                else
                {
                    sb.AppendLine(line);
                }
            }
        }
    }
}
