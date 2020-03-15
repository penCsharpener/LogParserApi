using System.Collections.Generic;

namespace LogParserApi.Core.Contracts
{
    public interface IFileReader
    {
        IAsyncEnumerable<string> ReadLinesAsync(string fullFilePath);
    }
}
