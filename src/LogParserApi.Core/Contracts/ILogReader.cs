using System.Collections.Generic;
using System.Threading.Tasks;
using LogParserApi.Core.Models;

namespace LogParserApi.Core.Contracts
{
    public interface ILogReader
    {
        Task<IEnumerable<LogEntry>> ReadAsync(string fullFilePath);
    }
}
