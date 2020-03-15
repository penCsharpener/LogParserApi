using System.Collections.Generic;
using System.IO;
using System.Text;
using LogParserApi.Core.Contracts;

namespace LogParserApi.Parsers.FileSystem
{
    public class FileReader : IFileReader
    {
        public async IAsyncEnumerable<string> ReadLinesAsync(string fullFilePath)
        {
            var fileInfo = new FileInfo(fullFilePath);
            var nextLine = "";

            using (var fs = fileInfo.OpenRead())
            {
                using (var streamReader = new StreamReader(fs, Encoding.UTF8))
                {
                    while ((nextLine = await streamReader.ReadLineAsync()) != null)
                    {
                        yield return nextLine;
                    }
                }
            }
        }
    }
}
