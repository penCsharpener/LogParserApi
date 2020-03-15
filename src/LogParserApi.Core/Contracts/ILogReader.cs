using System.Collections.Generic;
using LogParserApi.Core.Models;

namespace LogParserApi.Core.Contracts
{
    public interface ILogReader
    {
        IAsyncEnumerable<LogEntry> ReadAsync(string fullFilePath);
    }
}
