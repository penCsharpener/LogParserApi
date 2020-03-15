using System;
using System.Collections.Generic;
using LogParserApi.Core.Contracts;
using LogParserApi.Core.Models;

namespace LogParserApi.Parsers
{
    public class Log4NetParser : ILogReader
    {
        private readonly IFileReader _fileReader;

        public Log4NetParser(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public async IAsyncEnumerable<LogEntry> ReadAsync(string fullFilePath)
        {
            throw new NotImplementedException();
            await foreach (var line in _fileReader.ReadLinesAsync(fullFilePath))
            {
            }
        }
    }
}
