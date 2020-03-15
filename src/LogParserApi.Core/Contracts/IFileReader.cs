using System.Threading.Tasks;

namespace LogParserApi.Core.Contracts
{
    public interface IFileReader
    {
        Task<string[]> ReadLinesAsync(string fullFilePath);
    }
}
